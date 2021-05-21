// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetCatalogAccess.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the GetAccessFilter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.ProcessComponents.FilterViewModels.CommonDomain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Linq;

    using Buisness.Entities.CommonDomain;

    using Halfblood.Common;

    using ServiceContracts;
    using ServiceContracts.Facades;

    using UI.Infrastructure.ViewModels;

    [Export(typeof(IGetCatalogAccess))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class GetCatalogAccess : AsyncRunner<IList<CatalogHierarchical>>, IGetCatalogAccess
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private Type _entityType;
        private TypeActionInSystem _typeActionInSystem;

        [ImportingConstructor]
        public GetCatalogAccess(IUnitOfWorkFactory unitOfWorkFactory)
        {
            this._unitOfWorkFactory = unitOfWorkFactory;
            this.RegisterFunction(this.DoLoad);
        }

        public void LoadForEntity<TEntity>(TypeActionInSystem typeActionInSystem)
        {
            LoadForEntity(typeof(TEntity), typeActionInSystem);
        }
        public void LoadForEntity(Type typeOfTheEntity, TypeActionInSystem typeActionInSystem)
        {
            _entityType = typeOfTheEntity;
            _typeActionInSystem = typeActionInSystem;
            Load();
        }

        protected IList<CatalogHierarchical> DoLoad()
        {
            using (IUnitOfWork unitOfWork = this._unitOfWorkFactory.Create())
            {
                var service = unitOfWork.Create<IPolicyService>();

                var type = ProcessRelation.Instance.TryGetRelation(this._entityType)
                           ?? this._entityType.GetRelationUiEntityToDtoEntityAttribute();
                
                if (type != null)
                {
                    return new List<CatalogHierarchical> { service.GetCatalogHierarchical(type, this._typeActionInSystem) };
                }

                return Enumerable.Empty<CatalogHierarchical>().ToList();
            }
        }
    }
}