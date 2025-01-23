using Test_Car.Domain.Models.Base.Contracts;
using Test_Car.Domain.Repositories.Base;
using Test_Car.Domain.Services.Base;

namespace Test_Car.BusinessLogic.Services.Base
{
    public class GenericService<TEntity, TKey> : ServiceBase<TEntity, TKey>, IGenericService<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {
        public GenericService(IUnitOfWork uow, IGenericRepository<TEntity> repository) : base(uow, repository)
        {
        }
    }
}
