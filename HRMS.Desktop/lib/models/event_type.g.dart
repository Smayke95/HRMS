// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'event_type.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

EventType _$EventTypeFromJson(Map<String, dynamic> json) => EventType(
      json['id'] as int,
      json['name'] as String,
      json['isApprovalRequired'] as bool,
      json['color'] as String,
    );

Map<String, dynamic> _$EventTypeToJson(EventType instance) => <String, dynamic>{
      'id': instance.id,
      'name': instance.name,
      'isApprovalRequired': instance.isApprovalRequired,
      'color': instance.color,
    };
