using CarsNotes.Areas.Identity.Data;
using CarsNotes.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarsNotes.Models
{
    public class CarViewModel
    {
        public Guid Id { get; set; }
        public string ShortName { get; set; } = null!;
        public string MainImageUrl { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string RegistrationNumber { get; set; } = string.Empty;
        public string FuelType { get; set; } = string.Empty;
        public string BodyType { get; set; } = string.Empty;
        public string TransmissionType { get; set; } = string.Empty;
        public int DoorsNumber { get; set; }
        public string Color { get; set; } = string.Empty;
        public int HorsePower { get; set; }
        public string CubicCapacity { get; set; } = string.Empty;
        public string ChassisNumber { get; set; } = string.Empty;
        public string EngineNumber { get; set; } = string.Empty;
        public string TransmissionNumber { get; set; } = string.Empty;
        public int YearProduction { get; set; }
        public int YearAcquisition { get; set; }
        public string OriginalColorCode { get; set; } = string.Empty;
        public string VINCode { get; set; } = string.Empty;
        public string CountryProduction { get; set; } = string.Empty;
        public int KilometrageAcquisition { get; set; }
        public int KilometrageActual { get; set; }
        public bool IsDeleted { get; set; }
        public string OwnerId { get; set; } = string.Empty;
        public ICollection<CarOwner> CarsOwner { get; set; } = new HashSet<CarOwner>();
    }
}
