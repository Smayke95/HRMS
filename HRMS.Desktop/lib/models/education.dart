import 'package:json_annotation/json_annotation.dart';

part 'education.g.dart';

@JsonSerializable()
class Education {
  int id;
  String isced;
  int eqf;
  String qualification;
  String finishedEducation;
  String qualificationOld;
  String finishedEducationOld;

  Education(
    this.id,
    this.isced,
    this.eqf,
    this.qualification,
    this.finishedEducation,
    this.qualificationOld,
    this.finishedEducationOld,
  );

  factory Education.fromJson(Map<String, dynamic> json) =>
      _$EducationFromJson(json);

  Map<String, dynamic> toJson() => _$EducationToJson(this);
}
