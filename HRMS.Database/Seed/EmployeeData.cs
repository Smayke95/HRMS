using HRMS.Database.Models;
using HRMS.Database.Models.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRMS.Database.Seed;

public static class EmployeeData
{
    public static void SeedData(this EntityTypeBuilder<Employee> entity)
    {
        entity.HasData(
            new Employee
            {
                Id = 1,
                FirstName = "Anes",
                LastName = "Smajić",
                Gender = Gender.Male,
                RegistrationNumber = "1234567890123",
                BirthDate = new DateTime(1995, 09, 12),
                BirthPlaceId = 1,
                Address = "4. Muslimanske brigade 20",
                CityId = 1,
                Image = "/img/avatars/default.png",
                Email = "anes@hrms.com",
                Password = "19a2854144b63a8f7617a6f225019b12",
                Phone = "38762715825",
                Mobile = "38762715825",
                OfficePhone = "38762715825",
                Profession = "Ekonomski tehničar"
            },
            new Employee
            {
                Id = 2,
                FirstName = "Irena",
                LastName = "Vilić",
                Gender = Gender.Female,
                RegistrationNumber = "1234567890123",
                BirthDate = new DateTime(1998, 05, 26),
                BirthPlaceId = 1,
                Address = "Dobrinja",
                CityId = 1,
                Image = "/img/avatars/default.png",
                Email = "irena@hrms.com",
                Password = "19a2854144b63a8f7617a6f225019b12"
            }
        );
    }
}