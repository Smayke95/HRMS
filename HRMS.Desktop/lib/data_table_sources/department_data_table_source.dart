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
    departmentSearch.includeSupervisor = true;

    var _departments =
        await _departmentProvider.getAll(search: departmentSearch);

    return RemoteDataSourceDetails(
        _departments.totalCount, _departments.result);
  }

  @override
  DataRow? getRow(int index) {
    final currentRowData = lastDetails!.rows[index];
    return DataRow(
      onSelectChanged: (e) => {print('test')},
      cells: [
        DataCell(Text(currentRowData.id.toString())),
        DataCell(Text(currentRowData.name)),
        DataCell(Text("")),
        DataCell(Text("")),
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
