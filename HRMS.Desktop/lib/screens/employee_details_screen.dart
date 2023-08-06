import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:form_builder_validators/form_builder_validators.dart';
import 'package:provider/provider.dart';

import '../models/city.dart';
import '../models/country.dart';
import '../models/education.dart';
import '../models/employee.dart';
import '../models/paged_result.dart';
import '../providers/city_provider.dart';
import '../providers/country_provider.dart';
import '../providers/education_provider.dart';
import '../providers/employee_provider.dart';
import '../widgets/responsive.dart';

class EmployeeDetailsScreen extends StatefulWidget {
  final int? id;

  const EmployeeDetailsScreen(this.id, {super.key});

  @override
  State<EmployeeDetailsScreen> createState() => _EmployeeDetailsScreenState();
}

class _EmployeeDetailsScreenState extends State<EmployeeDetailsScreen> {
  late EmployeeProvider _employeeProvider;
  late CityProvider _cityProvider;
  late CountryProvider _countryProvider;
  late EducationProvider _educationProvider;
  late Employee? _employee;

  final _formKey = GlobalKey<FormBuilderState>();
  var _cities = PagedResult<City>();
  var _countries = PagedResult<Country>();
  var _educations = PagedResult<Education>();

  @override
  void initState() {
    super.initState();

    _employeeProvider = context.read<EmployeeProvider>();
    _cityProvider = context.read<CityProvider>();
    _countryProvider = context.read<CountryProvider>();
    _educationProvider = context.read<EducationProvider>();

    _loadData(widget.id);
  }

  Future _loadData(int? id) async {
    _cities = await _cityProvider.getAll();
    _countries = await _countryProvider.getAll();
    _educations = await _educationProvider.getAll();

    if (id != null) {
      var employee = await _employeeProvider.get(id);

      _formKey.currentState?.patchValue({
        "firstName": employee.firstName,
        "lastName": employee.lastName,
        "maidenName": employee.maidenName,
        "parentName": employee.parentName,
        "gender": employee.gender.index,
        "registrationNumber": employee.registrationNumber,
        "personalIdentificationNumber": employee.personalIdentificationNumber,
        "workerCode": employee.workerCode,
        "birthDate": employee.birthDate,
        "birthPlaceId": employee.city?.id ?? 0,
        "address": employee.address,
        "cityId": employee.city?.id.toString() ?? "0",
        "citizenshipId": employee.citizenship?.id.toString() ?? "0",
        "email": employee.email,
        "phone": employee.phone,
        "mobile": employee.mobile,
        "officePhone": employee.officePhone,
        "profession": employee.profession,
        "education": employee.education?.id.toString() ?? "0",
        "bankAccount": employee.bankAccount,
        "note": employee.note,
      });
    }

    setState(() {});
  }

  @override
  Widget build(BuildContext context) {
    return SingleChildScrollView(
      child: FormBuilder(
        key: _formKey,
        child: SizedBox(
          child: Row(
            children: [
              Expanded(
                child: Column(
                  children: [
                    _basicInfo(context),
                    if (Responsive.isMobile(context)) _accountInfo(context),
                    _contactInfo(context),
                    _otherInfo(context),
                  ],
                ),
              ),
              if (!Responsive.isMobile(context))
                SizedBox(
                  width: 400,
                  child: _accountInfo(context),
                )
            ],
          ),
        ),
      ),
    );
  }

  Widget _basicInfo(BuildContext context) {
    return Card(
      elevation: 2,
      child: Column(
        children: [
          Card(
            margin: const EdgeInsets.all(10),
            color: Theme.of(context).primaryColor,
            child: const SizedBox(
              width: 200,
              height: 30,
              child: Text(
                "Osnovni podaci",
                textAlign: TextAlign.center,
                style: TextStyle(color: Colors.white, fontSize: 20),
              ),
            ),
          ),
          SizedBox(
            height: 500,
            child: GridView.count(
              crossAxisCount: Responsive.isDesktop(context)
                  ? 3
                  : Responsive.isTablet(context)
                      ? 2
                      : 1,
              padding: const EdgeInsets.all(20),
              childAspectRatio: 4,
              crossAxisSpacing: 20,
              children: [
                Align(
                  alignment: Alignment.bottomCenter,
                  child: FormBuilderTextField(
                    name: "workerCode",
                    decoration:
                        const InputDecoration(labelText: "Šifra radnika"),
                  ),
                ),
                if (Responsive.isTablet(context) ||
                    Responsive.isDesktop(context))
                  const SizedBox(),
                if (Responsive.isDesktop(context)) const SizedBox(),
                Align(
                  alignment: Alignment.bottomCenter,
                  child: FormBuilderTextField(
                    name: "firstName",
                    decoration: const InputDecoration(labelText: "Ime *"),
                    validator: FormBuilderValidators.required(
                        errorText: "Ime je obavezno."),
                  ),
                ),
                Align(
                  alignment: Alignment.bottomCenter,
                  child: FormBuilderTextField(
                    name: "lastName",
                    decoration: const InputDecoration(labelText: "Prezime *"),
                    validator: FormBuilderValidators.required(
                        errorText: "Prezime je obavezno."),
                  ),
                ),
                if (Responsive.isDesktop(context)) const SizedBox(),
                Align(
                  alignment: Alignment.bottomCenter,
                  child: FormBuilderTextField(
                    name: "parentName",
                    decoration:
                        const InputDecoration(labelText: "Ime roditelja"),
                  ),
                ),
                Align(
                  alignment: Alignment.bottomCenter,
                  child: FormBuilderTextField(
                    name: "maidenName",
                    decoration:
                        const InputDecoration(labelText: "Djevojačko prezime"),
                  ),
                ),
                if (Responsive.isDesktop(context)) const SizedBox(),
                Align(
                  alignment: Alignment.bottomCenter,
                  child: FormBuilderTextField(
                    name: "registrationNumber",
                    decoration:
                        const InputDecoration(labelText: "Matični broj *"),
                    validator: FormBuilderValidators.required(
                        errorText: "Matični broj je obavezan."),
                  ),
                ),
                Align(
                  alignment: Alignment.bottomCenter,
                  child: FormBuilderTextField(
                    name: "personalIdentificationNumber",
                    decoration: const InputDecoration(labelText: "LIB/OIB"),
                  ),
                ),
                Align(
                  alignment: Alignment.bottomCenter,
                  child: FormBuilderDropdown(
                    name: "gender",
                    decoration: const InputDecoration(labelText: "Spol *"),
                    validator: FormBuilderValidators.required(
                        errorText: "Spol je obavezan."),
                    items: const [
                      DropdownMenuItem(
                        value: 0,
                        child: Text("Muško"),
                      ),
                      DropdownMenuItem(
                        value: 1,
                        child: Text("Žensko"),
                      ),
                    ],
                  ),
                ),
                Align(
                  alignment: Alignment.bottomCenter,
                  child: FormBuilderDateTimePicker(
                    name: "birthDate",
                    inputType: InputType.date,
                    decoration:
                        const InputDecoration(labelText: "Datum rođenja *"),
                    validator: FormBuilderValidators.required(
                        errorText: "Datum rođenja je obavezan."),
                  ),
                ),
                Align(
                  alignment: Alignment.bottomCenter,
                  child: FormBuilderDropdown(
                    name: "birthPlaceId",
                    decoration:
                        const InputDecoration(labelText: "Mjesto rođenja *"),
                    validator: FormBuilderValidators.required(
                        errorText: "Mjesto rođenja je obavezno."),
                    items: _cities.result
                        .map((city) => DropdownMenuItem(
                              value: city.id,
                              child: Text(city.name),
                            ))
                        .toList(),
                  ),
                ),
                if (Responsive.isDesktop(context)) const SizedBox(),
                Align(
                  alignment: Alignment.bottomCenter,
                  child: FormBuilderTextField(
                    name: "bankAccount",
                    decoration: const InputDecoration(labelText: "Žiro račun"),
                  ),
                ),
              ],
            ),
          ),
        ],
      ),
    );
  }

  Widget _accountInfo(BuildContext context) {
    return Card(
      elevation: 2,
      child: Column(
        children: [
          Card(
            margin: const EdgeInsets.all(10),
            color: Theme.of(context).primaryColor,
            child: const SizedBox(
              width: 200,
              height: 30,
              child: Text(
                "Podaci o profilu",
                textAlign: TextAlign.center,
                style: TextStyle(color: Colors.white, fontSize: 20),
              ),
            ),
          ),
          FormBuilderTextField(
            name: "email",
            decoration: const InputDecoration(labelText: "E-mail *"),
            validator: FormBuilderValidators.required(
                errorText: "E-mail je obavezan."),
          ),
          ElevatedButton(
            child: const Text("Potvrdi email"),
            onPressed: () => {setState(() {})},
          ),
          ElevatedButton(
            child: const Text("Otključaj"),
            onPressed: () => {},
          ),
          ElevatedButton(
            child: const Text("Resetuj lozinku"),
            onPressed: () => {},
          ),
        ],
      ),
    );
  }

  Widget _contactInfo(BuildContext context) {
    return Card(
      elevation: 2,
      child: Column(
        children: [
          Card(
            margin: const EdgeInsets.all(10),
            color: Theme.of(context).primaryColor,
            child: const SizedBox(
              width: 200,
              height: 30,
              child: Text(
                "Kontakt podaci",
                textAlign: TextAlign.center,
                style: TextStyle(color: Colors.white, fontSize: 20),
              ),
            ),
          ),
          SizedBox(
            height: 200,
            child: GridView.count(
              crossAxisCount: Responsive.isDesktop(context)
                  ? 3
                  : Responsive.isTablet(context)
                      ? 2
                      : 1,
              padding: const EdgeInsets.all(20),
              childAspectRatio: 4,
              crossAxisSpacing: 20,
              children: [
                Align(
                  alignment: Alignment.bottomCenter,
                  child: FormBuilderTextField(
                    name: "address",
                    decoration: const InputDecoration(labelText: "Adresa"),
                  ),
                ),
                Align(
                  alignment: Alignment.bottomCenter,
                  child: FormBuilderDropdown(
                    name: "cityId",
                    decoration: const InputDecoration(labelText: "Grad"),
                    items: _cities.result
                        .map((city) => DropdownMenuItem(
                              value: city.id.toString(),
                              child: Text(city.name),
                            ))
                        .toList(),
                  ),
                ),
                Align(
                  alignment: Alignment.bottomCenter,
                  child: FormBuilderDropdown(
                    name: "citizenshipId",
                    decoration:
                        const InputDecoration(labelText: "Državljanstvo"),
                    items: _countries.result
                        .map((country) => DropdownMenuItem(
                              value: country.id.toString(),
                              child: Text(country.name),
                            ))
                        .toList(),
                  ),
                ),
                Align(
                  alignment: Alignment.bottomCenter,
                  child: FormBuilderTextField(
                    name: "phone",
                    decoration: const InputDecoration(labelText: "Telefon"),
                  ),
                ),
                Align(
                  alignment: Alignment.bottomCenter,
                  child: FormBuilderTextField(
                    name: "mobile",
                    decoration: const InputDecoration(labelText: "Mobitel"),
                  ),
                ),
                Align(
                  alignment: Alignment.bottomCenter,
                  child: FormBuilderTextField(
                    name: "officePhone",
                    decoration:
                        const InputDecoration(labelText: "Službeni telefon"),
                  ),
                ),
              ],
            ),
          ),
        ],
      ),
    );
  }

  Widget _otherInfo(BuildContext context) {
    return Card(
      elevation: 2,
      child: Column(
        children: [
          Card(
            margin: const EdgeInsets.all(10),
            color: Theme.of(context).primaryColor,
            child: const SizedBox(
              width: 200,
              height: 30,
              child: Text(
                "Ostali podaci",
                textAlign: TextAlign.center,
                style: TextStyle(color: Colors.white, fontSize: 20),
              ),
            ),
          ),
          SizedBox(
            height: 130,
            child: GridView.count(
              crossAxisCount: Responsive.isDesktop(context)
                  ? 3
                  : Responsive.isTablet(context)
                      ? 2
                      : 1,
              padding: const EdgeInsets.all(20),
              childAspectRatio: 4,
              crossAxisSpacing: 20,
              children: [
                Align(
                  alignment: Alignment.bottomCenter,
                  child: FormBuilderTextField(
                    name: "profession",
                    decoration: const InputDecoration(labelText: "Zanimanje"),
                  ),
                ),
                Align(
                  alignment: Alignment.bottomCenter,
                  child: FormBuilderDropdown(
                    name: "educationId",
                    decoration: const InputDecoration(labelText: "Obrazovanje"),
                    items: _educations.result
                        .map((education) => DropdownMenuItem(
                              value: education.id.toString(),
                              child: Text(education.qualificationOld),
                            ))
                        .toList(),
                  ),
                ),
                Align(
                  alignment: Alignment.bottomCenter,
                  child: FormBuilderTextField(
                    name: "note",
                    decoration: const InputDecoration(labelText: "Bilješka"),
                  ),
                ),
              ],
            ),
          )
        ],
      ),
    );
  }
}
