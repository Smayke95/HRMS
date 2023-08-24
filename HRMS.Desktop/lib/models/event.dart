import 'package:json_annotation/json_annotation.dart';

import 'employee.dart';
import 'enums/event_status.dart';
import 'event_type.dart';

part 'event.g.dart';

@JsonSerializable()
class Event {
  int id;
  String name;
  String description;
  DateTime startDate;
  DateTime endDate;
  EventType? eventType;
  Employee? employee;
  EventStatus status;

  Event(
    this.id,
    this.name,
    this.description,
    this.startDate,
    this.endDate,
    this.eventType,
    this.employee,
    this.status
  );

  factory Event.fromJson(Map<String, dynamic> json) => _$EventFromJson(json);

  Map<String, dynamic> toJson() => _$EventToJson(this);
}
