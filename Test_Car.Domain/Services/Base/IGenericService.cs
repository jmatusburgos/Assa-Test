using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Car.Domain.Models.Base.Contracts;

namespace Test_Car.Domain.Services.Base
{
    public interface IGenericService<TEntity, TKey> : IService<TEntity, TKey>
        where TEntity : class, IEntity
    {
    }
}
