using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Car.Infrastructure.Context;

namespace Test_Car.Ioc.ServiceCollectionExtensions
{
    public static class DbContext
    {
        #region Public Methods

        public static void AddDbContext(this IServiceCollection services, string connectionString)
            => services.AddDbContext<MainDbContext>(options => options.UseNpgsql(connectionString));

        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var dataContext = scope.ServiceProvider.GetRequiredService<MainDbContext>();
            dataContext.Database.Migrate();
        }

        #endregion
    }
}
