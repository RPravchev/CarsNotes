using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static CarsNotes.Common.Constants.CarUserConstants;

namespace CarsNotes.Core
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
