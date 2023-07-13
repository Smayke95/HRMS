// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'position_insert.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

PositionInsert _$PositionInsertFromJson(Map<String, dynamic> json) =>
    PositionInsert(
      json['name'] as String,
      json['departmentId'] as int?,
      json['payGradeId'] as int?,
      json['requiredEducationId'] as int?,
      json['isWorkExperienceRequired'] as bool,
    );

Map<String, dynamic> _$PositionInsertToJson(PositionInsert instance) =>
    <String, dynamic>{
      'name': instance.name,
      'departmentId': instance.departmentId,
      'payGradeId': instance.payGradeId,
      'requiredEducationId': instance.requiredEducationId,
      'isWorkExperienceRequired': instance.isWorkExperienceRequired,
    };
