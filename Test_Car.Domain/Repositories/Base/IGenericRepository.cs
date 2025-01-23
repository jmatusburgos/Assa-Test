using Test_Car.Domain.Models.Base.Contracts;

namespace Test_Car.Domain.Repositories.Base
{
    /// <summary>
    /// Generic Repository
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IGenericRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : class, IEntity
    {
    }
}
