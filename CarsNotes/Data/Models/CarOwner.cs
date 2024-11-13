using CarsNotes.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarsNotes.Data.Models
{
    public class CarOwner
    {
        [Key]
        public Guid CarOwnerId { get; set; }
        public Guid CarId { get; set; }
        [ForeignKey(nameof(CarId))]
        public Car Car { get; set; } = null!;
        public string CarUserId { get; set; } = null!;
        [ForeignKey(nameof(CarUserId))]
        public CarUser Owner { get; set; } = null!;

    }
}