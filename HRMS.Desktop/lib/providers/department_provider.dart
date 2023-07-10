import '../models/department.dart';
import '../models/searches/department_search.dart';
import 'base_provider.dart';

class DepartmentProvider extends BaseProvider<Department, DepartmentSearch> {
  @override
  Department fromJson(data) => Department.fromJson(data);
}
