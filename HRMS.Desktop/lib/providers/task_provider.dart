import 'dart:convert';

import 'package:http/http.dart' as http;

import '../models/paged_result.dart';
import '../models/searches/task_search.dart';
import '../models/task.dart';
import 'base_provider.dart';

class TaskProvider extends BaseProvider<Task, TaskSearch> {
  @override
  Task fromJson(data) => Task.fromJson(data);

  Future<PagedResult<Task>> search({TaskSearch? search}) async {
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

      var result = PagedResult<Task>();

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
