using CarsNotes.Core.Models;

namespace CarsNotes.Core.Abstractions
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
