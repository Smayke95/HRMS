import 'package:flutter/material.dart';

import 'responsive.dart';

class Header extends StatelessWidget {
  final String _title;
  final GlobalKey<ScaffoldState> _menuKey;

  const Header(this._title, this._menuKey, {super.key});

  @override
  Widget build(BuildContext context) {
    return SizedBox(
      height: 60,
      child: Row(
        children: [
          if (!Responsive.isDesktop(context))
            TextButton(
              onPressed: () => _menuKey.currentState!.openDrawer(),
              child: const Icon(
                Icons.menu,
                color: Colors.grey,
              ),
            ),
          const SizedBox(width: 20),
          Expanded(
            child: Text(
              _title,
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
            child: TextButton(
              onPressed: () => print("Open notifications"),
              child: Badge.count(
                count: 6,
                child: const Icon(
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
