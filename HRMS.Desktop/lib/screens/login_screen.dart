import 'package:flutter/material.dart';

class LoginScreen extends StatelessWidget {
  const LoginScreen({super.key});

  @override
  Widget build(BuildContext context) {
    return Center(
        child: Container(
            constraints: const BoxConstraints(maxWidth: 400, maxHeight: 400),
            child: Card(
              child: Padding(
                padding: const EdgeInsets.all(10),
                child: Column(
                  children: [
                    Image.asset("assets/images/logo.png",
                        width: 200, height: 200),
                    const TextField(
                      decoration: InputDecoration(
                          labelText: "Email*", prefixIcon: Icon(Icons.email)),
                    ),
                    const SizedBox(height: 10),
                    const TextField(
                      decoration: InputDecoration(
                          labelText: "Password*",
                          prefixIcon: Icon(Icons.password)),
                    ),
                    const SizedBox(height: 10),
                    ElevatedButton(
                        onPressed: () {
                          print("Login");
                        },
                        child: Text("Login"))
                  ],
                ),
              ),
            )));
  }
}
