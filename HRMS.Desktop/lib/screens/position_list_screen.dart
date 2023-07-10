import 'package:advanced_datatable/datatable.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

import '../data_table_sources/position_data_table_source.dart';
import '../providers/position_provider.dart';
import '../widgets/master_screen.dart';
import 'dashboard_screen.dart';
import 'search.dart';

class PositionListScreen extends StatefulWidget {
  const PositionListScreen({super.key});

  @override
  State<PositionListScreen> createState() => _PositionListScreenState();
}

class _PositionListScreenState extends State<PositionListScreen> {
  late PositionDataTableSource positionDataTableSource;

  @override
  void initState() {
    super.initState();

    var positionProvider = context.read<PositionProvider>();
    positionDataTableSource = PositionDataTableSource(positionProvider);
  }

  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        Search(
          "Dodaj poziciju",
          () => {
            Navigator.of(context).pushReplacement(MaterialPageRoute(
                builder: (context) =>
                    const MasterScreen("Projekti", DashboardScreen())))
          },
          onSearch: (text) => positionDataTableSource.filterData(text),
        ),
        SizedBox(
          width: double.infinity,
          child: AdvancedPaginatedDataTable(
            addEmptyRows: false,
            showCheckboxColumn: false,
            source: positionDataTableSource,
            rowsPerPage: 7,
            columns: const [
              DataColumn(label: Text("Naziv")),
              DataColumn(label: Text("Odjel")),
              DataColumn(label: Text("Platni razred")),
              DataColumn(label: Text("Potrebno obrazovanje")),
              DataColumn(label: Text("Potrebno radno iskustvo")),
            ],
          ),
        ),
      ],
    );
  }
}
