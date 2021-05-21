// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICommonService.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the ICommonService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Buisness.Filters;
 

namespace ServiceContracts.Facades
{
    using System;
    using System.Collections.Generic;

    using Buisness.Entities;
    using Buisness.Entities.CommonDomain;
    using Halfblood.Common;

    using ParusModelLite.CommonDomain;

    /// <summary>
    /// The CommonService interface.
    /// </summary>
    public interface ICommonService
    {
        /// <summary>
        /// The get users.
        /// </summary>
        /// <param name="filter">
        /// The filter.
        /// </param>
        /// <returns>
        /// The <see cref="IList"/>.
        /// </returns>
        IList<UserDto> GetUsers(UserFilter filter);

        /// <summary>
        /// The get personal account filter.
        /// </summary>
        /// <param name="filter">
        /// The filter.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        IList<PersonalAccountDto> GetPersonalAccountFilter(PersonalAccountFilter filter);

        /// <summary>
        /// The get type of document filter.
        /// </summary>
        /// <param name="filter">
        /// The filter.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        IList<TypeOfDocumentDto> GetTypeOfDocumentFilter(TypeOfDocumentFilter filter);

   
        /// <summary>
        /// The get store gas station oil depot filter.
        /// </summary>
        /// <param name="filter">
        /// The filter.
        /// </param>
        /// <returns>
        /// The <see cref="IList"/>.
        /// </returns>
        IList<StoreLiteDto> GetStoreGasStationOilDepotFilter(StoreGasStationOilDepotFilter filter);

        /// <summary>
        /// The get currencies.
        /// </summary>
        /// <returns>
        /// The <see cref="IList"/>.
        /// </returns>
        IList<NameOfCurrencyDto> GetCurrencies();


        IList<LinkDto> GetLinkForWorkflow(LinkFilter filter);
    }
}
