import 'package:advanced_datatable/advanced_datatable_source.dart';
import 'package:flutter/material.dart';

import '../models/searches/event_type_search.dart';
import '../models/event_type.dart';
import '../providers/event_type_provider.dart';

class EventTypeDataTableSource extends AdvancedDataTableSource<EventType> {
  final EventTypeProvider _eventStatusProvider;
  final Function(int) _onSelectChanged;

  var eventStatusSearch = EventTypeSearch();

  EventTypeDataTableSource(this._eventStatusProvider, this._onSelectChanged);

  @override
  Future<RemoteDataSourceDetails<EventType>> getNextPage(
      NextPageRequest pageRequest) async {
    var page =
        (pageRequest.offset / pageRequest.pageSize).roundToDouble().ceil();

    eventStatusSearch.page = page + 1;
    eventStatusSearch.pageSize = pageRequest.pageSize;

    var eventTypes =
        await _eventStatusProvider.getAll(search: eventStatusSearch);

    return RemoteDataSourceDetails(eventTypes.totalCount, eventTypes.result);
  }

  @override
  DataRow? getRow(int index) {
    final currentRow = lastDetails!.rows[index];
   
    return DataRow(
      onSelectChanged: (e) => _onSelectChanged(currentRow.id),
      cells: [
        DataCell(Text(currentRow.name)),
        DataCell(Text(currentRow.isApprovalRequired ? "Da" : "Ne")),
        DataCell(Text(currentRow.color)),
      ],
    );
  }

  @override
  int get selectedRowCount => 0;

  Future filterData(String? name) async {
    eventStatusSearch.name = name;
    setNextView();
  }  
}
