import 'dart:convert';

import 'package:dart_amqp/dart_amqp.dart';
import 'package:flutter/material.dart';

import '../models/notification.dart' as hrms;
import '../models/user.dart';

class NotificationProvider with ChangeNotifier {
  Future listen(Function(hrms.Notification) add) async {
    var connectionSettings = ConnectionSettings(
      host: const String.fromEnvironment(
        "RabbitMQ:Host",
        defaultValue: "localhost",
      ),
      port: int.parse(
        const String.fromEnvironment(
          "RabbitMQ:Port",
          defaultValue: "5672",
        ),
      ),
      authProvider: const PlainAuthenticator(
        String.fromEnvironment(
          "RabbitMQ:User",
          defaultValue: "admin",
        ),
        String.fromEnvironment(
          "RabbitMQ:Password",
          defaultValue: "admin",
        ),
      ),
    );

    var client = Client(settings: connectionSettings);

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
