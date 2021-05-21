// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUnitOfWork.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The UnitOfWork interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace NhConnection
{
    using System;

    using NHibernate;

    /// <summary>
    /// The UnitOfWork interface.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Gets the session.
        /// </summary>
        ISession Session { get; }

        /// <summary>
        /// The commit.
        /// </summary>
        void Commit();

        /// <summary>
        /// The rollback.
        /// </summary>
        void Rollback();
    }
}
