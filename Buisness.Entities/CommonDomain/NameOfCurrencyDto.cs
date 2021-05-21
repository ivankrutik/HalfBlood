// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NameOfCurrencyDto.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the NameOfCurrencyDto type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Entities.CommonDomain
{
    using Halfblood.Common;

    public class NameOfCurrencyDto : IDto<long>
    {
        object IHasUid.Rn { get { return Rn; } }
        public string Code { get; set; }
        public string Name { get; set; }
        public long Rn { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1}", Name, Code);
        }

        public override bool Equals(object obj)
        {
            if (obj is NameOfCurrencyDto == false) return false;
            if (ReferenceEquals(this, obj)) return true;

            if (ReferenceEquals(this, null) || ReferenceEquals(obj, null))
                return false;

            var value = obj as NameOfCurrencyDto;

            return Rn == value.Rn;
        }

        public override int GetHashCode()
        {
            return Rn.GetHashCode();
        }
    }
}