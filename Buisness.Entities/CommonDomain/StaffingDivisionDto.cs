// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StaffingDivisionDto.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The staffing division dto.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Entities.CommonDomain
{
    using Halfblood.Common;

    /// <summary>
    ///     The staffing division dto.
    /// </summary>
    public class StaffingDivisionDto : IDto<long>
    {
        object IHasUid.Rn { get { return Rn; } }
        public string Code { get; set; }
        public string Name { get; set; }
        public long Rn { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}