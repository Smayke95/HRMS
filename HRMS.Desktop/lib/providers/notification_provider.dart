import 'package:dart_amqp/dart_amqp.dart';
import 'package:flutter/material.dart';

class NotificationProvider with ChangeNotifier {
  Future listen() async {
    var client = Client();

    var channel = await client.channel();
    var queue = await channel.queue("hello");
    var consumer = await queue.consume();

    consumer.listen((message) {
      print(" [x] Received string: ${message.payloadAsString}");
    });
  }
}
