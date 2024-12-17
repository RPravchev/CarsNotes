using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarsNotes.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddRestOfEntities_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CarId",
                table: "Cares",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Cares_CarId",
                table: "Cares",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cares_Cars_CarId",
                table: "Cares",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cares_Cars_CarId",
                table: "Cares");

            migrationBuilder.DropIndex(
                name: "IX_Cares_CarId",
                table: "Cares");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "Cares");
        }
    }
}
