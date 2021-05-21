// --------------------------------------------------------------------------------------------------------------------
// <copyright file="INomenclatureService.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the INomenclatureService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Buisness.Filters;

namespace ServiceContracts.Facades
{
    using System.Collections.Generic;
    using Buisness.Entities.NomenclatorDomain;

    /// <summary>
    /// The NomenclatorService interface.
    /// </summary>
    public interface INomenclatureService
    {
        /// <summary>
        /// The get nomenclature number.
        /// </summary>
        /// <param name="filter">
        /// The filter.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        IList<NomenclatureNumberDto> GetNomenclatureNumber(NomenclatureNumberFilter filter);

        IList<NomenclatureNumberModificationDto> GetNomenclatureNumberModification(NomenclatureNumberModificationFilter filter);
    }
}
