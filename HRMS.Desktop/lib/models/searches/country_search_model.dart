import 'package:json_annotation/json_annotation.dart';

import 'base_search.dart';

part 'country_search_model.g.dart';

@JsonSerializable()
class CountrySearch extends BaseSearch {
  String? name;

  CountrySearch();

  factory CountrySearch.fromJson(Map<String, dynamic> json) =>
      _$CountrySearchFromJson(json);

  @override
  Map<String, dynamic> toJson() => _$CountrySearchToJson(this);
}