// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NomenclatureNumberDto.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the NomenclatureNumberDto type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Entities.NomenclatorDomain
{
    using Buisness.Entities.CommonDomain;

    using Halfblood.Common;

    /// <summary>
    ///     The nomenclature number DTO.
    /// </summary>
    public class NomenclatureNumberDto : IDto<long>
    {
        object IHasUid.Rn { get { return Rn; } }
        public string Code { get; set; }
        public string Name { get; set; }
        public UnitOfMeasureDto DicmuntUmeasMain { get; set; }
        public UnitOfMeasureDto DicmuntUmeasAlt { get; set; }
        public long Rn { get; set; }
    }
}