import 'package:advanced_datatable/datatable.dart';
import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:form_builder_validators/form_builder_validators.dart';
import 'package:provider/provider.dart';

import '../data_table_sources/task_type_data_table_source.dart';
import '../providers/task_type_provider.dart';
import '../widgets/responsive.dart';
import '../widgets/search.dart';

class TaskTypeListScreen extends StatefulWidget {
  const TaskTypeListScreen({super.key});

  @override
  State<TaskTypeListScreen> createState() => _TaskTypeListScreenState();
}

class _TaskTypeListScreenState extends State<TaskTypeListScreen> {
  late TaskTypeProvider _taskTypeProvider;

  late TaskTypeDataTableSource taskTypeDataTableSource;

  final _formKey = GlobalKey<FormBuilderState>();

  @override
  void initState() {
    super.initState();

    _taskTypeProvider = context.read<TaskTypeProvider>();

    taskTypeDataTableSource =
        TaskTypeDataTableSource(_taskTypeProvider, _openDialog);

    _loadData(null);
  }

  Future _loadData(int? id) async {    

    if (id != null) {
      var taskType = await _taskTypeProvider.get(id);

      _formKey.currentState?.patchValue({"name": taskType.name});
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
          onSearch: (text) => taskTypeDataTableSource.filterData(text)
        ),
        SizedBox(
          width: double.infinity,
          child: AdvancedPaginatedDataTable(
            addEmptyRows: false,
            showCheckboxColumn: false,
            source: taskTypeDataTableSource,
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
            Text(id == null ? "Dodaj tip" : "Uredi tip"),
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
              await _taskTypeProvider.delete(id);
              taskTypeDataTableSource.filterData(null);
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
                  ? await _taskTypeProvider.insert(request)
                  : await _taskTypeProvider.update(id, request);

              taskTypeDataTableSource.filterData(null);
              if (context.mounted) Navigator.pop(context);
            }
          },
        ),
      ],
    );
  }
}
