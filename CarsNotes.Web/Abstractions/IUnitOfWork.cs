using CarsNotes.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CarsNotes.Web.Abstractions
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Car> Cars { get; }
        IRepository<Fuel> Fuels { get; }
        IRepository<Care> Cares { get; }
        IRepository<CareType> CareTypes { get; }
        IRepository<Legal> Legals { get; }
        IRepository<LegalType> LegalTypes { get; }
        IRepository<Place> Places { get; }
        Task<int> CompleteAsync();
    }
}
