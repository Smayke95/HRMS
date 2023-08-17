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
            },
            new EmployeePosition
            {
                Id = 3,
                EmployeeId = 3,
                PositionId = 2,
                StartDate = new DateTime(2021, 3, 1),
                EndDate = new DateTime(2024, 2, 28),
                VacationDays = 30,
                Type = EmploymentType.Fixed,
                Status = EmploymentStatus.Active,
                WorkingHours = "09:00-17:00"
            },
            new EmployeePosition
            {
                Id = 4,
                EmployeeId = 4,
                PositionId = 3,
                StartDate = new DateTime(2021, 3, 1),
                EndDate = new DateTime(2024, 2, 28),
                VacationDays = 30,
                Type = EmploymentType.Fixed,
                Status = EmploymentStatus.Active,
                WorkingHours = "09:00-17:00"
            },
            new EmployeePosition
            {
                Id = 5,
                EmployeeId = 5,
                PositionId = 4,
                StartDate = new DateTime(2021, 3, 1),
                EndDate = new DateTime(2024, 2, 28),
                VacationDays = 30,
                Type = EmploymentType.Fixed,
                Status = EmploymentStatus.Active,
                WorkingHours = "09:00-17:00"
            },
            new EmployeePosition
            {
                Id = 6,
                EmployeeId = 6,
                PositionId = 2,
                StartDate = new DateTime(2021, 3, 1),
                EndDate = new DateTime(2024, 2, 28),
                VacationDays = 30,
                Type = EmploymentType.Fixed,
                Status = EmploymentStatus.Active,
                WorkingHours = "09:00-17:00"
            },
            new EmployeePosition
            {
                Id = 7,
                EmployeeId = 7,
                PositionId = 3,
                StartDate = new DateTime(2021, 3, 1),
                EndDate = new DateTime(2024, 2, 28),
                VacationDays = 30,
                Type = EmploymentType.Fixed,
                Status = EmploymentStatus.Active,
                WorkingHours = "09:00-17:00"
            },
            new EmployeePosition
            {
                Id = 8,
                EmployeeId = 8,
                PositionId = 3,
                StartDate = new DateTime(2021, 3, 1),
                EndDate = new DateTime(2024, 2, 28),
                VacationDays = 30,
                Type = EmploymentType.Fixed,
                Status = EmploymentStatus.Active,
                WorkingHours = "09:00-17:00"
            },
            new EmployeePosition
            {
                Id = 9,
                EmployeeId = 9,
                PositionId = 2,
                StartDate = new DateTime(2021, 3, 1),
                EndDate = new DateTime(2024, 2, 28),
                VacationDays = 30,
                Type = EmploymentType.Fixed,
                Status = EmploymentStatus.Active,
                WorkingHours = "09:00-17:00"
            },
            new EmployeePosition
            {
                Id = 10,
                EmployeeId = 10,
                PositionId = 2,
                StartDate = new DateTime(2021, 3, 1),
                EndDate = new DateTime(2024, 2, 28),
                VacationDays = 30,
                Type = EmploymentType.Fixed,
                Status = EmploymentStatus.Active,
                WorkingHours = "09:00-17:00"
            }
        );
    }
}