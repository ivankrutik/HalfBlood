// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FixtureBase.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the FixtureBase type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UnitTestHelpers.CrudHelpers
{
    using log4net;

    using NhConnection;

    using NHibernate;
    using NHibernate.Stat;

    public abstract class FixtureBase
    {
        private static ILog Logger { get; set; }

        static FixtureBase()
        {
            log4net.Config.XmlConfigurator.Configure();
            Logger = log4net.LogManager.GetLogger(typeof(Fixture));
        }

        protected static ISessionFactory SessionFactory { get; private set; }
        protected IStatistics Statistics { get { return SessionFactory.Statistics; } }

        private static void GetSessionFactory()
        {
            SessionFactory = new NHInitializer()
                .GetConfiguration()
                .BuildSessionFactory();
        }

        public static void Connecting()
        {
            // init the connect
            GetSessionFactory();
        }

        protected static ISession CreateSession()
        {
            return SessionFactory.OpenSession();
        }
        protected static IStatelessSession CreateStatelessSession()
        {
            return SessionFactory.OpenStatelessSession();
        }
    }
}