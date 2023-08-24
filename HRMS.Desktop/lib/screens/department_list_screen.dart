import 'package:advanced_datatable/datatable.dart';
import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:form_builder_validators/form_builder_validators.dart';
import 'package:provider/provider.dart';

import '../data_table_sources/department_data_table_source.dart';
import '../models/department.dart';
import '../models/employee.dart';
import '../models/paged_result.dart';
import '../models/requests/department_insert_update.dart';
import '../providers/department_provider.dart';
import '../providers/employee_provider.dart';
import '../widgets/responsive.dart';
import '../widgets/search.dart';

class DepartmentListScreen extends StatefulWidget {
  const DepartmentListScreen({super.key});

  @override
  State<DepartmentListScreen> createState() => _DepartmentListScreenState();
}

class _DepartmentListScreenState extends State<DepartmentListScreen> {
  late DepartmentProvider _departmentProvider;
  late EmployeeProvider _employeeProvider;

  late DepartmentDataTableSource departmentDataTableSource;

  final _formKey = GlobalKey<FormBuilderState>();
  var _departments = PagedResult<Department>();
  var _employees = PagedResult<Employee>();

  @override
  void initState() {
    super.initState();

    _departmentProvider = context.read<DepartmentProvider>();
    _employeeProvider = context.read<EmployeeProvider>();

    departmentDataTableSource =
        DepartmentDataTableSource(_departmentProvider, _openDialog);

    _loadData(null);
  }

  Future _loadData(int? id) async {
    _departments = await _departmentProvider.getAll();
    _employees = await _employeeProvider.getAll();

    if (id != null) {
      var department = await _departmentProvider.get(id);

      var departmentInsertUpdate = DepartmentInsertUpdate(
        department.name,
        department.parentDepartment?.id ?? 0,
        department.supervisor?.id ?? 0,
      ).toJson();

      _formKey.currentState?.patchValue(departmentInsertUpdate);
    }
  }

  void _openDialog(int? id) {
    if (Responsive.isMobile(context)) return;

    showDialog(
      context: context,
      builder: (BuildContext context) => _buildDialog(context, id),
    );
  }

  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        Search(
          "Dodaj odjel",
          () => _openDialog(null),
          onSearch: (text) => departmentDataTableSource.filterData(text),
        ),
        SizedBox(
          width: double.infinity,
          child: AdvancedPaginatedDataTable(
            showHorizontalScrollbarAlways: Responsive.isMobile(context),
            addEmptyRows: false,
            showCheckboxColumn: false,
            source: departmentDataTableSource,
            rowsPerPage: 7,
            columns: const [
              DataColumn(label: Text("Naziv")),
              DataColumn(label: Text("Nivo")),
              DataColumn(label: Text("Krovni odjel")),
              DataColumn(label: Text("Nadležna osoba")),
            ],
          ),
        ),
      ],
    );
  }

  Widget _buildDialog(BuildContext context, int? id) {
    _loadData(id);

    return AlertDialog(
      icon: Icon(id == null ? Icons.add : Icons.edit),
      title: Text(id == null ? "Dodaj odjel" : "Uredi odjel"),
      content: FormBuilder(
        key: _formKey,
        child: SizedBox(
          height: 300,
          child: Column(
            children: [
              Row(
                children: [
                  SizedBox(
                    width: 400,
                    child: FormBuilderTextField(
                      name: "name",
                      decoration: const InputDecoration(labelText: "Naziv *"),
                      validator: FormBuilderValidators.required(
                          errorText: "Naziv je obavezan."),
                    ),
                  )
                ],
              ),
              const SizedBox(height: 20),
              Row(
                children: [
                  SizedBox(
                    width: 300,
                    child: FormBuilderDropdown(
                      name: "parentDepartmentId",
                      decoration:
                          const InputDecoration(labelText: "Bazni odjel *"),
                      validator: FormBuilderValidators.required(
                          errorText: "Bazni odjel je obavezan."),
                      items: _departments.result
                          .where((x) => x.id != (id ?? 0))
                          .map((department) => DropdownMenuItem(
                                value: department.id,
                                child: Text(department.name),
                              ))
                          .toList(),
                    ),
                  ),
                  const SizedBox(width: 20),
                  SizedBox(
                    width: 300,
                    child: FormBuilderDropdown(
                      name: "supervisorId",
                      decoration:
                          const InputDecoration(labelText: "Supervizor *"),
                      validator: FormBuilderValidators.required(
                          errorText: "Supervizor je obavezan."),
                      items: _employees.result
                          .map((employee) => DropdownMenuItem(
                                value: employee.id,
                                child: Text(
                                    "${employee.firstName} ${employee.lastName}"),
                              ))
                          .toList(),
                    ),
                  ),
                ],
              ),
            ],
          ),
        ),
      ),
      actionsPadding: const EdgeInsets.all(20),
      buttonPadding: const EdgeInsets.all(20),
      actions: [
        if (id != null)
          OutlinedButton(
            style: ButtonStyle(
              foregroundColor: MaterialStateProperty.all(Colors.red),
              padding: const MaterialStatePropertyAll(
                EdgeInsets.only(left: 40, top: 20, right: 40, bottom: 20),
              ),
            ),
            child: const Text("OBRIŠI"),
            onPressed: () async {
              try {
                await _departmentProvider.delete(id);
                departmentDataTableSource.filterData(null);
                if (context.mounted) Navigator.pop(context);
              } catch (error) {
                showDialog(
                  context: context,
                  builder: (context) {
                    return AlertDialog(
                      content: SizedBox(
                        width: 400,
                        child: Column(
                          mainAxisSize: MainAxisSize.min,
                          children: [
                            const Text(
                              "* Ovaj odjel sadrži pozicije ili pododjele te zbog toga ne može biti obrisan. Molimo prvo obrišite stavke koji referenciraju ovaj odjel.",
                              style: TextStyle(
                                color: Colors.red,
                              ),
                            ),
                            const SizedBox(height: 10),
                            TextButton(
                              onPressed: () {
                                Navigator.of(context).pop();
                              },
                              child: const Text("OK"),
                            ),
                          ],
                        ),
                      ),
                    );
                  },
                );
              }
            },
          ),
        const SizedBox(width: 185),
        OutlinedButton(
          style: const ButtonStyle(
            padding: MaterialStatePropertyAll(
              EdgeInsets.only(left: 40, top: 20, right: 40, bottom: 20),
            ),
          ),
          child: const Text("NAZAD"),
          onPressed: () => Navigator.pop(context),
        ),
        OutlinedButton(
          style: const ButtonStyle(
            padding: MaterialStatePropertyAll(
              EdgeInsets.only(left: 40, top: 20, right: 40, bottom: 20),
            ),
          ),
          child: const Text("SPREMI"),
          onPressed: () async {
            var isValid = _formKey.currentState?.saveAndValidate();

            if (isValid!) {
              var request = Map.from(_formKey.currentState!.value);

              id == null
                  ? await _departmentProvider.insert(request)
                  : await _departmentProvider.update(id, request);

              departmentDataTableSource.filterData(null);
              if (context.mounted) Navigator.pop(context);
            }
          },
        ),
      ],
    );
  }
}
