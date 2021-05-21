// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActInputControlTechnicalStateDto.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The act input control technical state dto.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Entities.CertificateQualityDomain
{
    using System;
    using System.Collections.Generic;

    using Buisness.Entities.CertificateQualityDomain.ActInputControlDomain;
    using Buisness.Entities.CommonDomain;

    using Halfblood.Common;

    /// <summary>
    ///     The act input control technical state dto.
    /// </summary>
    public class ActInputControlTechnicalStateDto : IDto<long>
    {
        object IHasUid.Rn { get { return Rn; } }
        public CatalogDto Catalog { get; set; }
        public DateTime? CreationDate { get; set; }
        public string Note { get; set; }
        public DateTime? ControlerBtkDate { get; set; }
        public DateTime? ControlertOtkDate { get; set; }
        public string Conclusion { get; set; }
        public UserDto UserCreator { get; set; }
        public UserDto ControlerBtk { get; set; }
        public UserDto ControlerOtk { get; set; }
        public IList<TechnicalStateEssentialDto> TechnicalStatesEssential { get; set; }
        public ActInputControlDto ActInputControl { get; set; }
        public long Rn { get; set; }
    }
}