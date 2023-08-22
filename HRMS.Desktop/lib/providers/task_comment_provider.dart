import '../models/searches/task_comment_search.dart';
import '../models/task_comment.dart';
import 'base_provider.dart';

class TaskCommentProvider extends BaseProvider<TaskComment, TaskCommentSearch> {
  @override
  TaskComment fromJson(data) => TaskComment.fromJson(data);
}
