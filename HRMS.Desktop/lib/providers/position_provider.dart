import 'dart:convert';

import 'package:http/http.dart' as http;

import '../models/paged_result.dart';
import '../models/position.dart';
import '../models/searches/position_search.dart';
import 'base_provider.dart';

class PositionProvider extends BaseProvider<Position, PositionSearch> {
  @override
  Position fromJson(data) => Position.fromJson(data);

  Future<PagedResult<Position>> search({PositionSearch? search}) async {
    final Map<String, String> queryParameters = {};

    if (search != null) {
      search.toJson().forEach((key, value) {
        queryParameters.addAll(<String, String>{key: value.toString()});
      });

      queryParameters.removeWhere((key, value) => value == "null");
    }

    var uri = Uri.https(baseUrl, endpoint, queryParameters);

    var response = await http.get(uri, headers: getHeaders());

    if (isValidResponse(response)) {
      var data = jsonDecode(response.body);

      var result = PagedResult<Position>();

      result.totalCount = data['totalCount'];
      result.totalPages = data['totalPages'];
      result.page = data['page'];
      result.pageSize = data['pageSize'];

      for (var item in data['result']) {
        result.result.add(fromJson(item));
      }

      return result;
    } else {
      throw Exception("Response is not valid");
    }
  }
}
