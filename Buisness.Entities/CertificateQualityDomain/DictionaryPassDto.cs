// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DictionaryPassDto.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the DictionaryPassDto type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Entities.CertificateQualityDomain
{
    using System;
    using System.Collections.Generic;

    using Buisness.Entities.CertificateQualityDomain.ManufacturersCertificateDomain;
    using Buisness.Entities.CommonDomain;

    using Halfblood.Common;

    /// <summary>
    ///     The dictionary pass DTO.
    /// </summary>
    public class DictionaryPassDto : IDto<long>
    {
        public CatalogDto Catalog { get; set; }
        public DateTime? CreationDate { get; set; }
        public string Pass { get; set; }
        public string MemoPass { get; set; }
        public UserDto Agnlist { get; set; }
        public IList<CertificateQualityDto> CertificateQualities { get; set; }
        public virtual IList<PassDto> Passes { get; set; }
        public virtual IList<DestinationDto> Destinations { get; set; }
        public long Rn { get; set; }
        object IHasUid.Rn { get { return Rn; } }
    }
}