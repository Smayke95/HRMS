import 'package:flutter/material.dart';

class Footer extends StatelessWidget {
  const Footer({super.key});

  @override
  Widget build(BuildContext context) {
    return Container(
      decoration: const BoxDecoration(
        border: Border(
          top: BorderSide(
            width: 0.2,
            color: Colors.grey,
          ),
        ),
      ),
      height: 50,
      child: const Row(children: [
        Expanded(
          child: Center(
            child: Text(
              "© 2023 - HRMS",
              style: TextStyle(
                color: Colors.grey,
              ),
            ),
          ),
        ),
      ]),
    );
  }
}
