using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HRMS.Database.Migrations
{
    /// <inheritdoc />
    public partial class Init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "EmployeePositions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: "Inactive");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EmployeeId", "EndDate", "StartDate" },
                values: new object[] { 3, new DateTime(2023, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Description", "EmployeeId", "EndDate", "EventTypeId", "Name", "StartDate" },
                values: new object[,]
                {
                    { 4, "", 1, new DateTime(2023, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Stručna obuka", new DateTime(2023, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "", 5, new DateTime(2023, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Sarajevski Film Festival", new DateTime(2023, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "", 6, new DateTime(2023, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Poslovni put - Zagreb", new DateTime(2023, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, "", 7, new DateTime(2023, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Oproštajna večera za kolegu", new DateTime(2023, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, "", 1, new DateTime(2023, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Timski izlet na planinu", new DateTime(2023, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, "", 9, new DateTime(2023, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Seminar o liderstvu", new DateTime(2023, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, "", 10, new DateTime(2023, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Sportski turnir - fudbal", new DateTime(2023, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, "", 1, new DateTime(2023, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Prezentacija novog proizvoda", new DateTime(2023, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, "", 2, new DateTime(2023, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Radionica o stresu", new DateTime(2023, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, "", 1, new DateTime(2023, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Praznična proslava", new DateTime(2023, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, "", 1, new DateTime(2023, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Timski sastanak", new DateTime(2023, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, "", 5, new DateTime(2023, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Volonterska akcija - čišćenje parka", new DateTime(2023, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, "", 6, new DateTime(2023, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Rad od kuće - Remote Week", new DateTime(2023, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, "", 7, new DateTime(2023, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Prezentacija poslovnih rezultata", new DateTime(2023, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, "", 1, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Timski izlet na jezero", new DateTime(2023, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.UpdateData(
                table: "TaskComments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Time",
                value: new DateTime(2023, 8, 14, 0, 50, 13, 2, DateTimeKind.Local).AddTicks(536));

            migrationBuilder.UpdateData(
                table: "TaskComments",
                keyColumn: "Id",
                keyValue: 2,
                column: "Time",
                value: new DateTime(2023, 8, 14, 0, 50, 13, 2, DateTimeKind.Local).AddTicks(545));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.UpdateData(
                table: "EmployeePositions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: "Draft");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EmployeeId", "EndDate", "StartDate" },
                values: new object[] { 2, new DateTime(2021, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "TaskComments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Time",
                value: new DateTime(2023, 8, 10, 22, 10, 21, 856, DateTimeKind.Local).AddTicks(2692));

            migrationBuilder.UpdateData(
                table: "TaskComments",
                keyColumn: "Id",
                keyValue: 2,
                column: "Time",
                value: new DateTime(2023, 8, 10, 22, 10, 21, 856, DateTimeKind.Local).AddTicks(2697));
        }
    }
}
