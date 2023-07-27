import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

import '../providers/auth_provider.dart';
import '../widgets/master_screen.dart';
import '../widgets/responsive.dart';
import 'dashboard_screen.dart';

class LoginScreen extends StatefulWidget {
  const LoginScreen({super.key});

  @override
  State<LoginScreen> createState() => _LoginScreenState();
}

class _LoginScreenState extends State<LoginScreen> {
  late AuthProvider _authProvider;

  final _emailController = TextEditingController();
  final _passwordController = TextEditingController();

  @override
  void initState() {
    super.initState();

    _authProvider = context.read<AuthProvider>();
  }

  Future _loginSubmit() async {
    try {
      var token = await _authProvider.login(
        _emailController.text,
        _passwordController.text,
      );

      _authProvider.getUser(token);

      if (!mounted) return;
      Navigator.of(context).pushReplacement(MaterialPageRoute(
          builder: (context) =>
              const MasterScreen("Početna", DashboardScreen())));
    } on Exception catch (e) {
      final snackBar = SnackBar(
        content: Text(e.toString()),
      );

      ScaffoldMessenger.of(context).showSnackBar(snackBar);
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Center(
        child: Container(
          constraints: BoxConstraints(
              maxWidth: 400,
              maxHeight: (Responsive.isMobile(context) ? 600 : 400)),
          child: !Responsive.isMobile(context)
              ? Card(
                  elevation: 2,
                  child: _buildLoginForm(context),
                )
              : _buildLoginForm(context),
        ),
      ),
    );
  }

  Widget _buildLoginForm(BuildContext context) {
    return Padding(
      padding: const EdgeInsets.all(10),
      child: Column(
        children: [
          Image.asset("assets/images/logo.png", width: 250, height: 150),
          if (Responsive.isMobile(context)) const SizedBox(height: 100),
          Padding(
            padding: const EdgeInsets.all(20.0),
            child: Column(
              children: [
                TextField(
                  decoration: const InputDecoration(
                      labelText: "Email*",
                      prefixIcon: Icon(Icons.email),
                      border: OutlineInputBorder()),
                  controller: _emailController,
                ),
                const SizedBox(height: 20),
                TextField(
                  decoration: const InputDecoration(
                      labelText: "Password*",
                      prefixIcon: Icon(Icons.password),
                      border: OutlineInputBorder()),
                  controller: _passwordController,
                  obscureText: true,
                  onSubmitted: (value) => _loginSubmit(),
                ),
              ],
            ),
          ),
          OutlinedButton(
            style: const ButtonStyle(
                padding: MaterialStatePropertyAll(
                    EdgeInsets.only(left: 40, top: 20, right: 40, bottom: 20))),
            onPressed: _loginSubmit,
            child: const Text("PRIJAVA"),
          )
        ],
      ),
    );
  }
}
