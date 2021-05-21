namespace UnitTestHelpers.CrudHelpers
{
    using NHibernate;

    public interface IInitializerTestData
    {
        void Create(ISession session);
        void Dispose(ISession session);
    }
}