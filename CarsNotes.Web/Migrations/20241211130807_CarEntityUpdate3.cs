using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarsNotes.Data.Migrations
{
    /// <inheritdoc />
    public partial class CarEntityUpdate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpencesTotalFuel",
                table: "Fuels");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Places",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                comment: "The place name",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<decimal>(
                name: "Longitude",
                table: "Places",
                type: "decimal(9,6)",
                nullable: false,
                comment: "The Geolocation - Longitude",
                oldClrType: typeof(decimal),
                oldType: "decimal(9,6)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Latitude",
                table: "Places",
                type: "decimal(9,6)",
                nullable: false,
                comment: "The Geolocation - Latitude",
                oldClrType: typeof(decimal),
                oldType: "decimal(9,6)");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Places",
                type: "bit",
                nullable: false,
                comment: "Soft Delete",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Places",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                comment: "The address of the place",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AdditionalDetails",
                table: "Places",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                comment: "Additional Information for the place",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "LegalTypes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                comment: "The name of the legal type",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ValidTo",
                table: "Legals",
                type: "datetime2",
                nullable: false,
                comment: "Valid To Date of the care",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ValidFrom",
                table: "Legals",
                type: "datetime2",
                nullable: false,
                comment: "Valid From Date of the care",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "TypeDetails",
                table: "Legals",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                comment: "Short description of the care type details",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Legals",
                type: "decimal(18,2)",
                nullable: false,
                comment: "The Price of the legal",
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "Issuer",
                table: "Legals",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "The seller of the legal service",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<bool>(
                name: "IsPayed",
                table: "Legals",
                type: "bit",
                nullable: false,
                comment: "Notice if the legal is payed or still pending",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Insurer",
                table: "Legals",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "The owner of the legal service",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Legals",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                comment: "Additional Details",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Legals",
                type: "datetime2",
                nullable: false,
                comment: "The care date indicated by owner",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<double>(
                name: "Volume",
                table: "Fuels",
                type: "float",
                nullable: false,
                comment: "The quantity of the fuel",
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "PriceTotalFuel",
                table: "Fuels",
                type: "decimal(18,2)",
                nullable: false,
                comment: "The total price of for the fuel",
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "PricePerLiter",
                table: "Fuels",
                type: "decimal(18,2)",
                nullable: false,
                comment: "The price of one liter",
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "KilometrageActual",
                table: "Fuels",
                type: "int",
                nullable: false,
                comment: "The kilometrage of the date of fuel",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Fuels",
                type: "bit",
                nullable: false,
                comment: "Soft delete",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "GasType",
                table: "Fuels",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "The type of the energy we use",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GasStation",
                table: "Fuels",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                comment: "The name of the Gas Station",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<bool>(
                name: "FullTank",
                table: "Fuels",
                type: "bit",
                nullable: false,
                comment: "The max fuel possible",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Fuels",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                comment: "Additional details",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Fuels",
                type: "datetime2",
                nullable: false,
                comment: "The fuel date indicated by owner",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Fuels",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                comment: "The name of the City where we fuel",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "CareTypes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                comment: "The name of the care type",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "TypeDetails",
                table: "Cares",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "Short description of the care type details",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Quantity",
                table: "Cares",
                type: "float",
                nullable: false,
                comment: "The quantity of the care",
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "PriceWork",
                table: "Cares",
                type: "decimal(18,2)",
                nullable: false,
                comment: "The Price only for the work without the material",
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "PriceTotal",
                table: "Cares",
                type: "decimal(18,2)",
                nullable: false,
                comment: "The Price total for the work and the material",
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "PriceMaterial",
                table: "Cares",
                type: "decimal(18,2)",
                nullable: false,
                comment: "The Price of one material",
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "Manifacturer",
                table: "Cares",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "Short description of the care type details",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsPendingCare",
                table: "Cares",
                type: "bit",
                nullable: false,
                comment: "If we finished or the care still should be done",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Cares",
                type: "datetime2",
                nullable: false,
                comment: "The care date indicated by owner",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "BuyedFrom",
                table: "Cares",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "The seller of the care",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AdditionalInfo",
                table: "Cares",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                comment: "The additinal data about the care",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Places",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "The place name");

            migrationBuilder.AlterColumn<decimal>(
                name: "Longitude",
                table: "Places",
                type: "decimal(9,6)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(9,6)",
                oldComment: "The Geolocation - Longitude");

            migrationBuilder.AlterColumn<decimal>(
                name: "Latitude",
                table: "Places",
                type: "decimal(9,6)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(9,6)",
                oldComment: "The Geolocation - Latitude");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Places",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "Soft Delete");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Places",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true,
                oldComment: "The address of the place");

            migrationBuilder.AlterColumn<string>(
                name: "AdditionalDetails",
                table: "Places",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true,
                oldComment: "Additional Information for the place");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "LegalTypes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "The name of the legal type");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ValidTo",
                table: "Legals",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "Valid To Date of the care");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ValidFrom",
                table: "Legals",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "Valid From Date of the care");

            migrationBuilder.AlterColumn<string>(
                name: "TypeDetails",
                table: "Legals",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "Short description of the care type details");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Legals",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldComment: "The Price of the legal");

            migrationBuilder.AlterColumn<string>(
                name: "Issuer",
                table: "Legals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "The seller of the legal service");

            migrationBuilder.AlterColumn<bool>(
                name: "IsPayed",
                table: "Legals",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "Notice if the legal is payed or still pending");

            migrationBuilder.AlterColumn<string>(
                name: "Insurer",
                table: "Legals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "The owner of the legal service");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Legals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true,
                oldComment: "Additional Details");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Legals",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "The care date indicated by owner");

            migrationBuilder.AlterColumn<double>(
                name: "Volume",
                table: "Fuels",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float",
                oldComment: "The quantity of the fuel");

            migrationBuilder.AlterColumn<decimal>(
                name: "PriceTotalFuel",
                table: "Fuels",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldComment: "The total price of for the fuel");

            migrationBuilder.AlterColumn<decimal>(
                name: "PricePerLiter",
                table: "Fuels",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldComment: "The price of one liter");

            migrationBuilder.AlterColumn<int>(
                name: "KilometrageActual",
                table: "Fuels",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "The kilometrage of the date of fuel");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Fuels",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "Soft delete");

            migrationBuilder.AlterColumn<string>(
                name: "GasType",
                table: "Fuels",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "The type of the energy we use");

            migrationBuilder.AlterColumn<string>(
                name: "GasStation",
                table: "Fuels",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "The name of the Gas Station");

            migrationBuilder.AlterColumn<bool>(
                name: "FullTank",
                table: "Fuels",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "The max fuel possible");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Fuels",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true,
                oldComment: "Additional details");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Fuels",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "The fuel date indicated by owner");

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Fuels",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "The name of the City where we fuel");

            migrationBuilder.AddColumn<decimal>(
                name: "ExpencesTotalFuel",
                table: "Fuels",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "CareTypes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldComment: "The name of the care type");

            migrationBuilder.AlterColumn<string>(
                name: "TypeDetails",
                table: "Cares",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "Short description of the care type details");

            migrationBuilder.AlterColumn<double>(
                name: "Quantity",
                table: "Cares",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float",
                oldComment: "The quantity of the care");

            migrationBuilder.AlterColumn<decimal>(
                name: "PriceWork",
                table: "Cares",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldComment: "The Price only for the work without the material");

            migrationBuilder.AlterColumn<decimal>(
                name: "PriceTotal",
                table: "Cares",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldComment: "The Price total for the work and the material");

            migrationBuilder.AlterColumn<decimal>(
                name: "PriceMaterial",
                table: "Cares",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldComment: "The Price of one material");

            migrationBuilder.AlterColumn<string>(
                name: "Manifacturer",
                table: "Cares",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "Short description of the care type details");

            migrationBuilder.AlterColumn<bool>(
                name: "IsPendingCare",
                table: "Cares",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "If we finished or the care still should be done");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Cares",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "The care date indicated by owner");

            migrationBuilder.AlterColumn<string>(
                name: "BuyedFrom",
                table: "Cares",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "The seller of the care");

            migrationBuilder.AlterColumn<string>(
                name: "AdditionalInfo",
                table: "Cares",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true,
                oldComment: "The additinal data about the care");
        }
    }
}
