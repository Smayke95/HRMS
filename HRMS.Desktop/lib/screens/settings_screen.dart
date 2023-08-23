import 'package:HRMS/screens/task_status_list_screen.dart';
import 'package:HRMS/screens/task_type_list_screen.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

import '../models/city.dart';
import '../models/country.dart';
import '../models/event_type.dart';
import '../models/paged_result.dart';
import '../models/task_status.dart';
import '../models/task_type.dart';
import '../providers/city_provider.dart';
import '../providers/country_provider.dart';
import '../providers/event_type_provider.dart';
import '../providers/task_status_provider.dart';
import '../providers/task_type_provider.dart';
import '../widgets/master_screen.dart';
import '../widgets/responsive.dart';
import 'city_list_screen.dart';
import 'country_list_screen.dart';
import 'event_type_list_screen.dart';

class SettingsScreen extends StatefulWidget {
  const SettingsScreen({super.key});

  @override
  State<SettingsScreen> createState() => _SettingsScreenState();
}

class _SettingsScreenState extends State<SettingsScreen> {
  late CityProvider _cityProvider;
  late CountryProvider _countryProvider;
  late TaskStatusProvider _taskStatusProvider;
  late TaskTypeProvider _taskTypeProvider;
  late EventTypeProvider _eventTypeProvider;

  var _cities = PagedResult<City>();
  var _countries = PagedResult<Country>();
  var _taskStatuses = PagedResult<TaskStatus>();
  var _taskTypes = PagedResult<TaskType>();
  var _eventTypes = PagedResult<EventType>();

  @override
  void initState() {
    super.initState();

    _cityProvider = context.read<CityProvider>();
    _countryProvider = context.read<CountryProvider>();
    _taskStatusProvider = context.read<TaskStatusProvider>();
    _taskTypeProvider = context.read<TaskTypeProvider>();
    _eventTypeProvider = context.read<EventTypeProvider>();

    _loadData(null);
  }

  Future _loadData(int? id) async {
    _cities = await _cityProvider.getAll();
    _countries = await _countryProvider.getAll();
    _taskStatuses = await _taskStatusProvider.getAll();
    _taskTypes = await _taskTypeProvider.getAll();
    _eventTypes = await _eventTypeProvider.getAll();
  }

  @override
  Widget build(BuildContext context) {
    return SingleChildScrollView(
      child: Column(
        children: [
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
                if (Responsive.isMobile(context)) {
                  return Column(
                    children: [
                      _buildSettingsBoxContainer(
                        context,
                        "Gradovi",
                        _cities.totalCount.toString(),
                        const CityListScreen(),
                      ),
                      const SizedBox(height: 16),
                      _buildSettingsBoxContainer(
                        context,
                        "Države",
                        _countries.totalCount.toString(),
                        const CountryListScreen(),
                      ),
                      const SizedBox(height: 16),
                      _buildSettingsBoxContainer(
                        context,
                        "Statusi na zadacima",
                        _taskStatuses.totalCount.toString(),
                        const TaskStatusListScreen(),
                      ),
                      const SizedBox(height: 16),
                      _buildSettingsBoxContainer(
                        context,
                        "Tipovi zadataka",
                        _taskTypes.totalCount.toString(),
                        const TaskTypeListScreen(),
                      ),
                      const SizedBox(height: 16),
                      _buildSettingsBoxContainer(
                        context,
                        "Tipovi događaja",
                        _eventTypes.totalCount.toString(),
                        const EventTypeListScreen(),
                      ),
                    ],
                  );
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
                        const SizedBox(width: 16),
                        _buildSettingsBoxContainer(
                          context,
                          "Statusi na zadacima",
                          _taskStatuses.totalCount.toString(),
                          const TaskStatusListScreen(),
                        ),
                        const SizedBox(width: 16),
                        _buildSettingsBoxContainer(
                          context,
                          "Tipovi zadataka",
                          _taskTypes.totalCount.toString(),
                          const TaskTypeListScreen(),
                        ),
                        const SizedBox(width: 16),
                        _buildSettingsBoxContainer(
                          context,
                          "Tipovi događaja",
                          _eventTypes.totalCount.toString(),
                          const EventTypeListScreen(),
                        ),
                      ],
                    ),
                  );
                }
              }
            },
          ),
        ],
      ),
    );
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
