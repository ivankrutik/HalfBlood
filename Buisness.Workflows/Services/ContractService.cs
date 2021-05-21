// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContractService.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the ContractService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Workflows.Services
{
    using System.Collections.Generic;

    using Buisness.Entities.ContractDomain;
    using Buisness.Filters;

    using Halfblood.Common;

    using NHibernate.Helper.Filter;
    using NHibernate.Helper.Repository;
    using NHibernate.Helper.Service;

    using ParusModel.Entities;

    using ServiceContracts.Facades;

    /// <summary>
    /// The contract service.
    /// </summary>
    [Register(typeof(IContractService))]
    public class ContractService : ServiceBase, IContractService
    {
        public ContractService(
             IRepositoryFactory repositoryFactory,
             IFilterStrategyFactory filterStrategyFactory)
            : base(repositoryFactory, filterStrategyFactory)
        {
        }

        public IList<ContractDto> GetContractsFilter(ContractFilter filter)
        {
            return this.GetEntities<ContractFilter, PersonalAccount, ContractDto>(filter);
        }
    }
}
