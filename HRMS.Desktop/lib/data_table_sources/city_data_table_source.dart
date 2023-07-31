import 'package:advanced_datatable/advanced_datatable_source.dart';
import 'package:flutter/material.dart';

import '../models/searches/city_search.dart';
import '../models/city.dart';
import '../providers/city_provider.dart';

class CityDataTableSource extends AdvancedDataTableSource<City> {
  final CityProvider _cityProvider;
  final Function(int) _onSelectChanged;

  var citySearch = CitySearch();

  CityDataTableSource(this._cityProvider, this._onSelectChanged);

  @override
  Future<RemoteDataSourceDetails<City>> getNextPage(
      NextPageRequest pageRequest) async {
    var page =
        (pageRequest.offset / pageRequest.pageSize).roundToDouble().ceil();

    citySearch.page = page + 1;
    citySearch.pageSize = pageRequest.pageSize;
    citySearch.includeCountry = true;

    var cities = await _cityProvider.getAll(search: citySearch);

    return RemoteDataSourceDetails(cities.totalCount, cities.result);
  }

  @override
  DataRow? getRow(int index) {
    final currentRow = lastDetails!.rows[index];
    return DataRow(
      onSelectChanged: (e) => _onSelectChanged(currentRow.id),
      cells: [
        DataCell(Text(currentRow.name)),
        DataCell(Text(currentRow.zipCode)),
        DataCell(Text(currentRow.country?.name ?? ""))       
      ],
    );
  }

  @override
  int get selectedRowCount => 0;

  Future filterData(String? name) async {
    citySearch.name = name;
    setNextView();
  }
}
