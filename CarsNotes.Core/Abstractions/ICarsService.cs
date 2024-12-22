using CarsNotes.Core.DTOs;

namespace CarsNotes.Core.Abstractions
{
    public interface ICarsService
    {
        Task<List<CarInfoDto>> GetCarShortInfosAsync(string userId);
        Task<CarDto> GetCarDetailsAsync(Guid id, string userId);
        Task<CarDto> GetCarForEditAsync(Guid id, string userId);
        Task AddCarAsync(CarDto model, string userId);
        Task EditCarAsync(CarDto model, string userId);
        Task DeleteCarAsync(Guid id, string userId);
    }
}
