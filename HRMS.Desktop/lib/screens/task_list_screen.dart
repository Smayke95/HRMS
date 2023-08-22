import 'dart:convert';

import 'package:HRMS/models/employee.dart';
import 'package:advanced_datatable/datatable.dart';
import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:form_builder_validators/form_builder_validators.dart';
import 'package:intl/intl.dart';
import 'package:provider/provider.dart';

import '../data_table_sources/task_data_table_source.dart';
import '../models/paged_result.dart';
import '../models/project.dart';
import '../models/requests/task_comment_insert_update.dart';
import '../models/searches/task_comment_search.dart';
import '../models/task_comment.dart';
import '../models/task_status.dart';
import '../models/task_type.dart';
import '../models/user.dart';
import '../providers/employee_provider.dart';
import '../providers/project_provider.dart';
import '../providers/task_comment_provider.dart';
import '../providers/task_provider.dart';
import '../providers/task_status_provider.dart';
import '../providers/task_type_provider.dart';
import '../widgets/responsive.dart';
import '../widgets/search.dart';

class TaskListScreen extends StatefulWidget {
  const TaskListScreen({super.key});

  @override
  State<TaskListScreen> createState() => _TaskListScreenState();
}

class _TaskListScreenState extends State<TaskListScreen> {
  late EmployeeProvider _employeeProvider;
  late ProjectProvider _projectProvider;
  late TaskProvider _taskProvider;
  late TaskStatusProvider _taskStatusProvider;
  late TaskTypeProvider _taskTypeProvider;
  late TaskCommentProvider _taskCommentProvider;

  late TaskDataTableSource taskDataTableSource;

  final _formKey = GlobalKey<FormBuilderState>();
  final _formKeyTaskComment = GlobalKey<FormBuilderState>();
  var _projects = PagedResult<Project>();
  var _statuses = PagedResult<TaskStatus>();
  var _types = PagedResult<TaskType>();
  var _employees = PagedResult<Employee>();
  var _comments = PagedResult<TaskComment>();

  @override
  void initState() {
    super.initState();

    _employeeProvider = context.read<EmployeeProvider>();
    _projectProvider = context.read<ProjectProvider>();
    _taskProvider = context.read<TaskProvider>();
    _taskStatusProvider = context.read<TaskStatusProvider>();
    _taskTypeProvider = context.read<TaskTypeProvider>();
    _taskCommentProvider = context.read<TaskCommentProvider>();

    taskDataTableSource = TaskDataTableSource(_taskProvider, _openDialog);

    _loadData(null);
  }

  Future _loadData(int? id) async {
    var taskCommentSearch = TaskCommentSearch();
    taskCommentSearch.taskId = id;

    _employees = await _employeeProvider.getAll();
    _projects = await _projectProvider.getAll();
    _statuses = await _taskStatusProvider.getAll();
    _types = await _taskTypeProvider.getAll();
    _comments = await _taskCommentProvider.getAll(search: taskCommentSearch);

    if (id != null) {
      var task = await _taskProvider.get(id);

      _formKey.currentState?.patchValue({
        "name": task.name,
        "description": task.description,
        "projectId": task.project?.id.toString() ?? "0",
        "statusId": task.status?.id.toString() ?? "0",
        "typeId": task.type?.id.toString() ?? "0",
        "employeeId": task.employee?.id.toString() ?? "0",
      });

      var taskCommentInsertUpdate = TaskCommentInsertUpdate(
              DateTime.now(), "", id.toString(), User.id.toString())
          .toJson();

      _formKeyTaskComment.currentState?.patchValue(taskCommentInsertUpdate);
    }
  }

  void _openDialog(int? id) {
    if (Responsive.isMobile(context)) return;

    _loadData(id).then((data) {
      showDialog(
        context: context,
        builder: (BuildContext context) => _buildDialog(context, id),
      );
    });
  }

  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        Search(
          "Dodaj zadatak",
          () => _openDialog(null),
          onSearch: (text) => taskDataTableSource.filterData(text),
        ),
        SizedBox(
          width: double.infinity,
          child: AdvancedPaginatedDataTable(
            addEmptyRows: false,
            showCheckboxColumn: false,
            source: taskDataTableSource,
            rowsPerPage: 7,
            columns: const [
              DataColumn(label: Text("Naziv")),
              DataColumn(label: Text("Opis")),
              DataColumn(label: Text("Projekat")),
              DataColumn(label: Text("Status")),
              DataColumn(label: Text("Tip")),
              DataColumn(label: Text("Zaposlenik"))
            ],
          ),
        ),
      ],
    );
  }

  Widget _buildDialog(BuildContext context, int? id) {
    _loadData(id);

    return AlertDialog(
      title: Align(
        alignment: Alignment.center,
        child: Row(
          mainAxisSize: MainAxisSize.min,
          children: [
            Icon(id == null ? Icons.add : Icons.edit),
            const SizedBox(width: 10),
            Text(id == null ? "Dodaj zadatak" : "Uredi zadatak"),
          ],
        ),
      ),
      content: SingleChildScrollView(
        child: FormBuilder(
          key: _formKey,
          child: SizedBox(
            child: Column(
              children: [
                Row(
                  children: [
                    SizedBox(
                      width: 600,
                      child: FormBuilderTextField(
                        name: "name",
                        decoration: const InputDecoration(labelText: "Naziv *"),
                        validator: FormBuilderValidators.required(
                            errorText: "Naziv je obavezan."),
                      ),
                    )
                  ],
                ),
                const SizedBox(height: 20),
                Row(
                  children: [
                    SizedBox(
                      width: 600,
                      child: FormBuilderTextField(
                          name: "description",
                          keyboardType: TextInputType.multiline,
                          maxLines: null,
                          decoration: const InputDecoration(labelText: "Opis")),
                    ),
                  ],
                ),
                const SizedBox(height: 20),
                Row(
                  children: [
                    SizedBox(
                      width: 300,
                      child: FormBuilderDropdown(
                        name: "projectId",
                        decoration:
                            const InputDecoration(labelText: "Projekat *"),
                        validator: FormBuilderValidators.required(
                            errorText: "Projekat je obavezan."),
                        items: _projects.result
                            .map((project) => DropdownMenuItem(
                                  value: project.id.toString(),
                                  child: Text(project.name),
                                ))
                            .toList(),
                      ),
                    ),
                    const SizedBox(width: 20),
                    SizedBox(
                      width: 300,
                      child: FormBuilderDropdown(
                        name: "statusId",
                        decoration:
                            const InputDecoration(labelText: "Status *"),
                        validator: FormBuilderValidators.required(
                            errorText: "Status zadatka je obavezan."),
                        items: _statuses.result
                            .map((status) => DropdownMenuItem(
                                  value: status.id.toString(),
                                  child: Text(status.name),
                                ))
                            .toList(),
                      ),
                    ),
                  ],
                ),
                const SizedBox(height: 20),
                Row(
                  children: [
                    SizedBox(
                      width: 300,
                      child: FormBuilderDropdown(
                        name: "typeId",
                        decoration: const InputDecoration(labelText: "Tip *"),
                        validator: FormBuilderValidators.required(
                            errorText: "Tip zadatka je obavezan."),
                        items: _types.result
                            .map((type) => DropdownMenuItem(
                                  value: type.id.toString(),
                                  child: Text(type.name),
                                ))
                            .toList(),
                      ),
                    ),
                    const SizedBox(width: 20),
                    SizedBox(
                      width: 300,
                      child: FormBuilderDropdown(
                        name: "employeeId",
                        decoration:
                            const InputDecoration(labelText: "Zaposlenik *"),
                        validator: FormBuilderValidators.required(
                            errorText: "Zaposlenik je obavezan."),
                        items: _employees.result
                            .map((employee) => DropdownMenuItem(
                                  value: employee.id.toString(),
                                  child: Text(
                                      "${employee.firstName} ${employee.lastName}"),
                                ))
                            .toList(),
                      ),
                    ),
                  ],
                ),
                const SizedBox(height: 30),
                Column(
                  children: _buildCommentWidgets(),
                ),
              ],
            ),
          ),
        ),
      ),
      actionsPadding: const EdgeInsets.all(20),
      buttonPadding: const EdgeInsets.all(20),
      actions: [
        if (id != null)
          OutlinedButton(
            style: ButtonStyle(
              foregroundColor: MaterialStateProperty.all(Colors.red),
              padding: const MaterialStatePropertyAll(
                EdgeInsets.only(left: 40, top: 20, right: 40, bottom: 20),
              ),
            ),
            child: const Text("OBRIŠI"),
            onPressed: () async {
              await _taskProvider.delete(id);
              taskDataTableSource.filterData(null);
              if (context.mounted) Navigator.pop(context);
            },
          ),
        const SizedBox(width: 185),
        OutlinedButton(
          style: const ButtonStyle(
            padding: MaterialStatePropertyAll(
              EdgeInsets.only(left: 40, top: 20, right: 40, bottom: 20),
            ),
          ),
          child: const Text("NAZAD"),
          onPressed: () => Navigator.pop(context),
        ),
        OutlinedButton(
          style: const ButtonStyle(
            padding: MaterialStatePropertyAll(
              EdgeInsets.only(left: 40, top: 20, right: 40, bottom: 20),
            ),
          ),
          child: const Text("SPREMI"),
          onPressed: () async {
            var isValid = _formKey.currentState?.saveAndValidate();

            if (isValid!) {
              var request = Map.from(_formKey.currentState!.value);

              id == null
                  ? await _taskProvider.insert(request)
                  : await _taskProvider.update(id, request);

              taskDataTableSource.filterData(null);
              if (context.mounted) Navigator.pop(context);
            }
          },
        ),
      ],
    );
  }

  List<Widget> _buildCommentWidgets() {
    List<Widget> commentWidgets = [];

    commentWidgets.add(const Text(
      "Komentari",
      style: TextStyle(fontWeight: FontWeight.bold),
      textAlign: TextAlign.left,
    ));

    for (var i = 0; i < _comments.totalCount; i++) {
      var comment = _comments.result[i];

      commentWidgets.add(
        Container(
          margin: const EdgeInsets.symmetric(vertical: 8.0),
          padding: const EdgeInsets.all(8.0),
          decoration: BoxDecoration(
            border: Border.all(color: Colors.grey),
            borderRadius: BorderRadius.circular(8.0),
          ),
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              Row(
                children: [
                  ClipRRect(
                    borderRadius: BorderRadius.circular(20),
                    child: SizedBox.fromSize(
                      size: const Size.fromRadius(20),
                      child: comment.employee!.image != ""
                          ? Image.memory(
                              base64Decode(comment.employee!.image),
                              width: 300,
                              fit: BoxFit.cover,
                            )
                          : Image.asset(
                              "assets/images/default-avatar.png",
                              width: 300,
                              height: 300,
                            ),
                    ),
                  ),
                  const SizedBox(width: 8.0),
                  Text(
                    "${comment.employee!.firstName} ${comment.employee!.lastName}",
                    style: const TextStyle(
                      fontWeight: FontWeight.bold,
                    ),
                  ),
                  const Spacer(),
                  IconButton(
                    icon: const Icon(Icons.delete, color: Colors.red),
                    onPressed: () async {
                      await _taskCommentProvider.delete(comment.id);
                      if (context.mounted) Navigator.pop(context);
                    },
                  ),
                ],
              ),
              const SizedBox(height: 4.0),
              Text(
                DateFormat('dd.MM.yyyy. HH:mm').format(comment.time),
                style: const TextStyle(
                  color: Colors.grey,
                  fontSize: 12.0,
                ),
              ),
              const SizedBox(height: 8.0),
              Text(
                comment.content,
              ),
            ],
          ),
        ),
      );
    }

    commentWidgets.add(
      Container(
        margin: const EdgeInsets.symmetric(vertical: 8.0),
        padding: const EdgeInsets.all(8.0),
        decoration: BoxDecoration(
          border: Border.all(color: Colors.grey),
          borderRadius: BorderRadius.circular(8.0),
        ),
        child: FormBuilder(
          key: _formKeyTaskComment,
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              FormBuilderField(
                name: 'employeeId',
                builder: (FormFieldState<dynamic> field) {
                  return Text(
                    User.name!,
                    style: const TextStyle(
                      fontWeight: FontWeight.bold,
                    ),
                  );
                },
              ),
              FormBuilderField(
                name: 'time',
                builder: (FormFieldState<dynamic> field) {
                  return const SizedBox.shrink();
                },
              ),
              FormBuilderField(
                name: 'taskId',
                builder: (FormFieldState<dynamic> field) {
                  return const SizedBox.shrink();
                },
              ),
              const SizedBox(height: 4.0),
              FormBuilderTextField(
                name: 'content',
                decoration: const InputDecoration(
                  hintText: "Unesite komentar...",
                ),
                validator: FormBuilderValidators.required(
                    errorText: "Komentar je obavezan."),
              ),
              const SizedBox(height: 8.0),
              Row(
                mainAxisAlignment: MainAxisAlignment.spaceBetween,
                children: [
                  Expanded(
                    child: Container(),
                  ),
                  OutlinedButton(
                    style: const ButtonStyle(
                      padding: MaterialStatePropertyAll(
                        EdgeInsets.only(
                            left: 20, top: 10, right: 20, bottom: 10),
                      ),
                    ),
                    child: const Text("SPREMI"),
                    onPressed: () async {
                      var isValid =
                          _formKeyTaskComment.currentState?.saveAndValidate();

                      if (isValid!) {
                        var request =
                            Map.from(_formKeyTaskComment.currentState!.value);

                        await _taskCommentProvider.insert(request);

                        if (context.mounted) Navigator.pop(context);
                      }
                    },
                  ),
                ],
              ),
            ],
          ),
        ),
      ),
    );

    return commentWidgets;
  }
}
