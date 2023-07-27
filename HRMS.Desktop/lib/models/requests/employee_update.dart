import 'package:json_annotation/json_annotation.dart';

import '../enums/gender.dart';

part 'employee_update.g.dart';

@JsonSerializable()
class EmployeeUpdate {
  String firstName;
  String lastName;
  String maidenName;
  String parentName;
  Gender gender;
  String registrationNumber;
  String personalIdentificationNumber;
  String workerCode;
  DateTime birthDate;
  int? birthPlaceId;
  String address;
  int? cityId;
  int? citizenshipId;
  String image;
  String email;
  String phone;
  String mobile;
  String officePhone;
  String profession;
  int? educationId;
  int previousLOSYears;
  int previousLOSMonths;
  String bankAccount;
  String note;

  EmployeeUpdate(
    this.firstName,
    this.lastName,
    this.maidenName,
    this.parentName,
    this.gender,
    this.registrationNumber,
    this.personalIdentificationNumber,
    this.workerCode,
    this.birthDate,
    this.birthPlaceId,
    this.address,
    this.cityId,
    this.citizenshipId,
    this.image,
    this.email,
    this.phone,
    this.mobile,
    this.officePhone,
    this.profession,
    this.educationId,
    this.previousLOSYears,
    this.previousLOSMonths,
    this.bankAccount,
    this.note,
  );

  factory EmployeeUpdate.fromJson(Map<String, dynamic> json) =>
      _$EmployeeUpdateFromJson(json);

  Map<String, dynamic> toJson() => _$EmployeeUpdateToJson(this);
}