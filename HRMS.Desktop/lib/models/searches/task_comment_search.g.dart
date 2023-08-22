// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'task_comment_search.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

TaskCommentSearch _$TaskCommentSearchFromJson(Map<String, dynamic> json) =>
    TaskCommentSearch()
      ..page = json['page'] as int
      ..pageSize = json['pageSize'] as int
      ..taskId = json['taskId'] as int?;

Map<String, dynamic> _$TaskCommentSearchToJson(TaskCommentSearch instance) =>
    <String, dynamic>{
      'page': instance.page,
      'pageSize': instance.pageSize,
      'taskId': instance.taskId,
    };
