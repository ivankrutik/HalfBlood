// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUnitOfWorkFactory.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The CoordinatorFactory interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ServiceContracts
{
    /// <summary>
    /// The CoordinatorFactory interface.
    /// </summary>
    public interface IUnitOfWorkFactory
    {
        /// <summary>
        /// The new.
        /// </summary>
        /// <returns>
        /// The <see cref="IUnitOfWork"/>.
        /// </returns>
        IUnitOfWork Create();
    }
}
