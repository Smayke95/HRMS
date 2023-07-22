import 'package:json_annotation/json_annotation.dart';

import 'base_search.dart';

part 'message_search.g.dart';

@JsonSerializable()
class MessageSearch extends BaseSearch {
  String? room;
  bool includeEmployee = false;

  MessageSearch();

  factory MessageSearch.fromJson(Map<String, dynamic> json) =>
      _$MessageSearchFromJson(json);

  Map<String, dynamic> toJson() => _$MessageSearchToJson(this);
}
