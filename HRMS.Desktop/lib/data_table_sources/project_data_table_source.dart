import 'package:advanced_datatable/advanced_datatable_source.dart';
import 'package:flutter/material.dart';

import '../models/project.dart';
import '../models/searches/project_search.dart';
import '../providers/project_provider.dart';

class ProjectDataTableSource extends AdvancedDataTableSource<Project> {
  final ProjectProvider _projectProvider;
  final Function(int) _onSelectChanged;

  var projectSearch = ProjectSearch();

  ProjectDataTableSource(this._projectProvider, this._onSelectChanged);

  @override
  Future<RemoteDataSourceDetails<Project>> getNextPage(
      NextPageRequest pageRequest) async {
    var page =
        (pageRequest.offset / pageRequest.pageSize).roundToDouble().ceil();

    projectSearch.page = page + 1;
    projectSearch.pageSize = pageRequest.pageSize;

    var projects = 
        await _projectProvider.getAll(search: projectSearch);

    return RemoteDataSourceDetails(projects.totalCount, projects.result);
  }

  @override
  DataRow? getRow(int index) {
    final currentRow = lastDetails!.rows[index];
    return DataRow(
      onSelectChanged: (e) => _onSelectChanged(currentRow.id),
      cells: [
        DataCell(Text(currentRow.name)),
        DataCell(Text(currentRow.description))
      ],
    );
  }

  @override
  int get selectedRowCount => 0;

  Future filterData(String? name) async {
    projectSearch.name = name;
    setNextView();
  }
}
