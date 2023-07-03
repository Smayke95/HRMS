using HRMS.Database.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRMS.Database.Seed;

public static class DepartmentData
{
    public static void SeedData(this EntityTypeBuilder<Department> entity)
    {
        entity.HasData(
            new Department
            {
                Id = 1,
                Name = "HRMS",
                Level = 0
            },
            new Department
            {
                Id = 2,
                Name = "Odjel IT",
                ParentDepartmentId = 1,
                Level = 1
            },
            new Department
            {
                Id = 3,
                Name = "Odjel REM",
                ParentDepartmentId = 1,
                Level = 1
            },
            new Department
            {
                Id = 4,
                Name = "Odjel HR",
                ParentDepartmentId = 1,
                Level = 1
            },
            new Department
            {
                Id = 5,
                Name = "Frontend tim",
                ParentDepartmentId = 2,
                Level = 2
            },
            new Department
            {
                Id = 6,
                Name = "Backend tim",
                ParentDepartmentId = 2,
                Level = 2
            },
            new Department
            {
                Id = 7,
                Name = "Database tim",
                ParentDepartmentId = 2,
                Level = 2
            }
        );
    }
}