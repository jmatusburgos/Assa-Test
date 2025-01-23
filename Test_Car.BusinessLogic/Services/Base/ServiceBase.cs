using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Test_Car.Domain.Models.Base.Contracts;
using Test_Car.Domain.Repositories.Base;
using Test_Car.Domain.Services.Base;

namespace Test_Car.BusinessLogic.Services.Base
{
    /// <summary>
    /// Abstract class for service
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class ServiceBase<TEntity, TKey> : IService<TEntity, TKey>
        where TEntity : class, IEntity<TKey>, IEntity
    {
        #region Private Members

        private readonly IBaseRepository<TEntity> _repository;
        private readonly IUnitOfWork _uow;

        #endregion

        #region Public Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="repository"></param>
        public ServiceBase(IUnitOfWork uow, IBaseRepository<TEntity> repository)
        {
            _uow = uow;
            _repository = repository;

        }


        #endregion

        #region Public Methods

        /// <inheritdoc/>
        public virtual IQueryable<TEntity> GetAll() => _repository.GetAll();

        /// <inheritdoc/>
        public virtual async Task<TEntity> Create(TEntity entity)
        {

            SetAuditable(entity, EntityState.Added);
            var record = _repository.Add(entity);

            await _uow.CommitAsync();

            return record;
        }

        /// <inheritdoc/>
        public virtual async Task<TEntity> Delete(TKey id)
        {
            var entity = await _repository.FindByKey(id);
            if (entity == null)
                throw new Exception("Entity to delete not Found");

            _repository.Delete(entity);
            await _uow.CommitAsync();

            return entity;
        }

        /// <inheritdoc/>
        public virtual async Task<TEntity> Find(params object[] keyValues)
        {
            var record = await _repository.FindByKey(keyValues);
            return record;
        }

        /// <inheritdoc/>
        public virtual async Task Modify(TKey id, TEntity entity)
        {
            if (!await ValidateEntityOnUpdate(id, entity))
                return;

            SetAuditable(entity, EntityState.Modified);
            _repository.Edit(entity);
            await _uow.CommitAsync();
        }

        /// <inheritdoc/>
        public IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> expression)
        => _repository.FindBy(expression);

        /// <summary>
        /// Set Modifiable on update method
        /// </summary>
        /// <param name="entity"></param>
        public virtual void SetModifiableUpdate(TEntity entity)
            => SetAuditable(entity, EntityState.Modified);

        /// <summary>
        /// Set Modifiable on create method
        /// </summary>
        /// <param name="entity"></param>
        public virtual void SetModifiableCreate(TEntity entity)
            => SetAuditable(entity, EntityState.Added);

        /// <summary>
        /// Validate entity on Update
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task<bool> ValidateEntityOnUpdateAsync(TKey id, TEntity entity)
            => await ValidateEntityOnUpdate(id, entity);

        #endregion

        #region Private Methods

        /// <summary>
        /// Validate if entity IsModifiable type
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        private static bool IsAuditable(TEntity entity)
          => entity is IAuditableEntity;

        /// <summary>
        /// Set Default Tenant
        /// </summary>
        /// <param name="entity"></param>
        private void SetAuditable(TEntity entity, EntityState state)
        {
            if (!IsAuditable(entity))
                return;

            var record = entity as IAuditableEntity;

            if (state == EntityState.Added)
                record.CreatedBy = "Guest";

            if (state == EntityState.Modified)
                record.ModifiedBy = "Guest";
        }

        /// <summary>
        /// Validate Entity on Update
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        private async Task<bool> ValidateEntityOnUpdate(TKey id, TEntity entity)
        {
            var entityId = (entity as IEntity<TKey>).Id;

            if (!Equals(entityId, id))
                throw new Exception("Id on record not equal to param");

            Expression<Func<TEntity, bool>> expression = x => x.Id.Equals(id);

            var record = await _repository.Any(expression);
            if (!record)
                throw new Exception("Entity to Update not Found");

            return true;
        }

        #endregion
    }
}
