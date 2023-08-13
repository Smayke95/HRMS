import 'package:json_annotation/json_annotation.dart';

enum EmploymentStatus {
  @JsonValue(0)
  initial,
  @JsonValue(1)
  inactive,
  @JsonValue(2)
  active,
  @JsonValue(3)
  deleted
}
