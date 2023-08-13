import '../models/event_type.dart';
import '../models/searches/event_type_search.dart';
import 'base_provider.dart';

class EventTypeProvider extends BaseProvider<EventType, EventTypeSearch> {
  @override
  EventType fromJson(data) => EventType.fromJson(data);
}
