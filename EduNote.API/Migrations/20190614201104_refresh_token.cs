using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EduNote.API.Migrations
{
    public partial class refresh_token : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "Users",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Created",
                value: new DateTime(2019, 6, 14, 20, 11, 3, 823, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Created",
                value: new DateTime(2019, 6, 14, 20, 11, 3, 823, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Created",
                value: new DateTime(2019, 6, 14, 20, 11, 3, 823, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Created",
                value: new DateTime(2019, 6, 14, 20, 11, 3, 823, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Created",
                value: new DateTime(2019, 6, 14, 20, 11, 3, 822, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Created",
                value: new DateTime(2019, 6, 14, 20, 11, 3, 822, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2b$10$7uFT6m3n9DTi9t7bsJSkUexLRcLGRhOo7u8oGA3Kot.OHUISLX//y");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2b$10$8xEP4LswE9o9zraXyToDaOqXOZWiImNYQcm8eFAFVJXPqVisoVBiq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2b$10$Tr5muBKf26Y.9uhV6K8e7eDKe7Lw1NJttRxkrDY6C/90MH6vsAoS2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2b$10$nRuGL1UnOc8G0jmy0LpGLu2EldEa6MsNaFLRk5FxO6rUPN4fDDHHi");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2b$10$TRHLLNDnMDFLlkvHi/zLue5y.1.XGvTC82gtqL4/YqHiRXJAX.R9q");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Created",
                value: new DateTime(2019, 3, 18, 18, 4, 55, 385, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Created",
                value: new DateTime(2019, 3, 18, 18, 4, 55, 385, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Created",
                value: new DateTime(2019, 3, 18, 18, 4, 55, 385, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Created",
                value: new DateTime(2019, 3, 18, 18, 4, 55, 385, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Created",
                value: new DateTime(2019, 3, 18, 18, 4, 55, 385, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Created",
                value: new DateTime(2019, 3, 18, 18, 4, 55, 385, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2b$10$kAnol6IKmJLj35UJXRETNeI9mrMvPIEzwXtRPKzPgacMa3YlUahvW");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2b$10$Olnpn6Lgzq1Js66Ktc3FROVoRgIwxPgxkdQ9S4Iq5FfJvkXBQxhvO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2b$10$bjkPjRpVIvj9xFGZ43NEOuTh3I4RCQikoQR0VyekjlQ8yKOYFjM1G");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2b$10$71F0Qh4xpZsZzh7qOEJeP.7flWhEEaKuZAQbAsMZU7GgAFn96NxGi");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2b$10$76fE9y8XtbKLJms6i7HTNuhb6qV9lbU.ClaO3sRb6u3S4Yrt.0g7C");
        }
    }
}
