using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarsNotes.Data.Migrations
{
    /// <inheritdoc />
    public partial class LegalUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Legals_LegalTypes_LegalTypeId",
                table: "Legals");

            migrationBuilder.AlterColumn<int>(
                name: "LegalTypeId",
                table: "Legals",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Legals",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "Legals",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Legals_OwnerId",
                table: "Legals",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Legals_AspNetUsers_OwnerId",
                table: "Legals",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Legals_LegalTypes_LegalTypeId",
                table: "Legals",
                column: "LegalTypeId",
                principalTable: "LegalTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Legals_AspNetUsers_OwnerId",
                table: "Legals");

            migrationBuilder.DropForeignKey(
                name: "FK_Legals_LegalTypes_LegalTypeId",
                table: "Legals");

            migrationBuilder.DropIndex(
                name: "IX_Legals_OwnerId",
                table: "Legals");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Legals");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Legals");

            migrationBuilder.AlterColumn<int>(
                name: "LegalTypeId",
                table: "Legals",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Legals_LegalTypes_LegalTypeId",
                table: "Legals",
                column: "LegalTypeId",
                principalTable: "LegalTypes",
                principalColumn: "Id");
        }
    }
}
