import 'package:advanced_datatable/datatable.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

import '../data_table_sources/employee_data_table_source.dart';
import '../providers/employee_provider.dart';
import '../widgets/master_screen.dart';
import 'dashboard_screen.dart';
import 'search.dart';

class EmployeeListScreen extends StatefulWidget {
  const EmployeeListScreen({super.key});

  @override
  State<EmployeeListScreen> createState() => _EmployeeListScreenState();
}

class _EmployeeListScreenState extends State<EmployeeListScreen> {
  late EmployeeDataTableSource employeeDataTableSource;

  @override
  void initState() {
    super.initState();

    var employeeProvider = context.read<EmployeeProvider>();
    employeeDataTableSource = EmployeeDataTableSource(employeeProvider);
  }

  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        Search(
          "Dodaj zaposlenika",
          () => {
            Navigator.of(context).pushReplacement(MaterialPageRoute(
                builder: (context) =>
                    const MasterScreen("Projekti", DashboardScreen())))
          },
          onSearch: (text) => employeeDataTableSource.filterData(text),
        ),
        SizedBox(
          width: double.infinity,
          child: AdvancedPaginatedDataTable(
            addEmptyRows: false,
            showCheckboxColumn: false,
            source: employeeDataTableSource,
            rowsPerPage: 7,
            columns: [
              _buildTableHeader("Id"),
              _buildTableHeader("Ime"),
              _buildTableHeader("Prezime"),
              _buildTableHeader("Spol"),
              _buildTableHeader("Adresa"),
              _buildTableHeader("Grad"),
              _buildTableHeader("Email"),
            ],
          ),
        ),
      ],
    );
  }

  DataColumn _buildTableHeader(String text) {
    return DataColumn(
      label: Text(text),
    );
  }
}
