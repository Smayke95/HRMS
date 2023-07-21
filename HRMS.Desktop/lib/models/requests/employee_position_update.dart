import 'package:json_annotation/json_annotation.dart';

import '../enums/employment_type.dart';

part 'employee_position_update.g.dart';

@JsonSerializable()
class EmployeePositionUpdate {
  int employeeId;
  int positionId;
  DateTime startDate;
  DateTime? endDate;
  double salary;
  int vacationDays;
  EmploymentType employmentType;
  String workingHours;

  EmployeePositionUpdate(
    this.employeeId,
    this.positionId,
    this.startDate,
    this.endDate,
    this.salary,
    this.vacationDays,
    this.employmentType,
    this.workingHours,
  );

  factory EmployeePositionUpdate.fromJson(Map<String, dynamic> json) =>
      _$EmployeePositionUpdateFromJson(json);

  Map<String, dynamic> toJson() => _$EmployeePositionUpdateToJson(this);
}
