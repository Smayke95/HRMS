// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'employee_search.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

EmployeeSearch _$EmployeeSearchFromJson(Map<String, dynamic> json) =>
    EmployeeSearch()
      ..page = json['page'] as int
      ..pageSize = json['pageSize'] as int
      ..name = json['name'] as String?
      ..includeCity = json['includeCity'] as bool
      ..includeCountry = json['includeCountry'] as bool
      ..includeEducation = json['includeEducation'] as bool;

Map<String, dynamic> _$EmployeeSearchToJson(EmployeeSearch instance) =>
    <String, dynamic>{
      'page': instance.page,
      'pageSize': instance.pageSize,
      'name': instance.name,
      'includeCity': instance.includeCity,
      'includeCountry': instance.includeCountry,
      'includeEducation': instance.includeEducation,
    };
