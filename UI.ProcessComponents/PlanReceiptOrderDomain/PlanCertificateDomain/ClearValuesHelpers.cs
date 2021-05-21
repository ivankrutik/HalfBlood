// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ClearValuesHelpers.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the ClearValuesHelpers type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Halfblood.Common;

namespace UI.ProcessComponents.PlanReceiptOrderDomain.PlanCertificateDomain
{
    using System.Reactive.Linq;

    using Buisness.Entities.CertificateQualityDomain.ManufacturersCertificateDomain;
    using Buisness.Entities.PlanReceiptOrderDomain;

    using Halfblood.Common.Mappers;

    using JetBrains.Annotations;

    using UI.Entities.PlanReceiptOrderDomain;

    internal static class ClearValuesHelpers
    {
        [NotNull]
        public static PlanCertificate ClearValues([NotNull] this PlanCertificate obj)
        {
            var ob = obj.MapTo<PlanCertificateDto>();
            ob.Rn = 0;
            ob.CertificateQuality = ob.CertificateQuality.ClearValues();
            ob.PersonalAccounts = null;
            ob.State=PlanCertificateState.NotСonfirm;
            return ob.MapTo<PlanCertificate>();
        }

        [NotNull]
        public static CertificateQualityDto ClearValues([NotNull] this CertificateQualityDto obj)
        {
            obj.Rn = 0;
            obj.ChemicalIndicatorValues.DoForEach(elem => elem.Value = "0");
            obj.MechanicIndicatorValues.DoForEach(elem => elem.Value = "0");
            obj.Destinations.Clear();
            obj.Passes.Clear();
            obj.AttachedDocuments.DoForEach(x => x.ClearValues());
            return obj;
        }
         [NotNull]
        public static CertificateQualityAttachedDocumentDto ClearValues([NotNull] this CertificateQualityAttachedDocumentDto obj)
        {
            obj.Rn = 0;
            return obj;
        }
    }
}
