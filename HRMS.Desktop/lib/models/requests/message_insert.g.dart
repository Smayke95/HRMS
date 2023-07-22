// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'message_insert.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

MessageInsert _$MessageInsertFromJson(Map<String, dynamic> json) =>
    MessageInsert(
      json['text'] as String,
      json['room'] as String,
      json['employeeId'] as int,
    );

Map<String, dynamic> _$MessageInsertToJson(MessageInsert instance) =>
    <String, dynamic>{
      'text': instance.text,
      'room': instance.room,
      'employeeId': instance.employeeId,
    };
