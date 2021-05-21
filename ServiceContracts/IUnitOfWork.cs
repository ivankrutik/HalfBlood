// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUnitOfWork.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The CoordinatorOfServices interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


namespace ServiceContracts
{
    using System;

    /// <summary>
    /// The CoordinatorOfServices interface.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// The create.
        /// </summary>
        /// <typeparam name="TService">
        /// The type of service.
        /// </typeparam>
        /// <returns>
        /// The <see cref="TService"/>.
        /// </returns>
        TService Create<TService>();

       

        /// <summary>
        /// The rollback.
        /// </summary>
        void Rollback();

        /// <summary>
        /// The commit
        /// </summary>
        void Commit();
        
    }
}
