// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ILinkViewModel.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the ILinkViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Infrastructure.ViewModels.Common
{
    using System.Collections.Generic;
    using Halfblood.Common;
    using ParusModelLite.CommonDomain;
    using ReactiveUI;

    /// <summary>
    /// The LinkViewModel interface.
    /// </summary>
    public interface ILinkViewModel : IRoutableViewModel
    {
        /// <summary>
        /// Gets the links dtos.
        /// </summary>
        IList<LinkDto> LinksDtos { get; }

        /// <summary>
        /// Gets or sets the direction.
        /// </summary>
        DirectionFind Direction { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is frozen.
        /// </summary>
        bool IsFrozen { get; set;}

        /// <summary>
        /// The load.
        /// </summary>
        void Load();
    }
}
