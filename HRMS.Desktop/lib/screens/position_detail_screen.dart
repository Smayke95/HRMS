import 'package:HRMS/models/paged_result.dart';
import 'package:HRMS/models/pay_grade.dart';
import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:form_builder_validators/form_builder_validators.dart';
import 'package:provider/provider.dart';

import '../models/position.dart';
import '../providers/pay_grade_provider.dart';
import '../providers/position_provider.dart';
import '../widgets/master_screen.dart';

class PositionDetailScreen extends StatefulWidget {
  const PositionDetailScreen({super.key});

  @override
  State<PositionDetailScreen> createState() => _PositionDetailScreenState();
}

class _PositionDetailScreenState extends State<PositionDetailScreen> {
  final _formKey = GlobalKey<FormBuilderState>();
  Position? position;

  PagedResult<PayGrade> payGrades = PagedResult<PayGrade>();

  @override
  void initState() {
    super.initState();
    _loadData();
  }

  Future _loadData() async {
    var payGradeProvider = context.read<PayGradeProvider>();
    payGrades = await payGradeProvider.getAll();

    var positionProvider = context.read<PositionProvider>();
    position = await positionProvider.get(2);

    _formKey.currentState?.patchValue({
      "name": position?.name ?? "",
      "isWorkExperienceRequired": position?.isWorkExperienceRequired ?? false,
    });

    setState(() {});
  }

  @override
  Widget build(BuildContext context) {
    return MasterScreen(
      "Detalji o poziciji",
      FormBuilder(
        key: _formKey,
        child: Column(
          children: [
            FormBuilderTextField(
              name: "name",
              decoration: const InputDecoration(labelText: "Naziv *"),
              validator: FormBuilderValidators.required(),
            ),
            FormBuilderCheckbox(
              name: "isWorkExperienceRequired",
              title: const Text("Potrebno radno iskustvo"),
            ),
            FormBuilderDropdown(
              name: "payGrade",
              items: payGrades.result
                  .map((payGrade) => DropdownMenuItem(
                        value: payGrade.id.toString(),
                        child: Text(
                            "${payGrade.name} (${payGrade.minAmount} - ${payGrade.maxAmount})"),
                      ))
                  .toList(),
            )
          ],
        ),
      ),
    );
  }
}
