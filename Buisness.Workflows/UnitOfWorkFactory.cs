// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnitOfWorkFactory.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the UnitOfWorkFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Workflows
{
    using System.ComponentModel.Composition;

    using Halfblood.Common.Log;

    using NhConnection.Infrasctructure;

    using NHibernate;

    using ServiceContracts;

    [Export(typeof(IUnitOfWorkFactory))]
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly INhConnection _connection;

        [ImportingConstructor]
        public UnitOfWorkFactory(INhConnection connection)
        {
            System.Diagnostics.Contracts.Contract.Requires(connection != null, "The connection must be is not null");

            _connection = connection;
        }

        public IUnitOfWork Create()
        {
            ISession session = _connection.GetSessionFactory().OpenSession();
            session.FlushMode = FlushMode.Commit;

            LogManager.Log.Debug("THE SESSION IS CREATED");

            return new UnitOfWork(session);
        }
    }
}