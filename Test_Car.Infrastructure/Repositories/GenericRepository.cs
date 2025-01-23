using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Car.Domain.Models.Base.Contracts;
using Test_Car.Domain.Repositories.Base;
using Test_Car.Infrastructure.Context;

namespace Test_Car.Infrastructure.Repositories
{
    public sealed class GenericRepository<TEntity> : BaseRepository<TEntity, MainDbContext>, IGenericRepository<TEntity>
         where TEntity : class, IEntity
    {
        public GenericRepository(MainDbContext context) : base(context)
        {
        }
    }
}
