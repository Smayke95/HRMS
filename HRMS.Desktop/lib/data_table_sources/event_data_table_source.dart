import 'package:flutter/material.dart';
import 'package:syncfusion_flutter_calendar/calendar.dart';

import '../models/event.dart';

class EventDataTableSource extends CalendarDataSource {
  EventDataTableSource(List<Event> source){
    appointments = source;
  }

  @override
  DateTime getStartTime(int index) {
    return appointments![index].startDate;
  }

  @override
  DateTime getEndTime(int index) {
    return appointments![index].endDate;
  }

  @override
  String getSubject(int index) {
    return appointments![index].name;
  }

  @override
  Color getColor(int index) {
    return const Color.fromRGBO(55, 92, 212, 0.671);//appointments![index].eventType.color;
  }

  @override
  bool isAllDay(int index) {
    return true;
  }
}