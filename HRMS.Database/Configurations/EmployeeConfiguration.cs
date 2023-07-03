using HRMS.Database.Models;
using HRMS.Database.Seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRMS.Database.Configurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasOne(x => x.BirthPlace)
               .WithMany()
               .IsRequired(false);

        builder.HasOne(x => x.City)
               .WithMany()
               .IsRequired(false);

        builder.SeedData();
    }
}