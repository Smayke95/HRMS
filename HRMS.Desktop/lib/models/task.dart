import 'package:json_annotation/json_annotation.dart';

import 'employee.dart';
import 'project.dart';
import 'task_status.dart';
import 'task_type.dart';

part 'task.g.dart';

@JsonSerializable()
class Task {
  int id;
  String name;
  String description;
  Project? project;
  TaskStatus? status;
  TaskType? type;
  Employee? employee;

  Task(
    this.id,
    this.name,
    this.description,
    this.project,
    this.status,
    this.type,
    this.employee
  );

  factory Task.fromJson(Map<String, dynamic> json) =>
      _$TaskFromJson(json);

  Map<String, dynamic> toJson() => _$TaskToJson(this);
}
