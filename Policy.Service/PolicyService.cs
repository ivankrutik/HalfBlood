// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PolicyService.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The policy service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.InternalService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Buisness.Entities;
    using Buisness.Entities.CommonDomain;
    using Buisness.InternalEntity.Filters;
    using Buisness.InternalService.Helpers;

    using Halfblood.Common;
    using Halfblood.Common.Log;
    using Halfblood.Common.Mappers;

    using JetBrains.Annotations;

    using NHibernate.Helper.Filter;
    using NHibernate.Helper.Repository;
    using NHibernate.Helper.Service;

    using ParusModel.Policy;

    using ServiceContracts.Exceptions;
    using ServiceContracts.Facades;

    /// <summary>
    /// The policy service.
    /// </summary>
    [Register(typeof(IPolicyService))]
    public class PolicyService : ServiceBase, IPolicyService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PolicyService"/> class.
        /// </summary>
        /// <param name="repositoryFactory">
        /// The repository factory.
        /// </param>
        /// <param name="filterStrategyFactory">
        /// The filter strategy factory.
        /// </param>
        public PolicyService(IRepositoryFactory repositoryFactory, IFilterStrategyFactory filterStrategyFactory)
            : base(repositoryFactory, filterStrategyFactory)
        {
        }

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
        public CatalogHierarchical GetCatalogHierarchical([NotNull] Type type, TypeActionInSystem typeActionInSystem)
        {
            var filter = new AcatalogFilter
                             {
                                 SectionOfSystem =
                                     new SectionOfSystemFilter { UnitCode = GetSectionOfSystem(type) }
                             };

            IList<CatalogHierarchical> catalogfull =
                GetEntities<AcatalogFilter, Acatalog>(filter).ConvertToHierarchical();

            if (catalogfull == null || !catalogfull.Any())
            {
                throw new CatalogNotExistException(GetSectionOfSystem(type));
            }

            var access = GetCatalogs(type, typeActionInSystem).SetIsAccess(catalogfull);
            return access[0];
        }

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
        public IList<UnitFunctionDto> GetFunction(Type type, TypeActionInSystem typeActionInSystem, CatalogDto catalog = null)
        {
            var functions = GetFunctions(type, typeActionInSystem, catalog);
            return functions.MapTo<UnitFunctionDto>();
        }

        private IList<Acatalog> GetCatalogs(Type type, TypeActionInSystem typeActionInSystem, CatalogDto catalog = null)
        {
            var filter = new AcatalogFilter
            {
                UserPrivilege = new UserPrivilegeFilter
                {
                    Role = new RoleFilter
                    {
                        UserRoles = new UserRoleFilter()
                    },
                    UnitFunction = new UnitFunctionFilter
                    {
                        Standard = typeActionInSystem,
                        SectionOfSystemUnitcode = new SectionOfSystemFilter
                        {
                            UnitCode = GetSectionOfSystem(type)
                        }
                    }
                }
            };
            if (catalog != null)
            {
                filter.Rn = catalog.Rn;
            }

            return GetEntities<AcatalogFilter, Acatalog>(filter);
        }
        private IList<UnitFunction> GetFunctions(Type type, TypeActionInSystem typeActionInSystem, CatalogDto catalog = null)
        {
            var filter = new UnitFunctionFilter
            {
                UserPrivilegeFilter = new UserPrivilegeFilter { RnAccessCatalog = catalog != null ? catalog.Rn : 0 },
                Standard = typeActionInSystem,
                SectionOfSystemUnitcode =
                    new SectionOfSystemFilter { UnitCode = GetSectionOfSystem(type) }
            };

            return GetEntities<UnitFunctionFilter, UnitFunction>(filter);
        }
        private string GetSectionOfSystem(Type type)
        {
            var dd = type.GetCustomAttributes(typeof(RelationEntityToDtoAttribute), false);
            if (!dd.Any())
            {
                Halfblood.Common.Log.LogManager.Log.Debug(
                    string.Format("For {0} don't setted attribute {1}", type, typeof(RelationEntityToDtoAttribute)));

                return string.Empty;
            }

            return ((RelationEntityToDtoAttribute)dd[0]).TypeOfDto;
        }
    }
}
