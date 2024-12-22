using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CarsNotes.Common.Constants.CareConstants;

//namespace CarsNotes.Data.Models
namespace CarsNotes.Core.Models
{
    public class CareType
    {
        [Key]
        [Comment("The identifier of each care type")]
        public int Id { get; set; }
        [Required]
        [MaxLength(CareTypeNameMax)]
        [Comment("The name of the care type")]
        public string Name { get; set; } = null!;
        public ICollection<Care> Cares { get; set; } = new HashSet<Care>();
        [Comment("Soft Delete")]
        public bool IsDeleted { get; set; }

    }
}
