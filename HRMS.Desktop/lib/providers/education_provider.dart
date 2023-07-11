import '../models/education.dart';
import '../models/searches/base_search.dart';
import 'base_provider.dart';

class EducationProvider extends BaseProvider<Education, BaseSearch> {
  @override
  Education fromJson(data) => Education.fromJson(data);
}
