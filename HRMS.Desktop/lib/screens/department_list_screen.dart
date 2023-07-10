import 'package:advanced_datatable/datatable.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

import '../data_table_sources/department_data_table_source.dart';
import '../providers/department_provider.dart';
import '../widgets/master_screen.dart';
import 'dashboard_screen.dart';
import 'search.dart';

class DepartmentListScreen extends StatefulWidget {
  const DepartmentListScreen({super.key});

  @override
  State<DepartmentListScreen> createState() => _DepartmentListScreenState();
}

class _DepartmentListScreenState extends State<DepartmentListScreen> {
  late DepartmentDataTableSource departmentDataTableSource;

  @override
  void initState() {
    super.initState();

    var departmentProvider = context.read<DepartmentProvider>();
    departmentDataTableSource = DepartmentDataTableSource(departmentProvider);
  }

  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        Search(
          "Dodaj odjel",
          () => {
            Navigator.of(context).pushReplacement(MaterialPageRoute(
                builder: (context) =>
                    const MasterScreen("Projekti", DashboardScreen())))
          },
          onSearch: (text) => departmentDataTableSource.filterData(text),
        ),
        SizedBox(
          width: double.infinity,
          child: AdvancedPaginatedDataTable(
            addEmptyRows: false,
            showCheckboxColumn: false,
            source: departmentDataTableSource,
            rowsPerPage: 7,
            columns: [
              _buildTableHeader("Id"),
              _buildTableHeader("Naziv"),
              _buildTableHeader("Test"),
              _buildTableHeader("Test"),
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
