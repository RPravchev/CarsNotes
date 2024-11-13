namespace CarsNotes.Models
{
    public class CarInfoViewModel
    {
        public Guid Id { get; set; }
        public required string ShortName { get; set; }
        public required string Brand { get; set; }
        public required string Model { get; set; }
        public string? MainImageUrl { get; set; }
        public int Year { get; set; }
    }
}
