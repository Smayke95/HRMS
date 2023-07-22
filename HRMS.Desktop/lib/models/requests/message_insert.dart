import 'package:json_annotation/json_annotation.dart';

part 'message_insert.g.dart';

@JsonSerializable()
class MessageInsert {
  String text;
  String room;
  int employeeId;

  MessageInsert(
    this.text,
    this.room,
    this.employeeId,
  );

  factory MessageInsert.fromJson(Map<String, dynamic> json) =>
      _$MessageInsertFromJson(json);

  Map<String, dynamic> toJson() => _$MessageInsertToJson(this);
}
