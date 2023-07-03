using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskStatus = HRMS.Database.Models.TaskStatus;

namespace HRMS.Database.Seed;

public static class TaskStatusData
{
    public static void SeedData(this EntityTypeBuilder<TaskStatus> entity)
    {
        entity.HasData(
             new TaskStatus
             {
                 Id = 1,
                 Name = "Kreiran"
             },
             new TaskStatus
             {
                 Id = 2,
                 Name = "Aktivan"
             },
             new TaskStatus
             {
                 Id = 3,
                 Name = "Riješen"
             },
             new TaskStatus
             {
                 Id = 4,
                 Name = "Zatvoren"
             }
         );
    }
}