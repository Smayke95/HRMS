import 'package:json_annotation/json_annotation.dart';

import 'base_search.dart';

part 'task_search.g.dart';

@JsonSerializable()
class TaskSearch extends BaseSearch {
  String? name;
  TaskSearch();

  factory TaskSearch.fromJson(Map<String, dynamic> json) =>
      _$TaskSearchFromJson(json);

  @override
  Map<String, dynamic> toJson() => _$TaskSearchToJson(this);
}
