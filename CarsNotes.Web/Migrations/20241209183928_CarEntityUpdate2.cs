using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarsNotes.Data.Migrations
{
    /// <inheritdoc />
    public partial class CarEntityUpdate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "YearProduction",
                table: "Cars",
                type: "int",
                nullable: false,
                comment: "When the car is produced",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "YearAcquisition",
                table: "Cars",
                type: "int",
                nullable: false,
                comment: "When the car is buyed",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "VINCode",
                table: "Cars",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "The Vehicle Identification Number",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TransmissionType",
                table: "Cars",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "The type of the gear of the car",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TransmissionNumber",
                table: "Cars",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "The Gear Number of the car",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ShortName",
                table: "Cars",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                comment: "The Short name of the car",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "RegistrationNumber",
                table: "Cars",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true,
                comment: "The plate of the car",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OriginalColorCode",
                table: "Cars",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                comment: "The technical number of color of the car",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedOn",
                table: "Cars",
                type: "datetime2",
                nullable: false,
                comment: "The last modification of the car data",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "MainImageUrl",
                table: "Cars",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                comment: "One main image for each car",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "KilometrageActual",
                table: "Cars",
                type: "int",
                nullable: false,
                comment: "The most recent data about the kilometrage",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "KilometrageAcquisition",
                table: "Cars",
                type: "int",
                nullable: false,
                comment: "The kilometrage when the car is buyed",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Cars",
                type: "bit",
                nullable: false,
                comment: "Soft delete",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<int>(
                name: "HorsePower",
                table: "Cars",
                type: "int",
                nullable: false,
                comment: "The value of the horse power of the car",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "FuelType",
                table: "Cars",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "The energy used to move the car",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EngineNumber",
                table: "Cars",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "The Engine Number of the car",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DoorsNumber",
                table: "Cars",
                type: "int",
                nullable: false,
                comment: "The number of doors of the car",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "CubicCapacity",
                table: "Cars",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                comment: "The engine volume of the car",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Cars",
                type: "datetime2",
                nullable: false,
                comment: "The date when the record was created",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "CountryProduction",
                table: "Cars",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "Where the car is produced",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Color",
                table: "Cars",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "The color of the car",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ChassisNumber",
                table: "Cars",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "The Chassis Number of the car",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CarModel",
                table: "Cars",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                comment: "The model of the car",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Brand",
                table: "Cars",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                comment: "The brand of the car",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "BodyType",
                table: "Cars",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "The body type of the car",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AdditionalDetails",
                table: "Cars",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                comment: "The additinal data about the car",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "YearProduction",
                table: "Cars",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "When the car is produced");

            migrationBuilder.AlterColumn<int>(
                name: "YearAcquisition",
                table: "Cars",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "When the car is buyed");

            migrationBuilder.AlterColumn<string>(
                name: "VINCode",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "The Vehicle Identification Number");

            migrationBuilder.AlterColumn<string>(
                name: "TransmissionType",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "The type of the gear of the car");

            migrationBuilder.AlterColumn<string>(
                name: "TransmissionNumber",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "The Gear Number of the car");

            migrationBuilder.AlterColumn<string>(
                name: "ShortName",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldComment: "The Short name of the car");

            migrationBuilder.AlterColumn<string>(
                name: "RegistrationNumber",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15,
                oldNullable: true,
                oldComment: "The plate of the car");

            migrationBuilder.AlterColumn<string>(
                name: "OriginalColorCode",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true,
                oldComment: "The technical number of color of the car");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedOn",
                table: "Cars",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "The last modification of the car data");

            migrationBuilder.AlterColumn<string>(
                name: "MainImageUrl",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true,
                oldComment: "One main image for each car");

            migrationBuilder.AlterColumn<int>(
                name: "KilometrageActual",
                table: "Cars",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "The most recent data about the kilometrage");

            migrationBuilder.AlterColumn<int>(
                name: "KilometrageAcquisition",
                table: "Cars",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "The kilometrage when the car is buyed");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Cars",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "Soft delete");

            migrationBuilder.AlterColumn<int>(
                name: "HorsePower",
                table: "Cars",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "The value of the horse power of the car");

            migrationBuilder.AlterColumn<string>(
                name: "FuelType",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "The energy used to move the car");

            migrationBuilder.AlterColumn<string>(
                name: "EngineNumber",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "The Engine Number of the car");

            migrationBuilder.AlterColumn<int>(
                name: "DoorsNumber",
                table: "Cars",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "The number of doors of the car");

            migrationBuilder.AlterColumn<string>(
                name: "CubicCapacity",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true,
                oldComment: "The engine volume of the car");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Cars",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "The date when the record was created");

            migrationBuilder.AlterColumn<string>(
                name: "CountryProduction",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "Where the car is produced");

            migrationBuilder.AlterColumn<string>(
                name: "Color",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "The color of the car");

            migrationBuilder.AlterColumn<string>(
                name: "ChassisNumber",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "The Chassis Number of the car");

            migrationBuilder.AlterColumn<string>(
                name: "CarModel",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "The model of the car");

            migrationBuilder.AlterColumn<string>(
                name: "Brand",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "The brand of the car");

            migrationBuilder.AlterColumn<string>(
                name: "BodyType",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "The body type of the car");

            migrationBuilder.AlterColumn<string>(
                name: "AdditionalDetails",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true,
                oldComment: "The additinal data about the car");
        }
    }
}
