import 'package:json_annotation/json_annotation.dart';

enum Gender {
  @JsonValue(0)
  male,
  @JsonValue(1)
  female
}
