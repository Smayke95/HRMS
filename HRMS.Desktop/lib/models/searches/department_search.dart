import 'package:json_annotation/json_annotation.dart';

import 'base_search.dart';

part 'department_search.g.dart';

@JsonSerializable()
class DepartmentSearch extends BaseSearch {
  String? name;
  bool includeSupervisor = false;

  DepartmentSearch();

  factory DepartmentSearch.fromJson(Map<String, dynamic> json) =>
      _$DepartmentSearchFromJson(json);

  @override
  Map<String, dynamic> toJson() => _$DepartmentSearchToJson(this);
}
