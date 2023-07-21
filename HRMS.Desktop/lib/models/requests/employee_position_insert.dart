import 'package:json_annotation/json_annotation.dart';

import '../enums/employment_type.dart';

part 'employee_position_insert.g.dart';

@JsonSerializable()
class EmployeePositionInsert {
  int employeeId;
  int positionId;
  DateTime startDate;
  DateTime? endDate;
  double salary;
  int vacationDays;
  EmploymentType employmentType;
  String workingHours;

  EmployeePositionInsert(
    this.employeeId,
    this.positionId,
    this.startDate,
    this.endDate,
    this.salary,
    this.vacationDays,
    this.employmentType,
    this.workingHours,
  );

  factory EmployeePositionInsert.fromJson(Map<String, dynamic> json) =>
      _$EmployeePositionInsertFromJson(json);

  Map<String, dynamic> toJson() => _$EmployeePositionInsertToJson(this);
}
