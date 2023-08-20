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
                StartDate = new DateTime(2023, 8, 16),
                EndDate = new DateTime(2023, 8, 28),
                EmployeeId = 1
            },
            new Event
            {
                Id = 2,
                Name = "Kurban Bajram",
                EventTypeId = 2,
                StartDate = new DateTime(2023, 9, 1),
                EndDate = new DateTime(2023, 9, 3),
                EmployeeId = 1
            },
            new Event
            {
                Id = 3,
                Name = "Godišnji odmor",
                EventTypeId = 1,
                StartDate = new DateTime(2023, 8, 30),
                EndDate = new DateTime(2023, 9, 13),
                EmployeeId = 3
            },
            new Event
            {
                Id = 4,
                Name = "Stručna obuka",
                EventTypeId = 4,
                StartDate = new DateTime(2023, 8, 21),
                EndDate = new DateTime(2023, 8, 25),
                EmployeeId = 1
            },
            new Event
            {
                Id = 5,
                Name = "Sarajevski Film Festival",
                EventTypeId = 5,
                StartDate = new DateTime(2023, 9, 10),
                EndDate = new DateTime(2023, 9, 18),
                EmployeeId = 5
            },
            new Event
            {
                Id = 6,
                Name = "Poslovni put - Zagreb",
                EventTypeId = 2,
                StartDate = new DateTime(2023, 9, 5),
                EndDate = new DateTime(2023, 9, 8),
                EmployeeId = 6
            },
            new Event
            {
                Id = 7,
                Name = "Oproštajna večera za kolegu",
                EventTypeId = 3,
                StartDate = new DateTime(2023, 8, 28),
                EndDate = new DateTime(2023, 8, 28),
                EmployeeId = 7
            },
            new Event
            {
                Id = 8,
                Name = "Timski izlet na planinu",
                EventTypeId = 4,
                StartDate = new DateTime(2023, 9, 16),
                EndDate = new DateTime(2023, 9, 18),
                EmployeeId = 1
            },
            new Event
            {
                Id = 9,
                Name = "Seminar o liderstvu",
                EventTypeId = 4,
                StartDate = new DateTime(2023, 10, 2),
                EndDate = new DateTime(2023, 10, 4),
                EmployeeId = 9
            },
            new Event
            {
                Id = 10,
                Name = "Sportski turnir - fudbal",
                EventTypeId = 1,
                StartDate = new DateTime(2023, 9, 23),
                EndDate = new DateTime(2023, 9, 24),
                EmployeeId = 10
            },
            new Event
            {
                Id = 11,
                Name = "Prezentacija novog proizvoda",
                EventTypeId = 3,
                StartDate = new DateTime(2023, 9, 15),
                EndDate = new DateTime(2023, 9, 15),
                EmployeeId = 1
            },
            new Event
            {
                Id = 12,
                Name = "Radionica o stresu",
                EventTypeId = 5,
                StartDate = new DateTime(2023, 10, 12),
                EndDate = new DateTime(2023, 10, 13),
                EmployeeId = 2
            },
            new Event
            {
                Id = 13,
                Name = "Praznična proslava",
                EventTypeId = 2,
                StartDate = new DateTime(2023, 12, 22),
                EndDate = new DateTime(2023, 12, 22),
                EmployeeId = 1
            },
            new Event
            {
                Id = 14,
                Name = "Timski sastanak",
                EventTypeId = 1,
                StartDate = new DateTime(2023, 8, 17),
                EndDate = new DateTime(2023, 8, 17),
                EmployeeId = 1
            },
            new Event
            {
                Id = 15,
                Name = "Volonterska akcija - čišćenje parka",
                EventTypeId = 5,
                StartDate = new DateTime(2023, 9, 9),
                EndDate = new DateTime(2023, 9, 9),
                EmployeeId = 5
            },
            new Event
            {
                Id = 16,
                Name = "Rad od kuće - Remote Week",
                EventTypeId = 4,
                StartDate = new DateTime(2023, 10, 9),
                EndDate = new DateTime(2023, 10, 13),
                EmployeeId = 6
            },
            new Event
            {
                Id = 17,
                Name = "Prezentacija poslovnih rezultata",
                EventTypeId = 1,
                StartDate = new DateTime(2023, 11, 5),
                EndDate = new DateTime(2023, 11, 5),
                EmployeeId = 7
            },
            new Event
            {
                Id = 18,
                Name = "Timski izlet na jezero",
                EventTypeId = 3,
                StartDate = new DateTime(2023, 9, 29),
                EndDate = new DateTime(2023, 10, 1),
                EmployeeId = 1
            },
            new Event
            {
                Id = 19,
                Name = "Trening radionica - Upravljanje vremenom",
                EventTypeId = 4,
                StartDate = new DateTime(2023, 10, 20),
                EndDate = new DateTime(2023, 10, 21),
                EmployeeId = 2
            },
            new Event
            {
                Id = 20,
                Name = "Timski sastanak - Planiranje Q4 projekata",
                EventTypeId = 1,
                StartDate = new DateTime(2023, 11, 10),
                EndDate = new DateTime(2023, 11, 10),
                EmployeeId = 2
            },
            new Event
            {
                Id = 21,
                Name = "Seminar o komunikaciji",
                EventTypeId = 4,
                StartDate = new DateTime(2023, 10, 5),
                EndDate = new DateTime(2023, 10, 6),
                EmployeeId = 2
            },
            new Event
            {
                Id = 22,
                Name = "Poslovni ručak sa partnerima",
                EventTypeId = 3,
                StartDate = new DateTime(2023, 11, 18),
                EndDate = new DateTime(2023, 11, 18),
                EmployeeId = 2
            },
            new Event
            {
                Id = 23,
                Name = "Sastanak sa klijentima",
                EventTypeId = 3,
                StartDate = new DateTime(2023, 12, 7),
                EndDate = new DateTime(2023, 12, 7),
                EmployeeId = 2
            }
        );
    }
}