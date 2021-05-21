// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DictionaryMechanicalIndicatorDto.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the DictionaryMechanicalIndicatorDto type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Entities.CertificateQualityDomain
{
    using Halfblood.Common;

    public class DictionaryMechanicalIndicatorDto : IDto<long>
    {
        public virtual CatalogDto Catalog { get; set; }
        public virtual string Code { get; set; }
        public virtual string Name { get; set; }
        public virtual long Rn { get; set; }
        object IHasUid.Rn { get { return Rn; } }
    }
}