// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'department_insert_update.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

DepartmentInsertUpdate _$DepartmentInsertUpdateFromJson(
        Map<String, dynamic> json) =>
    DepartmentInsertUpdate(
      json['name'] as String,
      json['parentDepartmentId'] as int?,
      json['supervisorId'] as int?,
    );

Map<String, dynamic> _$DepartmentInsertUpdateToJson(
        DepartmentInsertUpdate instance) =>
    <String, dynamic>{
      'name': instance.name,
      'parentDepartmentId': instance.parentDepartmentId,
      'supervisorId': instance.supervisorId,
    };
