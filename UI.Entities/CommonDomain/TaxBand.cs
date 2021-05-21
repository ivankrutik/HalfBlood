// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TaxBand.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the TaxBand type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Entities.CommonDomain
{
    using System;
    using System.Collections.Generic;

    using UI.Entities.PlanReceiptOrderDomain;

    public class TaxBand
    {
         public TaxBand(long rn)
        {
            Rn = rn;
        }

        public string Code { get; set; }
        public string Name { get; set; }
        public Catalog Catalog { get; set; }
        public IList<PlanCertificate> PlaneCertificates { get; set; }
        public long Rn { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is TaxBand == false) return false;
            if (Object.ReferenceEquals(this, obj)) return true;

            if (Object.ReferenceEquals(this, null) || Object.ReferenceEquals(obj, null))
                return false;

            var value = obj as TaxBand;

            return Rn == value.Rn;
        }
        public override int GetHashCode()
        {
            return Rn.GetHashCode();
        }

        public override string ToString()
        {
            return Code;
        }
    }
}
