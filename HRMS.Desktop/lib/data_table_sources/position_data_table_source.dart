import 'package:advanced_datatable/advanced_datatable_source.dart';
import 'package:flutter/material.dart';

import '../models/position.dart';
import '../models/searches/position_search.dart';
import '../providers/position_provider.dart';

class PositionDataTableSource extends AdvancedDataTableSource<Position> {
  final PositionProvider _positionProvider;
  var positionSearch = PositionSearch();

  PositionDataTableSource(this._positionProvider);

  @override
  Future<RemoteDataSourceDetails<Position>> getNextPage(
      NextPageRequest pageRequest) async {
    var page =
        (pageRequest.offset / pageRequest.pageSize).roundToDouble().ceil();

    positionSearch.page = page + 1;
    positionSearch.pageSize = pageRequest.pageSize;
    positionSearch.includeDepartment = true;
    positionSearch.includePayGrade = true;
    positionSearch.includeEducation = true;

    var positions = await _positionProvider.getAll(search: positionSearch);

    return RemoteDataSourceDetails(positions.totalCount, positions.result);
  }

  @override
  DataRow? getRow(int index) {
    final currentRowData = lastDetails!.rows[index];
    return DataRow(
      onSelectChanged: (e) => {print('test')},
      cells: [
        DataCell(Text(currentRowData.name)),
        DataCell(Text(currentRowData.department?.name ?? "")),
        DataCell(Text(currentRowData.payGrade?.name ?? "")),
        DataCell(
            Text(currentRowData.requiredEducation?.qualificationOld ?? "")),
        DataCell(Text(currentRowData.isWorkExperienceRequired ? "Da" : "Ne")),
      ],
    );
  }

  @override
  int get selectedRowCount => 0;

  Future filterData(String? name) async {
    positionSearch.name = name;
    setNextView();
  }
}
