using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarsNotes.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddRestOfEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Oils");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Cares");

            migrationBuilder.RenameColumn(
                name: "ModifyDate",
                table: "Fuels",
                newName: "ModifiedOn");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Fuels",
                newName: "CreatedOn");

            migrationBuilder.RenameColumn(
                name: "ModifyDate",
                table: "Cars",
                newName: "ModifiedOn");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Cars",
                newName: "CreatedOn");

            migrationBuilder.RenameColumn(
                name: "ModifyDate",
                table: "Cares",
                newName: "ModifiedOn");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Cares",
                newName: "Date");

            migrationBuilder.AddColumn<string>(
                name: "AdditionalInfo",
                table: "Cares",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BuyedFrom",
                table: "Cares",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Cares",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Manifacturer",
                table: "Cares",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "PriceMaterial",
                table: "Cares",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PriceTotal",
                table: "Cares",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PriceWork",
                table: "Cares",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<double>(
                name: "Quantity",
                table: "Cares",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "TypeDetails",
                table: "Cares",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Legals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValidFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValidTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PayedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AdditionalDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PriceYear = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Issuer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Insurer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Legals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Legals_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Places",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Latitude = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdditionalDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Places", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Places_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Legals_CarId",
                table: "Legals",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Places_CarId",
                table: "Places",
                column: "CarId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Legals");

            migrationBuilder.DropTable(
                name: "Places");

            migrationBuilder.DropColumn(
                name: "AdditionalInfo",
                table: "Cares");

            migrationBuilder.DropColumn(
                name: "BuyedFrom",
                table: "Cares");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Cares");

            migrationBuilder.DropColumn(
                name: "Manifacturer",
                table: "Cares");

            migrationBuilder.DropColumn(
                name: "PriceMaterial",
                table: "Cares");

            migrationBuilder.DropColumn(
                name: "PriceTotal",
                table: "Cares");

            migrationBuilder.DropColumn(
                name: "PriceWork",
                table: "Cares");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Cares");

            migrationBuilder.DropColumn(
                name: "TypeDetails",
                table: "Cares");

            migrationBuilder.RenameColumn(
                name: "ModifiedOn",
                table: "Fuels",
                newName: "ModifyDate");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "Fuels",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "ModifiedOn",
                table: "Cars",
                newName: "ModifyDate");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "Cars",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "ModifiedOn",
                table: "Cares",
                newName: "ModifyDate");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Cares",
                newName: "CreateDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Cares",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Oils",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CareId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<double>(type: "float", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oils", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Oils_Cares_CareId",
                        column: x => x.CareId,
                        principalTable: "Cares",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Oils_CareId",
                table: "Oils",
                column: "CareId");
        }
    }
}
