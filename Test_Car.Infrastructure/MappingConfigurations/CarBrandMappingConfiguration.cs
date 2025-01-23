using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Car.Domain.Models.Car;
using Test_Car.Infrastructure.Contracts.Base.MappingConfiguration;
using Test_Car.Infrastructure.ModelBuilderExtensions;

namespace Test_Car.Infrastructure.MappingConfigurations
{
    /// <summary>
    /// Model Mapping configuration for CarBrand Entity
    /// </summary>
    public class CarBrandMappingConfiguration : IEntityMappingConfiguration<CarBrand>
    {
        public CarBrandMappingConfiguration() { }
        public void Configure(EntityTypeBuilder<CarBrand> builder)
        {
            builder.ToTable("MarcasAutos").HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.SeedData();
        }
    }
}
