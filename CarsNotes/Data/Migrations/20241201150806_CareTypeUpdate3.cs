using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarsNotes.Data.Migrations
{
    /// <inheritdoc />
    public partial class CareTypeUpdate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cares_CareTypes_CareTypeId",
                table: "Cares");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Cares");

            migrationBuilder.AlterColumn<int>(
                name: "CareTypeId",
                table: "Cares",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cares_CareTypes_CareTypeId",
                table: "Cares",
                column: "CareTypeId",
                principalTable: "CareTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cares_CareTypes_CareTypeId",
                table: "Cares");

            migrationBuilder.AlterColumn<int>(
                name: "CareTypeId",
                table: "Cares",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Cares",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Cares_CareTypes_CareTypeId",
                table: "Cares",
                column: "CareTypeId",
                principalTable: "CareTypes",
                principalColumn: "Id");
        }
    }
}
