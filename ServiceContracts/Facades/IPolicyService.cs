// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPolicyService.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the IPolicyService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ServiceContracts.Facades
{
    using System;
    using System.Collections.Generic;

    using Buisness.Entities;
    using Buisness.Entities.CommonDomain;

    using Halfblood.Common;

    /// <summary>
    /// The PolicyService interface.
    /// </summary>
    public interface IPolicyService
    {
        /// <summary>
        /// The get catalog hierarchical.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <param name="typeActionInSystem">
        /// The type action in system.
        /// </param>
        /// <returns>
        /// The <see cref="CatalogHierarchical"/>.
        /// </returns>
        CatalogHierarchical GetCatalogHierarchical(Type type, TypeActionInSystem typeActionInSystem);

        /// <summary>
        /// The get function.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <param name="typeActionInSystem">
        /// The type action in system.
        /// </param>
        /// <param name="catalog">
        /// The catalog.
        /// </param>
        /// <returns>
        /// The <see cref="IList"/>.
        /// </returns>
        IList<UnitFunctionDto> GetFunction(Type type, TypeActionInSystem typeActionInSystem, CatalogDto catalog = null);
    }
}
