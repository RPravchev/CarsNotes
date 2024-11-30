using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarsNotes.Data.Migrations
{
    /// <inheritdoc />
    public partial class CareTableUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "Cares",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Cares_OwnerId",
                table: "Cares",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cares_AspNetUsers_OwnerId",
                table: "Cares",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cares_AspNetUsers_OwnerId",
                table: "Cares");

            migrationBuilder.DropIndex(
                name: "IX_Cares_OwnerId",
                table: "Cares");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Cares");
        }
    }
}
