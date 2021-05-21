// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TaxBandDto.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the TaxBandDto type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Entities.CommonDomain
{
    using System.Collections.Generic;

    using Buisness.Entities.PlanReceiptOrderDomain;

    using Halfblood.Common;

    public class TaxBandDto : IDto<long>
    {
        object IHasUid.Rn { get { return Rn; } }
        public string Code { get; set; }
        public string Name { get; set; }
        public CatalogDto Catalog { get; set; }
        public IList<PlanCertificateDto> PlaneCertificates { get; set; }
        public long Rn { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1}", Name, Code);
        }
    }
}