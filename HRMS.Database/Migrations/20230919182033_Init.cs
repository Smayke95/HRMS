﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HRMS.Database.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Educations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ISCED = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EQF = table.Column<int>(type: "int", nullable: false),
                    Qualification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FinishedEducation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QualificationOld = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FinishedEducationOld = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Educations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsApprovalRequired = table.Column<bool>(type: "bit", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PayGrades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaxAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayGrades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaskStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaskTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaidenName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonalIdentificationNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkerCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BirthPlaceId = table.Column<int>(type: "int", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    CitizenshipId = table.Column<int>(type: "int", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OfficePhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Profession = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EducationId = table.Column<int>(type: "int", nullable: true),
                    PreviousLOSYears = table.Column<int>(type: "int", nullable: false),
                    PreviousLOSMonths = table.Column<int>(type: "int", nullable: false),
                    BankAccount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Cities_BirthPlaceId",
                        column: x => x.BirthPlaceId,
                        principalTable: "Cities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employees_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employees_Countries_CitizenshipId",
                        column: x => x.CitizenshipId,
                        principalTable: "Countries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employees_Educations_EducationId",
                        column: x => x.EducationId,
                        principalTable: "Educations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentDepartmentId = table.Column<int>(type: "int", nullable: true),
                    Level = table.Column<int>(type: "int", nullable: false),
                    SupervisorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departments_Departments_ParentDepartmentId",
                        column: x => x.ParentDepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Departments_Employees_SupervisorId",
                        column: x => x.SupervisorId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeRoles_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventTypeId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Events_EventTypes_EventTypeId",
                        column: x => x.EventTypeId,
                        principalTable: "EventTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Room = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: true),
                    TaskStatusId = table.Column<int>(type: "int", nullable: true),
                    TaskTypeId = table.Column<int>(type: "int", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tasks_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tasks_TaskStatuses_TaskStatusId",
                        column: x => x.TaskStatusId,
                        principalTable: "TaskStatuses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tasks_TaskTypes_TaskTypeId",
                        column: x => x.TaskTypeId,
                        principalTable: "TaskTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    PayGradeId = table.Column<int>(type: "int", nullable: false),
                    RequiredEducationId = table.Column<int>(type: "int", nullable: false),
                    IsWorkExperienceRequired = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Positions_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Positions_Educations_RequiredEducationId",
                        column: x => x.RequiredEducationId,
                        principalTable: "Educations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Positions_PayGrades_PayGradeId",
                        column: x => x.PayGradeId,
                        principalTable: "PayGrades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaskComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaskId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskComments_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskComments_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeePositions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    PositionId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "Date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "Date", nullable: true),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VacationDays = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkingHours = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeePositions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeePositions_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeePositions_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Bosna i Hercegovina" },
                    { 2, "Crna Gora" },
                    { 3, "Hrvatska" },
                    { 4, "Makedonija" },
                    { 5, "Slovenija" },
                    { 6, "Srbija" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Level", "Name", "ParentDepartmentId", "SupervisorId" },
                values: new object[] { 1, 0, "HRMS", null, null });

            migrationBuilder.InsertData(
                table: "Educations",
                columns: new[] { "Id", "EQF", "FinishedEducation", "FinishedEducationOld", "ISCED", "Qualification", "QualificationOld" },
                values: new object[,]
                {
                    { 1, 1, "Osnovno obrazovanje", "Osnovna škola", "1/2A", "Nekvalificirani radnik", "Nekvalificirani radnik (NK)" },
                    { 2, 2, "Programi stručnog osposobljavanja", "Osnovna škola i stručna osposobljenost", "2B", "Niskokvalificirani radnik", "Polukvalificirani radnik (PKV)" },
                    { 3, 3, "Srednje stručno obrazovanje i obuka", "Trogodišnja srednja škola", "3C", "Kvalificirani radnik", "Kvalificirani radnik (KV)" },
                    { 4, 4, "Srednje opće i tehničko obrazovanje", "Četverogodišnja srednja škola", "3A/3B", "Opće ili specijalizirani kvalificirani radnik", "Srednja stručna sprema (SSS)" },
                    { 5, 5, "Postsekundarno obrazovanje uključujući majstorske i srodne ispite", "Specijalizacija na osnovu stručnosti srednjeg obrazovanja", "4A/4B", "Visokokvalificirani radnik specijaliziran za određeno zanimanje", "Visokokvalificiran radnik (VKV)" },
                    { 6, 6, "Prvi ciklus visokog obrazovanja", "Viša škola", "5B", "Bachelor ili Baccalaureat", "Viša stručna sprema (VŠS)" },
                    { 7, 7, "Drugi ciklus visokog obrazovanja", "Fakultet - osnovne studije / Specijalizacija", "5A", "Master", "Visoka stručna sprema (VSS) / Magistar specijalist" },
                    { 8, 8, "Treći ciklus visokog obrazovanja", "Magisterij / Doktorat", "5/6", "Doktorat", "Magistar nauka / Doktor nauka" }
                });

            migrationBuilder.InsertData(
                table: "EventTypes",
                columns: new[] { "Id", "Color", "IsApprovalRequired", "Name" },
                values: new object[,]
                {
                    { 1, "#4caf50", true, "Godišnji odmor" },
                    { 2, "#1e88e5", true, "Vjerski praznik" },
                    { 3, "#ff9800", true, "Bolovanje" },
                    { 4, "#3a87ad", true, "Plaćeno odsustvo" },
                    { 5, "#fb1b1b", true, "Neplaćeno odsustvo" },
                    { 6, "#9c27b0", true, "Obuka" },
                    { 7, "#795548", false, "Timski sastanak" }
                });

            migrationBuilder.InsertData(
                table: "PayGrades",
                columns: new[] { "Id", "MaxAmount", "MinAmount", "Name" },
                values: new object[,]
                {
                    { 1, 10000m, 4000m, "A1" },
                    { 2, 5000m, 4000m, "A2" },
                    { 3, 4000m, 3000m, "A3" },
                    { 4, 3000m, 2500m, "B1" },
                    { 5, 2500m, 2000m, "B2" },
                    { 6, 2000m, 500m, "C" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Sanovo Group je kompanija sa sjedistem u Danskoj. Bave se proizvodnjom masina za preradu jaja.", "Sanovo Group" },
                    { 2, "Designa je kompanija sa sjedistem u Norveskoj. Bave se proizvodnjom elemenata za kuhinje, kupatila i spavace sobe.", "Designa" },
                    { 3, "Autokonzept je projekat napravljen za Danskog klijenta. Svrha sistema je iznajmljivanje automobila.", "Autokonzept" },
                    { 4, "Vejers je sistem napravljen za iznajmljivanje kuca na jugu Danske, iznajmljivanje se vrsi preko Booking studija.", "Vejers" },
                    { 5, "Medicinska Oprema BH je projekat usmjeren na prodaju medicinske opreme i potrošnih materijala u Bosni i Hercegovini.", "Medicinska Oprema BH" },
                    { 6, "Art Galerija Sarajevo je online platforma za prodaju umjetničkih djela, sa fokusom na lokalne umjetnike iz Sarajeva.", "Art Galerija Sarajevo" },
                    { 7, "Restoran GastroMIX je restoran specijaliziran za internacionalnu kuhinju sa naglaskom na fusion jelima.", "Restoran GastroMIX" },
                    { 8, "IT Konsalting BH pruža IT konsultantske usluge za kompanije u Bosni i Hercegovini, sa ciljem optimizacije poslovnih procesa.", "IT Konsalting BH" },
                    { 9, "Turistička Agencija Sarajevo Explorer se bavi organizacijom turističkih tura i putovanja u Sarajevu i okolini, promovišući kulturno i prirodno bogatstvo regije.", "Turistička Agencija Sarajevo Explorer" },
                    { 10, "EduTech BH je projekat usmjeren na razvoj edukativnih tehnologija za bolje obrazovanje u Bosni i Hercegovini.", "EduTech BH" }
                });

            migrationBuilder.InsertData(
                table: "TaskStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Kreiran" },
                    { 2, "Aktivan" },
                    { 3, "Riješen" },
                    { 4, "Zatvoren" }
                });

            migrationBuilder.InsertData(
                table: "TaskTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Bug" },
                    { 2, "Feature" },
                    { 3, "Poboljšanje" },
                    { 4, "Održavanje" },
                    { 5, "Dokumentovanje" },
                    { 6, "Istraživanje" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name", "ZipCode" },
                values: new object[,]
                {
                    { 1, 6, "Beograd", "" },
                    { 2, 1, "Jablanica", "88420" },
                    { 3, 1, "Konjic", "88400" },
                    { 4, 5, "Ljubljana", "" },
                    { 5, 1, "Mostar", "88000" },
                    { 6, 2, "Priština", "" },
                    { 7, 1, "Sarajevo", "71000" },
                    { 8, 4, "Skoplje", "" },
                    { 9, 3, "Zagreb", "" },
                    { 10, 1, "Podgorica", "81000" },
                    { 11, 4, "Bitola", "7000" },
                    { 12, 3, "Split", "21000" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Level", "Name", "ParentDepartmentId", "SupervisorId" },
                values: new object[,]
                {
                    { 2, 1, "Odjel IT", 1, null },
                    { 3, 1, "Odjel REM", 1, null },
                    { 4, 1, "Odjel HR", 1, null }
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "DepartmentId", "IsWorkExperienceRequired", "Name", "PayGradeId", "RequiredEducationId" },
                values: new object[] { 1, 1, true, "Generalni direktor", 1, 7 });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Level", "Name", "ParentDepartmentId", "SupervisorId" },
                values: new object[,]
                {
                    { 5, 2, "Frontend tim", 2, null },
                    { 6, 2, "Backend tim", 2, null },
                    { 7, 2, "Database tim", 2, null }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Address", "BankAccount", "BirthDate", "BirthPlaceId", "CitizenshipId", "CityId", "CreateDate", "EducationId", "Email", "FirstName", "Gender", "Image", "LastName", "MaidenName", "Mobile", "Note", "OfficePhone", "ParentName", "Password", "PersonalIdentificationNumber", "Phone", "PreviousLOSMonths", "PreviousLOSYears", "Profession", "RegistrationNumber", "WorkerCode" },
                values: new object[,]
                {
                    { 1, "4. Muslimanske brigade 20", "", new DateTime(1995, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 1, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "anes@hrms.com", "Anes", "Male", "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", "Smajić", "", "38761234567", "", "38761234567", "", "19a2854144b63a8f7617a6f225019b12", "", "38761234567", 0, 0, "Ekonomski tehničar", "1234567890123", "SA0001" },
                    { 2, "Dobrinja", "", new DateTime(1998, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, null, 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "irena@hrms.com", "Irena", "Female", "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", "Vilić", "", "", "", "", "", "c99629a9aa107c23fe53e97433ea6b90", "", "", 0, 0, "", "1234567890123", "SA0002" },
                    { 3, "Hrasnica", "", new DateTime(1998, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, null, 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "meliha.k@hrms.com", "Meliha", "Female", "", "Kosnica", "", "", "", "", "", "827ef6760e76932136c9e529169ecb9b", "", "", 0, 0, "", "1234567890123", "SA0003" },
                    { 4, "Centar b.b.", "", new DateTime(1998, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, null, 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "mislava.s@hrms.com", "Mislava", "Female", "", "Šepović", "", "", "", "", "", "827ef6760e76932136c9e529169ecb9b", "", "", 0, 0, "", "1234567890123", "SA0004" },
                    { 5, "Aleja lipa 6", "", new DateTime(1998, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, null, 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "mileta.p@hrms.com", "Mileta", "Female", "", "Puček", "", "", "", "", "", "827ef6760e76932136c9e529169ecb9b", "", "", 0, 0, "", "1234567890123", "SA0005" },
                    { 6, "Dr. Silvane Rizvanbegović", "", new DateTime(1998, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, null, 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "arsenije.m@hrms.com", "Arsenije", "Male", "", "Murljačić", "", "", "", "", "", "827ef6760e76932136c9e529169ecb9b", "", "", 0, 0, "", "1234567890123", "SA0006" },
                    { 7, "Željeznička", "", new DateTime(1998, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, null, 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "stijepo.z@hrms.com", "Stijepo", "Male", "", "Željeznik", "", "", "", "", "", "827ef6760e76932136c9e529169ecb9b", "", "", 0, 0, "", "1234567890123", "SA0007" },
                    { 8, "Hrasno", "", new DateTime(1998, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, null, 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ana.r@hrms.com", "Ana", "Female", "", "Risojević", "", "", "", "", "", "827ef6760e76932136c9e529169ecb9b", "", "", 0, 0, "", "1234567890123", "SA0008" },
                    { 9, "Hrasno", "", new DateTime(1998, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, null, 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "dagmar.j@hrms.com", "Dagmar", "Male", "", "Jurić", "", "", "", "", "", "827ef6760e76932136c9e529169ecb9b", "", "", 0, 0, "", "1234567890123", "SA0009" },
                    { 10, "Centar", "", new DateTime(1998, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, null, 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ira.k@hrms.com", "Ira", "Female", "", "Kerežija", "", "", "", "", "", "827ef6760e76932136c9e529169ecb9b", "", "", 0, 0, "", "1234567890123", "SA0010" },
                    { 11, "Centar", "", new DateTime(1998, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, null, 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "sanja.t@hrms.com", "Sanja", "Female", "", "Terzić", "", "", "", "", "", "827ef6760e76932136c9e529169ecb9b", "", "", 0, 0, "", "1234567890123", "SA0011" },
                    { 12, "Zalik", "", new DateTime(1998, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, null, 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "josip.t@hrms.com", "Josip", "Male", "", "Tiro", "", "", "", "", "", "827ef6760e76932136c9e529169ecb9b", "", "", 0, 0, "", "1234567890123", "SA0012" }
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "DepartmentId", "IsWorkExperienceRequired", "Name", "PayGradeId", "RequiredEducationId" },
                values: new object[,]
                {
                    { 2, 2, true, "Direktor IT odjela", 3, 6 },
                    { 3, 3, true, "Direktor REM odjela", 2, 6 },
                    { 4, 4, true, "Direktor HR odjela", 3, 6 },
                    { 11, 4, true, "Viši stručni saradnik za upravljanje ljudskim resursima", 4, 6 },
                    { 12, 4, false, "Stručni saradnik za upravljanje ljudskim resursima", 5, 4 },
                    { 13, 3, false, "Čistač", 6, 1 }
                });

            migrationBuilder.InsertData(
                table: "EmployeePositions",
                columns: new[] { "Id", "EmployeeId", "EndDate", "PositionId", "Salary", "StartDate", "Status", "Type", "VacationDays", "WorkingHours" },
                values: new object[,]
                {
                    { 3, 3, new DateTime(2024, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 0m, new DateTime(2021, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "Fixed", 30, "09:00-17:00" },
                    { 4, 4, new DateTime(2024, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 0m, new DateTime(2021, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "Fixed", 30, "09:00-17:00" },
                    { 5, 5, new DateTime(2024, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 0m, new DateTime(2021, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "Fixed", 30, "09:00-17:00" },
                    { 6, 6, new DateTime(2024, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 0m, new DateTime(2021, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "Fixed", 30, "09:00-17:00" },
                    { 7, 7, new DateTime(2024, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 0m, new DateTime(2021, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "Fixed", 30, "09:00-17:00" },
                    { 8, 8, new DateTime(2024, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 0m, new DateTime(2021, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "Fixed", 30, "09:00-17:00" },
                    { 9, 9, new DateTime(2024, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 0m, new DateTime(2021, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "Fixed", 30, "09:00-17:00" },
                    { 10, 10, new DateTime(2024, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 0m, new DateTime(2021, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "Fixed", 30, "09:00-17:00" }
                });

            migrationBuilder.InsertData(
                table: "EmployeeRoles",
                columns: new[] { "Id", "EmployeeId", "Role" },
                values: new object[,]
                {
                    { 1, 1, "Admin" },
                    { 2, 1, "Manager" },
                    { 3, 1, "Employee" },
                    { 4, 2, "Manager" },
                    { 5, 2, "Employee" },
                    { 6, 3, "Employee" },
                    { 7, 4, "Employee" },
                    { 8, 5, "Employee" },
                    { 9, 6, "Employee" },
                    { 10, 7, "Employee" },
                    { 11, 8, "Employee" },
                    { 12, 9, "Employee" },
                    { 13, 10, "Employee" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Description", "EmployeeId", "EndDate", "EventTypeId", "Name", "StartDate", "Status" },
                values: new object[,]
                {
                    { 1, "", 1, new DateTime(2023, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Bolovanje", new DateTime(2023, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, "", 1, new DateTime(2023, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Kurban Bajram", new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 3, "", 3, new DateTime(2023, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Godišnji odmor", new DateTime(2023, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 4, "", 1, new DateTime(2023, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Stručna obuka", new DateTime(2023, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 5, "", 5, new DateTime(2023, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Sarajevski Film Festival", new DateTime(2023, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 6, "", 6, new DateTime(2023, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Poslovni put - Zagreb", new DateTime(2023, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 7, "", 7, new DateTime(2023, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Oproštajna večera za kolegu", new DateTime(2023, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 8, "", 1, new DateTime(2023, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Timski izlet na planinu", new DateTime(2023, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 9, "", 9, new DateTime(2023, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Seminar o liderstvu", new DateTime(2023, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 10, "", 10, new DateTime(2023, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Sportski turnir - fudbal", new DateTime(2023, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 11, "", 1, new DateTime(2023, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Prezentacija novog proizvoda", new DateTime(2023, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 12, "", 2, new DateTime(2023, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Radionica o stresu", new DateTime(2023, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 13, "", 1, new DateTime(2023, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Praznična proslava", new DateTime(2023, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 14, "", 1, new DateTime(2023, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Timski sastanak", new DateTime(2023, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 15, "", 5, new DateTime(2023, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Volonterska akcija - čišćenje parka", new DateTime(2023, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 16, "", 6, new DateTime(2023, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Rad od kuće - Remote Week", new DateTime(2023, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 17, "", 7, new DateTime(2023, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Prezentacija poslovnih rezultata", new DateTime(2023, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 18, "", 1, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Timski izlet na jezero", new DateTime(2023, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 19, "", 2, new DateTime(2023, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Trening radionica - Upravljanje vremenom", new DateTime(2023, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 20, "", 2, new DateTime(2023, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Timski sastanak - Planiranje Q4 projekata", new DateTime(2023, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 21, "", 2, new DateTime(2023, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Seminar o komunikaciji", new DateTime(2023, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 22, "", 2, new DateTime(2023, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Poslovni ručak sa partnerima", new DateTime(2023, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 23, "", 2, new DateTime(2023, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Sastanak sa klijentima", new DateTime(2023, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 }
                });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "EmployeeId", "Room", "Text", "Time" },
                values: new object[,]
                {
                    { 1, 1, "Anes Smajić & Irena Vilić", "Dobro jutro Irena", new DateTime(2023, 7, 22, 12, 1, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 1, "Anes Smajić & Irena Vilić", "Kako si danas?", new DateTime(2023, 7, 22, 12, 2, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 2, "Anes Smajić & Irena Vilić", "Jutro Anese", new DateTime(2023, 7, 22, 12, 3, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 2, "Anes Smajić & Irena Vilić", "Odlično sam, hvala. Kako si ti?", new DateTime(2023, 7, 22, 12, 4, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 1, "Anes Smajić & Irena Vilić", "Također dobro, hvala. Imaš li neki plan za danas?", new DateTime(2023, 7, 22, 12, 5, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 2, "Anes Smajić & Irena Vilić", "Da, imam par sastanaka i trebam završiti taj novi izvještaj do kraja dana", new DateTime(2023, 7, 22, 12, 6, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 2, "Anes Smajić & Irena Vilić", "A ti?", new DateTime(2023, 7, 22, 12, 7, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 1, "Anes Smajić & Irena Vilić", "Također imam sastanak ujutro", new DateTime(2023, 7, 22, 12, 8, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 1, "Anes Smajić & Irena Vilić", "ali popodne imam nekoliko sati slobodno", new DateTime(2023, 7, 22, 12, 9, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 1, "Anes Smajić & Irena Vilić", "Planiram završiti projekt koji radim", new DateTime(2023, 7, 22, 12, 10, 0, 0, DateTimeKind.Unspecified) },
                    { 11, 2, "Anes Smajić & Irena Vilić", "Zvuči kao da ćeš imati produktivan dan. Treba li ti ikakva pomoć s tim projektom?", new DateTime(2023, 7, 22, 12, 11, 0, 0, DateTimeKind.Unspecified) },
                    { 12, 1, "Anes Smajić & Irena Vilić", "Hvala na ponudi. Možda ću morati provjeriti neke podatke, pa ako imam pitanja, sigurno ću ti se obratiti", new DateTime(2023, 7, 22, 12, 12, 0, 0, DateTimeKind.Unspecified) },
                    { 13, 2, "Anes Smajić & Irena Vilić", "Svakako, uvijek sam tu da pomognem", new DateTime(2023, 7, 22, 12, 13, 0, 0, DateTimeKind.Unspecified) },
                    { 14, 2, "Anes Smajić & Irena Vilić", "Inače", new DateTime(2023, 7, 22, 12, 14, 0, 0, DateTimeKind.Unspecified) },
                    { 15, 2, "Anes Smajić & Irena Vilić", "što misliš o novom uređenju ureda?", new DateTime(2023, 7, 22, 12, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 16, 1, "Anes Smajić & Irena Vilić", "Meni se sviđa! Osjećam se puno udobnije u ovom novom okruženju", new DateTime(2023, 7, 22, 12, 16, 0, 0, DateTimeKind.Unspecified) },
                    { 17, 1, "Anes Smajić & Irena Vilić", "A tebi?", new DateTime(2023, 7, 22, 12, 17, 0, 0, DateTimeKind.Unspecified) },
                    { 18, 2, "Anes Smajić & Irena Vilić", "Potpuno se slažem", new DateTime(2023, 7, 22, 12, 18, 0, 0, DateTimeKind.Unspecified) },
                    { 19, 2, "Anes Smajić & Irena Vilić", "Ovo je puno svjetlije i prostranije", new DateTime(2023, 7, 22, 12, 19, 0, 0, DateTimeKind.Unspecified) },
                    { 20, 2, "Anes Smajić & Irena Vilić", "Nekako mi daje više inspiracije za rad", new DateTime(2023, 7, 22, 12, 20, 0, 0, DateTimeKind.Unspecified) },
                    { 21, 1, "Anes Smajić & Irena Vilić", "Da, baš tako! Volim kako je timski duh u ovom uredu, svi surađujemo tako dobro", new DateTime(2023, 7, 22, 12, 21, 0, 0, DateTimeKind.Unspecified) },
                    { 22, 2, "Anes Smajić & Irena Vilić", "Upravo tako!", new DateTime(2023, 7, 22, 12, 22, 0, 0, DateTimeKind.Unspecified) },
                    { 23, 2, "Anes Smajić & Irena Vilić", "Baš zbog toga nam i ide ovako dobro", new DateTime(2023, 7, 22, 12, 23, 0, 0, DateTimeKind.Unspecified) },
                    { 24, 1, "Anes Smajić & Irena Vilić", "Tako je. Sve u svemu, zadovoljan sam kako stvari idu na poslu", new DateTime(2023, 7, 22, 12, 24, 0, 0, DateTimeKind.Unspecified) },
                    { 25, 2, "Anes Smajić & Irena Vilić", "I ja isto! Ako ikada trebaš razgovarati o bilo čemu ili trebaš pomoć, slobodno mi se obrati", new DateTime(2023, 7, 22, 12, 25, 0, 0, DateTimeKind.Unspecified) },
                    { 26, 1, "Anes Smajić & Irena Vilić", "Hvala Irena", new DateTime(2023, 7, 22, 12, 26, 0, 0, DateTimeKind.Unspecified) },
                    { 27, 1, "Anes Smajić & Irena Vilić", "Cijenim to", new DateTime(2023, 7, 22, 12, 27, 0, 0, DateTimeKind.Unspecified) },
                    { 28, 2, "Anes Smajić & Irena Vilić", "Nema na čemu. Sada se moram vratiti radu, ali ako želiš, možemo se kasnije ponovno čuti.", new DateTime(2023, 7, 22, 12, 28, 0, 0, DateTimeKind.Unspecified) },
                    { 29, 1, "Anes Smajić & Irena Vilić", "U redu, zvuči dobro. Sretno s tvojim sastancima i projektom!", new DateTime(2023, 7, 22, 12, 29, 0, 0, DateTimeKind.Unspecified) },
                    { 30, 2, "Anes Smajić & Irena Vilić", "Hvala! I tebi želim uspješan dan", new DateTime(2023, 7, 22, 12, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 31, 2, "Anes Smajić & Irena Vilić", "Čujemo se kasnije", new DateTime(2023, 7, 22, 12, 31, 0, 0, DateTimeKind.Unspecified) },
                    { 32, 1, "Anes Smajić & Irena Vilić", "Čujemo se", new DateTime(2023, 7, 22, 12, 32, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "DepartmentId", "IsWorkExperienceRequired", "Name", "PayGradeId", "RequiredEducationId" },
                values: new object[,]
                {
                    { 5, 5, true, "Voditelj Frontend tima", 4, 6 },
                    { 6, 6, true, "Voditelj Backend tima", 4, 6 },
                    { 7, 7, true, "Voditelj Database tima", 4, 6 },
                    { 8, 5, true, "Software developer", 5, 6 },
                    { 9, 6, false, "Designer", 5, 4 },
                    { 10, 7, true, "Database administrator", 5, 4 }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "Description", "EmployeeId", "Name", "ProjectId", "TaskStatusId", "TaskTypeId" },
                values: new object[,]
                {
                    { 1, "Napraviti markup po datom dizajnu.", 1, "Markup", 1, 1, 2 },
                    { 2, "Odraditi integraciju newsletter signup-a.", 2, "Mailchimp", 1, 2, 1 },
                    { 3, "Napraviti banner komponentu.", 2, "Banner komponenta", 3, 3, 1 },
                    { 4, "Ispraviti footer prema dizajnu.", 1, "Popraviti bug u footer-u", 4, 4, 2 },
                    { 5, "Optimizirati upite u bazi podataka radi poboljšane performanse.", 3, "Optimizacija Baze Podataka", 2, 1, 3 },
                    { 6, "Implementirati novu funkcionalnost prema zahtjevima klijenta.", 4, "Implementacija Nove Funkcionalnosti", 5, 2, 2 },
                    { 7, "Unaprijediti korisničko sučelje radi boljeg korisničkog iskustva.", 5, "Unapređenje Korisničkog Sučelja", 7, 3, 3 },
                    { 8, "Ažurirati dokumentaciju projekta s najnovijim promjenama.", 6, "Ažuriranje Dokumentacije", 9, 4, 5 },
                    { 9, "Izvršiti istraživanje novih tehnologija za buduće projekte.", 7, "Istraživanje Novih Tehnologija", 10, 1, 6 },
                    { 10, "Izvršiti sigurnosnu reviziju sustava kako bi se identificirale ranjivosti.", 8, "Sigurnosna Revizija", 8, 2, 6 }
                });

            migrationBuilder.InsertData(
                table: "EmployeePositions",
                columns: new[] { "Id", "EmployeeId", "EndDate", "PositionId", "Salary", "StartDate", "Status", "Type", "VacationDays", "WorkingHours" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 0m, new DateTime(2021, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "Fixed", 30, "09:00-17:00" },
                    { 2, 2, new DateTime(2023, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 0m, new DateTime(2021, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Inactive", "Fixed", 30, "09:00-17:00" }
                });

            migrationBuilder.InsertData(
                table: "TaskComments",
                columns: new[] { "Id", "Content", "EmployeeId", "TaskId", "Time" },
                values: new object[,]
                {
                    { 1, "Task preuzet dana 19.8. i stavljen 'In progress'.", 1, 1, new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Task zavrsen.", 2, 2, new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Hvala na preuzimanju zadatka. Pogledat ću dizajn i krenuti s markup-om.", 3, 1, new DateTime(2023, 8, 31, 22, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Nema na čemu! Ako imate bilo kakvih pitanja, slobodno pitajte.", 1, 1, new DateTime(2023, 8, 31, 23, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "Task označen kao 'In progress'. Radim na integraciji s Mailchimp-om.", 4, 2, new DateTime(2023, 8, 31, 21, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "Super! Javite ako naiđete na bilo kakve prepreke.", 2, 2, new DateTime(2023, 8, 31, 22, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, "Banner komponenta uspješno dodana projektu. Čeka se vaš feedback.", 5, 3, new DateTime(2023, 8, 31, 20, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, "Izgleda odlično! Samo malo promijenite nijanse boja.", 3, 3, new DateTime(2023, 8, 31, 21, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, "Bug u footer-u uspješno riješen.", 6, 4, new DateTime(2023, 8, 31, 19, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, "Savršeno! Zatvaram task.", 4, 4, new DateTime(2023, 8, 31, 20, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_ParentDepartmentId",
                table: "Departments",
                column: "ParentDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_SupervisorId",
                table: "Departments",
                column: "SupervisorId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePositions_EmployeeId",
                table: "EmployeePositions",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePositions_PositionId",
                table: "EmployeePositions",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeRoles_EmployeeId",
                table: "EmployeeRoles",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_BirthPlaceId",
                table: "Employees",
                column: "BirthPlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CitizenshipId",
                table: "Employees",
                column: "CitizenshipId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CityId",
                table: "Employees",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EducationId",
                table: "Employees",
                column: "EducationId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_EmployeeId",
                table: "Events",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_EventTypeId",
                table: "Events",
                column: "EventTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_EmployeeId",
                table: "Messages",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_DepartmentId",
                table: "Positions",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_PayGradeId",
                table: "Positions",
                column: "PayGradeId");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_RequiredEducationId",
                table: "Positions",
                column: "RequiredEducationId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskComments_EmployeeId",
                table: "TaskComments",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskComments_TaskId",
                table: "TaskComments",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_EmployeeId",
                table: "Tasks",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ProjectId",
                table: "Tasks",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_TaskStatusId",
                table: "Tasks",
                column: "TaskStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_TaskTypeId",
                table: "Tasks",
                column: "TaskTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeePositions");

            migrationBuilder.DropTable(
                name: "EmployeeRoles");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "TaskComments");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "EventTypes");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "PayGrades");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "TaskStatuses");

            migrationBuilder.DropTable(
                name: "TaskTypes");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Educations");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}