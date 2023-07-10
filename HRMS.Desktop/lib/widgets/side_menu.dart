import 'package:flutter/material.dart';

import '../models/user.dart';
import '../screens/calendar_screen.dart';
import '../screens/chat_screen.dart';
import '../screens/dashboard_screen.dart';
import '../screens/department_list_screen.dart';
import '../screens/employee_list_screen.dart';
import '../screens/employee_position_list_screen.dart';
import '../screens/position_list_screen.dart';
import '../screens/projects_screen.dart';
import '../screens/settings_screen.dart';
import 'master_screen.dart';

class SideMenu extends StatelessWidget {
  const SideMenu({super.key});

  @override
  Widget build(BuildContext context) {
    return Drawer(
      child: SingleChildScrollView(
        child: Column(
          children: [
            buildHeader(context),
            const Divider(
              color: Colors.black,
              indent: 10,
              endIndent: 10,
              thickness: 0.1,
            ),
            buildUser(context),
            const Divider(
              color: Colors.black,
              indent: 10,
              endIndent: 10,
              thickness: 0.1,
            ),
            buildItems(context)
          ],
        ),
      ),
    );
  }

  Widget buildHeader(BuildContext context) {
    return Padding(
        padding: const EdgeInsets.only(top: 15, bottom: 10),
        child: Image.asset("assets/images/logo.png", width: 180));
  }

  Widget buildUser(BuildContext context) {
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

  Widget buildItems(BuildContext context) {
    double spaceHeight = MediaQuery.of(context).size.height > 545
        ? MediaQuery.of(context).size.height - 545
        : 0;

    return Padding(
      padding: const EdgeInsets.all(10.0),
      child: Wrap(
        runSpacing: 16,
        children: [
          ListTile(
            leading: const Icon(Icons.dashboard),
            title: const Text("Početna"),
            onTap: () {
              Navigator.of(context).pushReplacement(MaterialPageRoute(
                  builder: (context) =>
                      const MasterScreen("Početna", DashboardScreen())));
            },
          ),
          ListTile(
            leading: const Icon(Icons.content_paste),
            title: const Text("Zadaci"),
            onTap: () {
              Navigator.of(context).pushReplacement(MaterialPageRoute(
                  builder: (context) =>
                      const MasterScreen("Projekti", ProjectsScreen())));
            },
          ),
          ListTile(
            leading: const Icon(Icons.chat),
            title: const Text("Razgovor"),
            onTap: () {
              Navigator.of(context).pushReplacement(MaterialPageRoute(
                  builder: (context) =>
                      const MasterScreen("Razgovor", ChatScreen())));
            },
          ),
          ListTile(
            leading: const Icon(Icons.date_range),
            title: const Text("Kalendar"),
            onTap: () {
              Navigator.of(context).pushReplacement(MaterialPageRoute(
                  builder: (context) =>
                      const MasterScreen("Kalendar", CalendarScreen())));
            },
          ),
          ExpansionTile(
            leading: const Icon(Icons.groups),
            title: const Text("Zaposlenici"),
            children: [
              ListTile(
                leading: const Icon(Icons.groups),
                title: const Text("Zaposlenici"),
                onTap: () {
                  Navigator.of(context).pushReplacement(MaterialPageRoute(
                      builder: (context) => const MasterScreen(
                          "Zaposlenici", EmployeeListScreen())));
                },
              ),
              ListTile(
                leading: const Icon(Icons.content_copy),
                title: const Text("Zaposlenje"),
                onTap: () {
                  Navigator.of(context).pushReplacement(MaterialPageRoute(
                      builder: (context) => const MasterScreen(
                          "Zaposlenje", EmployeePositionListScreen())));
                },
              ),
              ListTile(
                leading: const Icon(Icons.storage),
                title: const Text("Pozicije"),
                onTap: () {
                  Navigator.of(context).pushReplacement(MaterialPageRoute(
                      builder: (context) => const MasterScreen(
                          "Pozicije", PositionListScreen())));
                },
              ),
              ListTile(
                leading: const Icon(Icons.location_city),
                title: const Text("Kompanija"),
                onTap: () {
                  Navigator.of(context).pushReplacement(MaterialPageRoute(
                      builder: (context) => const MasterScreen(
                          "Kompanija", DepartmentListScreen())));
                },
              ),
            ],
          ),
          SizedBox(height: spaceHeight),
          ListTile(
            leading: const Icon(Icons.settings),
            title: const Text("Postavke"),
            onTap: () {
              Navigator.of(context).pushReplacement(MaterialPageRoute(
                  builder: (context) =>
                      const MasterScreen("Postavke", SettingsScreen())));
            },
          )
        ],
      ),
    );
  }
}
