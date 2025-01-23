using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Car.Domain.Models.Car;

namespace Test_Car.Infrastructure.ModelBuilderExtensions
{
    internal static class CarBrandSeeder
    {
        public static void SeedData(this EntityTypeBuilder<CarBrand> carBrandBuilder)
        {
            DateTime currentTime = new DateTime(2025, 1, 21, 23, 35, 51, 508, DateTimeKind.Utc).AddTicks(5811);
            carBrandBuilder.HasData(
                new CarBrand { Id = 1, Name = "Toyota", Description = "Toyota Motor Corporation", CreatedBy = "system", CreatedDate = currentTime },
                new CarBrand { Id = 2, Name = "Nissan", Description = "Nissan Motor Corporation", CreatedBy = "system", CreatedDate = currentTime },
                new CarBrand { Id = 3, Name = "BMW", Description = "Bayerische Motoren Werke GmbH", CreatedBy = "system", CreatedDate = currentTime }
             );
        }
            
    }
}
