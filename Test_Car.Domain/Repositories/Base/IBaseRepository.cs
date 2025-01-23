using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Test_Car.Domain.Models.Base.Contracts;

namespace Test_Car.Domain.Repositories.Base
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        #region Public Methods

        /// <summary>
        /// Add Entity
        /// </summary>
        /// <param name="entity"></param>
        TEntity Add(TEntity entity);

        /// <summary>
        /// Add range of Entity
        /// </summary>
        /// <param name="entites"></param>
        Task AddRange(IEnumerable<TEntity> entites);

        /// <summary>
        ///Get true if exists Any record by expression
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<bool> Any(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Delete Entity
        /// </summary>
        /// <param name="entity"></param>
        void Delete(TEntity entity);

        /// <summary>
        /// Delete entity By Expression
        /// </summary>
        /// <param name="predicate"></param>
        void DeleteBy(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Edit entity record
        /// </summary>
        /// <param name="entity"></param>
        void Edit(TEntity entity);

        /// <summary>
        /// Get IQueriable by predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Get Entity by key 
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        Task<TEntity> FindByKey(params object[] keyValues);
       
        /// <summary>
        /// Get First record by Expression
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// GetAll IQueriable
        /// </summary>
        /// <returns></returns>
        IQueryable<TEntity> GetAll();

        /// <summary>
        /// GetDbSet
        /// </summary>
        /// <returns></returns>
        DbSet<TEntity> GetDbSet();

        /// <summary>
        /// Do a Patch of Entity
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="properties"></param>
        void Patch(TEntity entity, IEnumerable<string> properties);

        /// <summary>
        /// Save repository Context
        /// </summary>
        Task Save();


        #endregion Public Methods
    }
}
