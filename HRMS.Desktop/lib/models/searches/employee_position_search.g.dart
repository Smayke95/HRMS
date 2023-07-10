// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'employee_position_search.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

EmployeePositionSearch _$EmployeePositionSearchFromJson(
        Map<String, dynamic> json) =>
    EmployeePositionSearch()
      ..page = json['page'] as int
      ..pageSize = json['pageSize'] as int
      ..name = json['name'] as String?;

Map<String, dynamic> _$EmployeePositionSearchToJson(
        EmployeePositionSearch instance) =>
    <String, dynamic>{
      'page': instance.page,
      'pageSize': instance.pageSize,
      'name': instance.name,
    };
