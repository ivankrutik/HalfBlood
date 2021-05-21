// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DictionaryPass.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The dictionary pass.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Entities.CertificateQualityDomain
{
    using System;
    using System.Collections.Generic;
    using CommonDomain;
    using ManufacturersCertificateDomain;

    /// <summary>
    /// The dictionary pass.
    /// </summary>
    public class DictionaryPass
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DictionaryPass"/> class.
        /// </summary>
        /// <param name="rn">
        /// The rn.
        /// </param>
        public DictionaryPass(long rn)
            : this()
        {
            this.Rn = rn;
        }

        public DictionaryPass()
        {
        }

        public long Rn { get; private set; }
        public DateTime? CreationDate { get; set; }
        public string Pass { get; set; }
        public string MemoPass { get; set; }
        public User Agnlist { get; set; }
        public IList<CertificateQuality> CertificateQualities { get; set; }
        public virtual IList<Pass> Passes
        {
            get;
            set;
        }
        public virtual IList<Destination> Destinations
        {
            get;
            set;
        }
        public override string ToString()
        {
            return string.Format("{0} ({1})", this.MemoPass, this.Pass);
        }

    }
}
