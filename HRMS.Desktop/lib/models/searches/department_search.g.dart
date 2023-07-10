// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'department_search.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

DepartmentSearch _$DepartmentSearchFromJson(Map<String, dynamic> json) =>
    DepartmentSearch()
      ..page = json['page'] as int
      ..pageSize = json['pageSize'] as int
      ..name = json['name'] as String?
      ..includeParentDepartment = json['includeParentDepartment'] as bool
      ..includeSupervisor = json['includeSupervisor'] as bool;

Map<String, dynamic> _$DepartmentSearchToJson(DepartmentSearch instance) =>
    <String, dynamic>{
      'page': instance.page,
      'pageSize': instance.pageSize,
      'name': instance.name,
      'includeParentDepartment': instance.includeParentDepartment,
      'includeSupervisor': instance.includeSupervisor,
    };
