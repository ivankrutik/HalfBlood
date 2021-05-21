namespace Halfblood.Test.MockObjects
{
    using System.Collections.Generic;

    using Buisness.Entities;
    using Buisness.Entities.CommonDomain;
    using Buisness.Entities.DepartmentOrderDomain;
    using Buisness.Entities.NomenclatorDomain;
    using Buisness.Filters;

    using FizzWare.NBuilder;

    using ServiceContracts.Facades;

    public class FakeDepartmentOrderService : IDepartmentOrderService
    {
        public IList<DepartmentOrderDto> GetDepartmentOrderFilter(DepartmentOrderFilter filter)
        {
            return
                Builder<DepartmentOrderDto>.CreateListOfSize(10)
                    .All()
                    .With(x => x.Catalog, Builder<CatalogDto>.CreateNew().Build())
                    .Build();
        }

        public DepartmentOrderDto GetDepartmentOrder(long id)
        {
            return
                Builder<DepartmentOrderDto>.CreateNew()
                    .With(x => x.Catalog, Builder<CatalogDto>.CreateNew().Build())
                    .Build();
        }

        public void UpdateDepartmentOrder(DepartmentOrderDto entity)
        {
        }

        public DepartmentOrderDto InsertDepartmentOrderDto(DepartmentOrderDto entity)
        {
            entity.Rn = 999;
            entity.Catalog = new CatalogDto(1007318777);
            return entity;
        }

        public void RemoveDepartmentOrder(long id)
        {
        }
    }
}