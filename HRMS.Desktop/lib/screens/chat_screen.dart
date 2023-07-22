import 'package:HRMS/models/employee.dart';
import 'package:flutter/material.dart';
import 'package:grouped_list/grouped_list.dart';
import 'package:intl/intl.dart';
import 'package:provider/provider.dart';

import '../models/message.dart';
import '../models/paged_result.dart';
import '../models/searches/message_search.dart';
import '../models/user.dart';
import '../providers/chat_provider.dart';

class ChatScreen extends StatefulWidget {
  const ChatScreen({super.key});

  @override
  State<ChatScreen> createState() => _ChatScreenState();
}

class _ChatScreenState extends State<ChatScreen> {
  late ChatProvider _chatProvider;
  var _messages = PagedResult<Message>();

  final _messageController = TextEditingController();

  @override
  void initState() {
    super.initState();

    _chatProvider = context.read<ChatProvider>();
    _chatProvider.connect(receiveMessageHandler);

    _loadData();
  }

  @override
  void dispose() {
    _chatProvider.disconnect();
    super.dispose();
  }

  Future _loadData() async {
    var messageSearch = MessageSearch();
    messageSearch.room = "soba";

    _messages = await _chatProvider.getAll(search: messageSearch);
    setState(() {});
  }

  receiveMessageHandler(args) {
    print(args[1]);
    setState(() {});
  }

  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        SizedBox(
          height: 450,
          child: GroupedListView<Message, DateTime>(
            padding: const EdgeInsets.all(8),
            useStickyGroupSeparators: true,
            floatingHeader: true,
            elements: _messages.result,
            groupBy: (message) => DateTime(
              message.time.year,
              message.time.month,
              message.time.day,
            ),
            groupHeaderBuilder: (Message message) => SizedBox(
              height: 40,
              child: Card(
                color: Theme.of(context).primaryColor,
                child: Padding(
                  padding: const EdgeInsets.all(8),
                  child: Text(
                    DateFormat.yMMMd().format(message.time),
                    style: const TextStyle(color: Colors.white),
                  ),
                ),
              ),
            ),
            itemBuilder: (context, Message message) => Align(
              alignment: message.employeeId == User.id
                  ? Alignment.centerRight
                  : Alignment.centerLeft,
              child: Card(
                elevation: 8,
                child: Padding(
                  padding: const EdgeInsets.all(12),
                  child: Text(message.text),
                ),
              ),
            ),
          ),
        ),
        Container(
          color: Colors.grey.shade300,
          child: Row(
            children: [
              Expanded(
                child: TextField(
                  decoration: const InputDecoration(
                    contentPadding: EdgeInsets.all(12),
                    hintText: "Unesite poruku...",
                  ),
                  controller: _messageController,
                ),
              ),
              IconButton(
                icon: const Icon(Icons.send),
                onPressed: () => {
                  _chatProvider.sendMessage(Message(
                    _messageController.text,
                    DateTime.now(),
                    "soba",
                    User.id ?? 0,
                    null
                  ))
                },
              )
            ],
          ),
        )
      ],
    );
  }
}
