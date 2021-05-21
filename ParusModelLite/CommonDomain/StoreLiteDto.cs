// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StoreLiteDto.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the StoreLiteDto type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ParusModelLite.CommonDomain
{
    using Halfblood.Common;

    /// <summary>
    /// The store lite DTO.
    /// </summary>
    public class StoreLiteDto : IDto<long>
    {
        public virtual long Rn { get; set; }
        public virtual string AZSNUMBER { get; set; }
        public virtual string AZSNAME { get; set; }
        public virtual long STORETYPE { get; set; }
        public virtual string AZSADDRESS { get; set; }
        public virtual bool LOCKSIGN { get; set; }
        public virtual bool CALCTYPE { get; set; }
        public virtual bool DISTRIBUTIONSIGN { get; set; }
        public virtual bool PROCESSSIGN { get; set; }
        public virtual bool VOLCALCTYPE { get; set; }
        public virtual bool WGTCALCTYPE { get; set; }
        public virtual bool JURPERSSIGN { get; set; }
        object IHasUid.Rn { get { return Rn; } }

        public override string ToString()
        {
            return string.Format("{0} ({1}) ", AZSNUMBER, AZSNAME);
        }
    }
}
