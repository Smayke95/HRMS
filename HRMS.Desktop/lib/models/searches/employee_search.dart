import 'package:json_annotation/json_annotation.dart';

import 'base_search.dart';

part 'employee_search.g.dart';

@JsonSerializable()
class EmployeeSearch extends BaseSearch {
  String? name;
  bool includeCity = false;
  bool includeCountry = false;
  bool includeEducation = false;

  EmployeeSearch();

  factory EmployeeSearch.fromJson(Map<String, dynamic> json) =>
      _$EmployeeSearchFromJson(json);

  @override
  Map<String, dynamic> toJson() => _$EmployeeSearchToJson(this);
}
