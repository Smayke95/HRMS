import 'package:advanced_datatable/advanced_datatable_source.dart';
import 'package:flutter/material.dart';

import '../models/searches/task_search.dart';
import '../models/task.dart';
import '../providers/task_provider.dart';

class TaskDataTableSource extends AdvancedDataTableSource<Task> {
  final TaskProvider _taskProvider;
  final Function(int) _onSelectChanged;

  var taskSearch = TaskSearch();

  TaskDataTableSource(this._taskProvider, this._onSelectChanged);

  @override
  Future<RemoteDataSourceDetails<Task>> getNextPage(
      NextPageRequest pageRequest) async {
    var page =
        (pageRequest.offset / pageRequest.pageSize).roundToDouble().ceil();

    taskSearch.page = page + 1;
    taskSearch.pageSize = pageRequest.pageSize;
    taskSearch.includeEmployee = true;
    taskSearch.includeProject = true;
    taskSearch.includeStatus = true;
    taskSearch.includeType = true;

    var tasks = await _taskProvider.getAll(search: taskSearch);

    return RemoteDataSourceDetails(tasks.totalCount, tasks.result);
  }

  @override
  DataRow? getRow(int index) {
    final currentRow = lastDetails!.rows[index];
    return DataRow(
      onSelectChanged: (e) => _onSelectChanged(currentRow.id),
      cells: [
        DataCell(Text(currentRow.name)),
        DataCell(Text(currentRow.description)),
        DataCell(Text(currentRow.project?.name ?? "")),
        DataCell(Text(currentRow.status?.name ?? "")),
        DataCell(Text(currentRow.type?.name ?? "")),
        DataCell(Text(
            "${currentRow.employee?.firstName ?? ""} ${currentRow.employee?.lastName ?? ""}"))
      ],
    );
  }

  @override
  int get selectedRowCount => 0;

  Future filterData(String? name) async {
    taskSearch.name = name;
    setNextView();
  }
}
