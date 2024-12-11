using CarsNotes.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CarsNotes.Common.Constants.FuelConstants;

namespace CarsNotes.Data.Models
{
    public class Fuel
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [Comment("The fuel date indicated by owner")]
        public DateTime Date { get; set; }

        [Required]
        [MaxLength(FuelGasStationMax)]
        [Comment("The name of the Gas Station")]
        public string GasStation { get; set; } = null!;

        [Required]
        [MaxLength(FuelCityMax)]
        [Comment("The name of the City where we fuel")]
        public string City { get; set; } = null!;

        [Range(FuelVolumeMin, FuelVolumeMax)]
        [Comment("The quantity of the fuel")]
        public double Volume { get; set; }

        [MaxLength(FuelGasTypeMax)]
        [Comment("The type of the energy we use")]
        public string? GasType { get; set; }

        [Comment("The price of one liter")]
        public decimal PricePerLiter {  get; set; }

        [Comment("The total price of for the fuel")]
        public decimal PriceTotalFuel { get; set; }

        [Range(FuelKilometrageMin, FuelKilometrageMax)]
        [Comment("The kilometrage of the date of fuel")]
        public int KilometrageActual { get; set; }

        [Comment("The max fuel possible")]
        public bool FullTank { get; set; }

        [MaxLength(FuelDescriptionMax)]
        [Comment("Additional details")]
        public string? Description { get; set; }

        //public decimal ExpencesTotalFuel { get; set; }

        [Required]
        public string OwnerId { get; set; } = null!;
        [ForeignKey(nameof(OwnerId))]
        public CarUser Owner { get; set; } = null!;

        [Required]
        public Guid CarId { get; set; }
        [ForeignKey(nameof(CarId))]
        public Car Car { get; set; } = null!;

        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        [Comment("Soft delete")]
        public bool IsDeleted { get; set; }

    }
}
