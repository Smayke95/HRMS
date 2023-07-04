import 'package:http/http.dart' as http;
import 'package:flutter/material.dart';
import '../models/paged_result.dart';

abstract class BaseProvider<T> with ChangeNotifier {
  late String _baseUrl;

  BaseProvider({String? endpoint}) {
    _baseUrl = const String.fromEnvironment(
      "ApiUrl",
      defaultValue: "https://localhost:44378/",
    );

    _baseUrl += endpoint ?? T.toString();

    print(_baseUrl);
  }

  PagedResult<T> getAll(){
    var uri = Uri.parse(_baseUrl);

    http.get(uri).then((value) => print(value.body));

    return PagedResult();
  }
}
