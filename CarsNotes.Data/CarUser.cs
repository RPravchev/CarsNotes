using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

//using CarsNotes.Data.Models;
using static CarsNotes.Common.Constants.CarUserConstants;

namespace CarsNotes.Web.Areas.Identity.Data
{
    public class CarUser : IdentityUser
    {
        [PersonalData]
        [MaxLength(CarUserFirstNameMaxLength)]
        public string? FirstName { get; set; }
        [PersonalData]
        [MaxLength(CarUserLastNameMaxLength)]
        public string? LastName { get; set; } 
        
        public bool IsDeleted { get; set; }
    }
}
