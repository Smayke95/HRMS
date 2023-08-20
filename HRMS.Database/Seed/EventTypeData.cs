using HRMS.Database.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRMS.Database.Seed;

public static class EventTypeData
{
    public static void SeedData(this EntityTypeBuilder<EventType> entity)
    {
        entity.HasData(
            new EventType
            {
                Id = 1,
                Name = "Godišnji odmor",
                IsApprovalRequired = true,
                Color = "#4caf50"
            },
            new EventType
            {
                Id = 2,
                Name = "Vjerski praznik",
                IsApprovalRequired = true,
                Color = "#1e88e5"
            },
            new EventType
            {
                Id = 3,
                Name = "Bolovanje",
                IsApprovalRequired = true,
                Color = "#ff9800"
            },
            new EventType
            {
                Id = 4,
                Name = "Plaćeno odsustvo",
                IsApprovalRequired = true,
                Color = "#3a87ad"
            },
            new EventType
            {
                Id = 5,
                Name = "Neplaćeno odsustvo",
                IsApprovalRequired = true,
                Color = "#fb1b1b"
            },
            new EventType
            {
                Id = 6,
                Name = "Obuka",
                IsApprovalRequired = true,
                Color = "#9c27b0"
            },
            new EventType
            {
                Id = 7,
                Name = "Timski sastanak",
                IsApprovalRequired = false,
                Color = "#795548"
            }
        );
    }
}