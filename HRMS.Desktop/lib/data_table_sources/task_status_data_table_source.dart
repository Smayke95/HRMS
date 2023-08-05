import 'package:advanced_datatable/advanced_datatable_source.dart';
import 'package:flutter/material.dart';

import '../models/searches/task_status_search.dart';
import '../models/task_status.dart';
import '../providers/task_status_provider.dart';

class TaskStatusDataTableSource extends AdvancedDataTableSource<TaskStatus> {
  final TaskStatusProvider _taskStatusProvider;
  final Function(int) _onSelectChanged;

  var taskStatusSearch = TaskStatusSearch();

  TaskStatusDataTableSource(this._taskStatusProvider, this._onSelectChanged);

  @override
  Future<RemoteDataSourceDetails<TaskStatus>> getNextPage(
      NextPageRequest pageRequest) async {
    var page =
        (pageRequest.offset / pageRequest.pageSize).roundToDouble().ceil();

    taskStatusSearch.page = page + 1;
    taskStatusSearch.pageSize = pageRequest.pageSize;

    var taskStatuses = await _taskStatusProvider.getAll(search: taskStatusSearch);

    return RemoteDataSourceDetails(taskStatuses.totalCount, taskStatuses.result);
  }

  @override
  DataRow? getRow(int index) {
    final currentRow = lastDetails!.rows[index];
    return DataRow(
      onSelectChanged: (e) => _onSelectChanged(currentRow.id),
      cells: [
        DataCell(Text(currentRow.name)),   
      ],
    );
  }

  @override
  int get selectedRowCount => 0;

  Future filterData(String? name) async {
    taskStatusSearch.name = name;
    setNextView();
  }
}
