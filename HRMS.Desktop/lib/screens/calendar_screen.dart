import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:form_builder_validators/form_builder_validators.dart';
import 'package:provider/provider.dart';
import 'package:syncfusion_flutter_calendar/calendar.dart';

import '../data_table_sources/event_data_table_source.dart';
import '../models/employee.dart';
import '../models/event.dart';
import '../models/paged_result.dart';
import '../models/searches/event_search.dart';
import '../models/user.dart';
import '../providers/employee_provider.dart';
import '../providers/event_provider.dart';
import '../widgets/responsive.dart';

class CalendarScreen extends StatefulWidget {
  const CalendarScreen({super.key});

  @override
  State<CalendarScreen> createState() => _CalendarScreenState();
}

class _CalendarScreenState extends State<CalendarScreen> {
  late EmployeeProvider _employeeProvider;
  late EventProvider _eventProvider;

  late EventDataTableSource eventDataTableSource;

  final _formKey = GlobalKey<FormBuilderState>();
  var _employees = PagedResult<Employee>();
  //var _events = PagedResult<Event>();

  @override
  void initState() {
    super.initState();

    _employeeProvider = context.read<EmployeeProvider>();
    _eventProvider = context.read<EventProvider>();

    _loadData(null);
  }

  Future _loadData(int? id) async {
    _employees = await _employeeProvider.getAll();

    if (id != null) {
      var event = await _eventProvider.get(id);

      _formKey.currentState?.patchValue({
        "name": event.name,
        "description": event.description,
        "startDate": event.startDate.toString(),
        "endDate": event.endDate.toString(),
        "eventTypeId": event.eventType?.id.toString() ?? "0",
        "employeeId": event.employee?.id.toString() ?? "0",
      });
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
    var eventSearch = EventSearch();
    eventSearch.employeeId = User.id;
    eventSearch.includeEventType = true;

    return FutureBuilder<PagedResult<Event>>(
      future: _eventProvider.getAll(search: eventSearch),
      builder: (context, snapshot) {
        if (snapshot.connectionState == ConnectionState.waiting) {
          return const CircularProgressIndicator();
        } else if (snapshot.hasError) {
          return Text(
              "Error: ${snapshot.error}");
        } else if (!snapshot.hasData || snapshot.data?.result == null) {
          return const Text(
              "Podaci nisu dostupni.");
        } else {
          return SfCalendar(
            view: CalendarView.month,
            firstDayOfWeek: 1,
            dataSource: EventDataTableSource(
                snapshot.data!.result), // Use fetched data.
            monthViewSettings: const MonthViewSettings(
              appointmentDisplayMode: MonthAppointmentDisplayMode.appointment,
            ),
          );
        }
      },
    );
  }

  Widget _buildDialog(BuildContext context, int? id) {
    _loadData(id);

    return AlertDialog(
      title: Align(
        alignment: Alignment.center,
        child: Row(
          mainAxisSize: MainAxisSize.min,
          children: [
            Icon(id == null ? Icons.add : Icons.edit),
            const SizedBox(width: 10),
            Text(id == null ? "Dodaj događaj" : "Uredi događaj"),
          ],
        ),
      ),
      content: FormBuilder(
        key: _formKey,
        child: SizedBox(
          height: 450,
          child: Column(
            children: [
              Row(
                children: [
                  SizedBox(
                    width: 600,
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
                    width: 600,
                    child: FormBuilderTextField(
                      name: "description",
                      keyboardType: TextInputType.multiline,
                      maxLines: null,
                      decoration: const InputDecoration(labelText: "Opis *"),
                      validator: FormBuilderValidators.required(
                          errorText: "Opis je obavezan."),
                    ),
                  ),
                ],
              ),
              const SizedBox(height: 20),
              Row(
                children: [
                  SizedBox(
                    width: 300,
                    child: FormBuilderTextField(
                      name: "startDate",
                      keyboardType: TextInputType.multiline,
                      maxLines: null,
                      decoration: const InputDecoration(labelText: "Početak *"),
                      validator: FormBuilderValidators.required(
                          errorText: "Datum početka događaja je obavezan."),
                    ),
                  ),
                  const SizedBox(width: 20),
                  SizedBox(
                    width: 300,
                    child: FormBuilderTextField(
                      name: "endDate",
                      keyboardType: TextInputType.multiline,
                      maxLines: null,
                      decoration: const InputDecoration(labelText: "Kraj *"),
                      validator: FormBuilderValidators.required(
                          errorText: "Datum kraja događaja je obavezan."),
                    ),
                  ),
                ],
              ),
              const SizedBox(height: 20),
              Row(
                children: [
                  /*SizedBox(
                    width: 300,
                    child: FormBuilderDropdown(
                      name: "eventTypeId",
                      decoration: const InputDecoration(labelText: "Vrsta *"),
                      validator: FormBuilderValidators.required(
                          errorText: "Vrsta događaja je obavezna."),
                      items: _eventTypes.result
                          .map((type) => DropdownMenuItem(
                                value: type.id.toString(),
                                child: Text(type.name),
                              ))
                          .toList(),
                    ),
                  ),*/
                  const SizedBox(width: 20),
                  SizedBox(
                    width: 300,
                    child: FormBuilderDropdown(
                      name: "employeeId",
                      decoration:
                          const InputDecoration(labelText: "Zaposlenik *"),
                      validator: FormBuilderValidators.required(
                          errorText: "Zaposlenik je obavezan."),
                      items: _employees.result
                          .map((employee) => DropdownMenuItem(
                                value: employee.id.toString(),
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
              await _eventProvider.delete(id);
              //eventDataTableSource.filterData(null);
              if (context.mounted) Navigator.pop(context);
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
                  ? await _eventProvider.insert(request)
                  : await _eventProvider.update(id, request);

              //eventDataTableSource.filterData(null);
              if (context.mounted) Navigator.pop(context);
            }
          },
        ),
      ],
    );
  }
}
