import 'package:advanced_datatable/datatable.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

import '../data_table_sources/employee_position_data_table_source.dart';
import '../providers/employee_position_provider.dart';
import '../widgets/master_screen.dart';
import '../widgets/responsive.dart';
import '../widgets/search.dart';
import 'employee_position_details_screen.dart';

class EmployeePositionListScreen extends StatefulWidget {
  const EmployeePositionListScreen({super.key});

  @override
  State<EmployeePositionListScreen> createState() =>
      _EmployeePositionListScreenState();
}

class _EmployeePositionListScreenState
    extends State<EmployeePositionListScreen> {
  late EmployeePositionDataTableSource employeePositionDataTableSource;

  @override
  void initState() {
    super.initState();

    var employeePositionProvider = context.read<EmployeePositionProvider>();
    employeePositionDataTableSource =
        EmployeePositionDataTableSource(employeePositionProvider, _openDetails);
  }

  void _openDetails(int? id) {
    if (Responsive.isMobile(context)) return;

    Navigator.of(context).pushReplacement(MaterialPageRoute(
        builder: (context) => MasterScreen(
            "Detalji o zaposlenju", EmployeePositionDetailsScreen(id))));
  }

  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        Search(
          "Dodaj zaposlenje",
          () => _openDetails(null),
          onSearch: (text) => employeePositionDataTableSource.filterData(text),
        ),
        SizedBox(
          width: double.infinity,
          child: AdvancedPaginatedDataTable(
            addEmptyRows: false,
            showCheckboxColumn: false,
            source: employeePositionDataTableSource,
            rowsPerPage: 7,
            columns: const [
              DataColumn(label: Text("Zaposlenik")),
              DataColumn(label: Text("Pozicija")),
              DataColumn(label: Text("Datum početka")),
              DataColumn(label: Text("Datum kraja")),
              DataColumn(label: Text("Vrsta zaposlenja")),
              DataColumn(label: Text("Status")),
            ],
          ),
        ),
      ],
    );
  }
}
