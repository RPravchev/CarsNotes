using System.ComponentModel.DataAnnotations.Schema;

namespace CarsNotes.Data.Models
{
    public class Oil
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public double Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime DateTime { get; set; }
        public Guid CareId { get; set; }
        [ForeignKey(nameof(CareId))]
        public Care Care { get; set; }
        public bool IsDeleted { get; set; }

    }
}
