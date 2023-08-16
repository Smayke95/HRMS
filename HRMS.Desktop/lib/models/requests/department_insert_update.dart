import 'package:json_annotation/json_annotation.dart';

part 'department_insert_update.g.dart';

@JsonSerializable()
class DepartmentInsertUpdate {
  String name;
  int? parentDepartmentId;
  int? supervisorId;

  DepartmentInsertUpdate(
    this.name,
    this.parentDepartmentId,
    this.supervisorId,
  );

  factory DepartmentInsertUpdate.fromJson(Map<String, dynamic> json) =>
      _$DepartmentInsertUpdateFromJson(json);

  Map<String, dynamic> toJson() => _$DepartmentInsertUpdateToJson(this);
}
