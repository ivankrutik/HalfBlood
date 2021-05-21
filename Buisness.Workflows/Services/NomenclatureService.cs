// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NomenclatureService.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The nomenclature service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Workflows.Services
{
    using System;
    using System.Collections.Generic;

    using Buisness.Entities.NomenclatorDomain;
    using Buisness.Filters;

    using Halfblood.Common;

    using NHibernate.Helper.Filter;
    using NHibernate.Helper.Filter.Specification;
    using NHibernate.Helper.Repository;
    using NHibernate.Helper.Service;

    using ParusModel.Entities.NomenclatorDomain;

    using ServiceContracts.Facades;

    /// <summary>
    /// The nomenclature service.
    /// </summary>
    [Register(typeof(INomenclatureService))]
    public class NomenclatureService : ServiceBase, INomenclatureService
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="NomenclatureService"/> class.
        /// </summary>
        /// <param name="repositoryFactory">
        /// The repository factory.
        /// </param>
        /// <param name="filterStrategyFactory">
        /// The filter strategy factory.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// The repository or the strategy of filter is null
        /// </exception>
        public NomenclatureService(
         IRepositoryFactory repositoryFactory,
         IFilterStrategyFactory filterStrategyFactory)
            : base(repositoryFactory, filterStrategyFactory)
        {
        }

        public virtual IList<NomenclatureNumberDto> GetNomenclatureNumber(NomenclatureNumberFilter filter)
        {
            return this.GetEntities<NomenclatureNumberFilter, NomenclatureNumber, NomenclatureNumberDto>(
                filter,
                query => query.FetchEager(x => x.DicmuntUmeasStorage));
        }

        public IList<NomenclatureNumberModificationDto> GetNomenclatureNumberModification(NomenclatureNumberModificationFilter filter)
        {
            return this.GetEntities<NomenclatureNumberModificationFilter, NomenclatureNumberModification, NomenclatureNumberModificationDto>(filter);
        }
    }
}
