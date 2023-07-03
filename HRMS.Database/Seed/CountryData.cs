using HRMS.Database.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRMS.Database.Seed;

public static class CountryData
{
    public static void SeedData(this EntityTypeBuilder<Country> entity)
    {
        entity.HasData(
            new Country
            {
                Id = 1,
                Name = "Bosna i Hercegovina"
            },
            new Country
            {
                Id = 2,
                Name = "Crna Gora"
            },
            new Country
            {
                Id = 3,
                Name = "Hrvatska"
            },
            new Country
            {
                Id = 4,
                Name = "Makedonija"
            },
            new Country
            {
                Id = 5,
                Name = "Slovenija"
            },
            new Country
            {
                Id = 6,
                Name = "Srbija"
            }
        );
    }
}