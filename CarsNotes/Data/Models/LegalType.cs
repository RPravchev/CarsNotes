using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarsNotes.Data.Models
{
    public class LegalType
    {
        [Key]
        [Comment("The identifier of each legal type")]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;
        public ICollection<Legal> Legals { get; set; } = new HashSet<Legal>();
        [Comment("Soft Delete")]
        public bool IsDeleted { get; set; }

    }
}
