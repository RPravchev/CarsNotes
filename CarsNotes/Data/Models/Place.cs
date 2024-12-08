using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace CarsNotes.Data.Models
{
    public class Place
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = null!;
        [Column(TypeName = "decimal(9,6)")]
        public decimal Latitude { get; set; }
        [Column(TypeName = "decimal(9,6)")]
        public decimal Longitude { get; set; }
        public DateTime Date { get; set; }
        public string? Address { get; set; }
        public string? AdditionalDetails { get; set; }
        [Required]
        public Guid CarId { get; set; }
        [ForeignKey(nameof(CarId))]
        public Car Car { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }

    }
}
