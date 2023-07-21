// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'employee_update.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

EmployeeUpdate _$EmployeeUpdateFromJson(Map<String, dynamic> json) =>
    EmployeeUpdate(
      json['firstName'] as String,
      json['lastName'] as String,
      json['maidenName'] as String,
      json['parentName'] as String,
      $enumDecode(_$GenderEnumMap, json['gender']),
      json['registrationNumber'] as String,
      json['personalIdentificationNumber'] as String,
      json['workerCode'] as String,
      DateTime.parse(json['birthDate'] as String),
      json['birthPlaceId'] as int?,
      json['address'] as String,
      json['cityId'] as int?,
      json['citizenshipId'] as int?,
      json['image'] as String,
      json['email'] as String,
      json['phone'] as String,
      json['mobile'] as String,
      json['officePhone'] as String,
      json['profession'] as String,
      json['educationId'] as int?,
      json['previousLOSYears'] as int,
      json['previousLOSMonths'] as int,
      json['bankAccount'] as String,
      json['note'] as String,
    );

Map<String, dynamic> _$EmployeeUpdateToJson(EmployeeUpdate instance) =>
    <String, dynamic>{
      'firstName': instance.firstName,
      'lastName': instance.lastName,
      'maidenName': instance.maidenName,
      'parentName': instance.parentName,
      'gender': _$GenderEnumMap[instance.gender]!,
      'registrationNumber': instance.registrationNumber,
      'personalIdentificationNumber': instance.personalIdentificationNumber,
      'workerCode': instance.workerCode,
      'birthDate': instance.birthDate.toIso8601String(),
      'birthPlaceId': instance.birthPlaceId,
      'address': instance.address,
      'cityId': instance.cityId,
      'citizenshipId': instance.citizenshipId,
      'image': instance.image,
      'email': instance.email,
      'phone': instance.phone,
      'mobile': instance.mobile,
      'officePhone': instance.officePhone,
      'profession': instance.profession,
      'educationId': instance.educationId,
      'previousLOSYears': instance.previousLOSYears,
      'previousLOSMonths': instance.previousLOSMonths,
      'bankAccount': instance.bankAccount,
      'note': instance.note,
    };

const _$GenderEnumMap = {
  Gender.male: 0,
  Gender.female: 1,
};
