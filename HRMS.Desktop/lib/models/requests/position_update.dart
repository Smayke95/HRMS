import 'package:json_annotation/json_annotation.dart';

part 'position_update.g.dart';

@JsonSerializable()
class PositionUpdate {
  String name;
  int? departmentId;
  int? payGradeId;
  int? requiredEducationId;
  bool isWorkExperienceRequired;

  PositionUpdate(
    this.name,
    this.departmentId,
    this.payGradeId,
    this.requiredEducationId,
    this.isWorkExperienceRequired,
  );

  factory PositionUpdate.fromJson(Map<String, dynamic> json) =>
      _$PositionUpdateFromJson(json);

  Map<String, dynamic> toJson() => _$PositionUpdateToJson(this);
}
