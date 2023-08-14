import 'dart:convert';

import 'package:http/http.dart' as http;

import '../models/employee_position.dart';
import '../models/enums/employment_status.dart';
import '../models/searches/employee_position_search.dart';
import 'base_provider.dart';

class EmployeePositionProvider
    extends BaseProvider<EmployeePosition, EmployeePositionSearch> {
  @override
  EmployeePosition fromJson(data) => EmployeePosition.fromJson(data);

  Future<List<EmploymentStatus>> allowedActions(int id) async {
    var uri = Uri.https(baseUrl, '$endpoint/$id/AllowedActions');

    var response = await http.get(uri, headers: getHeaders());

    if (isValidResponse(response)) {
      var data = jsonDecode(response.body);

      List<EmploymentStatus> statuses = [];
      for (var type in data) {
        statuses.add(EmploymentStatus.values[type]);
      }

      return statuses;
    } else {
      throw Exception("Response is not valid");
    }
  }

  Future activate(int id) async {
    var uri = Uri.https(baseUrl, '$endpoint/$id/Activate');

    var response = await http.put(uri, headers: getHeaders());

    if (isValidResponse(response)) {
      return;
    } else {
      throw Exception("Response is not valid");
    }
  }

  Future deactivate(int id) async {
    var uri = Uri.https(baseUrl, '$endpoint/$id/Deactivate');

    var response = await http.put(uri, headers: getHeaders());

    if (isValidResponse(response)) {
      return;
    } else {
      throw Exception("Response is not valid");
    }
  }
}
