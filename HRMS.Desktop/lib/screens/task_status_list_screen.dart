import 'package:advanced_datatable/datatable.dart';
import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:form_builder_validators/form_builder_validators.dart';
import 'package:provider/provider.dart';

import '../data_table_sources/task_status_data_table_source.dart';
import '../providers/task_status_provider.dart';
import '../widgets/responsive.dart';
import '../widgets/search.dart';

class TaskStatusListScreen extends StatefulWidget {
  const TaskStatusListScreen({super.key});

  @override
  State<TaskStatusListScreen> createState() => _TaskStatusListScreenState();
}

class _TaskStatusListScreenState extends State<TaskStatusListScreen> {
  late TaskStatusProvider _taskStatusProvider;

  late TaskStatusDataTableSource taskStatusDataTableSource;

  final _formKey = GlobalKey<FormBuilderState>();

  @override
  void initState() {
    super.initState();

    _taskStatusProvider = context.read<TaskStatusProvider>();

    taskStatusDataTableSource =
        TaskStatusDataTableSource(_taskStatusProvider, _openDialog);

    _loadData(null);
  }

  Future _loadData(int? id) async {    

    if (id != null) {
      var taskStatus = await _taskStatusProvider.get(id);

      _formKey.currentState?.patchValue({"name": taskStatus.name});
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
          "Dodaj status", 
          () => _openDialog(null),
          onSearch: (text) => taskStatusDataTableSource.filterData(text)
        ),
        SizedBox(
          width: double.infinity,
          child: AdvancedPaginatedDataTable(
            addEmptyRows: false,
            showCheckboxColumn: false,
            source: taskStatusDataTableSource,
            rowsPerPage: 7,
            columns: const [
              DataColumn(label: Text("Naziv"))            
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
            Text(id == null ? "Dodaj status" : "Uredi status"),
          ],
        ),
      ),
      content: FormBuilder(
        key: _formKey,
        child: SizedBox(
          height: 300,
          child: Column(
            children: [
              Row(
                children: [
                  SizedBox(
                    width: 500,
                    child: FormBuilderTextField(
                      name: "name",
                      decoration: const InputDecoration(labelText: "Naziv *"),
                      validator: FormBuilderValidators.required(
                          errorText: "Naziv je obavezan."),
                    ),
                  )
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
              await _taskStatusProvider.delete(id);
              taskStatusDataTableSource.filterData(null);
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
                  ? await _taskStatusProvider.insert(request)
                  : await _taskStatusProvider.update(id, request);

              taskStatusDataTableSource.filterData(null);
              if (context.mounted) Navigator.pop(context);
            }
          },
        ),
      ],
    );
  }
}
