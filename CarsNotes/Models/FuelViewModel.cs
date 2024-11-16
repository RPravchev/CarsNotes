using System.ComponentModel.DataAnnotations;

namespace CarsNotes.Models
{
    public class FuelViewModel
    {
        public Guid Id { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime Date { get; set; }
        public string GasStation { get; set; }
        public string City { get; set; }
        public double Volume { get; set; }
        public string GasType { get; set; }
        public decimal PricePerLittre { get; set; }
        public decimal PriceTotal { get; set; }
        public int KilometrageActual { get; set; }
        public decimal ExpencesTotalFuel { get; set; }
        public string OwnerId { get; set; }
    }
}
