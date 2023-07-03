using HRMS.Database.Models;
using HRMS.Database.Models.Enums;
using HRMS.Database.Seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRMS.Database.Configurations;

public class LogConfiguration : IEntityTypeConfiguration<Log>
{
    public void Configure(EntityTypeBuilder<Log> builder)
    {
        builder.Property(x => x.Type)
               .HasConversion(
                    x => x.ToString(),
                    x => (LogType)Enum.Parse(typeof(LogType), x)
               );

        builder.SeedData();
    }
}