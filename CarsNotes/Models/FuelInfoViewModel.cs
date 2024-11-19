using CarsNotes.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace CarsNotes.Models
{
    public class FuelInfoViewModel
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
        public decimal ExpencesTotalFuel { get; set; }
        [Required]
        public string OwnerId { get; set; }
        [Required]
        public Guid CarId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public bool IsDeleted { get; set; }
        public IList<Fuel> FuelInfos { get; set; } = new List<Fuel>();
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double TotalFuelQtyForPeriod { get; set; }
        public decimal TotalFuelExpensesForPeriod { get; set; }

    }
}
