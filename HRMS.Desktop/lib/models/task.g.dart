// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'task.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Task _$TaskFromJson(Map<String, dynamic> json) => Task(
      json['id'] as int,
      json['name'] as String,
      json['description'] as String,
      json['project'] == null
          ? null
          : Project.fromJson(json['project'] as Map<String, dynamic>),
      json['status'] == null
          ? null
          : TaskStatus.fromJson(json['status'] as Map<String, dynamic>),
      json['type'] == null
          ? null
          : TaskType.fromJson(json['type'] as Map<String, dynamic>),
      json['employee'] == null
          ? null
          : Employee.fromJson(json['employee'] as Map<String, dynamic>),
    );

Map<String, dynamic> _$TaskToJson(Task instance) => <String, dynamic>{
      'id': instance.id,
      'name': instance.name,
      'description': instance.description,
      'project': instance.project,
      'status': instance.status,
      'type': instance.type,
      'employee': instance.employee,
    };
