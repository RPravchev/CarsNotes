namespace CarsNotes.Web.Models
{
    public class CareInfoViewModel
    {
        public IList<CareViewModel> CareInfos { get; set; } = new List<CareViewModel>();
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalExpensesForPeriod { get; set; }
    }
}
