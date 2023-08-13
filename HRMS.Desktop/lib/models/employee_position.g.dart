// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'employee_position.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

EmployeePosition _$EmployeePositionFromJson(Map<String, dynamic> json) =>
    EmployeePosition(
      json['id'] as int,
      json['employee'] == null
          ? null
          : Employee.fromJson(json['employee'] as Map<String, dynamic>),
      json['position'] == null
          ? null
          : Position.fromJson(json['position'] as Map<String, dynamic>),
      DateTime.parse(json['startDate'] as String),
      json['endDate'] == null
          ? null
          : DateTime.parse(json['endDate'] as String),
      (json['salary'] as num).toDouble(),
      json['vacationDays'] as int,
      $enumDecode(_$EmploymentTypeEnumMap, json['type']),
      $enumDecode(_$EmploymentStatusEnumMap, json['status']),
      json['workingHours'] as String,
    );

Map<String, dynamic> _$EmployeePositionToJson(EmployeePosition instance) =>
    <String, dynamic>{
      'id': instance.id,
      'employee': instance.employee,
      'position': instance.position,
      'startDate': instance.startDate.toIso8601String(),
      'endDate': instance.endDate?.toIso8601String(),
      'salary': instance.salary,
      'vacationDays': instance.vacationDays,
      'type': _$EmploymentTypeEnumMap[instance.type]!,
      'status': _$EmploymentStatusEnumMap[instance.status]!,
      'workingHours': instance.workingHours,
    };

const _$EmploymentTypeEnumMap = {
  EmploymentType.permanent: 0,
  EmploymentType.fixed: 1,
};

const _$EmploymentStatusEnumMap = {
  EmploymentStatus.initial: 0,
  EmploymentStatus.inactive: 1,
  EmploymentStatus.active: 2,
  EmploymentStatus.deleted: 3,
};
