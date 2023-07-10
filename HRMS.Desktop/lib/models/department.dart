import 'package:json_annotation/json_annotation.dart';

import 'employee.dart';

part 'department.g.dart';

@JsonSerializable()
class Department {
  int id;
  String name;
  Department? parentDepartment;
  int level;
  Employee? supervisor;

  Department(
    this.id,
    this.name,
    this.parentDepartment,
    this.level,
    this.supervisor,
  );

  factory Department.fromJson(Map<String, dynamic> json) =>
      _$DepartmentFromJson(json);

  Map<String, dynamic> toJson() => _$DepartmentToJson(this);
}
