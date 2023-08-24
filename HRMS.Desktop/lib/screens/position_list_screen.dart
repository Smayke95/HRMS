import 'package:advanced_datatable/datatable.dart';
import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:form_builder_validators/form_builder_validators.dart';
import 'package:provider/provider.dart';

import '../data_table_sources/position_data_table_source.dart';
import '../models/department.dart';
import '../models/education.dart';
import '../models/employee_position.dart';
import '../models/paged_result.dart';
import '../models/pay_grade.dart';
import '../models/requests/position_insert_update.dart';
import '../providers/department_provider.dart';
import '../providers/education_provider.dart';
import '../providers/employee_position_provider.dart';
import '../providers/pay_grade_provider.dart';
import '../providers/position_provider.dart';
import '../widgets/responsive.dart';
import '../widgets/search.dart';

class PositionListScreen extends StatefulWidget {
  const PositionListScreen({super.key});

  @override
  State<PositionListScreen> createState() => _PositionListScreenState();
}

class _PositionListScreenState extends State<PositionListScreen> {
  late PositionProvider _positionProvider;
  late DepartmentProvider _departmentProvider;
  late PayGradeProvider _payGradeProvider;
  late EducationProvider _educationProvider;
  late EmployeePositionProvider _employeePositionProvider;

  late PositionDataTableSource positionDataTableSource;

  final _formKey = GlobalKey<FormBuilderState>();
  var _departments = PagedResult<Department>();
  var _payGrades = PagedResult<PayGrade>();
  var _educations = PagedResult<Education>();
  var _employeePositions = PagedResult<EmployeePosition>();
  var canDelete = true;

  @override
  void initState() {
    super.initState();

    _positionProvider = context.read<PositionProvider>();
    _departmentProvider = context.read<DepartmentProvider>();
    _payGradeProvider = context.read<PayGradeProvider>();
    _educationProvider = context.read<EducationProvider>();
    _employeePositionProvider = context.read<EmployeePositionProvider>();

    positionDataTableSource =
        PositionDataTableSource(_positionProvider, _openDialog);

    _loadData(null);
  }

  Future _loadData(int? id) async {
    _departments = await _departmentProvider.getAll();
    _payGrades = await _payGradeProvider.getAll();
    _educations = await _educationProvider.getAll();
    _employeePositions = await _employeePositionProvider.getAll();

    if (id != null) {
      var position = await _positionProvider.get(id);

      var positionInsertUpdate = PositionInsertUpdate(
        position.name,
        position.department?.id,
        position.payGrade?.id,
        position.requiredEducation?.id,
        position.isWorkExperienceRequired,
      ).toJson();

      _formKey.currentState?.patchValue(positionInsertUpdate);

      canDelete = !_employeePositions.result.any((x) => x.position?.id == id);
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
          "Dodaj poziciju",
          () => _openDialog(null),
          onSearch: (text) => positionDataTableSource.filterData(text),
        ),
        SizedBox(
          width: double.infinity,
          child: AdvancedPaginatedDataTable(
            showHorizontalScrollbarAlways: Responsive.isMobile(context),
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

  Widget _buildDialog(BuildContext context, int? id) {
    _loadData(id);

    return AlertDialog(
      icon: Icon(id == null ? Icons.add : Icons.edit),
      title: Text(id == null ? "Dodaj poziciju" : "Uredi poziciju"),
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
                      name: "departmentId",
                      decoration: const InputDecoration(labelText: "Odjel *"),
                      validator: FormBuilderValidators.required(
                          errorText: "Odjel je obavezan."),
                      items: _departments.result
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
                      name: "payGradeId",
                      decoration:
                          const InputDecoration(labelText: "Platni razred *"),
                      validator: FormBuilderValidators.required(
                          errorText: "Platni razred je obavezan."),
                      items: _payGrades.result
                          .map((payGrade) => DropdownMenuItem(
                                value: payGrade.id,
                                child: Text(
                                    "${payGrade.name} (${payGrade.minAmount} - ${payGrade.maxAmount})"),
                              ))
                          .toList(),
                    ),
                  ),
                ],
              ),
              const SizedBox(height: 20),
              Row(
                children: [
                  SizedBox(
                    width: 300,
                    child: FormBuilderDropdown(
                      name: "requiredEducationId",
                      decoration: const InputDecoration(
                          labelText: "Potrebno obrazovanje"),
                      validator: FormBuilderValidators.required(
                          errorText: "Potrebno obrazovanje je obavezno."),
                      items: _educations.result
                          .map((education) => DropdownMenuItem(
                                value: education.id,
                                child: Text(education.qualificationOld),
                              ))
                          .toList(),
                    ),
                  ),
                  const SizedBox(width: 70),
                  SizedBox(
                    width: 200,
                    child: FormBuilderCheckbox(
                      name: "isWorkExperienceRequired",
                      title: const Text("Potrebno radno iskustvo"),
                      initialValue: false,
                    ),
                  ),
                ],
              )
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
              if (canDelete) {
                await _positionProvider.delete(id);
                positionDataTableSource.filterData(null);
                if (context.mounted) Navigator.pop(context);
              } else {
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
                              "* Ova pozicija sadrži zaposlenika, te zbog toga ne može biti obrisana.",
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
                  ? await _positionProvider.insert(request)
                  : await _positionProvider.update(id, request);

              positionDataTableSource.filterData(null);
              if (context.mounted) Navigator.pop(context);
            }
          },
        ),
      ],
    );
  }
}
