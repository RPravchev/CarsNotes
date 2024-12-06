using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarsNotes.Data.Models
{
    public class CareType
    {
        [Key]
        [Comment("The identifier of each care type")]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;
        public ICollection<Care> Cares { get; set; } = new HashSet<Care>();
        [Comment("Soft Delete")]
        public bool IsDeleted { get; set; }

    }
}
