import 'package:json_annotation/json_annotation.dart';

import 'base_search.dart';

part 'position_search.g.dart';

@JsonSerializable()
class PositionSearch extends BaseSearch {
  String? name;
  bool includeDepartment = false;
  bool includePayGrade = false;
  bool includeEducation = false;

  PositionSearch();

  factory PositionSearch.fromJson(Map<String, dynamic> json) =>
      _$PositionSearchFromJson(json);

  @override
  Map<String, dynamic> toJson() => _$PositionSearchToJson(this);
}
