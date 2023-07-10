import '../models/position.dart';
import '../models/searches/position_search.dart';
import 'base_provider.dart';

class PositionProvider extends BaseProvider<Position, PositionSearch> {
  @override
  Position fromJson(data) => Position.fromJson(data);
}
