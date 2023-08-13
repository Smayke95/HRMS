import 'package:advanced_datatable/advanced_datatable_source.dart';
import 'package:flutter/material.dart';
import 'package:intl/intl.dart';

import '../models/employee_position.dart';
import '../models/enums/employment_status.dart';
import '../models/enums/employment_type.dart';
import '../models/searches/employee_position_search.dart';
import '../providers/employee_position_provider.dart';

class EmployeePositionDataTableSource
    extends AdvancedDataTableSource<EmployeePosition> {
  final EmployeePositionProvider _employeePositionProvider;
  final Function(int) _onSelectChanged;

  var employeePositionSearch = EmployeePositionSearch();

  EmployeePositionDataTableSource(
      this._employeePositionProvider, this._onSelectChanged);

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
    final currentRow = lastDetails!.rows[index];
    return DataRow(
      onSelectChanged: (e) => _onSelectChanged(currentRow.id),
      cells: [
        DataCell(Text(
            "${currentRow.employee?.firstName ?? ""} ${currentRow.employee?.lastName ?? ""}")),
        DataCell(Text(currentRow.position?.name ?? "")),
        DataCell(Text(DateFormat("dd.MM.yyyy.").format(currentRow.startDate))),
        DataCell(Text(currentRow.endDate != null
            ? DateFormat("dd.MM.yyyy.").format(currentRow.endDate!)
            : "")),
        DataCell(Text(currentRow.type == EmploymentType.permanent
            ? "Neodređeno"
            : "Određeno")),
        DataCell(Text(currentRow.status == EmploymentStatus.active
            ? "Aktivno"
            : currentRow.status == EmploymentStatus.inactive
                ? "Neaktivno"
                : "Obrisano")),
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
