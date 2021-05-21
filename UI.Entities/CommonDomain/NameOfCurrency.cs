// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NameOfCurrency.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the NameOfCurrency type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Entities.CommonDomain
{
    using System;

    /// <summary>
    /// The name of currency.
    /// </summary>
    public class NameOfCurrency
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NameOfCurrency"/> class.
        /// </summary>
        /// <param name="rn">
        /// The rn.
        /// </param>
        public NameOfCurrency(long rn)
        {
            this.Rn = rn;
        }

        public NameOfCurrency()
        {
        }

        public long Rn { get; private set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is NameOfCurrency == false) return false;
            if (Object.ReferenceEquals(this, obj)) return true;

            if (Object.ReferenceEquals(this, null) || Object.ReferenceEquals(obj, null))
                return false;

            var value = obj as NameOfCurrency;

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
