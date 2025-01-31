﻿using CarsNotes.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace CarsNotes.Web.Models
{
    public class CareViewModel
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public string? TypeDetails { get; set; }
        public string? Manifacturer { get; set; }
        public string? AdditionalInfo { get; set; }
        public string? BuyedFrom { get; set; }
        public double Quantity { get; set; }
        public decimal PriceMaterial { get; set; }
        public decimal PriceWork { get; set; }
        public decimal PriceTotal { get; set; }
        public bool IsPendingCare { get; set; }
        [Required]
        public Guid CarId { get; set; }
        [Required]
        public int CareTypeId { get; set; }
        public string? CareType { get; set; }
        public decimal TotalExpensesForPeriod { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
        public IList<CareType> CareInfos { get; set; } = new List<CareType>();
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
