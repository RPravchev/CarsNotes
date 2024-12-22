using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsNotes.Core.DTOs
{
    public class CarInfoDto
    {
        public Guid Id { get; set; }
        public string ShortName { get; set; } = null!;
        public string Brand { get; set; } = null!;
        public string CarModel { get; set; } = null!;
        public string? MainImageUrl { get; set; }
        public int Year { get; set; }
    }
}
