using Microsoft.EntityFrameworkCore.Migrations;

namespace TestExc_with_ASPNet_Core_and_SQLite.Migrations
{
    public partial class UpdateSurename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "Employees",
                newName: "Surename");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Surename",
                table: "Employees",
                newName: "Surname");
        }
    }
}
