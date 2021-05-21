// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Destination.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the Destination type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Entities.CertificateQualityDomain.ManufacturersCertificateDomain
{
    using System;

    using Halfblood.Common;

    using UI.Entities.CommonDomain;

    /// <summary>
    /// The destination.
    /// </summary>
    public class Destination : EntityBase<Destination>
    {
        public Destination(long rn)
        {
            Rn = rn;
        }

        public Destination()
        {
        }

        public long Rn { get; private set; }
        public Catalog Catalog { get; set; }
        public string Note { get; set; }
        public ManufacturersCertificateDestinationState State { get; set; }
        public DateTime? StateDate { get; set; }
        public User UserCreator { get; set; }
        public User UserWhichSetState { get; set; }
        public CertificateQuality CertificateQuality { get; set; }
        public DictionaryPass DictionaryPass { get; set; }
    }
}