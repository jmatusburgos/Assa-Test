using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Car.Domain.Repositories.Base
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Commit Changes
        /// </summary>
        /// <returns></returns>
        int Commit();

        /// <summary>
        /// Commit Changes Async
        /// </summary>
        /// <returns></returns>
        Task<int> CommitAsync();


    }

    public interface IUnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
    {
        TContext Context { get; }
    }
}
