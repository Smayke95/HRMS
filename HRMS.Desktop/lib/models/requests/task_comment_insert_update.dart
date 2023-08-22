import 'package:json_annotation/json_annotation.dart';

part 'task_comment_insert_update.g.dart';

@JsonSerializable()
class TaskCommentInsertUpdate {
  DateTime time;
  String content;  
  String? taskId;
  String? employeeId;

  TaskCommentInsertUpdate(
    this.time,
    this.content,
    this.taskId,
    this.employeeId,
  );

  factory TaskCommentInsertUpdate.fromJson(Map<String, dynamic> json) =>
      _$TaskCommentInsertUpdateFromJson(json);

  Map<String, dynamic> toJson() => _$TaskCommentInsertUpdateToJson(this);
}
