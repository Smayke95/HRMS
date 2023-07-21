import 'package:json_annotation/json_annotation.dart';

import 'base_search.dart';

part 'project_search.g.dart';

@JsonSerializable()
class ProjectSearch extends BaseSearch {
  String? name;

  ProjectSearch();

  factory ProjectSearch.fromJson(Map<String, dynamic> json) =>
      _$ProjectSearchFromJson(json);

  @override
  Map<String, dynamic> toJson() => _$ProjectSearchToJson(this);
}
