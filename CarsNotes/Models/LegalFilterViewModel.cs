using CarsNotes.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarsNotes.Models
{
    public class LegalFilterViewModel
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal TotalExpensesForPeriod { get; set; }
        public IList<LegalViewModel> LegalInfos { get; set; } = new List<LegalViewModel>();
        public IList<string>? LegalTypesSelected { get; set; } = new List<string>();
        public IList<LegalType>? LegalTypeList { get; set; } = new List<LegalType>();
        public int? CurrentPage { get; set; }
        public int? TotalPages { get; set; }
        public int? EntitiesPerPage { get; set; }

    }
}
