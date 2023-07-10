using HRMS.Database.Models;
using HRMS.Database.Models.Enums;
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
                EndDate = new DateTime(2022, 2, 28),
                VacationDays = 30,
                EmploymentType = EmploymentType.Fixed,
                WorkingHours = "09:00-17:00"
            },
            new EmployeePosition
            {
                Id = 2,
                EmployeeId = 2,
                PositionId = 5,
                StartDate = new DateTime(2021, 6, 1),
                EndDate = new DateTime(2021, 11, 30),
                VacationDays = 30,
                EmploymentType = EmploymentType.Fixed,
                WorkingHours = "09:00-17:00"
            }
        );
    }
}