// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'notification.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Notification _$NotificationFromJson(Map<String, dynamic> json) => Notification(
      $enumDecode(_$NotificationTypeEnumMap, json['type']),
      $enumDecode(_$RoleEnumMap, json['group']),
      json['text'] as String,
    );

Map<String, dynamic> _$NotificationToJson(Notification instance) =>
    <String, dynamic>{
      'type': _$NotificationTypeEnumMap[instance.type]!,
      'group': _$RoleEnumMap[instance.group]!,
      'text': instance.text,
    };

const _$NotificationTypeEnumMap = {
  NotificationType.info: 0,
  NotificationType.warning: 1,
  NotificationType.error: 2,
};

const _$RoleEnumMap = {
  Role.admin: 0,
  Role.manager: 1,
  Role.employee: 2,
};
