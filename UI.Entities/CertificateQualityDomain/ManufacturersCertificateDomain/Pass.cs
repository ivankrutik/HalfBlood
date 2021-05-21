// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Pass.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the Pass type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Entities.CertificateQualityDomain.ManufacturersCertificateDomain
{
    using System;

    using Halfblood.Common;

    using UI.Entities.CommonDomain;

    /// <summary>
    /// The pass.
    /// </summary>
    public class Pass : EntityBase<Pass>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Pass"/> class.
        /// </summary>
        /// <param name="rn">
        /// The RN.
        /// </param>
        public Pass(long rn)
            : this()
        {
            this.Rn = rn;
        }

        public Pass()
        {
        }

        public DateTime? CreationDate { get; set; }
        public ManufacturersCertificatePassState State { get; set; }
        public DateTime? StateDate { get; set; }
        public string Note { get; set; }
        public User UserCreator { get; set; }
        public User UserWhichSetState { get; set; }
        public CertificateQuality CertificateQuality { get; set; }
        public DictionaryPass DictionaryPass { get; set; }
        
        public override string ToString()
        {
            return this.DictionaryPass.ToString();
        }
    }
}
