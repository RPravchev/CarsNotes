using CarsNotes.Core.Abstractions;
using CarsNotes.Core.Models;

namespace CarsNotes.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IRepository<Car> Cars { get; private set; }
        public IRepository<Fuel> Fuels { get; private set; }
        public IRepository<Care> Cares { get; private set; }
        public IRepository<CareType> CareTypes { get; private set; }
        public IRepository<Legal> Legals { get; private set; }
        public IRepository<LegalType> LegalTypes { get; private set; }
        public IRepository<Place> Places { get; private set; }

        public UnitOfWork(ApplicationDbContext context, IRepository<Car> carRepository,
                          IRepository<Fuel> fuelRepository, IRepository<Care> careRepository,
                          IRepository<CareType> careTypeRepository, IRepository<Legal> legalRepository,
                          IRepository<LegalType> legalTypeRepository, IRepository<Place> placeRepository)
        {
            _context = context;
            Cars = carRepository;
            Fuels = fuelRepository;
            Cares = careRepository;
            CareTypes = careTypeRepository;
            Legals = legalRepository;
            LegalTypes = legalTypeRepository;
            Places = placeRepository;
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
