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
               },
               new Task
               {
                   Id = 5,
                   Name = "Optimizacija Baze Podataka",
                   Description = "Optimizirati upite u bazi podataka radi poboljšane performanse.",
                   TaskStatusId = 1,
                   TaskTypeId = 3,
                   ProjectId = 2,
                   EmployeeId = 3
               },
               new Task
               {
                   Id = 6,
                   Name = "Implementacija Nove Funkcionalnosti",
                   Description = "Implementirati novu funkcionalnost prema zahtjevima klijenta.",
                   TaskStatusId = 2,
                   TaskTypeId = 2,
                   ProjectId = 5,
                   EmployeeId = 4
               },
               new Task
               {
                   Id = 7,
                   Name = "Unapređenje Korisničkog Sučelja",
                   Description = "Unaprijediti korisničko sučelje radi boljeg korisničkog iskustva.",
                   TaskStatusId = 3,
                   TaskTypeId = 3,
                   ProjectId = 7,
                   EmployeeId = 5
               },
               new Task
               {
                   Id = 8,
                   Name = "Ažuriranje Dokumentacije",
                   Description = "Ažurirati dokumentaciju projekta s najnovijim promjenama.",
                   TaskStatusId = 4,
                   TaskTypeId = 5,
                   ProjectId = 9,
                   EmployeeId = 6
               },
               new Task
               {
                   Id = 9,
                   Name = "Istraživanje Novih Tehnologija",
                   Description = "Izvršiti istraživanje novih tehnologija za buduće projekte.",
                   TaskStatusId = 1,
                   TaskTypeId = 6,
                   ProjectId = 10,
                   EmployeeId = 7
               },
               new Task
               {
                   Id = 10,
                   Name = "Sigurnosna Revizija",
                   Description = "Izvršiti sigurnosnu reviziju sustava kako bi se identificirale ranjivosti.",
                   TaskStatusId = 2,
                   TaskTypeId = 6,
                   ProjectId = 8,
                   EmployeeId = 8
               }
           );
    }
}