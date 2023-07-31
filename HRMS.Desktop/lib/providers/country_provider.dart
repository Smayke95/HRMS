import '../models/country.dart';
import '../models/searches/country_search_model.dart';
import 'base_provider.dart';

class CountryProvider extends BaseProvider<Country, CountrySearch> {
  @override
  Country fromJson(data) => Country.fromJson(data);
}
