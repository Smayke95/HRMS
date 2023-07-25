// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'task_search.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

TaskSearch _$TaskSearchFromJson(Map<String, dynamic> json) => TaskSearch()
  ..page = json['page'] as int
  ..pageSize = json['pageSize'] as int
  ..name = json['name'] as String?
  ..includeProject = json['includeProject'] as bool
  ..includeStatus = json['includeStatus'] as bool
  ..includeType = json['includeType'] as bool
  ..includeEmployee = json['includeEmployee'] as bool;

Map<String, dynamic> _$TaskSearchToJson(TaskSearch instance) =>
    <String, dynamic>{
      'page': instance.page,
      'pageSize': instance.pageSize,
      'name': instance.name,
      'includeProject': instance.includeProject,
      'includeStatus': instance.includeStatus,
      'includeType': instance.includeType,
      'includeEmployee': instance.includeEmployee,
    };
