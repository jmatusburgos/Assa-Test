using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Test_Car.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MarcasAutos",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "ModifiedBy", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, "system", new DateTime(2025, 1, 21, 23, 35, 51, 508, DateTimeKind.Utc).AddTicks(5811), "Toyota Motor Corporation", "", null, "Toyota" },
                    { 2, "system", new DateTime(2025, 1, 21, 23, 35, 51, 508, DateTimeKind.Utc).AddTicks(5811), "Nissan Motor Corporation", "", null, "Nissan" },
                    { 3, "system", new DateTime(2025, 1, 21, 23, 35, 51, 508, DateTimeKind.Utc).AddTicks(5811), "Bayerische Motoren Werke GmbH", "", null, "BMW" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MarcasAutos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MarcasAutos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MarcasAutos",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
