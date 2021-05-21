// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnitOfWork.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the UnitOfWork type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Workflows
{
    using System.Data;

    using Halfblood.Common.Log;

    using NHibernate;

    using ServiceContracts;

    using Contract = System.Diagnostics.Contracts.Contract;

    public class UnitOfWork : IUnitOfWork
    {
        private readonly ISession _session;
        private ITransaction _transaction;
        private static readonly IServiceFactory ServiceFactory = new ServiceFactory();

        public UnitOfWork(ISession session)
        {
            Contract.Requires(session != null, "The session must be is not null");

            //_serviceFactory = ServiceLocator.Container.GetExportedValue<IServiceFactory>();
            _session = session;
            _transaction = session.BeginTransaction(IsolationLevel.ReadCommitted);
#if !RELEASE
            LogManager.Log.Debug("START TRANSACTION");
#endif
        }

        public TService Create<TService>()
        {
            return ServiceFactory.Create<TService>(_session);
        }
        public void Commit()
        {
            if (!_transaction.WasCommitted && !_transaction.WasRolledBack)
            {
                _transaction.Commit();
#if !RELEASE
                LogManager.Log.Debug("TRANSACTION IS COMMIT");
#endif
            }
        }
        public void Rollback()
        {
            if (!_transaction.WasCommitted && !_transaction.WasRolledBack)
            {
                _transaction.Rollback();
#if !RELEASE
                LogManager.Log.Debug("TRANSACTION IS ROLLBACK");
#endif
            }
        }
        public void Dispose()
        {
            if (_transaction != null)
            {
                Rollback();
                _transaction.Dispose();
                _transaction = null;
#if !RELEASE
                LogManager.Log.Debug("TRANSACTION IS DISPOSE");
#endif
            }

            _session.Dispose();
#if !RELEASE
            LogManager.Log.Debug("THE SESSION IS DISPOSE");
#endif
        }
    }
}
