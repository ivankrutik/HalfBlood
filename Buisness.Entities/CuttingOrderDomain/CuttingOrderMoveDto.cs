// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CuttingOrderMoveDto.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the CuttingOrderMoveDto type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Entities.CuttingOrderDomain
{
    using System;

    using Buisness.Entities.CommonDomain;

    using Halfblood.Common;

    public class CuttingOrderMoveDto : IDto<long>
    {
        object IHasUid.Rn { get { return Rn; } }
        public DateTime? CreationDate { get; set; }
        public string Note { get; set; }
        public CatalogDto Catalog { get; set; }
        public UserDto RecipientDocument { get; set; }
        public CuttingOrderDto CuttingOrder { get; set; }
        public long Rn { get; set; }
    }
}