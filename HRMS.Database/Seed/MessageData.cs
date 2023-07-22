using HRMS.Database.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRMS.Database.Seed;

public static class MessageData
{
    public static void SeedData(this EntityTypeBuilder<Message> entity)
    {
        entity.HasData(
            new Message
            {
                Id = 1,
                Text = "Dobro jutro Irena",
                Time = new DateTime(2023, 7, 22, 12, 1, 0),
                Room = "AnesSmajicIrenaVilic",
                EmployeeId = 1
            },
            new Message
            {
                Id = 2,
                Text = "Kako si danas?",
                Time = new DateTime(2023, 7, 22, 12, 2, 0),
                Room = "AnesSmajicIrenaVilic",
                EmployeeId = 1
            },
            new Message
            {
                Id = 3,
                Text = "Jutro Anese",
                Time = new DateTime(2023, 7, 22, 12, 3, 0),
                Room = "AnesSmajicIrenaVilic",
                EmployeeId = 2
            },
            new Message
            {
                Id = 4,
                Text = "Odlično sam, hvala. Kako si ti?",
                Time = new DateTime(2023, 7, 22, 12, 4, 0),
                Room = "AnesSmajicIrenaVilic",
                EmployeeId = 2
            },
            new Message
            {
                Id = 5,
                Text = "Također dobro, hvala. Imaš li neki plan za danas?",
                Time = new DateTime(2023, 7, 22, 12, 5, 0),
                Room = "AnesSmajicIrenaVilic",
                EmployeeId = 1
            },
            new Message
            {
                Id = 6,
                Text = "Da, imam par sastanaka i trebam završiti taj novi izvještaj do kraja dana",
                Time = new DateTime(2023, 7, 22, 12, 6, 0),
                Room = "AnesSmajicIrenaVilic",
                EmployeeId = 2
            },
            new Message
            {
                Id = 7,
                Text = "A ti?",
                Time = new DateTime(2023, 7, 22, 12, 7, 0),
                Room = "AnesSmajicIrenaVilic",
                EmployeeId = 2
            },
            new Message
            {
                Id = 8,
                Text = "Također imam sastanak ujutro",
                Time = new DateTime(2023, 7, 22, 12, 8, 0),
                Room = "AnesSmajicIrenaVilic",
                EmployeeId = 1
            },
            new Message
            {
                Id = 9,
                Text = "ali popodne imam nekoliko sati slobodno",
                Time = new DateTime(2023, 7, 22, 12, 9, 0),
                Room = "AnesSmajicIrenaVilic",
                EmployeeId = 1
            },
            new Message
            {
                Id = 10,
                Text = "Planiram završiti projekt koji radim",
                Time = new DateTime(2023, 7, 22, 12, 10, 0),
                Room = "AnesSmajicIrenaVilic",
                EmployeeId = 1
            },
            new Message
            {
                Id = 11,
                Text = "Zvuči kao da ćeš imati produktivan dan. Treba li ti ikakva pomoć s tim projektom?",
                Time = new DateTime(2023, 7, 22, 12, 11, 0),
                Room = "AnesSmajicIrenaVilic",
                EmployeeId = 2
            },
            new Message
            {
                Id = 12,
                Text = "Hvala na ponudi. Možda ću morati provjeriti neke podatke, pa ako imam pitanja, sigurno ću ti se obratiti",
                Time = new DateTime(2023, 7, 22, 12, 12, 0),
                Room = "AnesSmajicIrenaVilic",
                EmployeeId = 1
            },
            new Message
            {
                Id = 13,
                Text = "Svakako, uvijek sam tu da pomognem",
                Time = new DateTime(2023, 7, 22, 12, 13, 0),
                Room = "AnesSmajicIrenaVilic",
                EmployeeId = 2
            },
            new Message
            {
                Id = 14,
                Text = "Inače",
                Time = new DateTime(2023, 7, 22, 12, 14, 0),
                Room = "AnesSmajicIrenaVilic",
                EmployeeId = 2
            },
            new Message
            {
                Id = 15,
                Text = "što misliš o novom uređenju ureda?",
                Time = new DateTime(2023, 7, 22, 12, 15, 0),
                Room = "AnesSmajicIrenaVilic",
                EmployeeId = 2
            },
            new Message
            {
                Id = 16,
                Text = "Meni se sviđa! Osjećam se puno udobnije u ovom novom okruženju",
                Time = new DateTime(2023, 7, 22, 12, 16, 0),
                Room = "AnesSmajicIrenaVilic",
                EmployeeId = 1
            },
            new Message
            {
                Id = 17,
                Text = "A tebi?",
                Time = new DateTime(2023, 7, 22, 12, 17, 0),
                Room = "AnesSmajicIrenaVilic",
                EmployeeId = 1
            },
            new Message
            {
                Id = 18,
                Text = "Potpuno se slažem",
                Time = new DateTime(2023, 7, 22, 12, 18, 0),
                Room = "AnesSmajicIrenaVilic",
                EmployeeId = 2
            },
            new Message
            {
                Id = 19,
                Text = "Ovo je puno svjetlije i prostranije",
                Time = new DateTime(2023, 7, 22, 12, 19, 0),
                Room = "AnesSmajicIrenaVilic",
                EmployeeId = 2
            },
            new Message
            {
                Id = 20,
                Text = "Nekako mi daje više inspiracije za rad",
                Time = new DateTime(2023, 7, 22, 12, 20, 0),
                Room = "AnesSmajicIrenaVilic",
                EmployeeId = 2
            },
            new Message
            {
                Id = 21,
                Text = "Da, baš tako! Volim kako je timski duh u ovom uredu, svi surađujemo tako dobro",
                Time = new DateTime(2023, 7, 22, 12, 21, 0),
                Room = "AnesSmajicIrenaVilic",
                EmployeeId = 1
            },
            new Message
            {
                Id = 22,
                Text = "Upravo tako!",
                Time = new DateTime(2023, 7, 22, 12, 22, 0),
                Room = "AnesSmajicIrenaVilic",
                EmployeeId = 2
            },
            new Message
            {
                Id = 23,
                Text = "Baš zbog toga nam i ide ovako dobro",
                Time = new DateTime(2023, 7, 22, 12, 23, 0),
                Room = "AnesSmajicIrenaVilic",
                EmployeeId = 2
            },
            new Message
            {
                Id = 24,
                Text = "Tako je. Sve u svemu, zadovoljan sam kako stvari idu na poslu",
                Time = new DateTime(2023, 7, 22, 12, 24, 0),
                Room = "AnesSmajicIrenaVilic",
                EmployeeId = 1
            },
            new Message
            {
                Id = 25,
                Text = "I ja isto! Ako ikada trebaš razgovarati o bilo čemu ili trebaš pomoć, slobodno mi se obrati",
                Time = new DateTime(2023, 7, 22, 12, 25, 0),
                Room = "AnesSmajicIrenaVilic",
                EmployeeId = 2
            },
            new Message
            {
                Id = 26,
                Text = "Hvala Irena",
                Time = new DateTime(2023, 7, 22, 12, 26, 0),
                Room = "AnesSmajicIrenaVilic",
                EmployeeId = 1
            },
            new Message
            {
                Id = 27,
                Text = "Cijenim to",
                Time = new DateTime(2023, 7, 22, 12, 27, 0),
                Room = "AnesSmajicIrenaVilic",
                EmployeeId = 1
            },
            new Message
            {
                Id = 28,
                Text = "Nema na čemu. Sada se moram vratiti radu, ali ako želiš, možemo se kasnije ponovno čuti.",
                Time = new DateTime(2023, 7, 22, 12, 28, 0),
                Room = "AnesSmajicIrenaVilic",
                EmployeeId = 2
            },
            new Message
            {
                Id = 29,
                Text = "U redu, zvuči dobro. Sretno s tvojim sastancima i projektom!",
                Time = new DateTime(2023, 7, 22, 12, 29, 0),
                Room = "AnesSmajicIrenaVilic",
                EmployeeId = 1
            },
            new Message
            {
                Id = 30,
                Text = "Hvala! I tebi želim uspješan dan",
                Time = new DateTime(2023, 7, 22, 12, 30, 0),
                Room = "AnesSmajicIrenaVilic",
                EmployeeId = 2
            },
            new Message
            {
                Id = 31,
                Text = "Čujemo se kasnije",
                Time = new DateTime(2023, 7, 22, 12, 31, 0),
                Room = "AnesSmajicIrenaVilic",
                EmployeeId = 2
            },
            new Message
            {
                Id = 32,
                Text = "Čujemo se",
                Time = new DateTime(2023, 7, 22, 12, 32, 0),
                Room = "AnesSmajicIrenaVilic",
                EmployeeId = 1
            }
        );
    }
}