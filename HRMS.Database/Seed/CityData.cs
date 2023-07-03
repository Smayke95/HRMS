using HRMS.Database.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRMS.Database.Seed;

public static class CityData
{
    public static void SeedData(this EntityTypeBuilder<City> entity)
    {
        entity.HasData(
            new City
            {
                Id = 1,
                Name = "Beograd",
                CountryId = 6
            },
            new City
            {
                Id = 2,
                Name = "Jablanica",
                ZipCode = "88420",
                CountryId = 1
            },
            new City
            {
                Id = 3,
                Name = "Konjic",
                ZipCode = "88400",
                CountryId = 1
            },
            new City
            {
                Id = 4,
                Name = "Ljubljana",
                CountryId = 5
            },
            new City
            {
                Id = 5,
                Name = "Mostar",
                ZipCode = "88000",
                CountryId = 1
            },
            new City
            {
                Id = 6,
                Name = "Priština",
                CountryId = 2
            },
            new City
            {
                Id = 7,
                Name = "Sarajevo",
                ZipCode = "71000",
                CountryId = 1
            },
            new City
            {
                Id = 8,
                Name = "Skoplje",
                CountryId = 4
            },
            new City
            {
                Id = 9,
                Name = "Zagreb",
                CountryId = 3
            }
        );
    }
}