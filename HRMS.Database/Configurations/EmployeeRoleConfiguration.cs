using HRMS.Core.Models.Enums;
using HRMS.Database.Models;
using HRMS.Database.Seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRMS.Database.Configurations;

public class EmployeeRoleConfiguration : IEntityTypeConfiguration<EmployeeRole>
{
    public void Configure(EntityTypeBuilder<EmployeeRole> builder)
    {
        builder.Property(x => x.Role)
               .HasConversion(
                    x => x.ToString(),
                    x => (Role)Enum.Parse(typeof(Role), x)
               );

        builder.SeedData();
    }
}