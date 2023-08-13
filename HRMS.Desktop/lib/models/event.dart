import 'package:json_annotation/json_annotation.dart';

import 'employee.dart';
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

  Event(
    this.id,
    this.name,
    this.description,
    this.startDate,
    this.endDate,
    this.eventType,
    this.employee,
  );

  factory Event.fromJson(Map<String, dynamic> json) => _$EventFromJson(json);

  Map<String, dynamic> toJson() => _$EventToJson(this);
}
