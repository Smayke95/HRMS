import '../models/employee.dart';
import '../models/searches/employee_search.dart';
import 'base_provider.dart';

class EmployeeProvider extends BaseProvider<Employee, EmployeeSearch> {
  @override
  Employee fromJson(data) => Employee.fromJson(data);
}
