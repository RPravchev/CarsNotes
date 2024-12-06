using CarsNotes.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarsNotes.Models
{
    public class CareInfoViewModel
    {
        /*
        [Key]
        public Guid Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Type { get; set; } = null!;
        public string? TypeDetails { get; set; }
        public string? Manifacturer { get; set; }
        public string? AdditionalInfo { get; set; }
        public string? BuyedFrom { get; set; }
        public decimal PriceTotal { get; set; }
        public bool IsPendingCare { get; set; }
        [Required]
        public string OwnerId { get; set; } = null!;
        [Required]
        public Guid CarId { get; set; }
        [ForeignKey(nameof(CarId))]
        public Car Car { get; set; }
        */
        public IList<CareViewModel> CareInfos { get; set; } = new List<CareViewModel>();
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalExpensesForPeriod { get; set; }
        //public bool IsDeleted { get; set; }
    }
}
