import 'package:json_annotation/json_annotation.dart';
import 'city.dart';
import 'country.dart';
import 'education.dart';

part 'employee.g.dart';

@JsonSerializable()
class Employee {
  int id;
  String firstName;
  String lastName;
  String maidenName;
  String parentName;
  String registrationNumber;
  String personalIdentificationNumber;
  String workerCode;
  DateTime birthDate;
  City? birthPlace;
  String address;
  City? city;
  Country? citizenship;
  String image;
  String email;
  String phone;
  String mobile;
  String officePhone;
  String profession;
  Education? education;
  int previousLOSYears;
  int previousLOSMonths;
  String bankAccount;
  String note;
  DateTime createDate;

  Employee(
    this.id,
    this.firstName,
    this.lastName,
    this.maidenName,
    this.parentName,
    this.registrationNumber,
    this.personalIdentificationNumber,
    this.workerCode,
    this.birthDate,
    this.birthPlace,
    this.address,
    this.city,
    this.citizenship,
    this.image,
    this.email,
    this.phone,
    this.mobile,
    this.officePhone,
    this.profession,
    this.education,
    this.previousLOSYears,
    this.previousLOSMonths,
    this.bankAccount,
    this.note,
    this.createDate,
  );

  factory Employee.fromJson(Map<String, dynamic> json) =>
      _$EmployeeFromJson(json);

  Map<String, dynamic> toJson() => _$EmployeeToJson(this);
}
