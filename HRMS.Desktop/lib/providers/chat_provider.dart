import 'package:signalr_netcore/signalr_client.dart';

import '../models/message.dart';
import '../models/requests/message_insert.dart';
import '../models/searches/message_search.dart';
import 'base_provider.dart';

class ChatProvider extends BaseProvider<Message, MessageSearch> {
  late String _baseUrl;
  late HubConnection hubConnection;

  ChatProvider() : super(endpoint: "chat") {
    _baseUrl = "${const String.fromEnvironment(
      "ApiUrl",
      defaultValue: "https://localhost:44378/",
    )}chatHub";
  }

  @override
  Message fromJson(data) => Message.fromJson(data);

  void connect(receiveMessageHandler) {
    hubConnection = HubConnectionBuilder().withUrl(_baseUrl).build();

    hubConnection.on('ReceiveMessage', receiveMessageHandler);
    hubConnection.start();
  }

  void sendMessage(MessageInsert message) {
    if (hubConnection.state == HubConnectionState.Connected) {
      hubConnection.invoke('SendMessage', args: [message]);
    } else {
      hubConnection.start();
    }
  }

  void disconnect() => hubConnection.stop();
}
