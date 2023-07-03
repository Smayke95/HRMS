using HRMS.Database.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRMS.Database.Seed;

public static class EmploymentTypeData
{
    public static void SeedData(this EntityTypeBuilder<EmploymentType> entity)
    {
        entity.HasData(
            new EmploymentType
            {
                Id = 1,
                Name = "Određeno"
            },
            new EmploymentType
            {
                Id = 2,
                Name = "Neodređeno"
            }
        );
    }
}