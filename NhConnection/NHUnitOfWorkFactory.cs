namespace NhConnection
{
    using System.Data;

    using NHibernate;

    public class NHUnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly ISessionFactory _sessionSessionFactory;

        public NHUnitOfWorkFactory(ISessionFactory sessionFactory)
        {
            _sessionSessionFactory = sessionFactory;
        }

        public IUnitOfWork Create(IsolationLevel isolationLevel)
        {
            return new NHUnitOfWork(_sessionSessionFactory.OpenSession(), isolationLevel);
        }
        public IUnitOfWork Create()
        {
            return Create(IsolationLevel.ReadCommitted);
        }
    }
}