import '../models/city.dart';
import '../models/searches/city_search.dart';
import 'base_provider.dart';

class CityProvider extends BaseProvider<City, CitySearch> {
  @override
  City fromJson(data) => City.fromJson(data);
}
