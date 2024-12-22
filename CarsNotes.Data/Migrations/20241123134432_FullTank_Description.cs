using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarsNotes.Data.Migrations
{
    /// <inheritdoc />
    public partial class FullTank_Description : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Fuels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "FullTank",
                table: "Fuels",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Fuels");

            migrationBuilder.DropColumn(
                name: "FullTank",
                table: "Fuels");
        }
    }
}
