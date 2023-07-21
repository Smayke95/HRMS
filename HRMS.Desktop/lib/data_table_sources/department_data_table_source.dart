import 'package:advanced_datatable/advanced_datatable_source.dart';
import 'package:flutter/material.dart';

import '../models/department.dart';
import '../models/searches/department_search.dart';
import '../providers/department_provider.dart';

class DepartmentDataTableSource extends AdvancedDataTableSource<Department> {
  final DepartmentProvider _departmentProvider;
  final Function(int) _onSelectChanged;

  var departmentSearch = DepartmentSearch();

  DepartmentDataTableSource(this._departmentProvider, this._onSelectChanged);

  @override
  Future<RemoteDataSourceDetails<Department>> getNextPage(
      NextPageRequest pageRequest) async {
    var page =
        (pageRequest.offset / pageRequest.pageSize).roundToDouble().ceil();

    departmentSearch.page = page + 1;
    departmentSearch.pageSize = pageRequest.pageSize;
    departmentSearch.includeParentDepartment = true;
    departmentSearch.includeSupervisor = true;

    var departments =
        await _departmentProvider.getAll(search: departmentSearch);

    return RemoteDataSourceDetails(departments.totalCount, departments.result);
  }

  @override
  DataRow? getRow(int index) {
    final currentRow = lastDetails!.rows[index];
    return DataRow(
      onSelectChanged: (e) => _onSelectChanged(currentRow.id),
      cells: [
        DataCell(Text(currentRow.name)),
        DataCell(Text(currentRow.level.toString())),
        DataCell(Text(currentRow.parentDepartment?.name ?? "")),
        DataCell(Text(
            "${currentRow.supervisor?.firstName ?? ""} ${currentRow.supervisor?.lastName ?? ""}")),
      ],
    );
  }

  @override
  int get selectedRowCount => 0;

  Future filterData(String? name) async {
    departmentSearch.name = name;
    setNextView();
  }
}
