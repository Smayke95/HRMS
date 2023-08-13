import 'package:signalr_netcore/signalr_client.dart';

import '../models/message.dart';
import '../models/requests/message_insert.dart';
import '../models/searches/message_search.dart';
import 'base_provider.dart';

class ChatProvider extends BaseProvider<Message, MessageSearch> {
  late String _baseUrl;
  late HubConnection hubConnection;

  ChatProvider() : super(altEndpoint: "chat") {
    _baseUrl = "${const String.fromEnvironment(
      "ApiUrl",
      defaultValue: "https://localhost:44300/",
    )}chatHub";
  }

  @override
  Message fromJson(data) => Message.fromJson(data);

  Future connect(receiveMessageHandler, receiveUserTypingHandler) async {
    hubConnection = HubConnectionBuilder().withUrl(_baseUrl).build();

    hubConnection.on("ReceiveMessage", receiveMessageHandler);
    hubConnection.on("UserTyping", receiveUserTypingHandler);
    await hubConnection.start();
  }

  Future joinRoom(String room) async {
    if (hubConnection.state == HubConnectionState.Connected) {
      await hubConnection.invoke('JoinRoom', args: [room]);
    } else {
      await hubConnection.start();
    }
  }

  void sendMessage(MessageInsert message) {
    if (hubConnection.state == HubConnectionState.Connected) {
      hubConnection.invoke('SendMessage', args: [message]);
    } else {
      hubConnection.start();
    }
  }

  void userTyping(String room, int employeeId, String employeeName) {
    if (hubConnection.state == HubConnectionState.Connected) {
      hubConnection
          .invoke('UserTyping', args: [room, employeeId, employeeName]);
    } else {
      hubConnection.start();
    }
  }

  void disconnect() => hubConnection.stop();
}
