// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FilteringService.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the FilteringService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Workflows.Services
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    using Buisness.Workflows.Mapping;

    using Filtering.Infrastructure;

    using Halfblood.Common;
    using Halfblood.Common.Mappers;

    using NHibernate.Helper.Filter;
    using NHibernate.Helper.Filter.Specification;
    using NHibernate.Helper.Repository;
    using NHibernate.Helper.Service;

    using ServiceContracts.Facades;

    [Register(typeof(IFilteringService))]
    public class FilteringService : ServiceBase, IFilteringService
    {
        protected const int MAX_COUNT_LOADING_ROWS = 500;

        public FilteringService(IRepositoryFactory repositoryFactory, IFilterStrategyFactory filterStrategyFactory)
            : base(repositoryFactory, filterStrategyFactory)
        {
        }

        public IList<IDto> Filtering(Type type, IUserFilter filter)
        {
            Type entityType = BusinessRelation.Instance.TryGetRelation(type) ?? type;
            dynamic repository = RepositoryFactory.InvokeGenericMethod<object>(entityType, "Create");

            var queryOver = repository.Specify();
            var filteredQueryOver = QueryOverExtension.Filtering(queryOver, filter).Take(MAX_COUNT_LOADING_ROWS);

            var entities = (IList)filteredQueryOver.List();

            if (entityType.HasInterface<IDto>())
            {
                return entities.Cast<IDto>().ToList();
            }

            var result = (from object item in entities select (IDto)item.MapTo(type)).ToList();
            return result;
        }
    }
}