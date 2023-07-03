import 'package:flutter/material.dart';

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
            const Text(
              "Anes Smajić",
              style: TextStyle(
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
            onTap: () {},
          ),
          ListTile(
            leading: const Icon(Icons.content_paste),
            title: const Text("Zadaci"),
            onTap: () {},
          ),
          ListTile(
            leading: const Icon(Icons.chat),
            title: const Text("Razgovor"),
            onTap: () {},
          ),
          ListTile(
            leading: const Icon(Icons.date_range),
            title: const Text("Kalendar"),
            onTap: () {},
          ),
          ListTile(
            leading: const Icon(Icons.groups),
            title: const Text("Zaposlenici"),
            onTap: () {},
          ),
          SizedBox(height: spaceHeight),
          ListTile(
            leading: const Icon(Icons.settings),
            title: const Text("Postavke"),
            onTap: () {},
          )
        ],
      ),
    );
  }
}
