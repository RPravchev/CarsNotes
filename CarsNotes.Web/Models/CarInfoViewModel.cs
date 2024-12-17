using System.ComponentModel.DataAnnotations;

namespace CarsNotes.Web.Models
{
    public class CarInfoViewModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Field {0} is required")]
        [Display(Name = "Short Name")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Field {0} must be between {2} and {1}")]
        public required string ShortName { get; set; }
        [Required]
        public string Brand { get; set; } = null!;
        [Required]
        public string CarModel { get; set; } = null!;
        public string? MainImageUrl { get; set; }
        public int Year { get; set; }
    }
}
