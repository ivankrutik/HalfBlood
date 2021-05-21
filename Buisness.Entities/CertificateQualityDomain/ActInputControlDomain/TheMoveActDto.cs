// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TheMoveActDto.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the TheMoveActDto type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Entities.CertificateQualityDomain.ActInputControlDomain
{
    using System;

    using Buisness.Entities.CommonDomain;

    using Halfblood.Common;

    public class TheMoveActDto : IDto<long>
    {
        object IHasUid.Rn { get { return Rn; } }
        public virtual DateTime? CreationDate { get; set; }
        public virtual UserDto UserCreator { get; set; }
        public virtual UserDto UserReciver { get; set; }
        public virtual ActInputControlDto ActInputControl { get; set; }
        public virtual StaffingDivisionDto DepartmentCreator { get; set; }
        public virtual StaffingDivisionDto DepartmentReciver { get; set; }
        public virtual long Rn { get; set; }
    }
}