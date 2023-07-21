import 'package:flutter/material.dart';

import '../models/user.dart';
import '../screens/calendar_screen.dart';
import '../screens/chat_screen.dart';
import '../screens/dashboard_screen.dart';
import '../screens/department_list_screen.dart';
import '../screens/employee_list_screen.dart';
import '../screens/employee_position_list_screen.dart';
import '../screens/position_list_screen.dart';
import '../screens/project_list_screen.dart';
import '../screens/settings_screen.dart';
import '../screens/task_list_screen.dart';
import 'master_screen.dart';

class SideMenu extends StatelessWidget {
  const SideMenu({super.key});

  @override
  Widget build(BuildContext context) {
    return Drawer(
      child: SingleChildScrollView(
        child: Column(
          children: [
            _buildHeader(context),
            const Divider(
              color: Colors.black,
              indent: 10,
              endIndent: 10,
              thickness: 0.1,
            ),
            _buildUser(context),
            const Divider(
              color: Colors.black,
              indent: 10,
              endIndent: 10,
              thickness: 0.1,
            ),
            _buildItems(context)
          ],
        ),
      ),
    );
  }

  Widget _buildHeader(BuildContext context) {
    return Padding(
        padding: const EdgeInsets.only(top: 15, bottom: 10),
        child: Image.asset("assets/images/logo.png", width: 180));
  }

  Widget _buildUser(BuildContext context) {
    return Padding(
        padding: const EdgeInsets.all(20),
        child: Row(
          children: [
            ClipRRect(
                borderRadius: BorderRadius.circular(50),
                child:
                    Image.asset("assets/images/default-avatar.png", width: 50)),
            const SizedBox(
              width: 20,
            ),
            Text(
              User.name ?? "Korisnik",
              style: const TextStyle(
                  fontFamily: "Roboto",
                  fontWeight: FontWeight.bold,
                  color: Color(0xFF3C4858),
                  fontSize: 16),
            )
          ],
        ));
  }

  Widget _buildItems(BuildContext context) {
    double spaceHeight = MediaQuery.of(context).size.height > 545
        ? MediaQuery.of(context).size.height - 545
        : 0;

    return Padding(
      padding: const EdgeInsets.all(10.0),
      child: Wrap(
        runSpacing: 16,
        children: [
          _buildListTile(
            context,
            "Početna",
            Icons.dashboard,
            const DashboardScreen(),
            true,
          ),
          ExpansionTile(
            leading: const Icon(Icons.content_paste),
            title: const Text("Projekti i zadaci"),
            children: [
              _buildListTile(
                context,
                "Projekti",
                Icons.folder,
                const ProjectListScreen(),
                true,
              ),
              _buildListTile(
                context,
                "Zadaci",
                Icons.format_list_bulleted,
                const TaskListScreen(),
                true,
              )
            ],
          ),         
          _buildListTile(
            context,
            "Razgovor",
            Icons.chat,
            const ChatScreen(),
            true,
          ),
          _buildListTile(
            context,
            "Kalendar",
            Icons.date_range,
            const CalendarScreen(),
            false,
          ),
          ExpansionTile(
            leading: const Icon(Icons.groups),
            title: const Text("Zaposlenici"),
            children: [
              _buildListTile(
                context,
                "Zaposlenici",
                Icons.groups,
                const EmployeeListScreen(),
                true,
              ),
              _buildListTile(
                context,
                "Zaposlenje",
                Icons.content_copy,
                const EmployeePositionListScreen(),
                true,
              ),
              _buildListTile(
                context,
                "Pozicije",
                Icons.storage,
                const PositionListScreen(),
                true,
              ),
              _buildListTile(
                context,
                "Kompanija",
                Icons.location_city,
                const DepartmentListScreen(),
                true,
              ),
            ],
          ),
          SizedBox(height: spaceHeight),
          _buildListTile(
            context,
            "Postavke",
            Icons.settings,
            const SettingsScreen(),
            true,
          ),
        ],
      ),
    );
  }

  ListTile _buildListTile(
    BuildContext context,
    String title,
    IconData icon,
    Widget screen,
    bool enabled,
  ) {
    return ListTile(
      enabled: enabled,
      leading: Icon(icon),
      title: Text(title),
      onTap: () {
        Navigator.of(context).pushReplacement(MaterialPageRoute(
            builder: (context) => MasterScreen(title, screen)));
      },
    );
  }
}
