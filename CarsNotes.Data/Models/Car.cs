using CarsNotes.Web.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CarsNotes.Common.Constants.CarConstants;

namespace CarsNotes.Data.Models
{
    public class Car
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [Comment("The Short name of the car")]
        [MaxLength(CarShortNameMaxLength)]
        public string ShortName { get; set; } = null!;

        [MaxLength(CarMainImageUrlMax)]
        [Comment("One main image for each car")]
        public string? MainImageUrl { get; set; }

        [Required]
        [MaxLength(CarBrandMax)]
        [Comment("The brand of the car")]
        public string Brand { get; set; } = null!;

        [Required]
        [MaxLength(CarModelMax)]
        [Comment("The model of the car")]
        public string CarModel { get; set; }= null!;

        [MaxLength(CarRegistrationNumberMax)]
        [Comment("The plate of the car")]
        public string? RegistrationNumber { get; set; }

        [MaxLength(CarFuelTypeMax)]
        [Comment("The energy used to move the car")]
        public string? FuelType { get; set; }

        [MaxLength(CarBodyTypeMax)]
        [Comment("The body type of the car")]
        public string? BodyType { get; set; }

        [MaxLength(CarTransmissionTypeMax)]
        [Comment("The type of the gear of the car")]
        public string? TransmissionType { get; set; }

        [Range(CarDoorsNumberMin,CarDoorsNumberMax)]
        [Comment("The number of doors of the car")]
        public int DoorsNumber { get; set; }

        [MaxLength(CarColorMax)]
        [Comment("The color of the car")]
        public string? Color {  get; set; }

        [Range(CarHorsePowerMin, CarHorsePowerMax)]
        [Comment("The value of the horse power of the car")]
        public int HorsePower { get; set; }

        [MaxLength(CarCubicCapacityMax)]
        [Comment("The engine volume of the car")]
        public string? CubicCapacity { get; set; }

        [MaxLength(CarChassisNumberMax)]
        [Comment("The Chassis Number of the car")]
        public string? ChassisNumber { get; set; }

        [MaxLength(CarEngineNumberMax)]
        [Comment("The Engine Number of the car")]
        public string? EngineNumber { get; set; }

        [MaxLength(CarTransmissionNumberMax)]
        [Comment("The Gear Number of the car")]
        public string? TransmissionNumber {  get; set; }

        [Comment("When the car is produced")]
        public int YearProduction { get; set; }

        [Comment("When the car is buyed")]
        public int YearAcquisition { get; set; }

        [MaxLength(CarOriginalColorCodeMax)]
        [Comment("The technical number of color of the car")]
        public string? OriginalColorCode { get; set; }

        [MaxLength(CarVINCodeMax)]
        [Comment("The Vehicle Identification Number")]
        public string? VINCode { get; set;}

        [MaxLength(CarCountryProductionMax)]
        [Comment("Where the car is produced")]
        public string? CountryProduction { get; set; }

        [Range(CarKilometrageMin, CarKilometrageMax)]
        [Comment("The kilometrage when the car is buyed")]
        public int KilometrageAcquisition { get; set; }

        [Range(CarKilometrageMin, CarKilometrageMax)]
        [Comment("The most recent data about the kilometrage")]
        public int KilometrageActual { get; set; }

        [MaxLength(CarAdditionalDetailsMax)]
        [Comment("The additinal data about the car")]
        public string? AdditionalDetails { get; set; }

        [Required]
        //[MaxLength(CarGuid)]
        public string OwnerId { get; set; } = null!;
        [ForeignKey(nameof(OwnerId))]
        public CarUser Owner { get; set; } = null!;
        [Comment("The date when the record was created")]
        public DateTime CreatedOn { get; set; }
        [Comment("The last modification of the car data")]
        public DateTime ModifiedOn { get; set; }
        [Comment("Soft delete")]
        public bool IsDeleted { get; set; }



    }
}
