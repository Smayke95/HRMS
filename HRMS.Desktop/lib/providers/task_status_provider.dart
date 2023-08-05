import '../models/task_status.dart';
import '../models/searches/task_status_search.dart';
import 'base_provider.dart';

class TaskStatusProvider extends BaseProvider<TaskStatus, TaskStatusSearch> {
  @override
  TaskStatus fromJson(data) => TaskStatus.fromJson(data);
}
