using HRMS.Database.Models;
using HRMS.Database.Models.Enums;
using HRMS.Database.Seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRMS.Database.Configurations;

public class EmployeePositionConfiguration : IEntityTypeConfiguration<EmployeePosition>
{
    public void Configure(EntityTypeBuilder<EmployeePosition> builder)
    {
        builder.Property(x => x.EmploymentType)
               .HasConversion(
                    x => x.ToString(),
                    x => (EmploymentType)Enum.Parse(typeof(EmploymentType), x)
               );

        builder.SeedData();
    }
}