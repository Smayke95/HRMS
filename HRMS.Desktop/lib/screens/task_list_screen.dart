import 'package:advanced_datatable/datatable.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

import '../data_table_sources/task_data_table_source.dart';
import '../providers/task_provider.dart';
import '../widgets/search.dart';

class TaskListScreen extends StatefulWidget {
  const TaskListScreen({super.key});

  @override
  State<TaskListScreen> createState() => _TaskListScreenState();
}

class _TaskListScreenState extends State<TaskListScreen> {
  late TaskDataTableSource taskDataTableSource;

  @override
  void initState() {
    super.initState();

    var taskProvider = context.read<TaskProvider>();
    taskDataTableSource = TaskDataTableSource(taskProvider);
  }

  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        Search(
          "Dodaj zadatak",
           () => {},   
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
}
