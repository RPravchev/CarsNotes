using CarsNotes.Web.Models;

namespace CarsNotes.Services.Interfaces
{
    public interface ICarService
    {
        Task<List<CarInfoViewModel>> GetCarShortInfosAsync(string userId);
        Task<CarViewModel> GetCarDetailsAsync(Guid id, string userId);
        Task<CarViewModel> GetCarForEditAsync(Guid id, string userId);
        Task AddCarAsync(CarViewModel model, string userId);
        Task EditCarAsync(CarViewModel model, string userId);
        Task DeleteCarAsync(Guid id, string userId);
    }
}
