namespace CarsNotes.Data.Models
{
    public class Care
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public DateTime? CreatedDate { get; set; } = default(DateTime?);
        public DateTime? UpdatedDate { get; } = default(DateTime?);
        public bool IsPendingCare { get; set; }
        public bool IsDeleted { get; set; }

    }
}
