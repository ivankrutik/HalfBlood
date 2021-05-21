// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnitOfMeasure.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the UnitOfMeasure type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Entities.CommonDomain
{
    using System;

    using Halfblood.Common.Helpers;

    /// <summary>
    /// The unit of measure.
    /// </summary>
    public class UnitOfMeasure
    {
        public UnitOfMeasure(long rn)
        {
            this.Rn = rn;
        }

        public UnitOfMeasure()
        {
        }

        public long Rn { get; private set; }
        public string MEASMNEMO { get; set; }
        public string MEASNAME { get; set; }
        public long MEASTYPE { get; set; }
        public long ETALON { get; set; }
        public decimal KOEFF { get; set; }
        public string CODEOKEI { get; set; }
        public bool MAINSIGN { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is UnitOfMeasure == false) return false;
            if (Object.ReferenceEquals(this, obj)) return true;

            if (Object.ReferenceEquals(this, null) || Object.ReferenceEquals(obj, null))
                return false;

            var value = obj as UnitOfMeasure;

            return Rn == value.Rn;
        }
        public override int GetHashCode()
        {
            return Rn.GetHashCode();
        }

        public override string ToString()
        {
            return "{0} ({1})".StringFormat(MEASMNEMO, MEASNAME);
        }
    }
}
