import 'package:advanced_datatable/advanced_datatable_source.dart';
import 'package:flutter/material.dart';

import '../models/searches/task_type_search.dart';
import '../models/task_type.dart';
import '../providers/task_type_provider.dart';

class TaskTypeDataTableSource extends AdvancedDataTableSource<TaskType> {
  final TaskTypeProvider _taskStatusProvider;
  final Function(int) _onSelectChanged;

  var taskStatusSearch = TaskTypeSearch();

  TaskTypeDataTableSource(this._taskStatusProvider, this._onSelectChanged);

  @override
  Future<RemoteDataSourceDetails<TaskType>> getNextPage(
      NextPageRequest pageRequest) async {
    var page =
        (pageRequest.offset / pageRequest.pageSize).roundToDouble().ceil();

    taskStatusSearch.page = page + 1;
    taskStatusSearch.pageSize = pageRequest.pageSize;

    var taskTypes = await _taskStatusProvider.getAll(search: taskStatusSearch);

    return RemoteDataSourceDetails(taskTypes.totalCount, taskTypes.result);
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
