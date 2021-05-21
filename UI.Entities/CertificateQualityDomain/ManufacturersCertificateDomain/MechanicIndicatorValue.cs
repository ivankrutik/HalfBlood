// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MechanicIndicatorValue.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the MechanicIndicatorValue type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Entities.CertificateQualityDomain.ManufacturersCertificateDomain
{
    using System;

    /// <summary>
    /// The mechanic indicator value.
    /// </summary>
    public class MechanicIndicatorValue : EntityBase<MechanicIndicatorValue>
    {
        public long Rn { get; set; }
        //public Catalog Catalog{get;set;}
        public string Value { get; set; }
        public CertificateQuality CertificateQuality { get; set; }
        public DictionaryMechanicalIndicator MechanicalIndicator { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is MechanicIndicatorValue == false) return false;
            if (Object.ReferenceEquals(this, obj)) return true;

            if (Object.ReferenceEquals(this, null) || Object.ReferenceEquals(obj, null))
                return false;

            var element = obj as MechanicIndicatorValue;

            if (MechanicalIndicator == null && element.MechanicalIndicator != null)
            {
                return false;
            }

            bool result = Value == element.Value
                          && ((MechanicalIndicator == null && element.MechanicalIndicator == null)
                              || MechanicalIndicator.Equals(element.MechanicalIndicator));

            return result;
        }

        public override int GetHashCode()
        {
            int hashValue = string.IsNullOrWhiteSpace(Value) ? 0 : Value.GetHashCode();
            int hashDict = this.MechanicalIndicator == null ? 0 : this.MechanicalIndicator.GetHashCode();

            // Calculate the hash code for the product.
            return hashDict ^ hashValue;
        }
    }
}
