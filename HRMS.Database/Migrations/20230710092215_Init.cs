using System;
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
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
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
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsReaded = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_Employees_EmployeeId",
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
                    EmploymentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    { 5, "#fb1b1b", true, "Neplaćeno odsustvo" }
                });

            migrationBuilder.InsertData(
                table: "Logs",
                columns: new[] { "Id", "Date", "Message", "Type" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 7, 10, 11, 22, 14, 979, DateTimeKind.Local).AddTicks(7093), "", "INFO" },
                    { 2, new DateTime(2023, 7, 10, 11, 22, 14, 979, DateTimeKind.Local).AddTicks(7147), "", "WARNING" },
                    { 3, new DateTime(2023, 7, 10, 11, 22, 14, 979, DateTimeKind.Local).AddTicks(7158), "", "ERROR" }
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
                    { 4, "Vejers je sistem napravljen za iznajmljivanje kuca na jugu Danske, iznajmljivanje se vrsi preko Booking studija.", "Vejers" }
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
                    { 2, "Feature" }
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
                    { 9, 3, "Zagreb", "" }
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
                    { 1, "4. Muslimanske brigade 20", "", new DateTime(1995, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "anes@hrms.com", "Anes", "Male", "/img/avatars/default.png", "Smajić", "", "38761234567", "", "38761234567", "", "19a2854144b63a8f7617a6f225019b12", "", "38761234567", 0, 0, "Ekonomski tehničar", "1234567890123", "" },
                    { 2, "Dobrinja", "", new DateTime(1998, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "irena@hrms.com", "Irena", "Female", "/img/avatars/default.png", "Vilić", "", "", "", "", "", "19a2854144b63a8f7617a6f225019b12", "", "", 0, 0, "", "1234567890123", "" },
                    { 3, "Dobrinja", "", new DateTime(1998, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "meliha.k@hrms.com", "Meliha", "Female", "/img/avatars/default.png", "Kosnica", "", "", "", "", "", "19a2854144b63a8f7617a6f225019b12", "", "", 0, 0, "", "1234567890123", "" },
                    { 4, "Dobrinja", "", new DateTime(1998, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "mislava.s@hrms.com", "Mislava", "Female", "/img/avatars/default.png", "Šepović", "", "", "", "", "", "19a2854144b63a8f7617a6f225019b12", "", "", 0, 0, "", "1234567890123", "" },
                    { 5, "Dobrinja", "", new DateTime(1998, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "mileta.p@hrms.com", "Mileta", "Female", "/img/avatars/default.png", "Puček", "", "", "", "", "", "19a2854144b63a8f7617a6f225019b12", "", "", 0, 0, "", "1234567890123", "" },
                    { 6, "Dobrinja", "", new DateTime(1998, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "arsenije.m@hrms.com", "Arsenije", "Female", "/img/avatars/default.png", "Murljačić", "", "", "", "", "", "19a2854144b63a8f7617a6f225019b12", "", "", 0, 0, "", "1234567890123", "" },
                    { 7, "Dobrinja", "", new DateTime(1998, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "stijepo.z@hrms.com", "Stijepo", "Female", "/img/avatars/default.png", "Željeznik", "", "", "", "", "", "19a2854144b63a8f7617a6f225019b12", "", "", 0, 0, "", "1234567890123", "" },
                    { 8, "Dobrinja", "", new DateTime(1998, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ana.r@hrms.com", "Ana", "Female", "/img/avatars/default.png", "Risojević", "", "", "", "", "", "19a2854144b63a8f7617a6f225019b12", "", "", 0, 0, "", "1234567890123", "" },
                    { 9, "Dobrinja", "", new DateTime(1998, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "dagmar.j@hrms.com", "Dagmar", "Female", "/img/avatars/default.png", "Jurić", "", "", "", "", "", "19a2854144b63a8f7617a6f225019b12", "", "", 0, 0, "", "1234567890123", "" },
                    { 10, "Dobrinja", "", new DateTime(1998, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ira.k@hrms.com", "Ira", "Female", "/img/avatars/default.png", "Kerežija", "", "", "", "", "", "19a2854144b63a8f7617a6f225019b12", "", "", 0, 0, "", "1234567890123", "" }
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "DepartmentId", "IsWorkExperienceRequired", "Name", "PayGradeId", "RequiredEducationId" },
                values: new object[,]
                {
                    { 2, 2, true, "Direktor IT odjela", 3, 6 },
                    { 3, 3, true, "Direktor REM odjela", 2, 6 },
                    { 4, 2, true, "Direktor HR odjela", 3, 6 },
                    { 11, 4, true, "Viši stručni saradnik za upravljanje ljudskim resursima", 4, 6 },
                    { 12, 4, false, "Stručni saradnik za upravljanje ljudskim resursima", 5, 4 },
                    { 13, 3, false, "Čistač", 6, 1 }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Description", "EmployeeId", "EndDate", "EventTypeId", "Name", "StartDate" },
                values: new object[,]
                {
                    { 1, "", 1, new DateTime(2021, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Bolovanje", new DateTime(2021, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "", 1, new DateTime(2021, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Kurban Bajram", new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "", 2, new DateTime(2021, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Godišnji odmor", new DateTime(2021, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "EmployeeId", "IsReaded", "Text" },
                values: new object[,]
                {
                    { 1, 1, false, "Dobili ste novog kolegu" },
                    { 2, 1, false, "Dodani ste na projekat" },
                    { 3, 1, false, "Imate novi komentar" }
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
                    { 4, "Ispraviti footer prema dizajnu.", 1, "Popraviti bug u footer-u", 4, 4, 2 }
                });

            migrationBuilder.InsertData(
                table: "EmployeePositions",
                columns: new[] { "Id", "EmployeeId", "EmploymentType", "EndDate", "PositionId", "Salary", "StartDate", "VacationDays", "WorkingHours" },
                values: new object[,]
                {
                    { 1, 1, "Fixed", new DateTime(2022, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 0m, new DateTime(2021, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 30, "09:00-17:00" },
                    { 2, 2, "Fixed", new DateTime(2021, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 0m, new DateTime(2021, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 30, "09:00-17:00" }
                });

            migrationBuilder.InsertData(
                table: "TaskComments",
                columns: new[] { "Id", "Content", "EmployeeId", "TaskId", "Time" },
                values: new object[,]
                {
                    { 1, "Task preuzet dana 19.8. i stavljen 'In progress'.", 1, 1, new DateTime(2023, 7, 10, 11, 22, 14, 979, DateTimeKind.Local).AddTicks(7920) },
                    { 2, "Task zavrsen.", 2, 2, new DateTime(2023, 7, 10, 11, 22, 14, 979, DateTimeKind.Local).AddTicks(7928) }
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
                name: "IX_Notifications_EmployeeId",
                table: "Notifications",
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
                name: "Events");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Notifications");

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
