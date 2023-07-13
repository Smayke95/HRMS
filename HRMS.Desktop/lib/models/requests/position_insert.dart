import 'package:json_annotation/json_annotation.dart';

part 'position_insert.g.dart';

@JsonSerializable()
class PositionInsert {
  String name;
  int? departmentId;
  int? payGradeId;
  int? requiredEducationId;
  bool isWorkExperienceRequired;

  PositionInsert(
    this.name,
    this.departmentId,
    this.payGradeId,
    this.requiredEducationId,
    this.isWorkExperienceRequired,
  );

  factory PositionInsert.fromJson(Map<String, dynamic> json) =>
      _$PositionInsertFromJson(json);

  Map<String, dynamic> toJson() => _$PositionInsertToJson(this);
}
