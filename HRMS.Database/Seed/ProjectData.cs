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
               },
               new Project
               {
                   Id = 5,
                   Name = "Medicinska Oprema BH",
                   Description = "Medicinska Oprema BH je projekat usmjeren na prodaju medicinske opreme i potrošnih materijala u Bosni i Hercegovini."
               },
               new Project
               {
                   Id = 6,
                   Name = "Art Galerija Sarajevo",
                   Description = "Art Galerija Sarajevo je online platforma za prodaju umjetničkih djela, sa fokusom na lokalne umjetnike iz Sarajeva."
               },
               new Project
               {
                   Id = 7,
                   Name = "Restoran GastroMIX",
                   Description = "Restoran GastroMIX je restoran specijaliziran za internacionalnu kuhinju sa naglaskom na fusion jelima."
               },
               new Project
               {
                   Id = 8,
                   Name = "IT Konsalting BH",
                   Description = "IT Konsalting BH pruža IT konsultantske usluge za kompanije u Bosni i Hercegovini, sa ciljem optimizacije poslovnih procesa."
               },
               new Project
               {
                   Id = 9,
                   Name = "Turistička Agencija Sarajevo Explorer",
                   Description = "Turistička Agencija Sarajevo Explorer se bavi organizacijom turističkih tura i putovanja u Sarajevu i okolini, promovišući kulturno i prirodno bogatstvo regije."
               },
               new Project
               {
                   Id = 10,
                   Name = "EduTech BH",
                   Description = "EduTech BH je projekat usmjeren na razvoj edukativnih tehnologija za bolje obrazovanje u Bosni i Hercegovini."
               }
           );
    }
}