using HRMS.Database.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRMS.Database.Seed;

public static class TaskTypeData
{
    public static void SeedData(this EntityTypeBuilder<TaskType> entity)
    {
        entity.HasData(
             new TaskType
             {
                 Id = 1,
                 Name = "Bug"
             },
             new TaskType
             {
                 Id = 2,
                 Name = "Feature"
             },
             new TaskType
             {
                 Id = 3,
                 Name = "Poboljšanje"
             },
             new TaskType
             {
                 Id = 4,
                 Name = "Održavanje"
             },
             new TaskType
             {
                 Id = 5,
                 Name = "Dokumentovanje"
             },
             new TaskType
             {
                 Id = 6,
                 Name = "Istraživanje"
             }
         );
    }
}