import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:form_builder_validators/form_builder_validators.dart';
import 'package:intl/intl.dart';
import 'package:provider/provider.dart';

import '../models/employee.dart';
import '../models/enums/employment_status.dart';
import '../models/paged_result.dart';
import '../models/position.dart';
import '../providers/employee_position_provider.dart';
import '../providers/employee_provider.dart';
import '../providers/position_provider.dart';

class EmployeePositionDetailsScreen extends StatefulWidget {
  final int? id;

  const EmployeePositionDetailsScreen(this.id, {super.key});

  @override
  State<EmployeePositionDetailsScreen> createState() =>
      _EmployeePositionDetailsScreenState();
}

class _EmployeePositionDetailsScreenState
    extends State<EmployeePositionDetailsScreen> {
  late EmployeePositionProvider _employeePositionProvider;
  late EmployeeProvider _employeeProvider;
  late PositionProvider _positionProvider;

  bool isLoading = true;
  final _formKey = GlobalKey<FormBuilderState>();
  Map<String, dynamic> _initialValue = {};

  var _employees = PagedResult<Employee>();
  var _positions = PagedResult<Position>();
  List<EmploymentStatus> _allowedActions = [];

  @override
  void initState() {
    super.initState();

    _employeePositionProvider = context.read<EmployeePositionProvider>();
    _employeeProvider = context.read<EmployeeProvider>();
    _positionProvider = context.read<PositionProvider>();

    _loadData(widget.id);
  }

  Future _loadData(int? id) async {
    _employees = await _employeeProvider.getAll();
    _positions = await _positionProvider.getAll();

    if (id != null) {
      var employeePosition = await _employeePositionProvider.get(id);

      _initialValue = {
        "employeeId": employeePosition.employee!.id,
        "positionId": employeePosition.position!.id,
        "startDate": employeePosition.startDate,
        "endDate": employeePosition.endDate,
        "salary": employeePosition.salary.toString(),
        "vacationDays": employeePosition.vacationDays.toString(),
        "type": employeePosition.type.index,
        "workingHours": employeePosition.workingHours,
      };

      _allowedActions = await _employeePositionProvider.allowedActions(id);
    }

    setState(() {
      isLoading = false;
    });
  }

  @override
  Widget build(BuildContext context) {
    return SingleChildScrollView(
      child: isLoading
          ? Container()
          : Card(
              elevation: 2,
              child: FormBuilder(
                key: _formKey,
                initialValue: _initialValue,
                child: Column(
                  children: [
                    FormBuilderDropdown(
                      name: "employeeId",
                      decoration:
                          const InputDecoration(labelText: "Zaposlenik *"),
                      validator: FormBuilderValidators.required(
                          errorText: "Zaposlenik je obavezan."),
                      items: _employees.result
                          .map((employee) => DropdownMenuItem(
                                value: employee.id,
                                child: Text(
                                    '${employee.firstName} ${employee.lastName}'),
                              ))
                          .toList(),
                    ),
                    FormBuilderDropdown(
                      name: "positionId",
                      decoration:
                          const InputDecoration(labelText: "Pozicija *"),
                      validator: FormBuilderValidators.required(
                          errorText: "Pozicija je obavezna."),
                      items: _positions.result
                          .map((position) => DropdownMenuItem(
                                value: position.id,
                                child: Text(position.name),
                              ))
                          .toList(),
                    ),
                    FormBuilderDateTimePicker(
                      name: "startDate",
                      inputType: InputType.date,
                      format: DateFormat('dd.MM.yyyy.'),
                      decoration:
                          const InputDecoration(labelText: "Datum početka *"),
                      validator: FormBuilderValidators.required(
                          errorText: "Datum početka je obavezan."),
                    ),
                    FormBuilderDateTimePicker(
                      name: "endDate",
                      inputType: InputType.date,
                      format: DateFormat('dd.MM.yyyy.'),
                      decoration:
                          const InputDecoration(labelText: "Datum kraja *"),
                    ),
                    FormBuilderTextField(
                      name: "salary",
                      decoration: const InputDecoration(labelText: "Plata *"),
                      validator: FormBuilderValidators.required(
                          errorText: "Plata je obavezna."),
                    ),
                    FormBuilderTextField(
                      name: "vacationDays",
                      decoration: const InputDecoration(
                          labelText: "Broj dana godišnjeg odmora *"),
                      validator: FormBuilderValidators.required(
                          errorText: "Broj dana godišnjeg odmora je obavezan."),
                    ),
                    FormBuilderDropdown(
                      name: "type",
                      decoration: const InputDecoration(
                          labelText: "Vrsta zaposlenja *"),
                      validator: FormBuilderValidators.required(
                          errorText: "Vrsta zaposlenja je obavezna."),
                      items: const [
                        DropdownMenuItem(
                          value: 0,
                          child: Text("Neodređeno"),
                        ),
                        DropdownMenuItem(
                          value: 1,
                          child: Text("Određeno"),
                        ),
                      ],
                    ),
                    FormBuilderTextField(
                      name: "workingHours",
                      decoration:
                          const InputDecoration(labelText: "Radno vrijeme"),
                    ),
                    if (_allowedActions.contains(EmploymentStatus.active))
                      Padding(
                        padding: const EdgeInsets.all(20),
                        child: ElevatedButton(
                          child:
                              const Text("SPREMI", textAlign: TextAlign.center),
                          onPressed: () async {
                            var isValid =
                                _formKey.currentState?.saveAndValidate();

                            if (isValid!) {
                              var request =
                                  Map.from(_formKey.currentState!.value);

                              widget.id == null
                                  ? await _employeePositionProvider
                                      .insert(request)
                                  : await _employeePositionProvider.update(
                                      widget.id!, request);

                              if (context.mounted) Navigator.pop(context);
                            }
                          },
                        ),
                      ),
                    if (_allowedActions.contains(EmploymentStatus.active))
                      Padding(
                        padding: const EdgeInsets.all(20),
                        child: ElevatedButton(
                          child: const Text("AKTIVIRAJ",
                              textAlign: TextAlign.center),
                          onPressed: () async {},
                        ),
                      ),
                    if (_allowedActions.contains(EmploymentStatus.inactive))
                      Padding(
                        padding: const EdgeInsets.all(20),
                        child: ElevatedButton(
                          child: const Text("DEAKTIVIRAJ",
                              textAlign: TextAlign.center),
                          onPressed: () async {},
                        ),
                      ),
                    if (_allowedActions.contains(EmploymentStatus.deleted))
                      Padding(
                        padding: const EdgeInsets.all(20),
                        child: ElevatedButton(
                          child:
                              const Text("OBRIŠI", textAlign: TextAlign.center),
                          onPressed: () async {},
                        ),
                      ),
                  ],
                ),
              ),
            ),
    );
  }
}
