using System.ComponentModel.DataAnnotations;
using static CarsNotes.Common.Constants.CarConstants;

namespace CarsNotes.Web.Models
{
    public class CarViewModel
    {
        public Guid Id { get; set; }
        [Required]
        [Display(Name = "Short Name")]
        [MaxLength(CarShortNameMaxLength)]
        public string ShortName { get; set; } = null!;

        [Display(Name = "Main Image Url")]
        [MaxLength(CarMainImageUrlMax)]
        public string? MainImageUrl { get; set; }

        [Required]
        [MaxLength(CarBrandMax)]
        public string Brand { get; set; } = null!;

        [Required]
        [Display(Name = "Car Model")]
        [MaxLength(CarModelMax)]
        public string CarModel { get; set; } = null!;

        [Display(Name = "Registration Number")]
        [MinLength(CarRegistrationNumberMin)]
        [MaxLength(CarRegistrationNumberMax)]
        public string? RegistrationNumber { get; set; }

        [Display(Name = "Fuel Type")]
        [MinLength(CarFuelTypeMin)]
        [MaxLength(CarFuelTypeMax)]
        public string? FuelType { get; set; }

        [Display(Name = "Body Type")]
        [MinLength(CarBodyTypeMin)]
        [MaxLength(CarBodyTypeMax)]
        public string? BodyType { get; set; }

        [Display(Name = "Transmission Type")]
        [MinLength(CarTransmissionTypeMin)]
        [MaxLength(CarTransmissionTypeMax)]
        public string? TransmissionType { get; set; }

        [Display(Name = "Doors Number")]
        [Range(CarDoorsNumberMin, CarDoorsNumberMax)]
        public int DoorsNumber { get; set; }

        [MinLength(CarColorMin)]
        [MaxLength(CarColorMax)]
        public string? Color { get; set; }

        [Display(Name = "Horse Power")]
        [Range(CarHorsePowerMin, CarHorsePowerMax)]
        public int HorsePower { get; set; }

        [Display(Name = "Cubic Capacity")]
        [MinLength(CarCubicCapacityMin)]
        [MaxLength(CarCubicCapacityMax)]
        public string? CubicCapacity { get; set; }

        [Display(Name = "Chassis Number")]
        [MinLength(CarChassisNumberMin)]
        [MaxLength(CarChassisNumberMax)]
        public string? ChassisNumber { get; set; }

        [Display(Name = "Engine Number")]
        [MinLength(CarEngineNumberMin)]
        [MaxLength(CarEngineNumberMax)]
        public string? EngineNumber { get; set; }

        [Display(Name = "Transmission Number")]
        [MinLength(CarTransmissionNumberMin)]
        [MaxLength(CarTransmissionNumberMax)]
        public string? TransmissionNumber { get; set; }

        [Display(Name = "Year of Production")]
        public int? YearProduction { get; set; }

        [Display(Name = "Year of Acquisition")]
        public int? YearAcquisition { get; set; }

        [Display(Name = "Original Color Code")]
        [MinLength(CarOriginalColorCodeMin)]
        [MaxLength(CarOriginalColorCodeMax)]
        public string? OriginalColorCode { get; set; }

        [Display(Name = "VIN Code")]
        [MinLength(CarVINCodeMin)]
        [MaxLength(CarVINCodeMax)]
        public string? VINCode { get; set; }

        [Display(Name = "Country of Production")]
        [MinLength(CarCountryProductionMin)]
        [MaxLength(CarCountryProductionMax)]
        public string? CountryProduction { get; set; }

        [Display(Name = "Kilometrage when buyed")]
        [Range(CarKilometrageMin, CarKilometrageMax)]
        public int KilometrageAcquisition { get; set; }

        [Display(Name = "Kilometrage today")]
        [Range(CarKilometrageMin, CarKilometrageMax)]
        public int KilometrageActual { get; set; }

        [Display(Name = "Additional Details")]
        [MinLength(CarAdditionalDetailsMin)]
        [MaxLength(CarAdditionalDetailsMax)]
        public string? AdditionalDetails { get; set; }
        public bool IsDeleted { get; set; }
        public string OwnerId { get; set; } = string.Empty;
    }
}
