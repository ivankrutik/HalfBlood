// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommonService.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the CommonService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Workflows.Services
{
    using System.Collections.Generic;

    using Buisness.Components.StoredProcedure.Common;
    using Buisness.Entities;
    using Buisness.Entities.CommonDomain;
    using Buisness.Filters;

    using Halfblood.Common;

    using NHibernate.Helper.Filter;
    using NHibernate.Helper.Repository;
    using NHibernate.Helper.Service;

    using ParusModel.Entities;

    using ParusModelLite.CommonDomain;

    using ServiceContracts.Facades;

    /// <summary>
    /// The common service.
    /// </summary>
    [Register(typeof(ICommonService))]
    public class CommonService : ServiceBase, ICommonService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommonService"/> class.
        /// </summary>
        /// <param name="repositoryFactory">
        /// The repository factory.
        /// </param>
        /// <param name="filterStrategyFactory">
        /// The filter strategy factory.
        /// </param>
        public CommonService(
             IRepositoryFactory repositoryFactory,
             IFilterStrategyFactory filterStrategyFactory)
            : base(repositoryFactory, filterStrategyFactory)
        {
        }

        public IList<UserDto> GetUsers(UserFilter filter)
        {
            return GetEntities<UserFilter, Contractor, UserDto>(filter);
        }

        public IList<PersonalAccountDto> GetPersonalAccountFilter(PersonalAccountFilter filter)
        {
            return GetEntities<PersonalAccountFilter, PersonalAccount, PersonalAccountDto>(filter);
        }

        public IList<TypeOfDocumentDto> GetTypeOfDocumentFilter(TypeOfDocumentFilter filter)
        {
            return GetEntities<TypeOfDocumentFilter, TypeOfDocument, TypeOfDocumentDto>(filter);
        }

        public IList<NameOfCurrencyDto> GetCurrencies()
        {
            return GetEntities<NameOfCurrency, NameOfCurrencyDto>();
        }

        public IList<StoreLiteDto> GetStoreGasStationOilDepotFilter(StoreGasStationOilDepotFilter filter)
        {
            return GetEntities<StoreGasStationOilDepotFilter, StoreGasStationOilDepot, StoreLiteDto>(filter);
        }

        public IList<LinkDto> GetLinkForWorkflow(LinkFilter filter)
        {
            var sp = new GetLinks(filter.Rn, filter.Direction);
            var result = ExecuteStoreProcedure<LinkDto>(sp);

            return result;
        }
    }
}
