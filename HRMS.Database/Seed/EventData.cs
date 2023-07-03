using HRMS.Database.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRMS.Database.Seed;

public static class EventData
{
    public static void SeedData(this EntityTypeBuilder<Event> entity)
    {
        entity.HasData(
            new Event
            {
                Id = 1,
                Name = "Bolovanje",
                EventTypeId = 3,
                StartDate = new DateTime(2021, 8, 16),
                EndDate = new DateTime(2021, 10, 6),
                EmployeeId = 1
            },
            new Event
            {
                Id = 2,
                Name = "Kurban Bajram",
                EventTypeId = 2,
                StartDate = new DateTime(2021, 9, 1),
                EndDate = new DateTime(2021, 9, 3),
                EmployeeId = 1
            },
            new Event
            {
                Id = 3,
                Name = "Godišnji odmor",
                EventTypeId = 1,
                StartDate = new DateTime(2021, 8, 30),
                EndDate = new DateTime(2021, 9, 13),
                EmployeeId = 2
            }
        );
    }
}