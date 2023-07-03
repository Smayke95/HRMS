using HRMS.Database.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRMS.Database.Seed;

public static class ProjectData
{
    public static void SeedData(this EntityTypeBuilder<Project> entity)
    {
        entity.HasData(
               new Project
               {
                   Id = 1,
                   Name = "Sanovo Group",
                   Description = "Sanovo Group je kompanija sa sjedistem u Danskoj. Bave se proizvodnjom masina za preradu jaja."
               },
               new Project
               {
                   Id = 2,
                   Name = "Designa",
                   Description = "Designa je kompanija sa sjedistem u Norveskoj. Bave se proizvodnjom elemenata za kuhinje, kupatila i spavace sobe."
               },
               new Project
               {
                   Id = 3,
                   Name = "Autokonzept",
                   Description = "Autokonzept je projekat napravljen za Danskog klijenta. Svrha sistema je iznajmljivanje automobila."
               },
               new Project
               {
                   Id = 4,
                   Name = "Vejers",
                   Description = "Vejers je sistem napravljen za iznajmljivanje kuca na jugu Danske, iznajmljivanje se vrsi preko Booking studija."
               }
           );
    }
}