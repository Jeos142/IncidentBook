using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IncidentBook.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ClientItems",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Василий" },
                    { 2, "Екатерина" },
                    { 3, "Алексей" }
                });

            migrationBuilder.InsertData(
                table: "ClosedIncidentsItems",
                columns: new[] { "Id", "Resolution" },
                values: new object[,]
                {
                    { 1, "Закрыто ТП 1-го уровня" },
                    { 2, "Закрыто ТП 2-го уровня" },
                    { 3, "Закрыто ТП 3-го уровня" },
                    { 4, "Другое" }
                });

            migrationBuilder.InsertData(
                table: "IncidentClassifications",
                columns: new[] { "Id", "ClassificationName" },
                values: new object[,]
                {
                    { 1, "Сбой ПО" },
                    { 2, "Ошибка сети" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ClientItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ClientItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ClientItems",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ClosedIncidentsItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ClosedIncidentsItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ClosedIncidentsItems",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ClosedIncidentsItems",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "IncidentClassifications",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "IncidentClassifications",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
