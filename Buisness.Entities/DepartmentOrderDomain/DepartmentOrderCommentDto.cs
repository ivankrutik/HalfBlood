// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DepartmentOrderPerformDto.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the DepartmentOrderPerformDto type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



namespace Buisness.Entities.DepartmentOrderDomain
{
    using System;
    using Halfblood.Common;
    using Buisness.Entities.CommonDomain;

    
    public class DepartmentOrderCommentDto : IDto<long>
    {
        object IHasUid.Rn { get { return Rn; } }
        public long Rn { get; set; }
        public CatalogDto Catalog { get; set; }
        public DateTime CreationDate { get; set; }
        public UserDto UserCreator { get; set; }
        public string Comment { get; set; }
        public DepartmentOrderDto DepartmentOrder { get; set; }
    }
}