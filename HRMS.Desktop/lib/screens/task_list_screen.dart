import 'package:HRMS/models/employee.dart';
import 'package:advanced_datatable/datatable.dart';
import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:form_builder_validators/form_builder_validators.dart';
import 'package:provider/provider.dart';

import '../data_table_sources/task_data_table_source.dart';
import '../models/paged_result.dart';
import '../models/project.dart';
import '../models/task.dart';
import '../models/task_status.dart';
import '../models/task_type.dart';
import '../providers/employee_provider.dart';
import '../providers/project_provider.dart';
import '../providers/task_provider.dart';
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

  late TaskDataTableSource taskDataTableSource;

  final _formKey = GlobalKey<FormBuilderState>();
  var _tasks = PagedResult<Task>();
  var _projects = PagedResult<Project>();
  var _statuses = PagedResult<TaskStatus>();
  var _types = PagedResult<TaskType>();
  var _employees = PagedResult<Employee>();

  @override
  void initState() {
    super.initState();

    _employeeProvider = context.read<EmployeeProvider>();
    _projectProvider = context.read<ProjectProvider>();
    _taskProvider = context.read<TaskProvider>();

    taskDataTableSource = TaskDataTableSource(_taskProvider, _openDialog);

    _loadData(null);
  }

  Future _loadData(int? id) async {
    _employees = await _employeeProvider.getAll();
    _tasks = await _taskProvider.getAll();
    _projects = await _projectProvider.getAll();

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
    }
  }

  void _openDialog(int? id) {
    if (Responsive.isMobile(context)) return;

    showDialog(
      context: context,
      builder: (BuildContext context) => _buildDialog(context, id),
    );
  }

  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        Search(
          "Dodaj odjel",
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
      content: FormBuilder(
        key: _formKey,
        child: SizedBox(
          height: 450,
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
                      decoration: const InputDecoration(labelText: "Opis *"),
                      validator: FormBuilderValidators.required(
                          errorText: "Opis je obavezan."),
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
                      decoration: const InputDecoration(labelText: "Status *"),
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
            ],
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
}
