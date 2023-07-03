using HRMS.Database.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRMS.Database.Seed;

public static class EducationData
{
    public static void SeedData(this EntityTypeBuilder<Education> entity)
    {
        entity.HasData(
            new Education
            {
                Id = 1,
                ISCED = "1/2A",
                EQF = 1,
                Qualification = "Nekvalificirani radnik",
                FinishedEducation = "Osnovno obrazovanje",
                QualificationOld = "Nekvalificirani radnik (NK)",
                FinishedEducationOld = "Osnovna škola"
            },
            new Education
            {
                Id = 2,
                ISCED = "2B",
                EQF = 2,
                Qualification = "Niskokvalificirani radnik",
                FinishedEducation = "Programi stručnog osposobljavanja",
                QualificationOld = "Polukvalificirani radnik (PKV)",
                FinishedEducationOld = "Osnovna škola i stručna osposobljenost"
            },
            new Education
            {
                Id = 3,
                ISCED = "3C",
                EQF = 3,
                Qualification = "Kvalificirani radnik",
                FinishedEducation = "Srednje stručno obrazovanje i obuka",
                QualificationOld = "Kvalificirani radnik (KV)",
                FinishedEducationOld = "Trogodišnja srednja škola"
            },
            new Education
            {
                Id = 4,
                ISCED = "3A/3B",
                EQF = 4,
                Qualification = "Opće ili specijalizirani kvalificirani radnik",
                FinishedEducation = "Srednje opće i tehničko obrazovanje",
                QualificationOld = "Srednja stručna sprema (SSS)",
                FinishedEducationOld = "Četverogodišnja srednja škola"
            },
            new Education
            {
                Id = 5,
                ISCED = "4A/4B",
                EQF = 5,
                Qualification = "Visokokvalificirani radnik specijaliziran za određeno zanimanje",
                FinishedEducation = "Postsekundarno obrazovanje uključujući majstorske i srodne ispite",
                QualificationOld = "Visokokvalificiran radnik (VKV)",
                FinishedEducationOld = "Specijalizacija na osnovu stručnosti srednjeg obrazovanja"
            },
            new Education
            {
                Id = 6,
                ISCED = "5B",
                EQF = 6,
                Qualification = "Bachelor ili Baccalaureat",
                FinishedEducation = "Prvi ciklus visokog obrazovanja",
                QualificationOld = "Viša stručna sprema (VŠS)",
                FinishedEducationOld = "Viša škola"
            },
            new Education
            {
                Id = 7,
                ISCED = "5A",
                EQF = 7,
                Qualification = "Master",
                FinishedEducation = "Drugi ciklus visokog obrazovanja",
                QualificationOld = "Visoka stručna sprema (VSS) / Magistar specijalist",
                FinishedEducationOld = "Fakultet - osnovne studije / Specijalizacija"
            },
            new Education
            {
                Id = 8,
                ISCED = "5/6",
                EQF = 8,
                Qualification = "Doktorat",
                FinishedEducation = "Treći ciklus visokog obrazovanja",
                QualificationOld = "Magistar nauka / Doktor nauka",
                FinishedEducationOld = "Magisterij / Doktorat"
            }
        );
    }
}