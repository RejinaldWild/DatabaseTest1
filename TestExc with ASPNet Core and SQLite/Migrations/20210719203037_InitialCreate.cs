using Microsoft.EntityFrameworkCore.Migrations;

namespace TestExc_with_ASPNet_Core_and_SQLite.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Surename = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    SecondName = table.Column<string>(type: "TEXT", nullable: true),
                    EmployeePosition = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TimeShift",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EmployeeId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeShift", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeShift_EmployeeItems_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "EmployeeItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TimeShift_EmployeeId",
                table: "TimeShift",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimeShift");

            migrationBuilder.DropTable(
                name: "EmployeeItems");
        }
    }
}
