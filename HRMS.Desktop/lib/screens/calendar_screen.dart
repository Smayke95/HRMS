import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:form_builder_validators/form_builder_validators.dart';
import 'package:intl/intl.dart';
import 'package:provider/provider.dart';
import 'package:syncfusion_flutter_calendar/calendar.dart';

import '../data_table_sources/event_data_table_source.dart';
import '../models/employee.dart';
import '../models/event.dart';
import '../models/event_type.dart';
import '../models/paged_result.dart';
import '../models/searches/event_search.dart';
import '../models/user.dart';
import '../providers/employee_provider.dart';
import '../providers/event_provider.dart';
import '../providers/event_type_provider.dart';
import '../widgets/responsive.dart';

class CalendarScreen extends StatefulWidget {
  const CalendarScreen({super.key});

  @override
  State<CalendarScreen> createState() => _CalendarScreenState();
}

class _CalendarScreenState extends State<CalendarScreen> {
  late EmployeeProvider _employeeProvider;
  late EventProvider _eventProvider;
  late EventTypeProvider _eventTypeProvider;

  late EventDataTableSource eventDataTableSource;

  final _formKey = GlobalKey<FormBuilderState>();
  var _employees = PagedResult<Employee>();
  var _eventTypes = PagedResult<EventType>();

  @override
  void initState() {
    super.initState();

    _employeeProvider = context.read<EmployeeProvider>();
    _eventProvider = context.read<EventProvider>();
    _eventTypeProvider = context.read<EventTypeProvider>();

    _loadData(null, null);
  }

  Future _loadData(int? id, DateTime? selectedDate) async {
    _employees = await _employeeProvider.getAll();
    _eventTypes = await _eventTypeProvider.getAll();

    if (id != null) {
      var event = await _eventProvider.get(id);

      _formKey.currentState?.patchValue({
        "name": event.name,
        "description": event.description,
        "startDate": event.startDate,
        "endDate": event.endDate,
        "eventTypeId": event.eventType?.id.toString() ?? "0",
        "employeeId": event.employee?.id.toString() ?? "0",
      });
    } else {
      _formKey.currentState?.patchValue({
        "startDate": selectedDate,
        "endDate": selectedDate,
      });
    }

    if (!User.roles.contains("Admin")) {
      _formKey.currentState?.patchValue({"employeeId": User.id.toString()});
    }
  }

  void _openDialog(int? id, DateTime? selectedDate) {
    if (Responsive.isMobile(context)) return;

    showDialog(
      context: context,
      builder: (BuildContext context) =>
          _buildDialog(context, id, selectedDate),
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
          return Text("Error: ${snapshot.error}");
        } else if (!snapshot.hasData || snapshot.data?.result == null) {
          return const Text("Podaci nisu dostupni.");
        } else {
          return FutureBuilder<PagedResult<EventType>>(
            future: _eventTypeProvider.getAll(),
            builder: (context, snapshotEventTypes) {
              if (snapshotEventTypes.connectionState ==
                  ConnectionState.waiting) {
                return const CircularProgressIndicator();
              } else if (snapshotEventTypes.hasError) {
                return Text("Error: ${snapshotEventTypes.error}");
              } else if (!snapshotEventTypes.hasData ||
                  snapshotEventTypes.data?.result == null) {
                return const Text("Podaci nisu dostupni");
              } else {
                bool isMobile = Responsive.isMobile(context);

                if (isMobile) {
                  return Column(
                    children: [
                      SizedBox(
                        width: 900,
                        height: 500,
                        child: SfCalendar(
                          view: CalendarView.month,
                          firstDayOfWeek: 1,
                          dataSource:
                              EventDataTableSource(snapshot.data!.result),
                          monthViewSettings: const MonthViewSettings(
                            appointmentDisplayMode:
                                MonthAppointmentDisplayMode.appointment,
                          ),
                          onTap: (CalendarTapDetails details) {
                            if (details.targetElement ==
                                CalendarElement.calendarCell) {
                              var selectedDate = details.date!;
                              _openDialog(null, selectedDate);
                            }

                            if (details.targetElement ==
                                CalendarElement.appointment) {
                              int id = details.appointments?[0].id;
                              _openDialog(id, null);
                            }
                          },
                        ),
                      ),
                      const SizedBox(height: 30),
                      Container(
                        width: double.infinity,
                        padding: const EdgeInsets.all(16),
                        decoration: BoxDecoration(
                          border: Border.all(
                              color: const Color.fromARGB(255, 185, 185, 185)),
                          borderRadius: BorderRadius.circular(8),
                        ),
                        child: Column(
                          crossAxisAlignment: CrossAxisAlignment.start,
                          children: [
                            ElevatedButton.icon(
                              icon: const Icon(Icons.add),
                              style: const ButtonStyle(
                                padding: MaterialStatePropertyAll(
                                    EdgeInsets.only(
                                        left: 15,
                                        top: 15,
                                        right: 20,
                                        bottom: 15)),
                              ),
                              label: const Text("Dodaj događaj"),
                              onPressed: () => _openDialog(null, null),
                            ),
                            const SizedBox(height: 50),
                            const Text(
                              'Legenda',
                              style: TextStyle(
                                color: Color.fromARGB(255, 95, 95, 95),
                                fontSize: 18,
                                fontWeight: FontWeight.bold,
                              ),
                            ),
                            const SizedBox(height: 10),
                            Column(
                              crossAxisAlignment: CrossAxisAlignment.start,
                              children:
                                  snapshotEventTypes.data!.result.map((type) {
                                return Column(
                                  children: [
                                    Row(
                                      children: [
                                        Container(
                                          width: 20,
                                          height: 20,
                                          decoration: BoxDecoration(
                                            shape: BoxShape.circle,
                                            boxShadow: const [
                                              BoxShadow(
                                                color: Colors.grey,
                                                offset: Offset(0, 2),
                                                blurRadius: 4.0,
                                                spreadRadius: 0.0,
                                              ),
                                            ],
                                            color: Color(int.parse(type.color
                                                .replaceAll("#", "0xff"))),
                                          ),
                                        ),
                                        const SizedBox(width: 8),
                                        Text(type.name),
                                      ],
                                    ),
                                    const SizedBox(height: 8),
                                  ],
                                );
                              }).toList(),
                            ),
                          ],
                        ),
                      ),
                    ],
                  );
                } else {
                  return Row(
                    children: [
                      SizedBox(
                        width: 900,
                        child: SfCalendar(
                          view: CalendarView.month,
                          firstDayOfWeek: 1,
                          dataSource:
                              EventDataTableSource(snapshot.data!.result),
                          monthViewSettings: const MonthViewSettings(
                            appointmentDisplayMode:
                                MonthAppointmentDisplayMode.appointment,
                          ),
                          onTap: (CalendarTapDetails details) {
                            if (details.targetElement ==
                                CalendarElement.calendarCell) {
                              var selectedDate = details.date!;
                              _openDialog(null, selectedDate);
                            }

                            if (details.targetElement ==
                                CalendarElement.appointment) {
                              int id = details.appointments?[0].id;
                              _openDialog(id, null);
                            }
                          },
                        ),
                      ),
                      const SizedBox(width: 50),
                      Container(
                        width: 200,
                        padding: const EdgeInsets.all(16),
                        decoration: BoxDecoration(
                          border: Border.all(
                              color: const Color.fromARGB(255, 185, 185, 185)),
                          borderRadius: BorderRadius.circular(8),
                        ),
                        child: Column(
                          crossAxisAlignment: CrossAxisAlignment.start,
                          children: [
                            ElevatedButton.icon(
                              icon: const Icon(Icons.add),
                              style: const ButtonStyle(
                                padding: MaterialStatePropertyAll(
                                    EdgeInsets.only(
                                        left: 15,
                                        top: 15,
                                        right: 20,
                                        bottom: 15)),
                              ),
                              label: const Text("Dodaj događaj"),
                              onPressed: () => _openDialog(null, null),
                            ),
                            const SizedBox(height: 50),
                            const Text(
                              'Legenda',
                              style: TextStyle(
                                color: Color.fromARGB(255, 95, 95, 95),
                                fontSize: 18,
                                fontWeight: FontWeight.bold,
                              ),
                            ),
                            const SizedBox(height: 10),
                            Column(
                              crossAxisAlignment: CrossAxisAlignment.start,
                              children:
                                  snapshotEventTypes.data!.result.map((type) {
                                return Column(
                                  children: [
                                    Row(
                                      children: [
                                        Container(
                                          width: 20,
                                          height: 20,
                                          decoration: BoxDecoration(
                                            shape: BoxShape.circle,
                                            boxShadow: const [
                                              BoxShadow(
                                                color: Colors.grey,
                                                offset: Offset(0, 2),
                                                blurRadius: 4.0,
                                                spreadRadius: 0.0,
                                              ),
                                            ],
                                            color: Color(int.parse(type.color
                                                .replaceAll("#", "0xff"))),
                                          ),
                                        ),
                                        const SizedBox(width: 8),
                                        Text(type.name),
                                      ],
                                    ),
                                    const SizedBox(height: 8),
                                  ],
                                );
                              }).toList(),
                            ),
                          ],
                        ),
                      ),
                    ],
                  );
                }
              }
            },
          );
        }
      },
    );
  }

  Widget _buildDialog(BuildContext context, int? id, DateTime? selectedDate) {
    _loadData(id, selectedDate);

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
                          decoration:
                              const InputDecoration(labelText: "Opis"))),
                ],
              ),
              const SizedBox(height: 20),
              Row(
                children: [
                  SizedBox(
                      width: 290,
                      child: FormBuilderDateTimePicker(
                        name: "startDate",
                        inputType: InputType.date,
                        format: DateFormat('dd.MM.yyyy.'),
                        decoration:
                            const InputDecoration(labelText: "Datum početka *"),
                        validator: FormBuilderValidators.required(
                            errorText: "Datum početka je obavezan."),
                      )),
                  const SizedBox(width: 20),
                  SizedBox(
                    width: 290,
                    child: FormBuilderDateTimePicker(
                      name: "endDate",
                      inputType: InputType.date,
                      format: DateFormat('dd.MM.yyyy.'),
                      decoration:
                          const InputDecoration(labelText: "Datum kraja *"),
                      validator: FormBuilderValidators.required(
                          errorText: "Datum kraja je obavezan."),
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
                  ),
                  const SizedBox(width: 20),
                  SizedBox(
                    width: 300,
                    child: FormBuilderDropdown(
                      name: "employeeId",
                      enabled: User.roles.contains("Admin"),
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

              await _loadData(null, null);
              setState(() {});

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

              await _loadData(null, null);
              setState(() {});
              if (context.mounted) Navigator.pop(context);
            }
          },
        ),
      ],
    );
  }
}
