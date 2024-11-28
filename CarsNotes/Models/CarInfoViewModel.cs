using System.ComponentModel.DataAnnotations;

namespace CarsNotes.Models
{
    public class CarInfoViewModel
    {
        public Guid Id { get; set; }
        //[Required(ErrorMessage = "Field {0} is required")]
        //[Display(Name = "Short Name")]
        //[StringLength(100, MinimumLength = 3, ErrorMessage ="Field {0} must be between {2} and {1}")]
        public required string ShortName { get; set; }
        public required string Brand { get; set; }
        public required string Model { get; set; }
        public string? MainImageUrl { get; set; }
        public int Year { get; set; }
    }
}
