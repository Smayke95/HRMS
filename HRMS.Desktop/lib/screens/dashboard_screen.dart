import 'package:HRMS/models/searches/event_search.dart';
import 'package:HRMS/models/searches/task_search.dart';
import 'package:HRMS/providers/event_provider.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:syncfusion_flutter_charts/charts.dart';

import '../models/chart_data.dart';
import '../models/department.dart';
import '../models/employee.dart';
import '../models/employee_position.dart';
import '../models/event.dart';
import '../models/paged_result.dart';
import '../models/searches/department_search.dart';
import '../models/searches/employee_position_search.dart';
import '../models/searches/employee_search.dart';
import '../models/searches/task_status_search.dart';
import '../models/task.dart';
import '../models/task_status.dart';
import '../providers/department_provider.dart';
import '../providers/employee_position_provider.dart';
import '../providers/employee_provider.dart';
import '../providers/task_provider.dart';
import '../providers/task_status_provider.dart';
import '../widgets/master_screen.dart';
import '../widgets/responsive.dart';
import 'calendar_screen.dart';
import 'chat_screen.dart';
import 'employee_list_screen.dart';
import 'employee_position_list_screen.dart';
import 'project_list_screen.dart';

class DashboardScreen extends StatefulWidget {
  const DashboardScreen({super.key});

  @override
  State<DashboardScreen> createState() => _DashboardScreenState();
}

class _DashboardScreenState extends State<DashboardScreen> {
  late DepartmentProvider _departmentProvider;
  late EmployeeProvider _employeeProvider;
  late EmployeePositionProvider _employeePositionProvider;
  late EventProvider _eventProvider;
  late TaskProvider _taskProvider;
  late TaskStatusProvider _taskStatusProvider;

  var _departments = PagedResult<Department>();
  var _employees = PagedResult<Employee>();
  var _employeePositions = PagedResult<EmployeePosition>();
  var _events = PagedResult<Event>();
  var _tasks = PagedResult<Task>();
  var _taskStatuses = PagedResult<TaskStatus>();

  late List<ChartData> columnChartData = [];
  late List<ChartData> pieChartData = [];
  late List<ChartData> radialChartData = [];
  late List<ChartData> barChartData = [];

  @override
  void initState() {
    super.initState();

    _departmentProvider = context.read<DepartmentProvider>();
    _employeeProvider = context.read<EmployeeProvider>();
    _employeePositionProvider = context.read<EmployeePositionProvider>();
    _eventProvider = context.read<EventProvider>();
    _taskProvider = context.read<TaskProvider>();
    _taskStatusProvider = context.read<TaskStatusProvider>();

    _loadData();
  }

  Future _loadData() async {
    var departmentSearch = DepartmentSearch();
    departmentSearch.pageSize = 50;
    _departments = await _departmentProvider.getAll(search: departmentSearch);

    var employeeSearch = EmployeeSearch();
    employeeSearch.pageSize = 50;
    _employees = await _employeeProvider.getAll(search: employeeSearch);

    var employeePositionSearch = EmployeePositionSearch();
    employeePositionSearch.pageSize = 50;
    _employeePositions =
        await _employeePositionProvider.getAll(search: employeePositionSearch);

    var eventSearch = EventSearch();
    eventSearch.pageSize = 50;
    eventSearch.includeEmployee = true;
    _events = await _eventProvider.getAll(search: eventSearch);

    var taskSearch = TaskSearch();
    taskSearch.pageSize = 50;
    taskSearch.includeStatus = true;
    _tasks = await _taskProvider.getAll(search: taskSearch);

    var taskStatusSearch = TaskStatusSearch();
    taskStatusSearch.pageSize = 50;
    _taskStatuses = await _taskStatusProvider.getAll(search: taskStatusSearch);

    var mainDepartments = _departments.result.where((x) => x.level == 1);
    for (var department in mainDepartments) {
      var count = _employeePositions.result
          .where((x) => (x.position?.department?.id ?? 1) == department.id)
          .length
          .toDouble();

      columnChartData.add(ChartData(department.name, count));
    }

    pieChartData.add(
        ChartData("Broj zaposlenih", _employeePositions.totalCount.toDouble()));
    pieChartData.add(ChartData(
        "Broj nezaposlenih",
        _employees.totalCount.toDouble() -
            _employeePositions.totalCount.toDouble()));

    for (var taskStatus in _taskStatuses.result) {
      var count = _tasks.result
          .where((x) => (x.status?.id ?? 1) == taskStatus.id)
          .length
          .toDouble();

      radialChartData.add(ChartData(taskStatus.name, count));
    }

    for (var employee in _employees.result) {
      var count = _events.result
          .where((event) => event.employee?.id == employee.id)
          .map((event) => event.endDate.difference(event.startDate).inDays)
          .fold(0, (total, days) => total + days)
          .toDouble();

      barChartData
          .add(ChartData("${employee.firstName} ${employee.lastName}", count));
    }

    setState(() {});
  }

  @override
  Widget build(BuildContext context) {
    return SingleChildScrollView(
      child: Padding(
        padding: const EdgeInsets.all(30),
        child: Responsive.isMobile(context)
            ? Wrap(
                alignment: WrapAlignment.spaceAround,
                spacing: 40,
                runSpacing: 60,
                children: [
                    ..._buildCards(context),
                    SizedBox(
                        height: 1000,
                        child: Column(
                          children: [
                            _buildColumnChart(context),
                            _buildPieChart(context),
                            _buildRadialChart(context),
                            _buildBarChart(context)
                          ],
                        ))
                  ])
            : Column(
                children: [
                  Wrap(
                    alignment: WrapAlignment.spaceAround,
                    spacing: 40,
                    runSpacing: 60,
                    children: [
                      ..._buildCards(context),
                    ],
                  ),
                  const SizedBox(height: 100),
                  Row(
                    mainAxisAlignment: MainAxisAlignment.spaceAround,
                    children: [
                      _buildColumnChart(context),
                      _buildPieChart(context),
                    ],
                  ),
                  const SizedBox(height: 100),
                  Row(
                    mainAxisAlignment: MainAxisAlignment.spaceAround,
                    children: [
                      _buildRadialChart(context),
                      _buildBarChart(context),
                    ],
                  ),
                ],
              ),
      ),
    );
  }

  List<Widget> _buildCards(BuildContext context) {
    return [
      _buildCard(
        context,
        "Projekti",
        Icons.folder,
        const ProjectListScreen(),
      ),
      _buildCard(
        context,
        "Razgovor",
        Icons.chat,
        const ChatScreen(),
      ),
      _buildCard(
        context,
        "Kalendar",
        Icons.date_range,
        const CalendarScreen(),
      ),
      _buildCard(
        context,
        "Zaposlenici",
        Icons.groups,
        const EmployeeListScreen(),
      ),
      _buildCard(
        context,
        "Zaposlenje",
        Icons.content_copy,
        const EmployeePositionListScreen(),
      ),
    ];
  }

  Card _buildCard(
    BuildContext context,
    String title,
    IconData icon,
    Widget screen,
  ) {
    return Card(
      color: Colors.white,
      child: SizedBox(
        width: 200,
        height: 200,
        child: Column(
          children: [
            const SizedBox(height: 10),
            Container(
              decoration: BoxDecoration(
                  border: Border.all(
                    color: Colors.grey,
                  ),
                  borderRadius: BorderRadius.circular(50)),
              child: SizedBox(
                width: 100,
                height: 100,
                child: Icon(
                  icon,
                  color: Colors.grey.shade700,
                  size: 40,
                ),
              ),
            ),
            const SizedBox(height: 10),
            Text(title),
            const SizedBox(height: 10),
            ElevatedButton(
              child: const Text("OTVORI"),
              onPressed: () {
                Navigator.of(context).pushReplacement(MaterialPageRoute(
                    builder: (context) => MasterScreen(title, screen)));
              },
            )
          ],
        ),
      ),
    );
  }

  Widget _buildColumnChart(BuildContext context) {
    return Expanded(
      child: SfCartesianChart(
        title: ChartTitle(
          text: "Broj zaposlenika po odjelima",
        ),
        primaryXAxis: CategoryAxis(),
        series: <ChartSeries<ChartData, String>>[
          ColumnSeries<ChartData, String>(
            dataSource: columnChartData,
            xValueMapper: (ChartData data, _) => data.x,
            yValueMapper: (ChartData data, _) => data.y,
          )
        ],
      ),
    );
  }

  Widget _buildPieChart(BuildContext context) {
    return Expanded(
      child: SfCircularChart(
        legend: const Legend(isVisible: true),
        series: <CircularSeries>[
          PieSeries<ChartData, String>(
            dataSource: pieChartData,
            xValueMapper: (ChartData data, _) => data.x,
            yValueMapper: (ChartData data, _) => data.y,
            explode: true,
            explodeIndex: 1,
          )
        ],
      ),
    );
  }

  Widget _buildRadialChart(BuildContext context) {
    return Expanded(
      child: SfCircularChart(
        title: ChartTitle(text: 'Broj zadataka po statusima'),
        legend: const Legend(isVisible: true),
        series: <CircularSeries>[
          RadialBarSeries<ChartData, String>(
            dataSource: radialChartData,
            xValueMapper: (ChartData data, _) => data.x,
            yValueMapper: (ChartData data, _) => data.y,
            dataLabelSettings: const DataLabelSettings(
              isVisible: true,
            ),
          ),
        ],
      ),
    );
  }

  Widget _buildBarChart(BuildContext context) {
    return Expanded(
      child: SfCartesianChart(
          title: ChartTitle(
            text: "Broj iskorištenih dana za događaje po zaposleniku",
          ),
          primaryXAxis: CategoryAxis(),
          primaryYAxis: NumericAxis(minimum: 0, maximum: 40, interval: 10),
          tooltipBehavior: TooltipBehavior(enable: true),
          series: <ChartSeries<ChartData, String>>[
            BarSeries<ChartData, String>(
              dataSource: barChartData,
              xValueMapper: (ChartData data, _) => data.x,
              yValueMapper: (ChartData data, _) => data.y,
            )
          ]),
    );
  }
}
