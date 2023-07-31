import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

import '../models/city.dart';
import '../models/country.dart';
import '../models/paged_result.dart';
import '../providers/city_provider.dart';
import '../providers/country_provider.dart';
import '../widgets/master_screen.dart';
import 'city_list_screen.dart';
import 'country_list_screen.dart';

class SettingsScreen extends StatefulWidget {
  const SettingsScreen({super.key});

  @override
  State<SettingsScreen> createState() => _SettingsScreenState();
}

class _SettingsScreenState extends State<SettingsScreen> {
  late CityProvider _cityProvider;
  late CountryProvider _countryProvider;

  var _cities = PagedResult<City>();
  var _countries = PagedResult<Country>();

 @override
  void initState() {
    super.initState();

    _cityProvider = context.read<CityProvider>();
    _countryProvider = context.read<CountryProvider>(); 
   
    _loadData(null);
  }

  Future _loadData(int? id) async {
    _cities = await _cityProvider.getAll();
    _countries = await _countryProvider.getAll();
  }

  @override
  Widget build(BuildContext context) {
    return Column(children: [
      const Text(
        'Održavanje tabela',
        textAlign: TextAlign.center,
        style: TextStyle(fontSize: 24),
      ),
      const SizedBox(height: 30),
      FutureBuilder(
        future: _loadData(null),
        builder: (context, snapshot) {
          if (snapshot.connectionState == ConnectionState.waiting) {
            return const CircularProgressIndicator();
          } else {
            return Center(
              child: Row(
                mainAxisAlignment: MainAxisAlignment.center,
                children: [
                  _buildSettingsBoxContainer(
                    context,
                    "Gradovi",
                    _cities.totalCount.toString(),
                    const CityListScreen(),
                  ),
                  const SizedBox(width: 16),
                  _buildSettingsBoxContainer(
                    context,
                    "Države",
                    _countries.totalCount.toString(),
                    const CountryListScreen(),
                  ),
                ],
              ),
            );
          }
        },
      ),
    ]);
  }
}

Container _buildSettingsBoxContainer(
    BuildContext context,
    String title,
    String items,
    Widget screen,
  ) {
    return Container(
      width: 200,
      padding: const EdgeInsets.all(16.0),
      decoration: BoxDecoration(
        border: Border.all(color: Colors.black, width: 1.0),
        borderRadius: BorderRadius.circular(8.0),
      ),
      child: Column(
        mainAxisSize: MainAxisSize.min,
        children: [
          Text(
            title,
            style: const TextStyle(fontSize: 18),
          ),
          const SizedBox(height: 16),
          Text(
            items,
            style: const TextStyle(fontSize: 18),
          ),
          const SizedBox(height: 16),
          ElevatedButton(
            onPressed: () {
             Navigator.of(context).pushReplacement(MaterialPageRoute(
                builder: (context) => MasterScreen(title, screen)));
            },
            child: const Text('UREDI'),
          ),
        ],
      ),
    );
  }
