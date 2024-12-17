using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarsNotes.Data.Migrations
{
    /// <inheritdoc />
    public partial class LegalUpdate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PayedOn",
                table: "Legals");

            migrationBuilder.DropColumn(
                name: "PriceYear",
                table: "Legals");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Legals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsPayed",
                table: "Legals",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "LegalTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Inspection");

            migrationBuilder.UpdateData(
                table: "LegalTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Insurance");

            migrationBuilder.UpdateData(
                table: "LegalTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Tax");

            migrationBuilder.InsertData(
                table: "LegalTypes",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 4, false, "Vignette" },
                    { 5, false, "Other" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LegalTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "LegalTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Legals");

            migrationBuilder.DropColumn(
                name: "IsPayed",
                table: "Legals");

            migrationBuilder.AddColumn<DateTime>(
                name: "PayedOn",
                table: "Legals",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "PriceYear",
                table: "Legals",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "LegalTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Insurance");

            migrationBuilder.UpdateData(
                table: "LegalTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Technical Inspection");

            migrationBuilder.UpdateData(
                table: "LegalTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Other");
        }
    }
}
