// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IContractService.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the IContractService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Buisness.Filters;

namespace ServiceContracts.Facades
{
    using System.Collections.Generic;
    using Buisness.Entities.ContractDomain;

    /// <summary>
    /// The ContractService interface.
    /// </summary>
    public interface IContractService
    {
        /// <summary>
        /// The get contracts filter.
        /// </summary>
        /// <param name="filter">
        /// The filter.
        /// </param>
        /// <returns>
        /// The <see cref="IList"/>.
        /// </returns>
        IList<ContractDto> GetContractsFilter(ContractFilter filter);
    }
}
