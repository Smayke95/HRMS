import 'package:advanced_datatable/advanced_datatable_source.dart';
import 'package:flutter/material.dart';

import '../models/position.dart';
import '../models/searches/position_search.dart';
import '../providers/position_provider.dart';

class PositionDataTableSource extends AdvancedDataTableSource<Position> {
  final PositionProvider _positionProvider;
  final Function(int) _onSelectChanged;

  var positionSearch = PositionSearch();

  PositionDataTableSource(this._positionProvider, this._onSelectChanged);

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
    final currentRow = lastDetails!.rows[index];
    return DataRow(
      onSelectChanged: (e) => _onSelectChanged(currentRow.id),
      cells: [
        DataCell(Text(currentRow.name)),
        DataCell(Text(currentRow.department?.name ?? "")),
        DataCell(Text(currentRow.payGrade?.name ?? "")),
        DataCell(Text(currentRow.requiredEducation?.qualificationOld ?? "")),
        DataCell(Text(currentRow.isWorkExperienceRequired ? "Da" : "Ne")),
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
