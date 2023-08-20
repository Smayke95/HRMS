import 'package:advanced_datatable/datatable.dart';
import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:form_builder_validators/form_builder_validators.dart';
import 'package:provider/provider.dart';

import '../data_table_sources/city_data_table_source.dart';
import '../models/country.dart';
import '../models/paged_result.dart';
import '../providers/city_provider.dart';
import '../providers/country_provider.dart';
import '../widgets/responsive.dart';
import '../widgets/search.dart';

class CityListScreen extends StatefulWidget {
  const CityListScreen({super.key});

  @override
  State<CityListScreen> createState() => _CityListScreenState();
}

class _CityListScreenState extends State<CityListScreen> {
  late CityProvider _cityProvider;
  late CountryProvider _countryProvider;

  late CityDataTableSource cityDataTableSource;

  final _formKey = GlobalKey<FormBuilderState>();
  var _countries = PagedResult<Country>();

  @override
  void initState() {
    super.initState();

    _cityProvider = context.read<CityProvider>();
    _countryProvider = context.read<CountryProvider>();

    cityDataTableSource =
        CityDataTableSource(_cityProvider, _openDialog);

    _loadData(null);
  }

  Future _loadData(int? id) async {
    _countries = await _countryProvider.getAll();

    if (id != null) {
      var city = await _cityProvider.get(id);

      _formKey.currentState?.patchValue({
        "name": city.name, 
        "zipCode": city.zipCode, 
        "countryId": city.country?.id.toString() ?? "0"
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
    return Column(
      children: [
        Search(
          "Dodaj grad", 
          () => _openDialog(null),
          onSearch: (text) => cityDataTableSource.filterData(text)
        ),
        SizedBox(
          width: double.infinity,
          child: AdvancedPaginatedDataTable(
            addEmptyRows: false,
            showCheckboxColumn: false,
            source: cityDataTableSource,
            rowsPerPage: 7,
            columns: const [
              DataColumn(label: Text("Naziv")),
              DataColumn(label: Text("Poštanski broj")),
              DataColumn(label: Text("Država"))
            ],
          ),
        ),
      ],
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
            Text(id == null ? "Dodaj grad" : "Uredi grad"),
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
                    width: 500,
                    child: FormBuilderTextField(
                      name: "zipCode",
                      keyboardType: TextInputType.multiline,
                      maxLines: null,
                      decoration: const InputDecoration(labelText: "Poštanski broj"),                      
                    ),
                  ),
                ],
              ),
              const SizedBox(height: 20),
              Row(
                children: [
                  SizedBox(
                    width: 500,
                    child: FormBuilderDropdown(
                      name: "countryId",
                      decoration: const InputDecoration(labelText: "Država *"),
                      validator: FormBuilderValidators.required(
                          errorText: "Država je obavezna."),
                      items: _countries.result
                          .map((country) => DropdownMenuItem(
                                value: country.id.toString(),
                                child: Text(country.name),
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
              await _cityProvider.delete(id);
              cityDataTableSource.filterData(null);
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
                  ? await _cityProvider.insert(request)
                  : await _cityProvider.update(id, request);

              cityDataTableSource.filterData(null);
              if (context.mounted) Navigator.pop(context);
            }
          },
        ),
      ],
    );
  }
}
