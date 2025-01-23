using Microsoft.EntityFrameworkCore;
using Test_Car.Infrastructure.Context;

namespace Test_Car.Test
{
    public abstract class BaseTest
    {
        protected DbContextOptions<MainDbContext> _dbContextOptions;
        protected MainDbContext _context;
        
        protected BaseTest()
        {
           
        }

        public void Initialize()
        {
            _dbContextOptions = new DbContextOptionsBuilder<MainDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            _context = new MainDbContext(_dbContextOptions);
            _context.Database.EnsureCreated();
           // context.SaveChanges();
        }
    }
}