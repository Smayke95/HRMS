import 'package:advanced_datatable/advanced_datatable_source.dart';
import 'package:flutter/material.dart';
import 'package:intl/intl.dart';

import '../models/employee_position.dart';
import '../models/enums/employment_type.dart';
import '../models/searches/employee_position_search.dart';
import '../providers/employee_position_provider.dart';

class EmployeePositionDataTableSource
    extends AdvancedDataTableSource<EmployeePosition> {
  final EmployeePositionProvider _employeePositionProvider;
  var employeePositionSearch = EmployeePositionSearch();
  DateFormat dateFormat = DateFormat("yyyy-MM-dd HH:mm:ss");

  EmployeePositionDataTableSource(this._employeePositionProvider);

  @override
  Future<RemoteDataSourceDetails<EmployeePosition>> getNextPage(
      NextPageRequest pageRequest) async {
    var page =
        (pageRequest.offset / pageRequest.pageSize).roundToDouble().ceil();

    employeePositionSearch.page = page + 1;
    employeePositionSearch.pageSize = pageRequest.pageSize;

    var employeePositions =
        await _employeePositionProvider.getAll(search: employeePositionSearch);

    return RemoteDataSourceDetails(
        employeePositions.totalCount, employeePositions.result);
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
        DataCell(
            Text(DateFormat("dd.MM.yyyy.").format(currentRowData.startDate))),
        DataCell(Text(currentRowData.endDate != null
            ? DateFormat("dd.MM.yyyy.").format(currentRowData.endDate!)
            : "")),
        DataCell(Text(currentRowData.employmentType == EmploymentType.permanent
            ? "Neodređeno"
            : "Određeno")),
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
