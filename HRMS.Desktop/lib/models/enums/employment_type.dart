import 'package:json_annotation/json_annotation.dart';

enum EmploymentType {
  @JsonValue(0)
  permanent,
  @JsonValue(1)
  fixed
}
