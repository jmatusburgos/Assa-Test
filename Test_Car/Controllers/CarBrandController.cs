using Microsoft.AspNetCore.Mvc;
using Test_Car.API.Controllers.Base;
using Test_Car.Domain.Models.Car;
using Test_Car.Domain.Services.Base;

namespace Test_Car.Controllers
{
   
    public class CarBrandController : CrudControllerBase<CarBrand,int>
    {
        public CarBrandController(IGenericService<CarBrand, int> service)
            :base(service) { }
    }
}
