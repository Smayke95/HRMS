import 'package:json_annotation/json_annotation.dart';

enum EventStatus {
  @JsonValue(0)
  initial,
  @JsonValue(1)
  approved,
  @JsonValue(2)
  declined,
  @JsonValue(3)
  deleted
}
