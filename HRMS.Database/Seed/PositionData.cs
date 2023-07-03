using HRMS.Database.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRMS.Database.Seed;

public static class PositionData
{
    public static void SeedData(this EntityTypeBuilder<Position> entity)
    {
        entity.HasData(
            new Position
            {
                Id = 1,
                Name = "Generalni direktor",
                DepartmentId = 1,
                PayGradeId = 1,
                RequiredEducationId = 7,
                IsWorkExperienceRequired = true
            },
            new Position
            {
                Id = 2,
                Name = "Direktor IT odjela",
                DepartmentId = 2,
                PayGradeId = 3,
                RequiredEducationId = 6,
                IsWorkExperienceRequired = true
            },
            new Position
            {
                Id = 3,
                Name = "Direktor REM odjela",
                DepartmentId = 3,
                PayGradeId = 2,
                RequiredEducationId = 6,
                IsWorkExperienceRequired = true
            },
            new Position
            {
                Id = 4,
                Name = "Direktor HR odjela",
                DepartmentId = 2,
                PayGradeId = 3,
                RequiredEducationId = 6,
                IsWorkExperienceRequired = true
            },
            new Position
            {
                Id = 5,
                Name = "Voditelj Frontend tima",
                DepartmentId = 5,
                PayGradeId = 4,
                RequiredEducationId = 6,
                IsWorkExperienceRequired = true
            },
            new Position
            {
                Id = 6,
                Name = "Voditelj Backend tima",
                DepartmentId = 6,
                PayGradeId = 4,
                RequiredEducationId = 6,
                IsWorkExperienceRequired = true
            },
            new Position
            {
                Id = 7,
                Name = "Voditelj Database tima",
                DepartmentId = 7,
                PayGradeId = 4,
                RequiredEducationId = 6,
                IsWorkExperienceRequired = true
            },
            new Position
            {
                Id = 8,
                Name = "Software developer",
                DepartmentId = 5,
                PayGradeId = 5,
                RequiredEducationId = 6,
                IsWorkExperienceRequired = true
            },
            new Position
            {
                Id = 9,
                Name = "Designer",
                DepartmentId = 6,
                PayGradeId = 5,
                RequiredEducationId = 4,
                IsWorkExperienceRequired = false
            },
            new Position
            {
                Id = 10,
                Name = "Database administrator",
                DepartmentId = 7,
                PayGradeId = 5,
                RequiredEducationId = 4,
                IsWorkExperienceRequired = true
            },
            new Position
            {
                Id = 11,
                Name = "Viši stručni saradnik za upravljanje ljudskim resursima",
                DepartmentId = 4,
                PayGradeId = 4,
                RequiredEducationId = 6,
                IsWorkExperienceRequired = true
            },
            new Position
            {
                Id = 12,
                Name = "Stručni saradnik za upravljanje ljudskim resursima",
                DepartmentId = 4,
                PayGradeId = 5,
                RequiredEducationId = 4,
                IsWorkExperienceRequired = false
            },
            new Position
            {
                Id = 13,
                Name = "Čistač",
                DepartmentId = 3,
                PayGradeId = 6,
                RequiredEducationId = 1,
                IsWorkExperienceRequired = false
            }
        );
    }
}