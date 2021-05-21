// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NHInitializer.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the NHInitializer type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace NhConnection
{
    using global::NhConnection.Infrasctructure;

    using NHibernate.Cfg;

    /// <summary>
    /// The hibernate initializer.
    /// </summary>
    public class NHInitializer : INHibernateInitializer
    {
        #region private fields
        private readonly string _fileNhConfiguration;
        private readonly string _login;
        private readonly string _password;
        private readonly string _database;
        #endregion

        /// <summary>
        /// The hibernate config file.
        /// </summary>
        public const string HIBERNATE_CFG_FILE = "hibernate.cfg.xml";

        /// <summary>
        /// Initializes a new instance of the <see cref="NHInitializer"/> class.
        /// </summary>
        public NHInitializer()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NHInitializer"/> class.
        /// </summary>
        /// <param name="assemblyName">
        /// The assembly name.
        /// </param>
        /// <param name="fileNhConfiguration">
        /// The file nh configuration.
        /// </param>
        public NHInitializer(string fileNhConfiguration)
        {
            _fileNhConfiguration = fileNhConfiguration;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NHInitializer"/> class.
        /// </summary>
        /// <param name="assemblyName">
        /// The assembly name.
        /// </param>
        /// <param name="login">
        /// The login.
        /// </param>
        /// <param name="password">
        /// The password.
        /// </param>
        /// <param name="database">
        /// The database.
        /// </param>
        public NHInitializer(string login, string password, string database, string fileNhConfiguration)
            : this(fileNhConfiguration)
        {
            _login = login;
            _password = password;
            _database = database;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NHInitializer"/> class.
        /// </summary>
        /// <param name="login">
        /// The login.
        /// </param>
        /// <param name="password">
        /// The password.
        /// </param>
        /// <param name="database">
        /// The database.
        /// </param>
        public NHInitializer(string login, string password, string database)
            : this(login, password, database, null)
        {
        }

        /// <summary>
        /// The get configuration.
        /// </summary>
        /// <returns>
        /// The <see cref="Configuration"/>.
        /// </returns>
        public virtual Configuration GetConfiguration()
        {
            Configuration config =
                new Configuration().Configure(_fileNhConfiguration ?? HIBERNATE_CFG_FILE);

            if (!string.IsNullOrEmpty(_login) && !string.IsNullOrEmpty(_database))
            {
                SetLogin(config, _login, _password, _database);
            }

            return config;
        }

        private static void SetLogin(Configuration cfg, string login, string password, string database)
        {
            cfg.SetProperty(
                "connection.connection_string",
                string.Format(
                    "Data Source={0};User ID={1};Password={2};Validate Connection=true",
                    database,
                    login,
                    password));
        }
    }
}