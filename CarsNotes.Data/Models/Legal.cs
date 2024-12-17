using CarsNotes.Web.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CarsNotes.Common.Constants.LegalConstants;

namespace CarsNotes.Data.Models
{
    public class Legal
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [Comment("The care date indicated by owner")]
        public DateTime Date { get; set; }

        [Required]
        [MaxLength(LegalTypeDetailsMax)]
        [Comment("Short description of the care type details")]
        public string TypeDetails { get; set; } = null!;
        [Comment("Valid From Date of the care")]
        public DateTime ValidFrom { get; set; }
        [Comment("Valid To Date of the care")]
        public DateTime ValidTo { get; set; }

        [Comment("The Price of the legal")]
        public decimal Price { get; set; }

        [MaxLength(LegalIssuerMax)]
        [Comment("The seller of the legal service")]
        public string? Issuer { get; set; }

        [MaxLength(LegalInsurerMax)]
        [Comment("The owner of the legal service")]
        public string? Insurer { get; set; }

        [MaxLength(LegalDescriptionMax)]
        [Comment("Additional Details")]
        public string? Description { get; set; }
        [Comment("Notice if the legal is payed or still pending")]
        public bool IsPayed { get; set; }

        [Required]
        public int LegalTypeId { get; set; }
        [ForeignKey(nameof(LegalTypeId))]
        public LegalType LegalType { get; set; } = null!;

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
