import 'package:json_annotation/json_annotation.dart';

import 'base_search.dart';

part 'city_search.g.dart';

@JsonSerializable()
class CitySearch extends BaseSearch {
  String? name;
  bool includeCountry = false;  

  CitySearch();

  factory CitySearch.fromJson(Map<String, dynamic> json) =>
      _$CitySearchFromJson(json);

  @override
  Map<String, dynamic> toJson() => _$CitySearchToJson(this);
}
