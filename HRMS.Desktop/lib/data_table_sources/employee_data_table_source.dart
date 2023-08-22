import 'package:advanced_datatable/advanced_datatable_source.dart';
import 'package:flutter/material.dart';

import '../models/employee.dart';
import '../models/enums/gender.dart';
import '../models/searches/employee_search.dart';
import '../providers/employee_provider.dart';

class EmployeeDataTableSource extends AdvancedDataTableSource<Employee> {
  final EmployeeProvider _employeeProvider;
  final Function(int) _onSelectChanged;

  var employeeSearch = EmployeeSearch();

  EmployeeDataTableSource(this._employeeProvider, this._onSelectChanged);

  @override
  Future<RemoteDataSourceDetails<Employee>> getNextPage(
      NextPageRequest pageRequest) async {
    var page =
        (pageRequest.offset / pageRequest.pageSize).roundToDouble().ceil();

    employeeSearch.page = page + 1;
    employeeSearch.pageSize = pageRequest.pageSize;
    employeeSearch.includeCity = true;

    var employees = await _employeeProvider.getAll(search: employeeSearch);

    return RemoteDataSourceDetails(employees.totalCount, employees.result);
  }

  @override
  DataRow? getRow(int index) {
    final currentRow = lastDetails!.rows[index];
    return DataRow(
      onSelectChanged: (e) => _onSelectChanged(currentRow.id),
      cells: [
        DataCell(Text(currentRow.workerCode)),
        DataCell(Text(currentRow.firstName)),
        DataCell(Text(currentRow.lastName)),
        DataCell(Text(currentRow.email)),
        DataCell(Text(currentRow.gender == Gender.male ? "Muško" : "Žensko")),
        DataCell(Text(currentRow.address)),
        DataCell(Text(currentRow.city?.name ?? "")),
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
