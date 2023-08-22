import 'package:HRMS/models/task.dart';
import 'package:json_annotation/json_annotation.dart';

import 'employee.dart';

part 'task_comment.g.dart';

@JsonSerializable()
class TaskComment {
  int id;
  DateTime time;
  String content;
  Task? task;
  Employee? employee;

  TaskComment(
    this.id,
    this.time,
    this.content,
    this.task,
    this.employee
  );

  factory TaskComment.fromJson(Map<String, dynamic> json) =>
      _$TaskCommentFromJson(json);

  Map<String, dynamic> toJson() => _$TaskCommentToJson(this);
}
