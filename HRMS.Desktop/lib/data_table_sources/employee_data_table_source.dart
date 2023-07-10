import 'package:advanced_datatable/advanced_datatable_source.dart';
import 'package:flutter/material.dart';

import '../models/employee.dart';
import '../models/searches/employee_search.dart';
import '../providers/employee_provider.dart';

class EmployeeDataTableSource extends AdvancedDataTableSource<Employee> {
  final EmployeeProvider _employeeProvider;
  var employeeSearch = EmployeeSearch();

  EmployeeDataTableSource(this._employeeProvider);

  @override
  Future<RemoteDataSourceDetails<Employee>> getNextPage(
      NextPageRequest pageRequest) async {
    var page =
        (pageRequest.offset / pageRequest.pageSize).roundToDouble().ceil();

    employeeSearch.page = page + 1;
    employeeSearch.pageSize = pageRequest.pageSize;
    employeeSearch.includeCity = true;

    var _employees = await _employeeProvider.getAll(search: employeeSearch);

    return RemoteDataSourceDetails(_employees.totalCount, _employees.result);
  }

  @override
  DataRow? getRow(int index) {
    final currentRowData = lastDetails!.rows[index];
    return DataRow(
      onSelectChanged: (e) => {print('test')},
      cells: [
        DataCell(Text(currentRowData.id.toString())),
        DataCell(Text(currentRowData.firstName)),
        DataCell(Text(currentRowData.lastName)),
        DataCell(Text(currentRowData.firstName)),
        DataCell(Text(currentRowData.address)),
        DataCell(Text(currentRowData.city?.name ?? "")),
        DataCell(Text(currentRowData.email)),
      ],
    );
  }

  @override
  int get selectedRowCount => 0;

  Future filterData(String? name) async {
    employeeSearch.name = name;
    setNextView();
  }
}
