using CarsNotes.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarsNotes.Data.Models
{
    public class Car
    {
        [Key]
        public Guid Id { get; set; }
        public string ShortName { get; set; } = null!;
        public string? MainImageUrl { get; set; }
        public string Brand  { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string? RegistrationNumber { get; set; }
        public string? FuelType { get; set; }
        public string? BodyType { get; set; }
        public string? TransmissionType { get; set; }
        public int DoorsNumber { get; set; }
        public string? Color {  get; set; }
        public int HorsePower { get; set; }
        public string? CubicCapacity { get; set; }
        public string? ChassisNumber { get; set; }
        public string? EngineNumber { get; set; }
        public string? TransmissionNumber {  get; set; }
        public int YearProduction { get; set; }
        public int YearAcquisition { get; set; }
        public string? OriginalColorCode { get; set; }
        public string? VINCode { get; set;}
        public string? CountryProduction { get; set; }
        public int KilometrageAcquisition { get; set; }
        public int KilometrageActual { get; set; }
        public string? AdditionalDetails { get; set; }
        [Required]
        public string OwnerId { get; set; } = null!;
        [ForeignKey(nameof(OwnerId))]
        public CarUser Owner { get; set; }
        public ICollection<CarOwner> CarsOwner { get; set; } = new HashSet<CarOwner>();
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }



    }
}
