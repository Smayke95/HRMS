import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'providers/department_provider.dart';
import 'providers/employee_provider.dart';
import 'screens/dashboard_screen.dart';
import 'widgets/master_screen.dart';

void main() {
  runApp(
    MultiProvider(
      providers: [
        ChangeNotifierProvider(create: (_) => DepartmentProvider()),
        ChangeNotifierProvider(create: (_) => EmployeeProvider()),
      ],
      child: const MyApp(),
    ),
  );
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
