// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUiEntity.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The UiEntity interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Entities
{
    using System.ComponentModel;

    using Halfblood.Common;

    using UI.Entities.CommonDomain;

    /// <summary>
    /// The UI entity interface.
    /// </summary>
    public interface IUiEntity : IHasUid<long>, INotifyPropertyChanged
    {
        /// <summary>
        /// Gets or sets the catalog.
        /// </summary>
        Catalog Catalog { get; set; }
    }
}
