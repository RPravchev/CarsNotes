using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using static CarsNotes.Common.Constants.PlaceConstants;

//namespace CarsNotes.Data.Models
namespace CarsNotes.Core.Models
{
    public class Place
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(PlaceNameMax)]
        [Comment("The place name")]
        public string Name { get; set; } = null!;

        [Column(TypeName = PlaceGeoDecimal)]
        [Comment("The Geolocation - Latitude")]
        public decimal Latitude { get; set; }

        [Column(TypeName = PlaceGeoDecimal)]
        [Comment("The Geolocation - Longitude")]
        public decimal Longitude { get; set; }
        public DateTime Date { get; set; }

        [MaxLength(PlaceAddressMax)]
        [Comment("The address of the place")]
        public string? Address { get; set; }

        [MaxLength(PlaceAdditionalDetailsMax)]
        [Comment("Additional Information for the place")]
        public string? AdditionalDetails { get; set; }

        [Required]
        public Guid CarId { get; set; }
        [ForeignKey(nameof(CarId))]
        public Car Car { get; set; } = null!;

        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        [Comment("Soft Delete")]
        public bool IsDeleted { get; set; }

    }
}
