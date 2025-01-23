using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Test_Car.Domain.Models.Base.Contracts;
using Test_Car.Domain.Repositories.Base;

namespace Test_Car.Infrastructure.Repositories
{
    public abstract class BaseRepository<TEntity, TContext> : IBaseRepository<TEntity>
        where TEntity : class, IEntity
        where TContext : DbContext
    {
        #region Private Members

        private readonly TContext context;

        #endregion

        #region Constructor
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="context"></param>
        public BaseRepository(TContext context)
        {
            this.context = context;
        }

        #endregion

        /// <inheritdoc cref="IBaseRepository<T>"/>
        public TEntity Add(TEntity entity)
        {
            if (IsModifiableEntity(entity))
                SetDefaultModifiable(entity, EntityState.Added);

            GetDbSet().Add(entity);
            return entity;
        }

        /// <inheritdoc cref="IBaseRepository<T>"/>
        public async Task AddRange(IEnumerable<TEntity> entites)
         => await GetDbSet().AddRangeAsync(entites);

        /// <inheritdoc cref="IBaseRepository<T>"/>
        public async Task<bool> Any(Expression<Func<TEntity, bool>> predicate)
        => await GetDbSet().AsNoTracking().AnyAsync(predicate);

        /// <inheritdoc cref="IBaseRepository<T>"/>
        public void Delete(TEntity entity)
        => HardDelete(entity);

        /// <inheritdoc cref="IBaseRepository<T>"/>
        public void DeleteBy(Expression<Func<TEntity, bool>> predicate)
        {
            var entities = FindBy(predicate);
            DeleteRange(entities.AsEnumerable());
        }

        /// <inheritdoc cref="IBaseRepository<T>"/>
        public void Edit(TEntity entity)
        {
            if (IsModifiableEntity(entity))
                SetDefaultModifiable(entity, EntityState.Modified);

            context.Entry(entity).State = EntityState.Modified;
        }

        /// <inheritdoc cref="IBaseRepository<T>"/>
        public IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        => GetDbSet().Where(predicate);

        /// <inheritdoc cref="IBaseRepository<T>"/>
        public async Task<TEntity> FindByKey(params object[] keyValues)
        => await GetDbSet().FindAsync(keyValues);

        /// <inheritdoc cref="IBaseRepository<T>"/>
        public async Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            TEntity? record = await GetDbSet().AsNoTracking().FirstOrDefaultAsync(predicate);
            return record;
        }

        /// <inheritdoc cref="IBaseRepository<T>"/>
        public IQueryable<TEntity> GetAll()
        => GetDbSet();

        /// <inheritdoc cref="IBaseRepository<T>"/>
        public DbSet<TEntity> GetDbSet()
        => context.Set<TEntity>();

        /// <inheritdoc cref="IBaseRepository<T>"/>
        public void Patch(TEntity entity, IEnumerable<string> properties)
        {
            GetDbSet().Attach(entity);
            var entry = context.Entry(entity);
            foreach (var property in properties)
            {
                entry.Property(property).IsModified = true;
            }

            if (IsModifiableEntity(entity))
                SetDefaultModifiable(entity, EntityState.Modified);
        }

        /// <inheritdoc cref="IBaseRepository<T>"/>
        public async Task Save()
        => await context.SaveChangesAsync();

        

        #region Private Methods

        /// <summary>
        /// Get if the entity implement IModifiableEntity interface
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        private static bool IsModifiableEntity(TEntity entity)
         => entity is IAuditableEntity;

        /// <summary>
        /// Do a Hard Delete , remove the record of the database
        /// </summary>
        /// <param name="entity"></param>
        private void HardDelete(TEntity entity)
        {
            GetDbSet().Attach(entity);
            GetDbSet().Remove(entity);
        }

        /// <summary>
        /// Set Default values for Modifiable Entity
        /// </summary>
        /// <param name="entity"></param>
        private void SetDefaultModifiable(TEntity entity, EntityState state)
        {
            var modifiableEntity = entity as IAuditableEntity;

            if (state == EntityState.Added)
                modifiableEntity.CreatedDate = DateTime.UtcNow;

            if (state == EntityState.Modified)
                modifiableEntity.ModifiedDate = DateTime.UtcNow;
        }

        private void DeleteRange(IEnumerable<TEntity> entities)
        => GetDbSet().RemoveRange(entities);



        #endregion
    }
}
