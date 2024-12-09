using CarsNotes.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarsNotes.Data.Models
{
    public class Fuel
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        [Required]
        public string GasStation { get; set; } = null!;
        [Required]
        public string City { get; set; } = null!;
        public double Volume { get; set; }
        public string? GasType { get; set; }
        public decimal PricePerLiter {  get; set; }
        public decimal PriceTotalFuel { get; set; }
        public int KilometrageActual { get; set; }
        public bool FullTank { get; set; }
        public string? Description { get; set; }
        public decimal ExpencesTotalFuel { get; set; }
        [Required]
        public string OwnerId { get; set; } = null!;
        [ForeignKey(nameof(OwnerId))]
        public CarUser Owner { get; set; }
        [Required]
        public Guid CarId { get; set; }
        [ForeignKey(nameof(CarId))]
        public Car Car { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }

    }
}
