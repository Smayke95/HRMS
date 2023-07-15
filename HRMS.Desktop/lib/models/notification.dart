import 'package:json_annotation/json_annotation.dart';

import 'enums/notification_type.dart';
import 'enums/role.dart';

part 'notification.g.dart';

@JsonSerializable()
class Notification {
  NotificationType type;
  Role group;
  String text;

  Notification(
    this.type,
    this.group,
    this.text,
  );

  factory Notification.fromJson(Map<String, dynamic> json) =>
      _$NotificationFromJson(json);

  Map<String, dynamic> toJson() => _$NotificationToJson(this);
}
