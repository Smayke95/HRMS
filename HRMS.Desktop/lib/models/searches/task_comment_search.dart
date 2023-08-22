import 'package:json_annotation/json_annotation.dart';

import 'base_search.dart';

part 'task_comment_search.g.dart';

@JsonSerializable()
class TaskCommentSearch extends BaseSearch {
  int? taskId;

  TaskCommentSearch();

  factory TaskCommentSearch.fromJson(Map<String, dynamic> json) =>
      _$TaskCommentSearchFromJson(json);

  @override
  Map<String, dynamic> toJson() => _$TaskCommentSearchToJson(this);
}