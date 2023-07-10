import 'package:json_annotation/json_annotation.dart';

import 'department.dart';
import 'education.dart';
import 'pay_grade.dart';

part 'position.g.dart';

@JsonSerializable()
class Position {
  int id;
  String name;
  Department? department;
  PayGrade? payGrade;
  Education? requiredEducation;
  bool isWorkExperienceRequired;

  Position(
    this.id,
    this.name,
    this.department,
    this.payGrade,
    this.requiredEducation,
    this.isWorkExperienceRequired,
  );

  factory Position.fromJson(Map<String, dynamic> json) =>
      _$PositionFromJson(json);

  Map<String, dynamic> toJson() => _$PositionToJson(this);
}
