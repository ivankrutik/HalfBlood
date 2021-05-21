// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PassDto.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the PassDto type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Entities.CertificateQualityDomain.ManufacturersCertificateDomain
{
    using System;

    using Buisness.Entities.CommonDomain;

    using Halfblood.Common;

    /// <summary>
    ///     The pass dto.
    /// </summary>
    public class PassDto : IDto<long>
    {
        object IHasUid.Rn { get { return Rn; } }
        public CatalogDto Catalog { get; set; }
        public DateTime? CreationDate { get; set; }
        public ManufacturersCertificatePassState State { get; set; }
        public DateTime? StateDate { get; set; }
        public string Note { get; set; }
        public UserDto UserCreator { get; set; }
        public UserDto UserWhichSetState { get; set; }
        public CertificateQualityDto CertificateQuality { get; set; }
        public DictionaryPassDto DictionaryPass { get; set; }
        public long Rn { get; set; }
    }
}