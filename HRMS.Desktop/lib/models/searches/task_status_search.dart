import 'package:json_annotation/json_annotation.dart';

import 'base_search.dart';

part 'task_status_search.g.dart';

@JsonSerializable()
class TaskStatusSearch extends BaseSearch {
  String? name;

  TaskStatusSearch();

  factory TaskStatusSearch.fromJson(Map<String, dynamic> json) =>
      _$TaskStatusSearchFromJson(json);

  @override
  Map<String, dynamic> toJson() => _$TaskStatusSearchToJson(this);
}