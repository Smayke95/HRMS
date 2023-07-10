// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'department.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Department _$DepartmentFromJson(Map<String, dynamic> json) => Department(
      json['id'] as int,
      json['name'] as String,
      json['parentDepartment'] == null
          ? null
          : Department.fromJson(
              json['parentDepartment'] as Map<String, dynamic>),
      json['level'] as int,
      json['supervisor'] == null
          ? null
          : Employee.fromJson(json['supervisor'] as Map<String, dynamic>),
    );

Map<String, dynamic> _$DepartmentToJson(Department instance) =>
    <String, dynamic>{
      'id': instance.id,
      'name': instance.name,
      'parentDepartment': instance.parentDepartment,
      'level': instance.level,
      'supervisor': instance.supervisor,
    };
