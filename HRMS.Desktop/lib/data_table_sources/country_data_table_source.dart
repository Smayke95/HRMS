import 'package:advanced_datatable/advanced_datatable_source.dart';
import 'package:flutter/material.dart';

import '../models/searches/country_search_model.dart';
import '../models/country.dart';
import '../providers/country_provider.dart';

class CountryDataTableSource extends AdvancedDataTableSource<Country> {
  final CountryProvider _countryProvider;
  final Function(int) _onSelectChanged;

  var countrySearch = CountrySearch();

  CountryDataTableSource(this._countryProvider, this._onSelectChanged);

  @override
  Future<RemoteDataSourceDetails<Country>> getNextPage(
      NextPageRequest pageRequest) async {
    var page =
        (pageRequest.offset / pageRequest.pageSize).roundToDouble().ceil();

    countrySearch.page = page + 1;
    countrySearch.pageSize = pageRequest.pageSize;

    var countries = await _countryProvider.getAll(search: countrySearch);

    return RemoteDataSourceDetails(countries.totalCount, countries.result);
  }

  @override
  DataRow? getRow(int index) {
    final currentRow = lastDetails!.rows[index];
    return DataRow(
      onSelectChanged: (e) => _onSelectChanged(currentRow.id),
      cells: [
        DataCell(Text(currentRow.name)),   
      ],
    );
  }

  @override
  int get selectedRowCount => 0;

  Future filterData(String? name) async {
    countrySearch.name = name;
    setNextView();
  }
}
