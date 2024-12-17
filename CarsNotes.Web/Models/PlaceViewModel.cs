using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace CarsNotes.Web.Models
{
    public class PlaceViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;

        public string? LatitudeString { get; set; } // Raw input from the form

        public string? LongitudeString { get; set; } // Raw input from the form

        [Range(-90, 90, ErrorMessage = "Latitude must be between -90 and 90.")]
        public decimal Latitude
        {
            get
            {
                if (LatitudeString != null)
                    return decimal.Parse(LatitudeString.Replace(',', '.'), CultureInfo.InvariantCulture);
                return 0;
            }
        }

        [Range(-180, 180, ErrorMessage = "Longitude must be between -180 and 180.")]
        public decimal Longitude
        {
            get
            {
                if (LongitudeString != null)
                    return decimal.Parse(LongitudeString.Replace(',', '.'), CultureInfo.InvariantCulture);
                return 0;
            }
        }
        public DateTime Date { get; set; }
        public string? Address { get; set; }
        public string? AdditionalDetails { get; set; }
        [Required]
        public Guid CarId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
