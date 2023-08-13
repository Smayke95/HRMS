// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'event_search.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

EventSearch _$EventSearchFromJson(Map<String, dynamic> json) => EventSearch()
  ..page = json['page'] as int
  ..pageSize = json['pageSize'] as int
  ..name = json['name'] as String?
  ..employeeId = json['employeeId'] as int?
  ..includeEventType = json['includeEventType'] as bool
  ..includeEmployee = json['includeEmployee'] as bool;

Map<String, dynamic> _$EventSearchToJson(EventSearch instance) =>
    <String, dynamic>{
      'page': instance.page,
      'pageSize': instance.pageSize,
      'name': instance.name,
      'employeeId': instance.employeeId,
      'includeEventType': instance.includeEventType,
      'includeEmployee': instance.includeEmployee,
    };
