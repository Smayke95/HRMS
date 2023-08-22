// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'task_comment.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

TaskComment _$TaskCommentFromJson(Map<String, dynamic> json) => TaskComment(
      json['id'] as int,
      DateTime.parse(json['time'] as String),
      json['content'] as String,
      json['task'] == null
          ? null
          : Task.fromJson(json['task'] as Map<String, dynamic>),
      json['employee'] == null
          ? null
          : Employee.fromJson(json['employee'] as Map<String, dynamic>),
    );

Map<String, dynamic> _$TaskCommentToJson(TaskComment instance) =>
    <String, dynamic>{
      'id': instance.id,
      'time': instance.time.toIso8601String(),
      'content': instance.content,
      'task': instance.task,
      'employee': instance.employee,
    };
