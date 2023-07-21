// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'department_update.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

DepartmentUpdate _$DepartmentUpdateFromJson(Map<String, dynamic> json) =>
    DepartmentUpdate(
      json['name'] as String,
      json['parentDepartmentId'] as int?,
      json['supervisorId'] as int?,
    );

Map<String, dynamic> _$DepartmentUpdateToJson(DepartmentUpdate instance) =>
    <String, dynamic>{
      'name': instance.name,
      'parentDepartmentId': instance.parentDepartmentId,
      'supervisorId': instance.supervisorId,
    };
