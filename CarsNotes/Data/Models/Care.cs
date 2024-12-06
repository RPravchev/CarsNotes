using CarsNotes.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarsNotes.Data.Models
{
    public class Care
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public string? TypeDetails { get; set; }
        public string? Manifacturer { get; set; }
        public string? AdditionalInfo { get; set; }
        public string? BuyedFrom { get; set; }
        public double Quantity { get; set; }
        public decimal PriceMaterial { get; set; }
        public decimal PriceWork { get; set; }
        public decimal PriceTotal { get; set; }
        public bool IsPendingCare { get; set; }
        [Required]
        public int CareTypeId { get; set; }
        [ForeignKey(nameof(CareTypeId))]
        public CareType CareType { get; set; } = null!;
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
