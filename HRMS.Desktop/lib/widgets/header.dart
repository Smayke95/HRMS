import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

import '../models/enums/notification_type.dart';
import '../models/notification.dart' as hrms;
import '../models/user.dart';
import '../providers/notification_provider.dart';
import '../screens/chat_screen.dart';
import '../screens/login_screen.dart';
import '../screens/settings_screen.dart';
import 'master_screen.dart';
import 'responsive.dart';

class Header extends StatefulWidget {
  final String _title;
  final GlobalKey<ScaffoldState> _menuKey;

  const Header(this._title, this._menuKey, {super.key});

  @override
  State<Header> createState() => _HeaderState();
}

class _HeaderState extends State<Header> {
  late NotificationProvider _notificationProvider;
  final List<hrms.Notification> _notifications = [];

  @override
  void initState() {
    super.initState();

    _notificationProvider = context.read<NotificationProvider>();
    _loadData();
  }

  Future _loadData() async {
    final BuildContext currentContext = context;

    try {
      await _notificationProvider.listen(_addNotification);
    } on Exception catch (e) {
      e.toString();

      const snackBar = SnackBar(
        content: Text(
            "Failed to connect to RabbitMQ. Notifications will not work properly."),
      );

      if (currentContext.mounted) {
        ScaffoldMessenger.of(currentContext).showSnackBar(snackBar);
      }
    }
  }

  void _addNotification(hrms.Notification notification) {
    _notifications.add(notification);
    setState(() {});
  }

  void _clearNotification() {
    _notifications.clear();
    setState(() {});
  }

  @override
  Widget build(BuildContext context) {
    return SizedBox(
      height: 60,
      child: Row(
        children: [
          if (!Responsive.isDesktop(context))
            TextButton(
              onPressed: () => widget._menuKey.currentState!.openDrawer(),
              child: const Icon(
                Icons.menu,
                color: Colors.grey,
              ),
            ),
          const SizedBox(width: 20),
          Expanded(
            child: Text(
              widget._title,
              style: TextStyle(
                fontSize: Responsive.isMobile(context) ? 18 : 24,
                height: 1,
                fontWeight: FontWeight.w100,
                color: Colors.grey,
              ),
            ),
          ),
          SizedBox(
            width: 60,
            child: PopupMenuButton(
              tooltip: "Razgovor",
              itemBuilder: (context) => <PopupMenuEntry>[
                PopupMenuItem(
                  child: ListTile(
                    leading: const Icon(Icons.open_in_new),
                    title: const Text("Otvori razgovor"),
                    onTap: () {
                      Navigator.of(context).pushReplacement(MaterialPageRoute(
                          builder: (context) =>
                              const MasterScreen("Razgovor", ChatScreen())));
                    },
                  ),
                ),
              ],
              child: const Center(
                child: Icon(
                  Icons.chat_bubble,
                  color: Colors.grey,
                ),
              ),
            ),
          ),
          SizedBox(
            width: 60,
            child: PopupMenuButton(
              tooltip: "Notifikacije",
              onCanceled: () => _clearNotification(),
              itemBuilder: (context) => _notifications
                  .map((e) => PopupMenuItem(
                        padding: const EdgeInsets.all(10),
                        child: ListTile(
                          leading: Icon(e.type == NotificationType.info
                              ? Icons.info
                              : e.type == NotificationType.warning
                                  ? Icons.warning
                                  : Icons.error),
                          title: Text(e.text),
                        ),
                      ))
                  .toList(),
              child: Center(
                child: _notifications.isNotEmpty
                    ? Badge.count(
                        count: _notifications.length,
                        child: const Icon(
                          Icons.notifications,
                          color: Colors.grey,
                        ),
                      )
                    : const Icon(
                        Icons.notifications,
                        color: Colors.grey,
                      ),
              ),
            ),
          ),
          SizedBox(
            width: 60,
            child: PopupMenuButton(
              tooltip: "Korisnik",
              itemBuilder: (context) => <PopupMenuEntry>[
                PopupMenuItem(
                  enabled: false,
                  child: ListTile(
                    title: Text(
                      User.name ?? "",
                      textAlign: TextAlign.center,
                    ),
                  ),
                ),
                const PopupMenuDivider(),
                if (User.roles.contains("Admin"))
                  PopupMenuItem(
                    child: ListTile(
                      leading: const Icon(Icons.settings),
                      title: const Text("Postavke"),
                      onTap: () {
                        Navigator.of(context).pushReplacement(MaterialPageRoute(
                            builder: (context) => const MasterScreen(
                                "Postavke", SettingsScreen())));
                      },
                    ),
                  ),
                PopupMenuItem(
                  child: ListTile(
                    leading: const Icon(Icons.logout),
                    title: const Text("Odjava"),
                    onTap: () {
                      Navigator.of(context).pushReplacement(MaterialPageRoute(
                          builder: (context) => const LoginScreen()));
                    },
                  ),
                ),
              ],
              child: const Center(
                child: Icon(
                  Icons.person,
                  color: Colors.grey,
                ),
              ),
            ),
          ),
          const SizedBox(width: 20)
        ],
      ),
    );
  }
}
