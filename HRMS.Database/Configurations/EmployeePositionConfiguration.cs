using HRMS.Core.Models.Enums;
using HRMS.Database.Models;
using HRMS.Database.Seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRMS.Database.Configurations;

public class EmployeePositionConfiguration : IEntityTypeConfiguration<EmployeePosition>
{
    public void Configure(EntityTypeBuilder<EmployeePosition> builder)
    {
        builder.Property(x => x.Type)
               .HasConversion(
                    x => x.ToString(),
                    x => (EmploymentType)Enum.Parse(typeof(EmploymentType), x)
               );

        builder.Property(x => x.Status)
               .HasConversion(
                    x => x.ToString(),
                    x => (EmploymentStatus)Enum.Parse(typeof(EmploymentStatus), x)
               );

        builder.SeedData();
    }
}