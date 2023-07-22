import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;

import '../models/constants/claim_type.dart';
import '../models/user.dart';

class AuthProvider with ChangeNotifier {
  late String _baseUrl;

  AuthProvider() {
    _baseUrl = const String.fromEnvironment(
      "IdentityServerUrl",
      defaultValue: "https://localhost:44379/",
    );
  }

  Future<String> login(String email, String password) async {
    var uri = Uri.parse('${_baseUrl}login?email=$email&password=$password');

    var response = await http.get(uri);

    if (_isValidResponse(response)) {
      return response.body;
    } else {
      throw Exception("Response is not valid");
    }
  }

  void getUser(String token) {
    final decodedToken = _decode(token);

    User.id = int.parse(decodedToken[ClaimType.sid] as String);
    User.name = decodedToken[ClaimType.name] as String?;
    User.email = decodedToken[ClaimType.email] as String?;
    User.token = token;

    var role = decodedToken[ClaimType.role];

    if (role is List<dynamic>) {
      User.roles = List<String>.from(decodedToken[ClaimType.role]);
    } else {
      User.roles.add(role);
    }
  }

  bool _isValidResponse(http.Response response) {
    if (response.statusCode < 299) {
      return true;
    } else if (response.statusCode == 401) {
      throw Exception("Neispravni kredencijali za prijavu.");
    } else {
      throw Exception("Serverska greška.");
    }
  }

  Map<String, dynamic> _decode(String token) {
    final splitToken = token.split(".");
    if (splitToken.length != 3) {
      throw const FormatException('Invalid token');
    }
    try {
      final payloadBase64 = splitToken[1];
      final normalizedPayload = base64.normalize(payloadBase64);
      final payloadString = utf8.decode(base64.decode(normalizedPayload));
      final decodedPayload = jsonDecode(payloadString);

      return decodedPayload;
    } catch (error) {
      throw const FormatException('Invalid payload');
    }
  }
}
