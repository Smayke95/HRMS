import '../models/employee_position.dart';
import '../models/searches/employee_position_search.dart';
import 'base_provider.dart';

class EmployeePositionProvider
    extends BaseProvider<EmployeePosition, EmployeePositionSearch> {
  @override
  EmployeePosition fromJson(data) => EmployeePosition.fromJson(data);
}
