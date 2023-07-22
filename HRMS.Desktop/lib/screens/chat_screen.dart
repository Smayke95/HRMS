import 'package:HRMS/models/requests/message_insert.dart';
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
  var _room = "";
  var _messages = PagedResult<Message>();

  final _messageController = TextEditingController();

  @override
  void initState() {
    super.initState();

    _room = "AnesSmajicIrenaVilic"; //TODO dynamic set

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
    messageSearch.pageSize = 50;
    messageSearch.room = _room;
    messageSearch.includeEmployee = true;

    _messages = await _chatProvider.getAll(search: messageSearch);
    setState(() {});

    for (var message in _messages.result) {
      print(message.text);
    }
  }

  receiveMessageHandler(args) {
    print("Received");
    print(args[0]);

    var message = Message.fromJson(args[0]);
    _messages.result.add(message);

    print(_messages.result);

    setState(() {});
  }

  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        SizedBox(
          height: 750,
          child: GroupedListView<Message, DateTime>(
            padding: const EdgeInsets.all(8),
            useStickyGroupSeparators: true,
            floatingHeader: true,
            reverse: true,
            order: GroupedListOrder.DESC,
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
            itemComparator: (e1, e2) => e1.time.compareTo(e2.time),
            itemBuilder: (context, Message message) =>
                _buildMessage(context, message),
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
                onPressed: () {
                  _chatProvider.sendMessage(
                    MessageInsert(
                      _messageController.text,
                      _room,
                      User.id!,
                    ),
                  );

                  _messageController.text = "";
                },
              )
            ],
          ),
        )
      ],
    );
  }

  Widget _buildMessage(BuildContext context, Message message) {
    return Align(
      alignment: message.employee!.id == User.id
          ? Alignment.centerRight
          : Alignment.centerLeft,
      child: Card(
        clipBehavior: Clip.hardEdge,
        shape: RoundedRectangleBorder(
          borderRadius: BorderRadius.only(
            topLeft: Radius.circular(message.employee!.id == User.id ? 10 : 0),
            topRight: const Radius.circular(10.0),
            bottomLeft: const Radius.circular(10),
            bottomRight:
                Radius.circular(message.employee!.id == User.id ? 0 : 10),
          ),
        ),
        elevation: 2,
        child: Container(
          color: message.employee!.id == User.id
              ? Theme.of(context).primaryColor
              : Colors.white,
          child: Padding(
            padding: const EdgeInsets.all(12),
            child: Text(
              message.text,
              style: TextStyle(
                  color: message.employee!.id == User.id
                      ? Colors.white
                      : Colors.black),
            ),
          ),
        ),
      ),
    );
  }
}
