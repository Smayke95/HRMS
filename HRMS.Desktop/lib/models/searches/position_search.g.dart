// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'position_search.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

PositionSearch _$PositionSearchFromJson(Map<String, dynamic> json) =>
    PositionSearch()
      ..page = json['page'] as int
      ..pageSize = json['pageSize'] as int
      ..name = json['name'] as String?
      ..includeDepartment = json['includeDepartment'] as bool
      ..includePayGrade = json['includePayGrade'] as bool
      ..includeEducation = json['includeEducation'] as bool;

Map<String, dynamic> _$PositionSearchToJson(PositionSearch instance) =>
    <String, dynamic>{
      'page': instance.page,
      'pageSize': instance.pageSize,
      'name': instance.name,
      'includeDepartment': instance.includeDepartment,
      'includePayGrade': instance.includePayGrade,
      'includeEducation': instance.includeEducation,
    };
