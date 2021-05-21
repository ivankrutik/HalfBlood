// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IHasAccessCatalog.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the IHasAccessCatalog type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Infrastructure
{
    using UI.Infrastructure.ViewModels;

    /// <summary>
    /// The has access catalog interface.
    /// </summary>
    public interface IHasAccessCatalog
    {
        /// <summary>
        /// Gets the get catalog access.
        /// </summary>
        IGetCatalogAccess GetCatalogAccess { get; }
    }
}
