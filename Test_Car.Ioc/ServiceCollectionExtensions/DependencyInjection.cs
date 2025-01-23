using Microsoft.Extensions.DependencyInjection;
using Test_Car.BusinessLogic.Services.Base;
using Test_Car.Domain.Models.Car;
using Test_Car.Domain.Repositories.Base;
using Test_Car.Domain.Services.Base;
using Test_Car.Infrastructure.Context;
using Test_Car.Infrastructure.Repositories;
using Test_Car.Infrastructure.Uow;

namespace Test_Car.Ioc.ServiceCollectionExtensions
{
    public static class DependencyInjection
    {
        #region Public Methods

        public static void ConfigureDependencyInjenction(this IServiceCollection services)
        {
           services.AddScoped<IGenericRepository<CarBrand>,GenericRepository<CarBrand>>();
           services.AddScoped<IUnitOfWork, UnitOfWork<MainDbContext>>();
           services.AddScoped<IGenericService<CarBrand, int>, GenericService<CarBrand, int>>();
        }

        #endregion
    }
}
