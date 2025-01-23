using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Car.Domain.Models.Car;
using Test_Car.Infrastructure.Contracts;
using Test_Car.Infrastructure.Contracts.Base.MappingConfiguration;

namespace Test_Car.Infrastructure.Context
{
    /// <summary>
    /// Main DbContext for domain entities
    /// </summary>
    public class MainDbContext : DbContext, IDbContext
    {
        #region Public Constructors
        public MainDbContext(DbContextOptions<MainDbContext> options)
            :base(options) { }
        

        #endregion

        #region Public Members DbSet

        /// <summary>
        /// CarBrand DbSet (MarcasAutos)
        /// </summary>
        public DbSet<CarBrand> CarBrands { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IEntityMappingConfiguration<>).Assembly);
        }

    }
}
