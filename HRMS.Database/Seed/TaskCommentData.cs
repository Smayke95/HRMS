using HRMS.Database.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRMS.Database.Seed;

public static class TaskCommentData
{
    public static void SeedData(this EntityTypeBuilder<TaskComment> entity)
    {
        entity.HasData(
               new TaskComment
               {
                   Id = 1,
                   Content = "Task preuzet dana 19.8. i stavljen 'In progress'.",
                   Time = DateTime.Now,
                   TaskId = 1,
                   EmployeeId = 1
               },
               new TaskComment
               {
                   Id = 2,
                   Content = "Task zavrsen.",
                   Time = DateTime.Now,
                   TaskId = 2,
                   EmployeeId = 2
               },
               new TaskComment
               {
                   Id = 3,
                   Content = "Hvala na preuzimanju zadatka. Pogledat ću dizajn i krenuti s markup-om.",
                   Time = DateTime.Now.AddHours(-2),
                   TaskId = 1,
                   EmployeeId = 3
               },
               new TaskComment
               {
                    Id = 4,
                    Content = "Nema na čemu! Ako imate bilo kakvih pitanja, slobodno pitajte.",
                    Time = DateTime.Now.AddHours(-1),
                    TaskId = 1,
                    EmployeeId = 1
               },
               new TaskComment
               {
                    Id = 5,
                    Content = "Task označen kao 'In progress'. Radim na integraciji s Mailchimp-om.",
                    Time = DateTime.Now.AddHours(-3),
                    TaskId = 2,
                    EmployeeId = 4
               },
               new TaskComment
               {
                    Id = 6,
                    Content = "Super! Javite ako naiđete na bilo kakve prepreke.",
                    Time = DateTime.Now.AddHours(-2),
                    TaskId = 2,
                    EmployeeId = 2
               },
               new TaskComment
               {
                    Id = 7,
                    Content = "Banner komponenta uspješno dodana projektu. Čeka se vaš feedback.",
                    Time = DateTime.Now.AddHours(-4),
                    TaskId = 3,
                    EmployeeId = 5
               },
               new TaskComment
               {
                    Id = 8,
                    Content = "Izgleda odlično! Samo malo promijenite nijanse boja.",
                    Time = DateTime.Now.AddHours(-3),
                    TaskId = 3,
                    EmployeeId = 3
               },
               new TaskComment
               {
                    Id = 9,
                    Content = "Bug u footer-u uspješno riješen.",
                    Time = DateTime.Now.AddHours(-5),
                    TaskId = 4,
                    EmployeeId = 6
               },
               new TaskComment
               {
                    Id = 10,
                    Content = "Savršeno! Zatvaram task.",
                    Time = DateTime.Now.AddHours(-4),
                    TaskId = 4,
                    EmployeeId = 4
               }
           );
    }
}