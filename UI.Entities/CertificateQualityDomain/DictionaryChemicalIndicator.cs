// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DictionaryChemicalIndicator.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the DictionaryChemicalIndicator type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Entities.CertificateQualityDomain
{
    using System;

    using UI.Entities.CommonDomain;

    public class DictionaryChemicalIndicator
    {
        public long Rn { get; set; }
        public Catalog Catalog { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            if (obj is DictionaryChemicalIndicator == false) return false;
            if (Object.ReferenceEquals(this, obj)) return true;

            if (Object.ReferenceEquals(this, null) || Object.ReferenceEquals(obj, null))
                return false;

            var dict = obj as DictionaryChemicalIndicator;
            return Rn == dict.Rn;
        }
        public override int GetHashCode()
        {
            return Rn.GetHashCode();
        }
    }
}
