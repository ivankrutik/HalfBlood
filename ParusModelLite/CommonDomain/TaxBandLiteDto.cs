// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TaxBand.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the TaxBand type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ParusModelLite.CommonDomain
{
    using Halfblood.Common;

    public class TaxBandLiteDto : IDto<long>
    {
        public virtual long Rn { get; set; }
        public virtual string Code { get; set; }
        public virtual string Name { get; set; }
        object IHasUid.Rn { get { return Rn; } }

        public override string ToString()
        {
            return string.Format("{0} {1}", Name, Code);
        }
    }
}
