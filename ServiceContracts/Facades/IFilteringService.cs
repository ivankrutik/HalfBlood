// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFilteringService.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the IFilteringService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Filtering.Infrastructure;

namespace ServiceContracts.Facades
{
    using Halfblood.Common;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The FilterService interface.
    /// </summary>
    public interface IFilteringService
    {
        /// <summary>
        /// The filtering.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <param name="filter">
        /// The filter.
        /// </param>
        /// <returns>
        /// The <see cref="IList"/>.
        /// </returns>
        IList<IDto> Filtering(Type type, IUserFilter filter);
    }
}