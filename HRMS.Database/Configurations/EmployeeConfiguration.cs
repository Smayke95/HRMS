using HRMS.Core.Models.Enums;
using HRMS.Database.Models;
using HRMS.Database.Seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRMS.Database.Configurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.Property(x => x.Gender)
               .HasConversion(
                    x => x.ToString(),
                    x => (Gender)Enum.Parse(typeof(Gender), x)
               );

        builder.HasOne(x => x.BirthPlace)
               .WithMany()
               .IsRequired(false);

        builder.HasOne(x => x.City)
               .WithMany()
               .IsRequired(false);

        builder.SeedData();
    }
}