﻿using CarsNotes.Data.Models;
using CarsNotes.Web.Models;

namespace CarsNotes.Web.Abstractions
{
    public interface ICarsService
    {
        Task<List<CarInfoViewModel>> GetCarShortInfosAsync(string userId);
        Task<CarViewModel> GetCarDetailsAsync(Guid id, string userId);
        Task<CarViewModel> GetCarForEditAsync(Guid id, string userId);
        Task AddCarAsync(CarViewModel model, string userId);
        Task EditCarAsync(CarViewModel model, string userId);
        Task DeleteCarAsync(Guid id, string userId);
    }
}
