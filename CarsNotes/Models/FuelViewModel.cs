using System.ComponentModel.DataAnnotations;

namespace CarsNotes.Models
{
    public class FuelViewModel
    {
        public Guid Id { get; set; }
         public DateTime Date { get; set; }
        public string GasStation { get; set; }
        public string City { get; set; }
        public double Volume { get; set; }
        public string GasType { get; set; }
        public decimal PricePerLiter { get; set; }
        public decimal PriceTotalFuel { get; set; }
        public int KilometrageActual { get; set; }
        public bool FullTank {  get; set; }
        public string? Description { get; set; }
        public decimal ExpencesTotalFuel { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
        public Guid CarId { get; set; }
    }
}
