import 'package:json_annotation/json_annotation.dart';

part 'department_insert.g.dart';

@JsonSerializable()
class DepartmentInsert {
  String name;
  int? parentDepartmentId;
  int? supervisorId;

  DepartmentInsert(
    this.name,
    this.parentDepartmentId,
    this.supervisorId,
  );

  factory DepartmentInsert.fromJson(Map<String, dynamic> json) =>
      _$DepartmentInsertFromJson(json);

  Map<String, dynamic> toJson() => _$DepartmentInsertToJson(this);
}
