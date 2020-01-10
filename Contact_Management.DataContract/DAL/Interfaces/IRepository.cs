using System;

namespace Contact_Management.DataContracts.DAL.Interfaces
{
    public interface IRepository : IDisposable
    {

        TEntity Add<TEntity>(TEntity entity) where TEntity : class;
        void Update<TEntity>(TEntity entity) where TEntity : class;
        void Delete<TEntity>(TEntity entity) where TEntity : class;
        IUnitOfWork UnitOfWork { get; }

    }
}
