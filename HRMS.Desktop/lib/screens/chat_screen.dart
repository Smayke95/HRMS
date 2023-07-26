import 'package:HRMS/widgets/responsive.dart';
import 'package:flutter/material.dart';
import 'package:grouped_list/grouped_list.dart';
import 'package:intl/intl.dart';
import 'package:provider/provider.dart';

import '../models/employee.dart';
import '../models/message.dart';
import '../models/paged_result.dart';
import '../models/requests/message_insert.dart';
import '../models/searches/employee_search.dart';
import '../models/searches/message_search.dart';
import '../models/user.dart';
import '../providers/chat_provider.dart';
import '../providers/employee_provider.dart';

class ChatScreen extends StatefulWidget {
  const ChatScreen({super.key});

  @override
  State<ChatScreen> createState() => _ChatScreenState();
}

class _ChatScreenState extends State<ChatScreen> {
  late ChatProvider _chatProvider;
  late EmployeeProvider _employeeProvider;

  var _room = "";
  var _typing = "";
  var _messageFocusNode = FocusNode();
  var _messages = PagedResult<Message>();
  var _employees = PagedResult<Employee>();

  final _messageController = TextEditingController();

  @override
  void initState() {
    super.initState();

    _room = "Anes Smajić & Irena Vilić";

    _chatProvider = context.read<ChatProvider>();
    _chatProvider.connect(receiveMessageHandler, receiveUserTypingHandler);
    _employeeProvider = context.read<EmployeeProvider>();

    _loadData();
  }

  @override
  void dispose() {
    _chatProvider.disconnect();
    super.dispose();
  }

  Future _loadData() async {
    var employeeSearch = EmployeeSearch();
    _employees = await _employeeProvider.getAll(search: employeeSearch);
    _employees.result.removeWhere((x) => x.id == User.id);
    _employees.result.sort((a, b) => a.firstName.compareTo(b.firstName));

    var messageSearch = MessageSearch();
    messageSearch.pageSize = 50;
    messageSearch.room = _room;
    messageSearch.includeEmployee = true;

    _messages = await _chatProvider.getAll(search: messageSearch);
    _chatProvider.joinRoom(_room);

    setState(() {});
  }

  changeRoom(Employee selectedEmployee) {
    if (selectedEmployee.id > User.id!) {
      _room =
          "${User.name!} & ${selectedEmployee.firstName} ${selectedEmployee.lastName}";
    } else {
      _room =
          "${selectedEmployee.firstName} ${selectedEmployee.lastName} & ${User.name!}";
    }

    _loadData();
  }

  receiveMessageHandler(args) {
    var message = Message.fromJson(args[0]);
    _messages.result.add(message);
    setState(() {});
  }

  receiveUserTypingHandler(args) async {
    var employeeId = args[1] as int;
    var employeeName = args[2];

    if (employeeId != User.id!) {
      _typing = "••• $employeeName piše";
      setState(() {});

      await Future.delayed(const Duration(seconds: 3));
      _typing = "";
      setState(() {});
    }
  }

  @override
  Widget build(BuildContext context) {
    return LayoutBuilder(
      builder: (context, constraints) {
        if (Responsive.isMobile(context)) {
          return SingleChildScrollView(
            child: Column(
              children: [
                _buildEmployeeList(context),
                const SizedBox(height: 10),
                _buildChat(context),
              ],
            ),
          );
        } else {
          return Row(
            children: [
              Expanded(
                child: _buildChat(context),
              ),
              _buildEmployeeList(context),
            ],
          );
        }
      },
    );
  }

  Widget _buildChat(BuildContext context) {
    return Column(
      children: [
        if (Responsive.isMobile(context))
          SizedBox(
            height: 500,
            child: _buildChatListView(context),
          )
        else
          Expanded(
            child: _buildChatListView(context),
          ),
        Align(
          alignment: Alignment.centerLeft,
          child: Padding(
            padding: const EdgeInsets.all(8.0),
            child: Text(_typing),
          ),
        ),
        Card(
          clipBehavior: Clip.hardEdge,
          shape: BeveledRectangleBorder(borderRadius: BorderRadius.circular(5)),
          child: Container(
            height: 60,
            color: Colors.white,
            child: Row(
              children: [
                Expanded(
                  child: TextField(
                    decoration: const InputDecoration(
                      contentPadding: EdgeInsets.all(12),
                      hintText: "Unesite poruku...",
                      border: InputBorder.none,
                    ),
                    autofocus: true,
                    focusNode: _messageFocusNode,
                    controller: _messageController,
                    onChanged: (value) => _chatProvider.userTyping(
                      _room,
                      User.id!,
                      User.name!,
                    ),
                    onSubmitted: (value) {
                      _chatProvider.sendMessage(
                        MessageInsert(
                          _messageController.text,
                          _room,
                          User.id!,
                        ),
                      );

                      _messageController.text = "";
                      FocusScope.of(context).requestFocus(_messageFocusNode);
                    },
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
          ),
        )
      ],
    );
  }

  Widget _buildChatListView(BuildContext context) {
    return GroupedListView<Message, DateTime>(
      padding: const EdgeInsets.all(8),
      reverse: true,
      order: GroupedListOrder.DESC,
      elements: _messages.result,
      groupBy: (message) => DateTime(
        message.time.year,
        message.time.month,
        message.time.day,
      ),
      groupHeaderBuilder: (Message message) =>
          _buildMessageGroupHeader(context, message),
      itemComparator: (e1, e2) => e1.time.compareTo(e2.time),
      itemBuilder: (context, Message message) =>
          _buildMessage(context, message),
    );
  }

  Widget _buildMessageGroupHeader(BuildContext context, Message message) {
    return Align(
      alignment: Alignment.center,
      child: Padding(
        padding: const EdgeInsets.all(8),
        child: Text(
          DateFormat.yMMMd().format(message.time),
          style: const TextStyle(color: Colors.grey),
        ),
      ),
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

  Widget _buildEmployeeList(BuildContext context) {
    return SizedBox(
      width: Responsive.isMobile(context) ? double.infinity : 300,
      height: Responsive.isMobile(context) ? 200 : double.infinity,
      child: Card(
        child: ListView(
          shrinkWrap: true,
          padding: const EdgeInsets.all(8),
          children: _employees.result
              .map(
                (employee) => ListTile(
                  selected: true,
                  title: Text("${employee.firstName} ${employee.lastName}"),
                  onTap: () => changeRoom(employee),
                ),
              )
              .toList(),
        ),
      ),
    );
  }
}
