import '../models/task.dart';
import '../models/searches/task_search.dart';
import 'base_provider.dart';

class TaskProvider extends BaseProvider<Task, TaskSearch> {
  @override
  Task fromJson(data) => Task.fromJson(data);
}
