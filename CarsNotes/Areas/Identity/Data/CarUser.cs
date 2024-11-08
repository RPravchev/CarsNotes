using CarsNotes.Constants;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
//using CarsNotes.Data.Models;
using static CarsNotes.Constants.CarUserConstants;

namespace CarsNotes.Areas.Identity.Data
{
    public class CarUser : IdentityUser
    {
        //public virtual ICollection<Car> Cars { get; set; } = new List<Car>();

        [MaxLength(CarUserFirstNameMaxLength)]
        public string FirstName { get; set; } = string.Empty;
        [MaxLength(CarUserLastNameMaxLength)]
        public string LastName { get; set; } = string.Empty;
        
    }
}
