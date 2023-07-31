// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'country_search_model.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

CountrySearch _$CountrySearchFromJson(Map<String, dynamic> json) =>
    CountrySearch()
      ..page = json['page'] as int
      ..pageSize = json['pageSize'] as int
      ..name = json['name'] as String?;

Map<String, dynamic> _$CountrySearchToJson(CountrySearch instance) =>
    <String, dynamic>{
      'page': instance.page,
      'pageSize': instance.pageSize,
      'name': instance.name,
    };
