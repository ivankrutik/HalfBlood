// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IConnection.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The Connection interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.Common.Connection
{
    /// <summary>
    /// The Connection interface.
    /// </summary>
    public interface IConnection
    {
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
        /// The database.
        /// </param>
        void Connecting(string login, string password, string database);
    }

    public interface IHasAuthentificationMetadata
    {
        AuthorizationMetadata AuthorizationMetadata { get; }
    }
}
