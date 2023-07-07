import '../models/employee.dart';
import 'base_provider.dart';

class EmployeeProvider extends BaseProvider<Employee> {
  @override
  Employee fromJson(data) => Employee.fromJson(data);
}
