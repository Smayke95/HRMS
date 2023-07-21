import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:form_builder_validators/form_builder_validators.dart';
import 'package:provider/provider.dart';

import '../providers/employee_provider.dart';

class EmployeeDetailsScreen extends StatefulWidget {
  final int? id;

  const EmployeeDetailsScreen(this.id, {super.key});

  @override
  State<EmployeeDetailsScreen> createState() => _EmployeeDetailsScreenState();
}

class _EmployeeDetailsScreenState extends State<EmployeeDetailsScreen> {
  late EmployeeProvider _employeeProvider;

  final _formKey = GlobalKey<FormBuilderState>();

  @override
  void initState() {
    super.initState();

    _employeeProvider = context.read<EmployeeProvider>();
    _loadData(widget.id);
  }

  Future _loadData(int? id) async {
    if (id != null) {
      var employee = await _employeeProvider.get(id);

      _formKey.currentState?.patchValue({
        "firstName": employee.firstName,
        "lastName": employee.lastName,
        "maidenName": employee.maidenName,
      });
    }
  }

  @override
  Widget build(BuildContext context) {
    return FormBuilder(
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
                    name: "firstName",
                    decoration: const InputDecoration(labelText: "Ime *"),
                    validator: FormBuilderValidators.required(
                        errorText: "Ime je obavezno."),
                  ),
                )
              ],
            ),
            const SizedBox(height: 20),
            Row(
              children: [
                SizedBox(
                  width: 300,
                  child: FormBuilderTextField(
                    name: "lastName",
                    decoration: const InputDecoration(labelText: "Prezime *"),
                    validator: FormBuilderValidators.required(
                        errorText: "Prezime je obavezno."),
                  ),
                ),
                const SizedBox(width: 20),
                SizedBox(
                  width: 300,
                  child: FormBuilderTextField(
                    name: "maidenName",
                    decoration:
                        const InputDecoration(labelText: "Djevojačko prezime"),
                  ),
                ),
              ],
            ),
          ],
        ),
      ),
    );
  }
}
