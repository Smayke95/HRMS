import 'package:json_annotation/json_annotation.dart';

part 'task_status.g.dart';

@JsonSerializable()
class TaskStatus {
  int id;
  String name;  

  TaskStatus(
    this.id,
    this.name
  );

  factory TaskStatus.fromJson(Map<String, dynamic> json) =>
      _$TaskStatusFromJson(json);

  Map<String, dynamic> toJson() => _$TaskStatusToJson(this);
}
