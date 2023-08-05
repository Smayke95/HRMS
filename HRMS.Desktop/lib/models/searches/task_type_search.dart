import 'package:json_annotation/json_annotation.dart';

import 'base_search.dart';

part 'task_type_search.g.dart';

@JsonSerializable()
class TaskTypeSearch extends BaseSearch {
  String? name;

  TaskTypeSearch();

  factory TaskTypeSearch.fromJson(Map<String, dynamic> json) =>
      _$TaskTypeSearchFromJson(json);

  @override
  Map<String, dynamic> toJson() => _$TaskTypeSearchToJson(this);
}