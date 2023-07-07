import '../models/department.dart';
import '../models/searches/base_search.dart';
import 'base_provider.dart';

class DepartmentProvider extends BaseProvider<Department, BaseSearch> {
  @override
  Department fromJson(data) => Department.fromJson(data);
}
