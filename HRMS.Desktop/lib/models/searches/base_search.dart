import 'package:json_annotation/json_annotation.dart';

part 'base_search.g.dart';

@JsonSerializable()
class BaseSearch {
  int page = 1;
  int pageSize = 10;

  BaseSearch();

  factory BaseSearch.fromJson(Map<String, dynamic> json) =>
      _$BaseSearchFromJson(json);

  Map<String, dynamic> toJson() => _$BaseSearchToJson(this);
}
