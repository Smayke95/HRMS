import 'dart:convert';

import 'package:http/http.dart' as http;

import '../models/enums/event_status.dart';
import '../models/event.dart';
import '../models/searches/event_search.dart';
import 'base_provider.dart';

class EventProvider extends BaseProvider<Event, EventSearch> {
  @override
  Event fromJson(data) => Event.fromJson(data);

  Future<List<EventStatus>> allowedActions(int id) async {
    var uri = Uri.https(baseUrl, '$endpoint/$id/AllowedActions');

    var response = await http.get(uri, headers: getHeaders());

    if (isValidResponse(response)) {
      var data = jsonDecode(response.body);

      List<EventStatus> statuses = [];
      for (var type in data) {
        statuses.add(EventStatus.values[type]);
      }

      return statuses;
    } else {
      throw Exception("Response is not valid");
    }
  }

  Future approve(int id) async {
    var uri = Uri.https(baseUrl, '$endpoint/$id/Approve');

    var response = await http.put(uri, headers: getHeaders());

    if (isValidResponse(response)) {
      return;
    } else {
      throw Exception("Response is not valid");
    }
  }

  Future decline(int id) async {
    var uri = Uri.https(baseUrl, '$endpoint/$id/Decline');

    var response = await http.put(uri, headers: getHeaders());

    if (isValidResponse(response)) {
      return;
    } else {
      throw Exception("Response is not valid");
    }
  }
}
