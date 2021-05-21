// --------------------------------------------------------------------------------------------------------------------
// <copyright file="INhConnection.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the INhConnection type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace NhConnection.Infrasctructure
{
    using NHibernate;

    /// <summary>
    /// The hibernate connection interface.
    /// </summary>
    public interface INhConnection
    {
        /// <summary>
        /// The get session factory.
        /// </summary>
        /// <returns>
        /// The <see cref="ISessionFactory"/>.
        /// </returns>
        ISessionFactory GetSessionFactory();

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
        void Connecting(string login, string password, string database);

        /// <summary>
        /// The connecting.
        /// </summary>
        void Connecting();
    }
}
