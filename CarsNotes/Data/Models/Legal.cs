using CarsNotes.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarsNotes.Data.Models
{
    public class Legal
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string TypeDetails { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public DateTime PayedOn { get; set; }
        public string AdditionalDetails { get; set; }
        public decimal Price { get; set; }
        public decimal PriceYear { get; set; }
        public string Issuer { get; set; }
        public string Insurer { get; set; }
        [Required]
        public Guid CarId { get; set; }
        [ForeignKey(nameof(CarId))]
        public Car Car { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }

    }
}
