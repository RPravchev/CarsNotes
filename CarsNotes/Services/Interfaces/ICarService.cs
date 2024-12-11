using CarsNotes.Models;

namespace CarsNotes.Web.Services.Interfaces
{
    public interface ICarService
    {
        Task<IEnumerable<CarInfoViewModel>> GetCarShortInfosAsync();
    }
}
