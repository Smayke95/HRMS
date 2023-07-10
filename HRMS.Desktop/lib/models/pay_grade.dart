import 'package:json_annotation/json_annotation.dart';

part 'pay_grade.g.dart';

@JsonSerializable()
class PayGrade {
  int id;
  String name;
  double minAmount;
  double maxAmount;

  PayGrade(
    this.id,
    this.name,
    this.minAmount,
    this.maxAmount,
  );

  factory PayGrade.fromJson(Map<String, dynamic> json) =>
      _$PayGradeFromJson(json);

  Map<String, dynamic> toJson() => _$PayGradeToJson(this);
}
