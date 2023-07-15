import 'package:json_annotation/json_annotation.dart';

enum Role {
  @JsonValue(0)
  admin,
  @JsonValue(1)
  manager,
  @JsonValue(2)
  employee
}
