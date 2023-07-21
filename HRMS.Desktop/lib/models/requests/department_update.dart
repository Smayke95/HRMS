import 'package:json_annotation/json_annotation.dart';

part 'department_update.g.dart';

@JsonSerializable()
class DepartmentUpdate {
  String name;
  int? parentDepartmentId;
  int? supervisorId;

  DepartmentUpdate(
    this.name,
    this.parentDepartmentId,
    this.supervisorId,
  );

  factory DepartmentUpdate.fromJson(Map<String, dynamic> json) =>
      _$DepartmentUpdateFromJson(json);

  Map<String, dynamic> toJson() => _$DepartmentUpdateToJson(this);
}
