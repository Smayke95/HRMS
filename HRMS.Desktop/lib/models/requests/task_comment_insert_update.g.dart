// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'task_comment_insert_update.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

TaskCommentInsertUpdate _$TaskCommentInsertUpdateFromJson(
        Map<String, dynamic> json) =>
    TaskCommentInsertUpdate(
      DateTime.parse(json['time'] as String),
      json['content'] as String,
      json['taskId'] as String?,
      json['employeeId'] as String?,
    );

Map<String, dynamic> _$TaskCommentInsertUpdateToJson(
        TaskCommentInsertUpdate instance) =>
    <String, dynamic>{
      'time': instance.time.toIso8601String(),
      'content': instance.content,
      'taskId': instance.taskId,
      'employeeId': instance.employeeId,
    };
