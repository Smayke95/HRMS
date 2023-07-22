// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'message.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Message _$MessageFromJson(Map<String, dynamic> json) => Message(
      json['text'] as String,
      DateTime.parse(json['time'] as String),
      json['room'] as String,
      json['employeeId'] as int?,
      json['employee'] == null
          ? null
          : Employee.fromJson(json['employee'] as Map<String, dynamic>),
    );

Map<String, dynamic> _$MessageToJson(Message instance) => <String, dynamic>{
      'text': instance.text,
      'time': instance.time.toIso8601String(),
      'room': instance.room,
      'employeeId': instance.employeeId,
      'employee': instance.employee,
    };
