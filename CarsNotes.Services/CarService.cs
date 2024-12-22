using Microsoft.EntityFrameworkCore;
using CarsNotes.Core.Abstractions;
using CarsNotes.Core.DTOs;
using CarsNotes.Core.Models;


namespace CarsNotes.Services
{
    public class CarService(IUnitOfWork repo) : ICarsService
    {

        public async Task<List<CarInfoDto>> GetCarShortInfosAsync(string userId)
        {
            return await repo.Cars.Query()
                .AsNoTracking()
                .Where(g => !g.IsDeleted && g.OwnerId == userId)
                .Select(g => new CarInfoDto
                { 
                    Id = g.Id,
                    MainImageUrl = g.MainImageUrl,
                    ShortName = g.ShortName,
                    Brand = g.Brand ?? string.Empty,
                    CarModel = g.CarModel ?? string.Empty,
                    Year = g.YearProduction
                })                
                .ToListAsync();
        }

        public async Task<CarDto> GetCarDetailsAsync(Guid id, string userId)
        {
            var car = await repo.Cars.Query()
                .FirstOrDefaultAsync(c => c.OwnerId == userId && c.Id == id);

            if (car == null) return null;

            return new CarDto
            {
                Id = id,
                ShortName = car.ShortName,
                MainImageUrl = car.MainImageUrl,
                Brand = car.Brand,
                CarModel = car.CarModel,
                RegistrationNumber = car.RegistrationNumber,
                FuelType = car.FuelType,
                BodyType = car.BodyType,
                TransmissionType = car.TransmissionType,
                DoorsNumber = car.DoorsNumber,
                Color = car.Color,
                HorsePower = car.HorsePower,
                CubicCapacity = car.CubicCapacity,
                ChassisNumber = car.ChassisNumber,
                EngineNumber = car.EngineNumber,
                TransmissionNumber = car.TransmissionNumber,
                YearProduction = car.YearProduction,
                YearAcquisition = car.YearAcquisition,
                OriginalColorCode = car.OriginalColorCode,
                VINCode = car.VINCode,
                CountryProduction = car.CountryProduction,
                KilometrageAcquisition = car.KilometrageAcquisition,
                KilometrageActual = car.KilometrageActual,
                AdditionalDetails = car.AdditionalDetails,
                IsDeleted = car.IsDeleted,
                OwnerId = userId
            };
        }

        public async Task<CarDto> GetCarForEditAsync(Guid id, string userId)
        {
            var model = await repo.Cars.Query()
                .AsNoTracking()
                .Where(c => c.Id == id && c.OwnerId == userId && !c.IsDeleted)
                .Select(c => new CarDto
                {
                    Id = id,
                    ShortName = c.ShortName,
                    MainImageUrl = c.MainImageUrl,
                    Brand = c.Brand ?? string.Empty,
                    CarModel = c.CarModel ?? string.Empty,
                    RegistrationNumber = c.RegistrationNumber,
                    FuelType = c.FuelType,
                    BodyType = c.BodyType,
                    TransmissionType = c.TransmissionType,
                    DoorsNumber = c.DoorsNumber,
                    Color = c.Color,
                    HorsePower = c.HorsePower,
                    CubicCapacity = c.CubicCapacity,
                    ChassisNumber = c.ChassisNumber,
                    EngineNumber = c.EngineNumber,
                    TransmissionNumber = c.TransmissionNumber,
                    YearProduction = c.YearProduction,
                    YearAcquisition = c.YearAcquisition,
                    OriginalColorCode = c.OriginalColorCode,
                    VINCode = c.VINCode,
                    CountryProduction = c.CountryProduction,
                    KilometrageAcquisition = c.KilometrageAcquisition,
                    KilometrageActual = c.KilometrageActual,
                    AdditionalDetails = c.AdditionalDetails
                })
                .FirstOrDefaultAsync();

            return model;
        }

        public async Task AddCarAsync(CarDto model, string userId)
        {
            Car car = new Car
            {
                ShortName = model.ShortName,
                MainImageUrl = model.MainImageUrl,
                Brand = model.Brand,
                CarModel = model.CarModel,
                RegistrationNumber = model.RegistrationNumber,
                FuelType = model.FuelType,
                BodyType = model.BodyType,
                TransmissionType = model.TransmissionType,
                DoorsNumber = model.DoorsNumber,
                Color = model.Color,
                HorsePower = model.HorsePower,
                CubicCapacity = model.CubicCapacity,
                ChassisNumber = model.ChassisNumber,
                EngineNumber = model.EngineNumber,
                TransmissionNumber = model.TransmissionNumber,
                YearProduction = model.YearProduction ?? 0,
                YearAcquisition = model.YearAcquisition ?? 0,
                OriginalColorCode = model.OriginalColorCode,
                VINCode = model.VINCode,
                CountryProduction = model.CountryProduction,
                KilometrageAcquisition = model.KilometrageAcquisition,
                KilometrageActual = model.KilometrageActual,
                AdditionalDetails = model.AdditionalDetails,
                IsDeleted = model.IsDeleted,
                OwnerId = userId,
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now
            };
            await repo.Cars.AddAsync(car);
            await repo.CompleteAsync();
        }

        public async Task EditCarAsync(CarDto model, string userId)
        {
            var car = await repo.Cars.Query()
                .FirstOrDefaultAsync(c => c.OwnerId == userId && c.Id == model.Id);

            if (car == null) throw new Exception("Car not found.");

            car.ShortName = model.ShortName;
            car.MainImageUrl = model.MainImageUrl;
            car.Brand = model.Brand;
            car.CarModel = model.CarModel;
            car.RegistrationNumber = model.RegistrationNumber;
            car.FuelType = model.FuelType;
            car.BodyType = model.BodyType;
            car.TransmissionType = model.TransmissionType;
            car.DoorsNumber = model.DoorsNumber;
            car.Color = model.Color;
            car.HorsePower = model.HorsePower;
            car.CubicCapacity = model.CubicCapacity;
            car.ChassisNumber = model.ChassisNumber;
            car.EngineNumber = model.EngineNumber;
            car.TransmissionNumber = model.TransmissionNumber;
            car.YearProduction = model.YearProduction ?? 0;
            car.YearAcquisition = model.YearAcquisition ?? 0;
            car.OriginalColorCode = model.OriginalColorCode;
            car.VINCode = model.VINCode;
            car.CountryProduction = model.CountryProduction;
            car.KilometrageAcquisition = model.KilometrageAcquisition;
            car.KilometrageActual = model.KilometrageActual;
            car.AdditionalDetails = model.AdditionalDetails;
            car.ModifiedOn = DateTime.Now;

            await repo.CompleteAsync();
        }
        public async Task DeleteCarAsync(Guid id, string userId)
        {
            var car = await repo.Cars.Query()
                .FirstOrDefaultAsync(c => c.OwnerId == userId && c.Id == id);

            if (car == null) throw new Exception("Car not found.");

            car.IsDeleted = true;
            car.ModifiedOn = DateTime.Now;

            await repo.CompleteAsync();
        }
    }
}
