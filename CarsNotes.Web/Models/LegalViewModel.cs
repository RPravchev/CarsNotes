using CarsNotes.Core.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarsNotes.Web.Models
{
    public class LegalViewModel
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public string? TypeDetails { get; set; }
        public DateTime? ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }
        public decimal? Price { get; set; }
        public string? Issuer { get; set; }
        public string? Insurer { get; set; }
        public string? Description { get; set; }
        public bool IsPayed { get; set; }
        [Required]
        public int LegalTypeId { get; set; }
        [ForeignKey(nameof(LegalTypeId))]
        public string? LegalType { get; set; }

        [Required]
        public Guid CarId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
        public IList<LegalType> LegalInfos { get; set; } = new List<LegalType>();
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
