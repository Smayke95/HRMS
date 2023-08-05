import 'package:flutter/material.dart';
import 'package:table_calendar/table_calendar.dart';

class CalendarScreen extends StatefulWidget {
  const CalendarScreen({super.key});

  @override
  State<CalendarScreen> createState() => _CalendarScreenState();
}

class _CalendarScreenState extends State<CalendarScreen> {
  //CalendarController _calendarController;

  @override
  void initState() {
    super.initState();
    //_calendarController = CalendarController();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Događaji'),
      ),
      body: TableCalendar(
        focusedDay: DateTime.now(),
        firstDay: DateTime(2023, 1, 1),
        lastDay: DateTime.now().add(const Duration(days: 365)),
        onDaySelected: (date, events) {},
      ),
    );
  }

  @override
  void dispose() {
    //_calendarController.dispose();
    super.dispose();
  }
}
