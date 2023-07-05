// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'employee.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Employee _$EmployeeFromJson(Map<String, dynamic> json) => Employee(
      json['id'] as int,
      json['firstName'] as String,
      json['lastName'] as String,
      json['maidenName'] as String,
      json['parentName'] as String,
      json['registrationNumber'] as String,
      json['personalIdentificationNumber'] as String,
      json['workerCode'] as String,
      DateTime.parse(json['birthDate'] as String),
      json['birthPlace'] == null
          ? null
          : City.fromJson(json['birthPlace'] as Map<String, dynamic>),
      json['address'] as String,
      json['city'] == null
          ? null
          : City.fromJson(json['city'] as Map<String, dynamic>),
      json['citizenship'] == null
          ? null
          : Country.fromJson(json['citizenship'] as Map<String, dynamic>),
      json['image'] as String,
      json['email'] as String,
      json['phone'] as String,
      json['mobile'] as String,
      json['officePhone'] as String,
      json['profession'] as String,
      json['education'] == null
          ? null
          : Education.fromJson(json['education'] as Map<String, dynamic>),
      json['previousLOSYears'] as int,
      json['previousLOSMonths'] as int,
      json['bankAccount'] as String,
      json['note'] as String,
      DateTime.parse(json['createDate'] as String),
    );

Map<String, dynamic> _$EmployeeToJson(Employee instance) => <String, dynamic>{
      'id': instance.id,
      'firstName': instance.firstName,
      'lastName': instance.lastName,
      'maidenName': instance.maidenName,
      'parentName': instance.parentName,
      'registrationNumber': instance.registrationNumber,
      'personalIdentificationNumber': instance.personalIdentificationNumber,
      'workerCode': instance.workerCode,
      'birthDate': instance.birthDate.toIso8601String(),
      'birthPlace': instance.birthPlace,
      'address': instance.address,
      'city': instance.city,
      'citizenship': instance.citizenship,
      'image': instance.image,
      'email': instance.email,
      'phone': instance.phone,
      'mobile': instance.mobile,
      'officePhone': instance.officePhone,
      'profession': instance.profession,
      'education': instance.education,
      'previousLOSYears': instance.previousLOSYears,
      'previousLOSMonths': instance.previousLOSMonths,
      'bankAccount': instance.bankAccount,
      'note': instance.note,
      'createDate': instance.createDate.toIso8601String(),
    };
