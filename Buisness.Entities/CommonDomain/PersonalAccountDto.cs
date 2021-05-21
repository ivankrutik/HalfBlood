// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PersonalAccountDto.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the PersonalAccountDto type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Entities.CommonDomain
{
    using Buisness.Entities.ContractDomain;

    using Halfblood.Common;

    public class PersonalAccountDtoForView : IDto<long>
    {
        object IHasUid.Rn { get { return Rn; } }
        public virtual string Numb { get; set; }
        public virtual long Rn { get; set; }

        public override string ToString()
        {
            return Numb;
        }
    }

    /// <summary>
    ///     The personal account dto.
    /// </summary>
    public class PersonalAccountDto : PersonalAccountDtoForView
    {
        public virtual StagesOfTheContractDto StagesOfTheContract { get; set; }
    }
}