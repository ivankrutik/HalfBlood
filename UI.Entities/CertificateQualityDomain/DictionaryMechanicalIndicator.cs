// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DictionaryMechanicalIndicator.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the DictionaryMechanicalIndicator type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Entities.CertificateQualityDomain
{
    using System;

    using UI.Entities.CommonDomain;

    public class DictionaryMechanicalIndicator
    {
        public long Rn { get; set; }
        public Catalog Catalog { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is DictionaryMechanicalIndicator == false) return false;
            if (Object.ReferenceEquals(this, obj)) return true;

            if (Object.ReferenceEquals(this, null) || Object.ReferenceEquals(obj, null))
                return false;

            var value = obj as DictionaryMechanicalIndicator;

            return Rn == value.Rn;
        }
        public override int GetHashCode()
        {
            return Rn.GetHashCode();
        }
    }
}
