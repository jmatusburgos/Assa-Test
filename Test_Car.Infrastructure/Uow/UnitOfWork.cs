using Microsoft.EntityFrameworkCore;
using Test_Car.Domain.Repositories.Base;

namespace Test_Car.Infrastructure.Uow
{
    /// <summary>
    /// UnitOfwork for context operation
    /// </summary>
    /// <typeparam name="TContext"></typeparam>
    public class UnitOfWork<TContext> : IUnitOfWork<TContext> where TContext : DbContext
    {
        //private IServiceProvider serviceProvider;

        public TContext Context { get; }

        public UnitOfWork(TContext context)
        {
            //this.serviceProvider = serviceProvider;
            Context = context;
        }

        /// <inheritdoc/>
        public int Commit()
        => Context.SaveChanges();

        /// <inheritdoc/>
        public Task<int> CommitAsync()
        => Context.SaveChangesAsync();

        /// <inheritdoc/>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #region Protected Methods

        protected bool _isDisposed;

        protected void CheckDisposed()
        {
            if (_isDisposed) 
                throw new ObjectDisposedException("The UnitOfWork is already disposed and cannot be used anymore.");
        }

        /// <summary>
        /// Dispose object
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                    if (Context != null)
                        Context.Dispose();
            }
            _isDisposed = true;
        }

        #endregion
    }
}
