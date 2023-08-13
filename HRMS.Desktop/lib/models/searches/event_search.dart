import 'package:json_annotation/json_annotation.dart';

import 'base_search.dart';

part 'event_search.g.dart';

@JsonSerializable()
class EventSearch extends BaseSearch {
  String? name;
  int? employeeId;
  bool includeEventType = false;
  bool includeEmployee = false;  

  EventSearch();

  factory EventSearch.fromJson(Map<String, dynamic> json) =>
      _$EventSearchFromJson(json);

  @override
  Map<String, dynamic> toJson() => _$EventSearchToJson(this);
}
