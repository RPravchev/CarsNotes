using CarsNotes.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarsNotes.Models
{
    public class CareInfoViewModel
    {
        public IList<CareViewModel> CareInfos { get; set; } = new List<CareViewModel>();
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalExpensesForPeriod { get; set; }
    }
}
