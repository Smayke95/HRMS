import '../models/task_type.dart';
import '../models/searches/task_type_search.dart';
import 'base_provider.dart';

class TaskTypeProvider extends BaseProvider<TaskType, TaskTypeSearch> {
  @override
  TaskType fromJson(data) => TaskType.fromJson(data);
}
