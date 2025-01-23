using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Linq.Expressions;
using Test_Car.BusinessLogic.Services.Base;
using Test_Car.Controllers;
using Test_Car.Domain.Models.Car;
using Test_Car.Domain.Repositories.Base;
using Test_Car.Domain.Services.Base;
using Test_Car.Infrastructure.Context;
using Test_Car.Infrastructure.Uow;

namespace Test_Car.Test
{
    public class ControllerTest : BaseTest
    {
        private readonly CarBrandController _carBrandController;
        private readonly Mock<IGenericRepository<CarBrand>> _repositoryMock;
        private readonly Mock<UnitOfWork<MainDbContext>> _uowMock;
        private readonly Mock<GenericService<CarBrand,int>> _genericServiceMock;


        /// <summary>
        /// Default constructor
        /// </summary>
        public ControllerTest()
        {
            Initialize();
            _uowMock = new Mock<UnitOfWork<MainDbContext>>(_context);
            _repositoryMock = new Mock<IGenericRepository<CarBrand>>();
            _genericServiceMock = new Mock<GenericService<CarBrand, int>>(_uowMock.Object, _repositoryMock.Object);
            _carBrandController = new CarBrandController(_genericServiceMock.Object);
        }
        /// <summary>
        /// Unit test to Get the 3 records of the brands car
        /// </summary>
        [Fact]
        public void GetAll_Ok()
        {
            _repositoryMock.Setup(c => c.GetAll()).Returns(_context.CarBrands.ToList().AsQueryable());
            _genericServiceMock.Setup(s => s.GetAll()).Returns(_repositoryMock.Object.GetAll());

            var result = _carBrandController.Get();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var carBrands = Assert.IsType<List<CarBrand>>(okResult.Value);

            Assert.NotNull(result);
            Assert.NotNull(carBrands);
            Assert.Equal(carBrands?.Count, 3);
        }

        [Fact]
        public async Task GetByIdAnExistingRecordAsync()
        {
            //Id existing on records
            var Id = 2;

            _repositoryMock.Setup(c => c.FindByKey(Id)).Returns(_context.CarBrands.FirstOrDefaultAsync(predicate: x => x.Id == Id));
            _genericServiceMock.Setup(s => s.Find(Id)).Returns(_repositoryMock.Object.FindByKey(Id));

            var result = await _carBrandController.GetAsync(Id);
            var okResult = Assert.IsType<OkObjectResult>(result);
            var carBrand = Assert.IsType<CarBrand>(okResult.Value);

            Assert.NotNull(result);
            Assert.NotNull(carBrand);

        }

        [Fact]
        public async Task GetByIdAnNotExistingRecordAsync()
        {
            //Id not existing on records
            var Id = 4;

            _repositoryMock.Setup(c => c.FindByKey(Id)).Returns(_context.CarBrands.FirstOrDefaultAsync(predicate: x => x.Id == Id));
            _genericServiceMock.Setup(s => s.Find(Id)).Returns(_repositoryMock.Object.FindByKey(Id));

            var result = await _carBrandController.GetAsync(Id);
            var res = Assert.IsType<NotFoundObjectResult>(result);

            Assert.NotNull(result);
            Assert.Equal(res.StatusCode, 404);

        }

        [Fact]
        public async Task CreateRecord()
        {
            //Id not existing on records
            CarBrand car = new CarBrand
            {
                Id = 4,
                Name = "Chevrolet",
                Description = "Chevy",
                CreatedBy = "test",
                CreatedDate = DateTime.UtcNow,
            };

            _repositoryMock.Setup(c => c.Add(It.IsAny<CarBrand>())).Returns(car);
            _genericServiceMock.Setup(s => s.Create(It.IsAny<CarBrand>())).ReturnsAsync(car);

            var result = await _carBrandController.Post(car);
            var res = Assert.IsType<CreatedAtActionResult>(result);

            Assert.Equal(nameof(CarBrandController.Post), res.ActionName); 
            Assert.Equal(201, res?.StatusCode);  // status code must be 201
            Assert.Equal(car, res?.Value);  // The returned value should match with the created entity

        }

        [Fact]
        public async Task DeleteExistingRecord()
        {
            //Id existing on records
            var Id = 3;

            _repositoryMock.Setup(c => c.DeleteBy(It.IsAny<Expression<Func<CarBrand,bool>>>()));
            _genericServiceMock.Setup(s => s.Delete(It.IsAny<int>())).Returns(_context.CarBrands.FirstOrDefaultAsync(x => x.Id == Id));

            var result = await _carBrandController.Delete(Id);
            var okResult = Assert.IsType<OkObjectResult>(result);
            var carBrand = Assert.IsType<CarBrand>(okResult.Value);

            Assert.NotNull(result);
            Assert.NotNull(carBrand);

        }

        [Fact]
        public async Task DeleteNotExistingRecord()
        {
            //Id not existing on records
            var Id = 4;

            _repositoryMock.Setup(c => c.DeleteBy(It.IsAny<Expression<Func<CarBrand, bool>>>()));
            _genericServiceMock.Setup(s => s.Delete(It.IsAny<int>())).Returns(_context.CarBrands.FirstOrDefaultAsync(x => x.Id == Id));

            var result = await _carBrandController.Delete(Id);
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);

            Assert.NotNull(result);
            Assert.Equal(notFoundResult.Value, Id);

        }
    }
}