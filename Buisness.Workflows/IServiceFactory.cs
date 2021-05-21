// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IServiceFactory.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the IServiceFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Workflows
{
    using NHibernate;

    /// <summary>
    /// The ServiceFactory interface.
    /// </summary>
    public interface IServiceFactory
    {
        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="session">
        /// The session.
        /// </param>
        /// <typeparam name="T">
        /// The type of service.
        /// </typeparam>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        T Create<T>(ISession session);
    }
}