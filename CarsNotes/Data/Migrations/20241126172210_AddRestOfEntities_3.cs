using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarsNotes.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddRestOfEntities_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LegalTypeId",
                table: "Legals",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CareTypeId",
                table: "Cares",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CareTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "The identifier of each care type")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Soft Delete")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CareTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LegalTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "The identifier of each legal type")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Soft Delete")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegalTypes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "CareTypes",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, false, "Antifreeze" },
                    { 2, false, "Oil" },
                    { 3, false, "Tyres" },
                    { 4, false, "Repairs" },
                    { 5, false, "Other" }
                });

            migrationBuilder.InsertData(
                table: "LegalTypes",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, false, "Insurance" },
                    { 2, false, "Technical Inspection" },
                    { 3, false, "Other" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Legals_LegalTypeId",
                table: "Legals",
                column: "LegalTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Cares_CareTypeId",
                table: "Cares",
                column: "CareTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cares_CareTypes_CareTypeId",
                table: "Cares",
                column: "CareTypeId",
                principalTable: "CareTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Legals_LegalTypes_LegalTypeId",
                table: "Legals",
                column: "LegalTypeId",
                principalTable: "LegalTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cares_CareTypes_CareTypeId",
                table: "Cares");

            migrationBuilder.DropForeignKey(
                name: "FK_Legals_LegalTypes_LegalTypeId",
                table: "Legals");

            migrationBuilder.DropTable(
                name: "CareTypes");

            migrationBuilder.DropTable(
                name: "LegalTypes");

            migrationBuilder.DropIndex(
                name: "IX_Legals_LegalTypeId",
                table: "Legals");

            migrationBuilder.DropIndex(
                name: "IX_Cares_CareTypeId",
                table: "Cares");

            migrationBuilder.DropColumn(
                name: "LegalTypeId",
                table: "Legals");

            migrationBuilder.DropColumn(
                name: "CareTypeId",
                table: "Cares");
        }
    }
}
