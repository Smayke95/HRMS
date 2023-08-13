import 'package:json_annotation/json_annotation.dart';

import 'base_search.dart';

part 'event_type_search.g.dart';

@JsonSerializable()
class EventTypeSearch extends BaseSearch {
  String? name;

  EventTypeSearch();

  factory EventTypeSearch.fromJson(Map<String, dynamic> json) =>
      _$EventTypeSearchFromJson(json);

  @override
  Map<String, dynamic> toJson() => _$EventTypeSearchToJson(this);
}