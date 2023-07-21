// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'employee_position_update.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

EmployeePositionUpdate _$EmployeePositionUpdateFromJson(
        Map<String, dynamic> json) =>
    EmployeePositionUpdate(
      json['employeeId'] as int,
      json['positionId'] as int,
      DateTime.parse(json['startDate'] as String),
      json['endDate'] == null
          ? null
          : DateTime.parse(json['endDate'] as String),
      (json['salary'] as num).toDouble(),
      json['vacationDays'] as int,
      $enumDecode(_$EmploymentTypeEnumMap, json['employmentType']),
      json['workingHours'] as String,
    );

Map<String, dynamic> _$EmployeePositionUpdateToJson(
        EmployeePositionUpdate instance) =>
    <String, dynamic>{
      'employeeId': instance.employeeId,
      'positionId': instance.positionId,
      'startDate': instance.startDate.toIso8601String(),
      'endDate': instance.endDate?.toIso8601String(),
      'salary': instance.salary,
      'vacationDays': instance.vacationDays,
      'employmentType': _$EmploymentTypeEnumMap[instance.employmentType]!,
      'workingHours': instance.workingHours,
    };

const _$EmploymentTypeEnumMap = {
  EmploymentType.permanent: 0,
  EmploymentType.fixed: 1,
};
