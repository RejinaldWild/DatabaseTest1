using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestExc_with_ASPNet_Core_and_SQLite.Migrations
{
    public partial class UpdateModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeShift_EmployeeItems_EmployeeId",
                table: "TimeShift");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TimeShift",
                table: "TimeShift");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeItems",
                table: "EmployeeItems");

            migrationBuilder.RenameTable(
                name: "TimeShift",
                newName: "TimeShifts");

            migrationBuilder.RenameTable(
                name: "EmployeeItems",
                newName: "Employees");

            migrationBuilder.RenameIndex(
                name: "IX_TimeShift_EmployeeId",
                table: "TimeShifts",
                newName: "IX_TimeShifts_EmployeeId");

            migrationBuilder.RenameColumn(
                name: "Surename",
                table: "Employees",
                newName: "Surname");

            migrationBuilder.RenameColumn(
                name: "EmployeePosition",
                table: "Employees",
                newName: "Position");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndShift",
                table: "TimeShifts",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartShift",
                table: "TimeShifts",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "WorkingHours",
                table: "TimeShifts",
                type: "TEXT",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddPrimaryKey(
                name: "PK_TimeShifts",
                table: "TimeShifts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeShifts_Employees_EmployeeId",
                table: "TimeShifts",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeShifts_Employees_EmployeeId",
                table: "TimeShifts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TimeShifts",
                table: "TimeShifts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EndShift",
                table: "TimeShifts");

            migrationBuilder.DropColumn(
                name: "StartShift",
                table: "TimeShifts");

            migrationBuilder.DropColumn(
                name: "WorkingHours",
                table: "TimeShifts");

            migrationBuilder.RenameTable(
                name: "TimeShifts",
                newName: "TimeShift");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "EmployeeItems");

            migrationBuilder.RenameIndex(
                name: "IX_TimeShifts_EmployeeId",
                table: "TimeShift",
                newName: "IX_TimeShift_EmployeeId");

            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "EmployeeItems",
                newName: "Surename");

            migrationBuilder.RenameColumn(
                name: "Position",
                table: "EmployeeItems",
                newName: "EmployeePosition");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TimeShift",
                table: "TimeShift",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeItems",
                table: "EmployeeItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeShift_EmployeeItems_EmployeeId",
                table: "TimeShift",
                column: "EmployeeId",
                principalTable: "EmployeeItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
