import 'package:json_annotation/json_annotation.dart';

import 'employee.dart';
import 'enums/employment_status.dart';
import 'enums/employment_type.dart';
import 'position.dart';

part 'employee_position.g.dart';

@JsonSerializable()
class EmployeePosition {
  int id;
  Employee? employee;
  Position? position;
  DateTime startDate;
  DateTime? endDate;
  double salary;
  int vacationDays;
  EmploymentType type;
  EmploymentStatus status;
  String workingHours;

  EmployeePosition(
    this.id,
    this.employee,
    this.position,
    this.startDate,
    this.endDate,
    this.salary,
    this.vacationDays,
    this.type,
    this.status,
    this.workingHours,
  );

  factory EmployeePosition.fromJson(Map<String, dynamic> json) =>
      _$EmployeePositionFromJson(json);

  Map<String, dynamic> toJson() => _$EmployeePositionToJson(this);
}
