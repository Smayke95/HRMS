import 'package:json_annotation/json_annotation.dart';

enum NotificationType {
  @JsonValue(0)
  info,
  @JsonValue(1)
  warning,
  @JsonValue(2)
  error
}
