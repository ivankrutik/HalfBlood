// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ChemicalIndicatorValue.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the ChemicalIndicatorValue type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Entities.CertificateQualityDomain.ManufacturersCertificateDomain
{
    using System;

    public class ChemicalIndicatorValue : EntityBase<ChemicalIndicatorValue>
    {
        public string Value { get; set; }
        public CertificateQuality CertificateQuality { get; set; }
        public DictionaryChemicalIndicator DictChemicalIndicator { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is ChemicalIndicatorValue == false) return false;
            if (Object.ReferenceEquals(this, obj)) return true;

            if (Object.ReferenceEquals(this, null) || Object.ReferenceEquals(obj, null))
                return false;

            var element = obj as ChemicalIndicatorValue;

            if (DictChemicalIndicator == null && element.DictChemicalIndicator != null)
            {
                return false;
            }

            bool result = Value == element.Value
                          && ((DictChemicalIndicator == null && element.DictChemicalIndicator == null)
                              || DictChemicalIndicator.Equals(element.DictChemicalIndicator));

            return result;
        }

        public override int GetHashCode()
        {
            int hashValue = string.IsNullOrWhiteSpace(Value) ? 0 : Value.GetHashCode();
            int hashDict = this.DictChemicalIndicator == null ? 0 : this.DictChemicalIndicator.GetHashCode();

            // Calculate the hash code for the product.
            return hashDict ^ hashValue;
        }
    }
}
