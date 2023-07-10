import 'package:json_annotation/json_annotation.dart';

import 'country.dart';

part 'city.g.dart';

@JsonSerializable()
class City {
  int id;
  String name;
  String zipCode;
  Country? country;

  City(
    this.id,
    this.name,
    this.zipCode,
    this.country,
  );

  factory City.fromJson(Map<String, dynamic> json) => _$CityFromJson(json);

  Map<String, dynamic> toJson() => _$CityToJson(this);
}
