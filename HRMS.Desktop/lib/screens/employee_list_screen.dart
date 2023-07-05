import 'package:flutter/material.dart';
import 'package:hrms/models/employee.dart';
import 'package:hrms/models/paged_result.dart';
import 'package:hrms/providers/employee_provider.dart';
import 'package:provider/provider.dart';

class EmployeeListScreen extends StatefulWidget {
  const EmployeeListScreen({super.key});

  @override
  State<EmployeeListScreen> createState() => _EmployeeListScreenState();
}

class _EmployeeListScreenState extends State<EmployeeListScreen> {
  late EmployeeProvider _employeeProvider;

  bool isLoading = false;
  PagedResult<Employee> _employees = PagedResult();

  @override
  void initState() {
    super.initState();

    _employeeProvider = context.read<EmployeeProvider>();
    _loadData();
  }

  Future _loadData() async {
    isLoading = true;
    _employees = await _employeeProvider.getAll();
    setState(() => isLoading = false);
  }

  @override
  Widget build(BuildContext context) {
    return SizedBox(
      width: double.infinity,
      child: DataTable(
        showCheckboxColumn: false,
        columns: [
          _buildTableHeader("Id"),
          _buildTableHeader("Ime"),
          _buildTableHeader("Prezime"),
          _buildTableHeader("Spol"),
          _buildTableHeader("Adresa"),
          _buildTableHeader("Grad"),
          _buildTableHeader("Email"),
          _buildTableHeader(""),
        ],
        rows: _employees.result
            .map(
                (e) => DataRow(onSelectChanged: (e) => {print('test')}, cells: [
                      DataCell(Text(e.id.toString())),
                      DataCell(Text(e.firstName)),
                      DataCell(Text(e.lastName)),
                      DataCell(Text(e.firstName)),
                      DataCell(Text(e.address)),
                      DataCell(Text(e.firstName)),
                      DataCell(Text(e.email)),
                      DataCell(TextButton(
                        child: const Icon(Icons.delete),
                        onPressed: () => {
                          showDialog(
                            context: context,
                            builder: (BuildContext context) => AlertDialog(
                              icon: const Icon(Icons.delete),
                              title: const Text("Obriši zaposlenika"),
                              content: const Text(
                                  "Da li ste sigurni da želite obrisati zaposlenika?"),
                              actionsPadding: const EdgeInsets.all(20),
                              buttonPadding: const EdgeInsets.all(20),
                              actions: [
                                ElevatedButton(
                                  child: const Text("NAZAD"),
                                  onPressed: () => Navigator.pop(context),
                                ),
                                ElevatedButton(
                                  child: const Text("OBRIŠI"),
                                  onPressed: () => Navigator.pop(context),
                                )
                              ],
                            ),
                          )
                        },
                      ))
                    ]))
            .toList(),
      ),
    );
  }

  DataColumn _buildTableHeader(String text) {
    return DataColumn(
      label: Text(text),
    );
  }
}
