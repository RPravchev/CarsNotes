using CarsNotes.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CarsNotes.Models;

namespace CarsNotes.Web.Models
{
    public class PlaceFilterViewModel
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public IList<Place> PlaceInfos { get; set; } = new List<Place>();

        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
    }
}
