using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarsNotes.Data.Migrations
{
    /// <inheritdoc />
    public partial class FuelIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PricePerLittre",
                table: "Fuels",
                newName: "PricePerLiter");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PricePerLiter",
                table: "Fuels",
                newName: "PricePerLittre");
        }
    }
}
