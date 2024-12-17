using System.ComponentModel.DataAnnotations;

namespace CarsNotes.Web.Models
{
    public class FuelViewModel
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        [Required]
        public string GasStation { get; set; } = null!;
        [Required]
        public string City { get; set; } = null!;
        public double Volume { get; set; }
        public string? GasType { get; set; }
        public decimal PricePerLiter { get; set; }
        public decimal PriceTotalFuel { get; set; }
        public int KilometrageActual { get; set; }
        public bool FullTank { get; set; }
        public string? Description { get; set; }
        public decimal ExpencesTotalFuel { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
        public Guid CarId { get; set; }
    }
}
