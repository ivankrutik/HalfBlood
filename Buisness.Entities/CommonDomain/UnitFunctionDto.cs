// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnitFunctionDto.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the UnitFunctionDto type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Entities.CommonDomain
{
    using Halfblood.Common;

    public class UnitFunctionDto : IDto<long>
    {
        object IHasUid.Rn { get { return Rn; } }
        public string Code { get; set; }
        public string Name { get; set; }
        public long Numb { get; set; }
        public TypeActionInSystem Standard { get; set; }
        public long Rn { get; set; }
        public bool IsAccess { get; set; }
    }
}