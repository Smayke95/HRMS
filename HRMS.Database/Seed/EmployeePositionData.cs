using HRMS.Core.Models.Enums;
using HRMS.Database.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRMS.Database.Seed;

public static class EmployeePositionData
{
    public static void SeedData(this EntityTypeBuilder<EmployeePosition> entity)
    {
        entity.HasData(
            new EmployeePosition
            {
                Id = 1,
                EmployeeId = 1,
                PositionId = 6,
                StartDate = new DateTime(2021, 3, 1),
                EndDate = new DateTime(2024, 2, 28),
                VacationDays = 30,
                Type = EmploymentType.Fixed,
                Status = EmploymentStatus.Active,
                WorkingHours = "09:00-17:00"
            },
            new EmployeePosition
            {
                Id = 2,
                EmployeeId = 2,
                PositionId = 5,
                StartDate = new DateTime(2021, 6, 1),
                EndDate = new DateTime(2023, 11, 30),
                VacationDays = 30,
                Type = EmploymentType.Fixed,
                Status = EmploymentStatus.Inactive,
                WorkingHours = "09:00-17:00"
            }
        );
    }
}