// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IGetCatalogAccess.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The GetCatalogAccess interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Infrastructure.ViewModels
{
    using System;
    using System.Collections.Generic;

    using Buisness.Entities.CommonDomain;

    using Halfblood.Common;

    using JetBrains.Annotations;

    /// <summary>
    /// The GetCatalogAccess interface.
    /// </summary>
    public interface IGetCatalogAccess : IAyncRunner<IList<CatalogHierarchical>>
    {
        /// <summary>
        /// The load for entity.
        /// </summary>
        /// <param name="typeOfTheEntity">
        ///     The type of the entity.
        /// </param>
        /// <param name="typeActionInSystem">
        ///     The type action in system.
        /// </param>
        void LoadForEntity([NotNull] Type typeOfTheEntity,  TypeActionInSystem typeActionInSystem);
    }
}
