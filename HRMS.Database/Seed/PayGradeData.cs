using HRMS.Database.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRMS.Database.Seed;

public static class PayGradeData
{
    public static void SeedData(this EntityTypeBuilder<PayGrade> entity)
    {
        entity.HasData(
            new PayGrade
            {
                Id = 1,
                Name = "A1",
                MinAmount = 4000,
                MaxAmount = 10000
            },
            new PayGrade
            {
                Id = 2,
                Name = "A2",
                MinAmount = 4000,
                MaxAmount = 5000
            },
            new PayGrade
            {
                Id = 3,
                Name = "A3",
                MinAmount = 3000,
                MaxAmount = 4000
            },
            new PayGrade
            {
                Id = 4,
                Name = "B1",
                MinAmount = 2500,
                MaxAmount = 3000
            },
            new PayGrade
            {
                Id = 5,
                Name = "B2",
                MinAmount = 2000,
                MaxAmount = 2500
            },
            new PayGrade
            {
                Id = 6,
                Name = "C",
                MinAmount = 500,
                MaxAmount = 2000
            }
        );
    }
}