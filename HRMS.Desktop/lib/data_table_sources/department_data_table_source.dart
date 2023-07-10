import 'package:advanced_datatable/advanced_datatable_source.dart';
import 'package:flutter/material.dart';

import '../models/department.dart';
import '../models/searches/department_search.dart';
import '../providers/department_provider.dart';

class DepartmentDataTableSource extends AdvancedDataTableSource<Department> {
  final DepartmentProvider _departmentProvider;
  var departmentSearch = DepartmentSearch();

  DepartmentDataTableSource(this._departmentProvider);

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
    final currentRowData = lastDetails!.rows[index];
    return DataRow(
      onSelectChanged: (e) => {print('test')},
      cells: [
        DataCell(Text(currentRowData.name)),
        DataCell(Text(currentRowData.level.toString())),
        DataCell(Text(currentRowData.parentDepartment?.name ?? "")),
        DataCell(Text(
            "${currentRowData.supervisor?.firstName ?? ""} ${currentRowData.supervisor?.lastName ?? ""}")),
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
