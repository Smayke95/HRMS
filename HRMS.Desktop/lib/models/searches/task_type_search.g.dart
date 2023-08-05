// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'task_type_search.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

TaskTypeSearch _$TaskTypeSearchFromJson(Map<String, dynamic> json) =>
    TaskTypeSearch()
      ..page = json['page'] as int
      ..pageSize = json['pageSize'] as int
      ..name = json['name'] as String?;

Map<String, dynamic> _$TaskTypeSearchToJson(TaskTypeSearch instance) =>
    <String, dynamic>{
      'page': instance.page,
      'pageSize': instance.pageSize,
      'name': instance.name,
    };
