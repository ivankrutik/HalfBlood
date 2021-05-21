// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DepartmentOrderService.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the DepartmentOrderService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Workflows.Services
{
    using System;
    using System.Collections.Generic;

    using Buisness.Filters;

    using Entities.DepartmentOrderDomain;
    using Halfblood.Common;

    using NHibernate.Helper.Filter;
    using NHibernate.Helper.Repository;
    using NHibernate.Helper.Service;

    using ParusModel.Entities.DepartmentOrderDomain;

    using ServiceContracts.Facades;

    [Register(typeof(IDepartmentOrderService))]
    class DepartmentOrderService : ServiceBase, IDepartmentOrderService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DepartmentOrderService"/> class.
        /// </summary>
        /// <param name="repositoryFactory">
        /// The repository factory.
        /// </param>
        /// <param name="filterStrategyFactory">
        /// The filter strategy factory.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// </exception>
        public DepartmentOrderService(
           IRepositoryFactory repositoryFactory,
           IFilterStrategyFactory filterStrategyFactory)
            : base(repositoryFactory, filterStrategyFactory)
        {
        }

        public IList<DepartmentOrderDto> GetDepartmentOrderFilter(DepartmentOrderFilter filter)
        {
            var orders = GetEntities<DepartmentOrderFilter, DepartmentOrderDto>(filter);
            return orders;
        }

        public DepartmentOrderDto GetDepartmentOrder(long id)
        {
            DepartmentOrderDto result = GetEntity<DepartmentOrder, DepartmentOrderDto>(id);
            return result;
        }

        public void UpdateDepartmentOrder(DepartmentOrderDto entity)
        {

            UpdateEntity<DepartmentOrder, DepartmentOrderDto>(entity);
        }

        public DepartmentOrderDto InsertDepartmentOrderDto(DepartmentOrderDto entity)
        {
            return AddEntity<DepartmentOrder, DepartmentOrderDto>(entity);
        }

        public void RemoveDepartmentOrder(long id)
        {
            throw new NotImplementedException();
        }
    }
}
