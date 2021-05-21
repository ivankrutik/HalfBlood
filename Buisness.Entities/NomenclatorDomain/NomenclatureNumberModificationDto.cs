// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NomenclatureNumberModificationDto.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The nomenclature number modification dto.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Entities.NomenclatorDomain
{
    using Halfblood.Common;

    /// <summary>
    ///     The nomenclature number modification DTO.
    /// </summary>
    public class NomenclatureNumberModificationDto : IDto<long>
    {
        object IHasUid.Rn { get { return Rn; } }
        public string Code { get; set; }
        public string Name { get; set; }
        public long Rn { get; set; }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Code, Name);
        }
    }
}