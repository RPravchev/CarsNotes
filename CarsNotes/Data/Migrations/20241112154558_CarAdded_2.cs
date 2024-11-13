using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarsNotes.Data.Migrations
{
    /// <inheritdoc />
    public partial class CarAdded_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MileageActual",
                table: "Cars",
                newName: "KilometrageActual");

            migrationBuilder.RenameColumn(
                name: "MileageAcquisition",
                table: "Cars",
                newName: "KilometrageAcquisition");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "KilometrageActual",
                table: "Cars",
                newName: "MileageActual");

            migrationBuilder.RenameColumn(
                name: "KilometrageAcquisition",
                table: "Cars",
                newName: "MileageAcquisition");
        }
    }
}
