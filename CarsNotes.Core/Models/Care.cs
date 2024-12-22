//using CarsNotes.Web.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CarsNotes.Common.Constants.CareConstants;

//namespace CarsNotes.Data.Models
namespace CarsNotes.Core.Models
{
    public class Care
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [Comment("The care date indicated by owner")]
        public DateTime Date { get; set; }

        [MaxLength(CareTypeDetailsMax)]
        [Comment("Short description of the care type details")]
        public string? TypeDetails { get; set; }

        [MaxLength(CareManifacturerMax)]
        [Comment("Short description of the care type details")]
        public string? Manifacturer { get; set; }

        [MaxLength(CareAdditionalDetailsMax)]
        [Comment("The additinal data about the care")]
        public string? AdditionalInfo { get; set; }

        [MaxLength(CareBuyedFromMax)]
        [Comment("The seller of the care")]
        public string? BuyedFrom { get; set; }

        [Range(CareQuantityMin, CareQuantityMax)]
        [Comment("The quantity of the care")]
        public double Quantity { get; set; }

        [Comment("The Price of one material")]
        public decimal PriceMaterial { get; set; }

        [Comment("The Price only for the work without the material")]
        public decimal PriceWork { get; set; }

        [Comment("The Price total for the work and the material")]
        public decimal PriceTotal { get; set; }

        [Comment("If we finished or the care still should be done")]
        public bool IsPendingCare { get; set; }

        [Required]
        public int CareTypeId { get; set; }
        [ForeignKey(nameof(CareTypeId))]
        public CareType CareType { get; set; } = null!;

        [Required]
        public string OwnerId { get; set; } = null!;
        [ForeignKey(nameof(OwnerId))]
        public CarUser Owner { get; set; } = null!;

        [Required]
        public Guid CarId { get; set; }
        [ForeignKey(nameof(CarId))]
        public Car Car { get; set; } = null!;

        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }

    }
}
