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
    var rgbColor = appointments![index].eventType.color.replaceFirst('#', '0xff');
    return Color(int.parse(rgbColor));
  }

  @override
  bool isAllDay(int index) {
    return true;
  }
}