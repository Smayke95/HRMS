using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRMS.Database.Migrations
{
    /// <inheritdoc />
    public partial class Task_Full_Text_Search : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sqlFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Scripts/TaskFullTextSearch.sql");
            migrationBuilder.Sql(File.ReadAllText(sqlFile), true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sqlFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Scripts/TaskFullTextSearchUndo.sql");
            migrationBuilder.Sql(File.ReadAllText(sqlFile), true);
        }
    }
}
