import 'package:json_annotation/json_annotation.dart';

import 'employee.dart';

part 'message.g.dart';

@JsonSerializable()
class Message {
  String text;
  DateTime time;
  String room;
  int? employeeId;
  Employee? employee;

  Message(
    this.text,
    this.time,
    this.room,
    this.employeeId,
    this.employee,
  );

  factory Message.fromJson(Map<String, dynamic> json) =>
      _$MessageFromJson(json);

  Map<String, dynamic> toJson() => _$MessageToJson(this);
}
