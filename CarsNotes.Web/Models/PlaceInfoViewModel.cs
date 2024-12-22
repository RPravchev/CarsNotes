//using CarsNotes.Data.Models;

using CarsNotes.Core.Models;

namespace CarsNotes.Web.Models
{
    public class PlaceInfoViewModel
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public IList<Place>? PlaceInfos { get; set; } = new List<Place>();

    }
}
