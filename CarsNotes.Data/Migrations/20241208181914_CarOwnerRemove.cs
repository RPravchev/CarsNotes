using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarsNotes.Data.Migrations
{
    /// <inheritdoc />
    public partial class CarOwnerRemove : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarsOwner");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarsOwner",
                columns: table => new
                {
                    CarOwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CarUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarsOwner", x => x.CarOwnerId);
                    table.ForeignKey(
                        name: "FK_CarsOwner_AspNetUsers_CarUserId",
                        column: x => x.CarUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarsOwner_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarsOwner_CarId",
                table: "CarsOwner",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_CarsOwner_CarUserId",
                table: "CarsOwner",
                column: "CarUserId");
        }
    }
}
