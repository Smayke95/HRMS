using HRMS.Database.Models;
using HRMS.Database.Models.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRMS.Database.Seed;

public static class LogData
{
    public static void SeedData(this EntityTypeBuilder<Log> entity)
    {
        entity.HasData(
            new Log
            {
                Id = 1,
                Date = DateTime.Now,
                Type = LogType.INFO,
                Message = ""
            },
            new Log
            {
                Id = 2,
                Date = DateTime.Now,
                Type = LogType.WARNING,
                Message = ""
            },
            new Log
            {
                Id = 3,
                Date = DateTime.Now,
                Type = LogType.ERROR,
                Message = ""
            }
        );
    }
}