using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task = HRMS.Database.Models.Task;

namespace HRMS.Database.Seed;

public static class TaskData
{
    public static void SeedData(this EntityTypeBuilder<Task> entity)
    {
        entity.HasData(
               new Task
               {
                   Id = 1,
                   Name = "Markup",
                   Description = "Napraviti markup po datom dizajnu.",
                   TaskStatusId = 1,
                   TaskTypeId = 2,
                   ProjectId = 1,
                   EmployeeId = 1
               },
               new Task
               {
                   Id = 2,
                   Name = "Mailchimp",
                   Description = "Odraditi integraciju newsletter signup-a.",
                   TaskStatusId = 2,
                   TaskTypeId = 1,
                   ProjectId = 1,
                   EmployeeId = 2
               },
               new Task
               {
                   Id = 3,
                   Name = "Banner komponenta",
                   Description = "Napraviti banner komponentu.",
                   TaskStatusId = 3,
                   TaskTypeId = 1,
                   ProjectId = 3,
                   EmployeeId = 2
               },
               new Task
               {
                   Id = 4,
                   Name = "Popraviti bug u footer-u",
                   Description = "Ispraviti footer prema dizajnu.",
                   TaskStatusId = 4,
                   TaskTypeId = 2,
                   ProjectId = 4,
                   EmployeeId = 1
               }
           );
    }
}