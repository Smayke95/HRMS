import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;

import '../models/paged_result.dart';
import '../models/searches/base_search.dart';
import '../models/user.dart';

abstract class BaseProvider<T, TSearch extends BaseSearch> with ChangeNotifier {
  late String _baseUrl;
  late String _endpoint;

  BaseProvider({String? endpoint}) {
    _baseUrl = const String.fromEnvironment(
      "ApiUrl",
      defaultValue: "localhost:44378",
    );

    _endpoint = endpoint ?? T.toString();
  }

  Future<T> get(int id) async {
    var uri = Uri.https(_baseUrl, '$_endpoint/$id');

    var response = await http.get(uri, headers: _getHeaders());

    if (_isValidResponse(response)) {
      var data = jsonDecode(response.body);
      return fromJson(data);
    } else {
      throw Exception("Response is not valid");
    }
  }

  Future<PagedResult<T>> getAll({TSearch? search}) async {
    final Map<String, String> queryParameters = {};

    if (search != null) {
      search.toJson().forEach((key, value) {
        queryParameters.addAll(<String, String>{key: value.toString()});
      });

      queryParameters.removeWhere((key, value) => value == "null");
    }

    var uri = Uri.https(_baseUrl, _endpoint, queryParameters);

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

  Future<T> insert(dynamic request) async {
    var uri = Uri.https(_baseUrl, _endpoint);

    var jsonRequest = jsonEncode(request);

    var response =
        await http.post(uri, headers: _getHeaders(), body: jsonRequest);

    if (_isValidResponse(response)) {
      var data = jsonDecode(response.body);
      return fromJson(data);
    } else {
      throw Exception("Response is not valid");
    }
  }

  Future<T> update(int id, dynamic request) async {
    var uri = Uri.https(_baseUrl, '$_endpoint/$id');

    var jsonRequest = jsonEncode(request);

    var response =
        await http.put(uri, headers: _getHeaders(), body: jsonRequest);

    if (_isValidResponse(response)) {
      var data = jsonDecode(response.body);
      return fromJson(data);
    } else {
      throw Exception("Response is not valid");
    }
  }

  Future<bool> delete(int id) async {
    var uri = Uri.https(_baseUrl, '$_endpoint/$id');

    var response = await http.delete(uri, headers: _getHeaders());

    if (_isValidResponse(response)) {
      return true;
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
