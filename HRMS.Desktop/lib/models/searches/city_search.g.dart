// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'city_search.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

CitySearch _$CitySearchFromJson(Map<String, dynamic> json) => CitySearch()
  ..page = json['page'] as int
  ..pageSize = json['pageSize'] as int
  ..name = json['name'] as String?
  ..includeCountry = json['includeCountry'] as bool;

Map<String, dynamic> _$CitySearchToJson(CitySearch instance) =>
    <String, dynamic>{
      'page': instance.page,
      'pageSize': instance.pageSize,
      'name': instance.name,
      'includeCountry': instance.includeCountry,
    };
