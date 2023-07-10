// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'position.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Position _$PositionFromJson(Map<String, dynamic> json) => Position(
      json['id'] as int,
      json['name'] as String,
      json['department'] == null
          ? null
          : Department.fromJson(json['department'] as Map<String, dynamic>),
      json['payGrade'] == null
          ? null
          : PayGrade.fromJson(json['payGrade'] as Map<String, dynamic>),
      json['requiredEducation'] == null
          ? null
          : Education.fromJson(
              json['requiredEducation'] as Map<String, dynamic>),
      json['isWorkExperienceRequired'] as bool,
    );

Map<String, dynamic> _$PositionToJson(Position instance) => <String, dynamic>{
      'id': instance.id,
      'name': instance.name,
      'department': instance.department,
      'payGrade': instance.payGrade,
      'requiredEducation': instance.requiredEducation,
      'isWorkExperienceRequired': instance.isWorkExperienceRequired,
    };
