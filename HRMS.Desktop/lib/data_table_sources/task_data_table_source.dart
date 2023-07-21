import 'package:advanced_datatable/advanced_datatable_source.dart';
import 'package:flutter/material.dart';

import '../models/task.dart';
import '../providers/task_provider.dart';

class TaskDataTableSource extends AdvancedDataTableSource<Task> {
  final TaskProvider _taskProvider; 

  TaskDataTableSource(this._taskProvider);

  @override
  Future<RemoteDataSourceDetails<Task>> getNextPage(
      NextPageRequest pageRequest) async {
    var page =
        (pageRequest.offset / pageRequest.pageSize).roundToDouble().ceil();

    var tasks = await _taskProvider.getAll();

    return RemoteDataSourceDetails(tasks.totalCount, tasks.result);
  }

  @override
  DataRow? getRow(int index) {
    final currentRowData = lastDetails!.rows[index];
    return DataRow(
      onSelectChanged: (e) => {print('test')},
      cells: [       
        DataCell(Text(currentRowData.name)),
        DataCell(Text(currentRowData.description)),
        DataCell(Text(currentRowData.project?.name ?? "")),
        DataCell(Text(currentRowData.status?.name ?? "")),
        DataCell(Text(currentRowData.type?.name ?? "")),
        DataCell(Text("${currentRowData.employee?.firstName ?? ""} ${currentRowData.employee?.lastName ?? ""}"))
      ],
    );
  }

  @override
  int get selectedRowCount => 0;
}
