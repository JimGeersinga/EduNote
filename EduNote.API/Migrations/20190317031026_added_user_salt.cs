using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EduNote.API.Migrations
{
    public partial class added_user_salt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Token",
                table: "Users",
                newName: "Salt");

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Created",
                value: new DateTime(2019, 3, 17, 3, 10, 26, 415, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Created",
                value: new DateTime(2019, 3, 17, 3, 10, 26, 415, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Created",
                value: new DateTime(2019, 3, 17, 3, 10, 26, 415, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Created",
                value: new DateTime(2019, 3, 17, 3, 10, 26, 415, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Created",
                value: new DateTime(2019, 3, 17, 3, 10, 26, 415, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Created",
                value: new DateTime(2019, 3, 17, 3, 10, 26, 415, DateTimeKind.Utc));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Salt",
                table: "Users",
                newName: "Token");

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Created",
                value: new DateTime(2019, 3, 16, 22, 44, 56, 984, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Created",
                value: new DateTime(2019, 3, 16, 22, 44, 56, 984, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Created",
                value: new DateTime(2019, 3, 16, 22, 44, 56, 984, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Created",
                value: new DateTime(2019, 3, 16, 22, 44, 56, 984, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Created",
                value: new DateTime(2019, 3, 16, 22, 44, 56, 983, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Created",
                value: new DateTime(2019, 3, 16, 22, 44, 56, 983, DateTimeKind.Utc));
        }
    }
}
