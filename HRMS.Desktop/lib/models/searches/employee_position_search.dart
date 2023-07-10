import 'package:json_annotation/json_annotation.dart';

import 'base_search.dart';

part 'employee_position_search.g.dart';

@JsonSerializable()
class EmployeePositionSearch extends BaseSearch {
  String? name;

  EmployeePositionSearch();

  factory EmployeePositionSearch.fromJson(Map<String, dynamic> json) =>
      _$EmployeePositionSearchFromJson(json);

  @override
  Map<String, dynamic> toJson() => _$EmployeePositionSearchToJson(this);
}
