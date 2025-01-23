using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Test_Car.Domain.Services.Base
{
    /// <summary>
    /// Service Interface
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IService<TEntity, TKey> where TEntity : class
    {
        /// <summary>
        /// Get all Records 
        /// </summary>
        /// <returns></returns>
        IQueryable<TEntity> GetAll();

        /// <summary>
        /// Create Record
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<TEntity> Create(TEntity entity);

        /// <summary>
        /// Delete a Record
        /// </summary>
        /// <param name="entity"></param>
        Task<TEntity> Delete(TKey id);

        /// <summary>
        /// Find a specific record by a identifier key
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        Task<TEntity> Find(params object[] keyValues);

        /// <summary>
        /// Find with a expression
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> expression);

        /// <summary>
        /// Modify Entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task Modify(TKey id, TEntity entity);

    }
}
