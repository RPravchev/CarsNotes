using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CarsNotes.Common.Constants.LegalConstants;

//namespace CarsNotes.Data.Models
namespace CarsNotes.Core.Models
{
    public class LegalType
    {
        [Key]
        [Comment("The identifier of each legal type")]
        public int Id { get; set; }
        [Required]
        [MaxLength(LegalTypeNameMax)]
        [Comment("The name of the legal type")]
        public string Name { get; set; } = null!;
        public ICollection<Legal> Legals { get; set; } = new HashSet<Legal>();
        [Comment("Soft Delete")]
        public bool IsDeleted { get; set; }

    }
}
