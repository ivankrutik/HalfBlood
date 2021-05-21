// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NhConnection.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   The hibernate connection.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace NhConnection
{
    using System;

    using global::NhConnection.Infrasctructure;

    using NHibernate;

    /// <summary>
    /// The hibernate connection.
    /// </summary>
    public class NhConnection : INhConnection, IDisposable
    {
        private static ISessionFactory sesionFactory;
        private readonly string _hibernateCfgFile;

        private string _login;
        private string _password;
        private string _database;

        /// <summary>
        /// Initializes a new instance of the <see cref="NhConnection"/> class.
        /// </summary>
        /// <param name="hibernateCfgFile">
        /// The hibernate config file.
        /// </param>
        public NhConnection(string hibernateCfgFile = null)
        {
            _hibernateCfgFile = hibernateCfgFile;
        }

        /// <summary>
        /// The get session factory.
        /// </summary>
        /// <returns>
        /// The <see cref="ISessionFactory"/>.
        /// </returns>
        public ISessionFactory GetSessionFactory()
        {
            return sesionFactory
                   ?? (sesionFactory =
                       string.IsNullOrWhiteSpace(_hibernateCfgFile)
                           ? new NHInitializer(_login, _password, _database).GetConfiguration().BuildSessionFactory()
                           : new NHInitializer(_hibernateCfgFile).GetConfiguration().BuildSessionFactory());
        }

        /// <summary>
        /// The connecting.
        /// </summary>
        /// <param name="login">
        /// The login.
        /// </param>
        /// <param name="password">
        /// The password.
        /// </param>
        /// <param name="database">
        /// The name of database.
        /// </param>
        public void Connecting(string login, string password, string database)
        {
            _login = login;
            _password = password;
            _database = database;

            // init the connect
            this.GetSessionFactory();
        }

        /// <summary>
        /// The connecting.
        /// </summary>
        public void Connecting()
        {
            // init the connect
            this.GetSessionFactory();
        }

        /// <summary>
        /// The dispose.
        /// </summary>
        public void Dispose()
        {
            if (sesionFactory != null)
            {
                sesionFactory.Dispose();
                sesionFactory = null;
            }
        }
    }
}