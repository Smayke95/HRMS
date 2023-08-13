import 'package:json_annotation/json_annotation.dart';

part 'event_type.g.dart';

@JsonSerializable()
class EventType {
  int id;
  String name;
  bool isApprovalRequired;
  String color;

  EventType(
    this.id,
    this.name,
    this.isApprovalRequired,
    this.color
  );

  factory EventType.fromJson(Map<String, dynamic> json) => _$EventTypeFromJson(json);

  Map<String, dynamic> toJson() => _$EventTypeToJson(this);
}
