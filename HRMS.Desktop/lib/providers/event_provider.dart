import '../models/event.dart';
import '../models/searches/event_search.dart';
import 'base_provider.dart';

class EventProvider extends BaseProvider<Event, EventSearch> {
  @override
  Event fromJson(data) => Event.fromJson(data);
}
