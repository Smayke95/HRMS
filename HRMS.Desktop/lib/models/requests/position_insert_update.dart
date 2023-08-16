import 'package:json_annotation/json_annotation.dart';

part 'position_insert_update.g.dart';

@JsonSerializable()
class PositionInsertUpdate {
  String name;
  int? departmentId;
  int? payGradeId;
  int? requiredEducationId;
  bool isWorkExperienceRequired;

  PositionInsertUpdate(
    this.name,
    this.departmentId,
    this.payGradeId,
    this.requiredEducationId,
    this.isWorkExperienceRequired,
  );

  factory PositionInsertUpdate.fromJson(Map<String, dynamic> json) =>
      _$PositionInsertUpdateFromJson(json);

  Map<String, dynamic> toJson() => _$PositionInsertUpdateToJson(this);
}
