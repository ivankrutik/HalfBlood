using Buisness.Filters;

namespace ServiceContracts.Facades
{
    using System.Collections.Generic;
    using Buisness.Entities.DepartmentOrderDomain;

    public interface IDepartmentOrderService
   {
       IList<DepartmentOrderDto> GetDepartmentOrderFilter(DepartmentOrderFilter filter);
       DepartmentOrderDto GetDepartmentOrder(long id);
       void UpdateDepartmentOrder(DepartmentOrderDto entity);
       DepartmentOrderDto InsertDepartmentOrderDto(DepartmentOrderDto entity);
       void RemoveDepartmentOrder(long id );
   }
}
