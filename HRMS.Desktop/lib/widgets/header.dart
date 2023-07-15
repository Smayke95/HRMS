import 'package:HRMS/models/enums/notification_type.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

import '../models/notification.dart' as hrms;
import '../providers/notification_provider.dart';
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
    _notificationProvider.listen(addNotification);
  }

  void addNotification(hrms.Notification notification) {
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
              style: const TextStyle(
                fontSize: 24,
                height: 1,
                fontWeight: FontWeight.w100,
                color: Colors.grey,
              ),
            ),
          ),
          SizedBox(
            width: 60,
            child: TextButton(
              onPressed: () => print("Open chat"),
              child: Badge.count(
                count: 4,
                child: const Icon(
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
            child: TextButton(
              onPressed: () => print("Open user"),
              child: const Icon(
                Icons.person,
                color: Colors.grey,
              ),
            ),
          ),
          const SizedBox(width: 20)
        ],
      ),
    );
  }
}
