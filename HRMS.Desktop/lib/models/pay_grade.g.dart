// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'pay_grade.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

PayGrade _$PayGradeFromJson(Map<String, dynamic> json) => PayGrade(
      json['id'] as int,
      json['name'] as String,
      (json['minAmount'] as num).toDouble(),
      (json['maxAmount'] as num).toDouble(),
    );

Map<String, dynamic> _$PayGradeToJson(PayGrade instance) => <String, dynamic>{
      'id': instance.id,
      'name': instance.name,
      'minAmount': instance.minAmount,
      'maxAmount': instance.maxAmount,
    };
