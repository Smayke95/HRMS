import '../models/department.dart';
import 'base_provider.dart';

class DepartmentProvider extends BaseProvider<Department> {
  @override
  Department fromJson(data) => Department.fromJson(data);
}
