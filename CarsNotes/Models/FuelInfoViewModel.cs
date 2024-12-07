using CarsNotes.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace CarsNotes.Models
{
    public class FuelInfoViewModel
    {
        public IList<Fuel> FuelInfos { get; set; } = new List<Fuel>();
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; } 
        public double TotalFuelQtyForPeriod { get; set; }
        public decimal TotalFuelExpensesForPeriod { get; set; }
        public string? AveragePrice { get; set; }
        public int KilometrageFirst { get; set; }
        public int KilometrageLast { get; set; }
        public double FuelConsumption { get; set; }
        public int Distance { get; set; }
        public string FuelConsumptionAvarage { get; set; } = null!;

        public int CurrentPage { get; set; } 
        public int TotalPages { get; set; }
        public int PageSize { get; set; }   
    }
}
