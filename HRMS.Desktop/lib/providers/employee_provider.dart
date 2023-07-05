import 'base_provider.dart';
import '../models/employee.dart';

class EmployeeProvider extends BaseProvider<Employee> {
  @override
  Employee fromJson(data) => Employee.fromJson(data);
}
