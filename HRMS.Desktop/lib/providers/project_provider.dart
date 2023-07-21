import '../models/project.dart';
import '../models/searches/project_search.dart';
import 'base_provider.dart';

class ProjectProvider extends BaseProvider<Project, ProjectSearch> {
  @override
  Project fromJson(data) => Project.fromJson(data);
}
