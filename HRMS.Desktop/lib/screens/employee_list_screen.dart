import 'package:advanced_datatable/datatable.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

import '../data_table_sources/employee_data_table_source.dart';
import '../providers/employee_provider.dart';
import '../providers/notification_provider.dart';
import '../widgets/master_screen.dart';
import 'dashboard_screen.dart';
import 'search.dart';

class EmployeeListScreen extends StatefulWidget {
  const EmployeeListScreen({super.key});

  @override
  State<EmployeeListScreen> createState() => _EmployeeListScreenState();
}

class _EmployeeListScreenState extends State<EmployeeListScreen> {
  late NotificationProvider _notificationProvider;
  
  late EmployeeDataTableSource employeeDataTableSource;

  @override
  void initState() {
    super.initState();

    var employeeProvider = context.read<EmployeeProvider>();
    employeeDataTableSource = EmployeeDataTableSource(employeeProvider);

    _notificationProvider = context.read<NotificationProvider>();
  }

  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        Search(
          "Dodaj zaposlenika",
          () => {
            //_notificationProvider.listen()
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
            columns: const [
              DataColumn(label: Text("Šifra")),
              DataColumn(label: Text("Ime")),
              DataColumn(label: Text("Prezime")),
              DataColumn(label: Text("Email")),
              DataColumn(label: Text("Spol")),
              DataColumn(label: Text("Adresa")),
              DataColumn(label: Text("Grad")),
            ],
          ),
        ),
      ],
    );
  }
}
