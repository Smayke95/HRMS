// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'position_update.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

PositionUpdate _$PositionUpdateFromJson(Map<String, dynamic> json) =>
    PositionUpdate(
      json['name'] as String,
      json['departmentId'] as int?,
      json['payGradeId'] as int?,
      json['requiredEducationId'] as int?,
      json['isWorkExperienceRequired'] as bool,
    );

Map<String, dynamic> _$PositionUpdateToJson(PositionUpdate instance) =>
    <String, dynamic>{
      'name': instance.name,
      'departmentId': instance.departmentId,
      'payGradeId': instance.payGradeId,
      'requiredEducationId': instance.requiredEducationId,
      'isWorkExperienceRequired': instance.isWorkExperienceRequired,
    };
