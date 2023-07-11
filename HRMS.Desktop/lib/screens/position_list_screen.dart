import 'package:advanced_datatable/datatable.dart';
import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:form_builder_validators/form_builder_validators.dart';
import 'package:provider/provider.dart';

import '../data_table_sources/position_data_table_source.dart';
import '../models/department.dart';
import '../models/education.dart';
import '../models/paged_result.dart';
import '../models/pay_grade.dart';
import '../providers/department_provider.dart';
import '../providers/education_provider.dart';
import '../providers/pay_grade_provider.dart';
import '../providers/position_provider.dart';
import 'search.dart';

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

  late PositionDataTableSource positionDataTableSource;

  final _formKey = GlobalKey<FormBuilderState>();
  var _departments = PagedResult<Department>();
  var _payGrades = PagedResult<PayGrade>();
  var _educations = PagedResult<Education>();

  @override
  void initState() {
    super.initState();

    _positionProvider = context.read<PositionProvider>();
    _departmentProvider = context.read<DepartmentProvider>();
    _payGradeProvider = context.read<PayGradeProvider>();
    _educationProvider = context.read<EducationProvider>();

    positionDataTableSource = PositionDataTableSource(_positionProvider);
    _loadData();
  }

  Future _loadData() async {
    _departments = await _departmentProvider.getAll();
    _payGrades = await _payGradeProvider.getAll();
    _educations = await _educationProvider.getAll();

    var position = await _positionProvider.get(2);

    _formKey.currentState?.patchValue({
      "name": position?.name ?? "",
      "isWorkExperienceRequired": position?.isWorkExperienceRequired ?? false,
    });
  }

  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        Search(
          "Dodaj poziciju",
          () => {
            showDialog(
              context: context,
              builder: (BuildContext context) => _buildDialog(context),
            )
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

  Widget _buildDialog(BuildContext context) {
    return AlertDialog(
      icon: const Icon(Icons.add),
      title: const Text("Dodaj poziciju"),
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
                      validator: FormBuilderValidators.required(),
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
                      name: "department",
                      decoration: const InputDecoration(labelText: "Odjel"),
                      items: _departments.result
                          .map((department) => DropdownMenuItem(
                                value: department.id.toString(),
                                child: Text(department.name),
                              ))
                          .toList(),
                    ),
                  ),
                  const SizedBox(width: 20),
                  SizedBox(
                    width: 300,
                    child: FormBuilderDropdown(
                      name: "payGrade",
                      decoration:
                          const InputDecoration(labelText: "Platni razred"),
                      items: _payGrades.result
                          .map((payGrade) => DropdownMenuItem(
                                value: payGrade.id.toString(),
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
                      name: "education",
                      decoration: const InputDecoration(
                          labelText: "Potrebno obrazovanje"),
                      items: _educations.result
                          .map((education) => DropdownMenuItem(
                                value: education.id.toString(),
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
                    ),
                  ),
                ],
              )
            ],
          ),
        ),
      ),
    );
  }
}
