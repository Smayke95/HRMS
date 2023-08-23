import 'package:advanced_datatable/datatable.dart';
import 'package:flutter/material.dart';
import 'package:flutter_colorpicker/flutter_colorpicker.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:form_builder_validators/form_builder_validators.dart';
import 'package:provider/provider.dart';

import '../data_table_sources/event_type_data_table_source.dart';
import '../providers/event_type_provider.dart';
import '../widgets/responsive.dart';
import '../widgets/search.dart';

class EventTypeListScreen extends StatefulWidget {
  const EventTypeListScreen({super.key});

  @override
  State<EventTypeListScreen> createState() => _EventTypeListScreenState();
}

class _EventTypeListScreenState extends State<EventTypeListScreen> {
  late EventTypeProvider _eventTypeProvider;

  late EventTypeDataTableSource eventTypeDataTableSource;
  late FocusNode _focusNode;

  final _formKey = GlobalKey<FormBuilderState>();
  Color currentColor = const Color(0xff0175C2);

  @override
  void initState() {
    super.initState();

    _focusNode = FocusNode();
    _eventTypeProvider = context.read<EventTypeProvider>();

    eventTypeDataTableSource =
        EventTypeDataTableSource(_eventTypeProvider, _openDialog);

    _loadData(null);
  }

  Future _loadData(int? id) async {
    if (id != null) {
      var eventType = await _eventTypeProvider.get(id);

      var rgbColor = eventType.color.replaceFirst('#', '0xff');
      currentColor = Color(int.parse(rgbColor != "" ? rgbColor : "0xfffff"));

      _formKey.currentState?.patchValue({"name": eventType.name});
      _formKey.currentState
          ?.patchValue({"isApprovalRequired": eventType.isApprovalRequired});
      _formKey.currentState?.patchValue({"color": eventType.color});
    }
  }

  void _openDialog(int? id) {
    if (Responsive.isMobile(context)) return;

    WidgetsBinding.instance.addPostFrameCallback((_) {
      _focusNode.requestFocus();
    });

    _loadData(id).then((data) {
      showDialog(
        context: context,
        builder: (BuildContext context) => _buildDialog(context, id),
      );
    });
  }

  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        Search("Dodaj tip događaja", () => _openDialog(null),
            onSearch: (text) => eventTypeDataTableSource.filterData(text)),
        SizedBox(
          width: double.infinity,
          child: AdvancedPaginatedDataTable(
            showHorizontalScrollbarAlways: Responsive.isMobile(context),
            addEmptyRows: false,
            showCheckboxColumn: false,
            source: eventTypeDataTableSource,
            rowsPerPage: 7,
            columns: const [
              DataColumn(label: Text("Naziv")),
              DataColumn(label: Text("Da li je potrebno odobrenje?")),
              DataColumn(label: Text("Boja"))
            ],
          ),
        ),
      ],
    );
  }

  Widget _buildDialog(BuildContext context, int? id) {
    _loadData(id);

    if (id == null) currentColor = Colors.white;

    return StatefulBuilder(builder: (context, setState) {
      return AlertDialog(
        title: Align(
          alignment: Alignment.center,
          child: Row(
            mainAxisSize: MainAxisSize.min,
            children: [
              Icon(id == null ? Icons.add : Icons.edit),
              const SizedBox(width: 10),
              Text(id == null ? "Dodaj tip" : "Uredi tip"),
            ],
          ),
        ),
        content: FormBuilder(
          key: _formKey,
          child: SizedBox(
            height: 300,
            child: Column(
              children: [
                Row(
                  children: [
                    SizedBox(
                      width: 500,
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
                      width: 250,
                      child: Column(
                        children: [
                          FormBuilderTextField(
                            name: "color",
                            focusNode: _focusNode,
                            decoration: InputDecoration(
                              border: InputBorder.none,
                              prefix: Align(
                                alignment: Alignment.center,
                                child: Padding(
                                  padding: const EdgeInsets.only(right: 8.0),
                                  child: Container(
                                    width: 50,
                                    height: 50,
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
                                      color: currentColor,
                                    ),
                                  ),
                                ),
                              ),
                            ),
                          ),                         
                          const SizedBox(height: 10),
                          OutlinedButton(
                            style: const ButtonStyle(
                              padding: MaterialStatePropertyAll(
                                EdgeInsets.only(
                                    left: 20, top: 15, right: 20, bottom: 15),
                              ),
                            ),
                            child: const Text("Izaberi boju *"),
                            onPressed: () => showDialog(
                                context: context,
                                builder: (context) => AlertDialog(
                                    title: const Text("Izaberi boju"),
                                    content: Column(
                                        mainAxisSize: MainAxisSize.min,
                                        children: [
                                          ColorPicker(
                                              pickerColor: currentColor,
                                              enableAlpha: false,
                                              labelTypes: const [],
                                              onColorChanged: (newColor) => {
                                                    setState(() {
                                                      currentColor = newColor;
                                                      _formKey.currentState!
                                                          .patchValue({
                                                        'color':
                                                            '#${newColor.value.toRadixString(16).replaceAll("ff", "")}'
                                                      });
                                                    })
                                                  }),
                                          const SizedBox(height: 20),
                                          TextButton(
                                            child: const Text("IZABERI"),
                                            onPressed: () =>
                                                Navigator.pop(context),
                                          )
                                        ]))),
                          ),
                        ],
                      ),
                    ),
                    const SizedBox(width: 20),
                    SizedBox(
                      width: 250,
                      child: FormBuilderCheckbox(
                        name: "isApprovalRequired",
                        title: const Text("Da li je potrebno odobrenje?"),
                        initialValue: false,
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
                  await _eventTypeProvider.delete(id);
                  eventTypeDataTableSource.filterData(null);
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
                                "* Ne možete obrisati ovaj tip događaja.",
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
                    ? await _eventTypeProvider.insert(request)
                    : await _eventTypeProvider.update(id, request);

                eventTypeDataTableSource.filterData(null);
                if (context.mounted) Navigator.pop(context);
              }
            },
          ),
        ],
      );
    });
  }
}
