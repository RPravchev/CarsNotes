using CarsNotes.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarsNotes.Data.Models
{
    public class Fuel
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string GasStation { get; set; }
        public string City { get; set; }
        public double Volume { get; set; }
        public string GasType { get; set; }
        public decimal PricePerLittre {  get; set; }
        public decimal PriceTotal { get; set; }
        public int KilometrageActual { get; set; }
        public decimal ExpencesTotalFuel { get; set; }
        [Required]
        public string OwnerId { get; set; }
        [ForeignKey(nameof(OwnerId))]
        public CarUser Owner { get; set; }
        [Required]
        public Guid CarId { get; set; }
        [ForeignKey(nameof(CarId))]
        public Car Car { get; set; }
        public bool IsDeleted { get; set; }

    }
}
