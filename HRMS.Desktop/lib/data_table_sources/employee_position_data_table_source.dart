import 'package:advanced_datatable/advanced_datatable_source.dart';
import 'package:flutter/material.dart';

import '../models/employee_position.dart';
import '../models/searches/employee_position_search.dart';
import '../providers/employee_position_provider.dart';

class EmployeePositionDataTableSource
    extends AdvancedDataTableSource<EmployeePosition> {
  final EmployeePositionProvider _employeePositionProvider;
  var employeePositionSearch = EmployeePositionSearch();

  EmployeePositionDataTableSource(this._employeePositionProvider);

  @override
  Future<RemoteDataSourceDetails<EmployeePosition>> getNextPage(
      NextPageRequest pageRequest) async {
    var page =
        (pageRequest.offset / pageRequest.pageSize).roundToDouble().ceil();

    employeePositionSearch.page = page + 1;
    employeePositionSearch.pageSize = pageRequest.pageSize;

    var _employeePositions =
        await _employeePositionProvider.getAll(search: employeePositionSearch);

    return RemoteDataSourceDetails(
        _employeePositions.totalCount, _employeePositions.result);
  }

  @override
  DataRow? getRow(int index) {
    final currentRowData = lastDetails!.rows[index];
    return DataRow(
      onSelectChanged: (e) => {print('test')},
      cells: [
        DataCell(Text(
            "${currentRowData.employee?.firstName ?? ""} ${currentRowData.employee?.lastName ?? ""}")),
        DataCell(Text(currentRowData.position?.name ?? "")),
        DataCell(Text(currentRowData.startDate.toIso8601String())),
        DataCell(Text(currentRowData.endDate?.toIso8601String() ?? "")),
        DataCell(Text(currentRowData.employmentType.toString())),
      ],
    );
  }

  @override
  int get selectedRowCount => 0;

  Future filterData(String? name) async {
    employeePositionSearch.name = name;
    setNextView();
  }
}
