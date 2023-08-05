// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'task_status_search.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

TaskStatusSearch _$TaskStatusSearchFromJson(Map<String, dynamic> json) =>
    TaskStatusSearch()
      ..page = json['page'] as int
      ..pageSize = json['pageSize'] as int
      ..name = json['name'] as String?;

Map<String, dynamic> _$TaskStatusSearchToJson(TaskStatusSearch instance) =>
    <String, dynamic>{
      'page': instance.page,
      'pageSize': instance.pageSize,
      'name': instance.name,
    };
