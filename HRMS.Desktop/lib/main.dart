import 'dart:io';

import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

import 'providers/auth_provider.dart';
import 'providers/chat_provider.dart';
import 'providers/city_provider.dart';
import 'providers/country_provider.dart';
import 'providers/department_provider.dart';
import 'providers/education_provider.dart';
import 'providers/employee_position_provider.dart';
import 'providers/employee_provider.dart';
import 'providers/event_provider.dart';
import 'providers/event_type_provider.dart';
import 'providers/notification_provider.dart';
import 'providers/pay_grade_provider.dart';
import 'providers/position_provider.dart';
import 'providers/project_provider.dart';
import 'providers/task_provider.dart';
import 'providers/task_status_provider.dart';
import 'providers/task_type_provider.dart';
import 'screens/login_screen.dart';

void main() async {
  HttpOverrides.global = MyHttpOverrides();

  runApp(
    MultiProvider(
      providers: [
        ChangeNotifierProvider(create: (_) => AuthProvider()),
        ChangeNotifierProvider(create: (_) => ChatProvider()),
        ChangeNotifierProvider(create: (_) => CityProvider()),
        ChangeNotifierProvider(create: (_) => CountryProvider()),
        ChangeNotifierProvider(create: (_) => DepartmentProvider()),
        ChangeNotifierProvider(create: (_) => EducationProvider()),
        ChangeNotifierProvider(create: (_) => EmployeeProvider()),
        ChangeNotifierProvider(create: (_) => EmployeePositionProvider()),
        ChangeNotifierProvider(create: (_) => EventProvider()),
        ChangeNotifierProvider(create: (_) => EventTypeProvider()),
        ChangeNotifierProvider(create: (_) => NotificationProvider()),
        ChangeNotifierProvider(create: (_) => PayGradeProvider()),
        ChangeNotifierProvider(create: (_) => PositionProvider()),
        ChangeNotifierProvider(create: (_) => ProjectProvider()),
        ChangeNotifierProvider(create: (_) => TaskProvider()),
        ChangeNotifierProvider(create: (_) => TaskStatusProvider()),
        ChangeNotifierProvider(create: (_) => TaskTypeProvider()),
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
      home: const LoginScreen(),
    );
  }
}

class MyHttpOverrides extends HttpOverrides {
  @override
  HttpClient createHttpClient(SecurityContext? context) {
    return super.createHttpClient(context)
      ..badCertificateCallback =
          (X509Certificate cert, String host, int port) => true;
  }
}
