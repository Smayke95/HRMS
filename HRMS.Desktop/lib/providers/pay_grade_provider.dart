import '../models/pay_grade.dart';
import '../models/searches/base_search.dart';
import 'base_provider.dart';

class PayGradeProvider extends BaseProvider<PayGrade, BaseSearch> {
  @override
  PayGrade fromJson(data) => PayGrade.fromJson(data);
}
