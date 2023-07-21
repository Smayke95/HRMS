// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'department_insert.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

DepartmentInsert _$DepartmentInsertFromJson(Map<String, dynamic> json) =>
    DepartmentInsert(
      json['name'] as String,
      json['parentDepartmentId'] as int?,
      json['supervisorId'] as int?,
    );

Map<String, dynamic> _$DepartmentInsertToJson(DepartmentInsert instance) =>
    <String, dynamic>{
      'name': instance.name,
      'parentDepartmentId': instance.parentDepartmentId,
      'supervisorId': instance.supervisorId,
    };
