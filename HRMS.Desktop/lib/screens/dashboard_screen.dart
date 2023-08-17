import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:syncfusion_flutter_charts/charts.dart';

import '../models/chart_data.dart';
import '../models/department.dart';
import '../models/employee.dart';
import '../models/employee_position.dart';
import '../models/paged_result.dart';
import '../models/searches/department_search.dart';
import '../models/searches/employee_position_search.dart';
import '../models/searches/employee_search.dart';
import '../providers/department_provider.dart';
import '../providers/employee_position_provider.dart';
import '../providers/employee_provider.dart';
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

  var _departments = PagedResult<Department>();
  var _employees = PagedResult<Employee>();
  var _employeePositions = PagedResult<EmployeePosition>();

  late List<ChartData> columnChartData = [];
  late List<ChartData> pieChartData = [];

  @override
  void initState() {
    super.initState();

    _departmentProvider = context.read<DepartmentProvider>();
    _employeeProvider = context.read<EmployeeProvider>();
    _employeePositionProvider = context.read<EmployeePositionProvider>();

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
    pieChartData
        .add(ChartData("Broj nezaposlenih", _employees.totalCount.toDouble() - _employeePositions.totalCount.toDouble()));

    setState(() {});
  }

  @override
  Widget build(BuildContext context) {
    return SingleChildScrollView(
      child: Padding(
        padding: const EdgeInsets.all(30),
        child: Wrap(
          alignment: WrapAlignment.spaceAround,
          spacing: 40,
          runSpacing: 60,
          children: [
            ..._buildCards(context),
            Padding(
              padding: const EdgeInsets.only(top: 100.0),
              child: Responsive.isMobile(context)
                  ? SizedBox(
                      height: 500,
                      child: Column(
                        children: [
                          _buildColumnChart(context),
                          _buildPieChart(context),
                        ],
                      ))
                  : Row(
                      children: [
                        _buildColumnChart(context),
                        _buildPieChart(context),
                      ],
                    ),
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
}
