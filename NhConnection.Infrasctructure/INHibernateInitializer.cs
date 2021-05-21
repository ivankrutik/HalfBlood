// --------------------------------------------------------------------------------------------------------------------
// <copyright file="INHibernateInitializer.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The NHibernateInitializer interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace NhConnection.Infrasctructure
{
    using NHibernate.Cfg;

    /// <summary>
    /// The NHibernateInitializer interface.
    /// </summary>
    public interface INHibernateInitializer
    {
        /// <summary>
        /// The get configuration.
        /// </summary>
        /// <returns>
        /// The <see cref="Configuration"/>.
        /// </returns>
        Configuration GetConfiguration();
    }
}
