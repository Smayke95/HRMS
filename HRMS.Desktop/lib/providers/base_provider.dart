import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;

import '../models/paged_result.dart';
import '../models/user.dart';

abstract class BaseProvider<T> with ChangeNotifier {
  late String _baseUrl;

  BaseProvider({String? endpoint}) {
    _baseUrl = const String.fromEnvironment(
      "ApiUrl",
      defaultValue: "https://localhost:44378/",
    );

    _baseUrl += endpoint ?? T.toString();
  }

  Future<T> get(int id) async {
    var uri = Uri.parse('$_baseUrl/$id');

    var response = await http.get(uri, headers: _getHeaders());

    if (_isValidResponse(response)) {
      var data = jsonDecode(response.body);
      return fromJson(data);
    } else {
      throw Exception("Response is not valid");
    }
  }

  Future<PagedResult<T>> getAll() async {
    var uri = Uri.parse(_baseUrl);

    var response = await http.get(uri, headers: _getHeaders());

    if (_isValidResponse(response)) {
      var data = jsonDecode(response.body);

      var result = PagedResult<T>();

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

  Map<String, String> _getHeaders() => {
        "Content-Type": "application/json",
        "Authorization": "Bearer ${User.token ?? ""}"
      };

  bool _isValidResponse(http.Response response) {
    if (response.statusCode < 299) {
      return true;
    } else if (response.statusCode == 401) {
      throw Exception("Unauthorized");
    } else {
      throw Exception("Something bad happened");
    }
  }

  T fromJson(data) => throw Exception("Method not implemented");
}
