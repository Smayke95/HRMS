import 'dart:convert';

import 'package:dart_amqp/dart_amqp.dart';
import 'package:flutter/material.dart';

import '../models/notification.dart' as hrms;
import '../models/user.dart';

class NotificationProvider with ChangeNotifier {
  Future listen(Function(hrms.Notification) add) async {
    var client = Client();

    var channel = await client.channel();
    var queue = await channel.queue(User.name ?? "");

    for (var role in User.roles) {
      var exchange = await channel.exchange(role, ExchangeType.FANOUT);
      queue.bind(exchange, "");
    }

    var consumer = await queue.consume();

    consumer.listen((message) {
      var data = jsonDecode(message.payloadAsString);
      var notification = hrms.Notification.fromJson(data);

      add(notification);
    });
  }
}
