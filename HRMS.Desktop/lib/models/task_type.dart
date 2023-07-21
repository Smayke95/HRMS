import 'package:json_annotation/json_annotation.dart';

part 'task_type.g.dart';

@JsonSerializable()
class TaskType {
  int id;
  String name;  

  TaskType(
    this.id,
    this.name
  );

  factory TaskType.fromJson(Map<String, dynamic> json) =>
      _$TaskTypeFromJson(json);

  Map<String, dynamic> toJson() => _$TaskTypeToJson(this);
}
