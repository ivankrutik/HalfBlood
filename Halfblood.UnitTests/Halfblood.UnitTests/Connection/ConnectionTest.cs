// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConnectionTest.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The log in test.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.UnitTests.Connection
{
    using NhConnection;
    using NhConnection.Infrasctructure;

    using NHibernate;

    using NUnit.Framework;

    /// <summary>
    /// The connection test.
    /// </summary>
    [TestFixture]
    public class ConnectionTest
    {
        /// <summary>
        /// The connect to db.
        /// </summary>
        [Test]
        public void ConnectToDb()
        {
            INhConnection connection = new NhConnection();
            connection.Connecting("parus", "q", "dupparus");

            using (ISessionFactory sessionFactory = connection.GetSessionFactory())
            using (ISession session = sessionFactory.OpenSession())
            {
                var login = session.CreateSQLQuery("select user from dual")
                                   .UniqueResult<string>();

                Assert.That(login, Is.EqualTo("parus").IgnoreCase);
            }
        }
    }
}