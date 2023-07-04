import 'package:flutter/material.dart';
import 'screens/dashboard_screen.dart';
import 'widgets/master_screen.dart';

void main() {
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'HRMS',
      theme: ThemeData(
        primarySwatch: Colors.blue,
      ),
      home: MasterScreen("Početna", DashboardScreen()),
    );
  }
}
