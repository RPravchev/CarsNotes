using NUnit.Framework;
using Moq;
//using CarsNotes.Web.Abstractions;
//using CarsNotes.Web.Services;
//using CarsNotes.Data.Models;
using CarsNotes.Web.Models;
using CarsNotes.Core.Abstractions;
using CarsNotes.Core.Models;
using CarsNotes.Services;
using CarsNotes.Core.DTOs;

namespace CarsNotes.Tests
{
    [TestFixture]
    public class CarServiceTests
    {
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private Mock<IRepository<Car>> _mockCarRepository;
        private CarService _carService;
        private string _userId;

        [SetUp]
        public void SetUp()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockCarRepository = new Mock<IRepository<Car>>();
            _carService = new CarService(_mockUnitOfWork.Object);
            _userId = "user123";
            _mockUnitOfWork.Setup(u => u.Cars).Returns(_mockCarRepository.Object);
        }

        [Test]
        public async Task AddCarAsync_ShouldAddNewCar()
        {
            // Arrange
            var model = new CarDto
            {
                ShortName = "NewCar",
                MainImageUrl = "url.com",
                Brand = "Brand2",
                CarModel = "Model2",
                YearProduction = 2022
            };

            // Act
            await _carService.AddCarAsync(model, _userId);

            // Assert
            _mockCarRepository.Verify(r => r.AddAsync(It.IsAny<Car>()), Times.Once);
            _mockUnitOfWork.Verify(u => u.CompleteAsync(), Times.Once);
        }      
    }
}
