// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'education.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Education _$EducationFromJson(Map<String, dynamic> json) => Education(
      json['id'] as int,
      json['isced'] as String,
      json['eqf'] as int,
      json['qualification'] as String,
      json['finishedEducation'] as String,
      json['qualificationOld'] as String,
      json['finishedEducationOld'] as String,
    );

Map<String, dynamic> _$EducationToJson(Education instance) => <String, dynamic>{
      'id': instance.id,
      'isced': instance.isced,
      'eqf': instance.eqf,
      'qualification': instance.qualification,
      'finishedEducation': instance.finishedEducation,
      'qualificationOld': instance.qualificationOld,
      'finishedEducationOld': instance.finishedEducationOld,
    };
