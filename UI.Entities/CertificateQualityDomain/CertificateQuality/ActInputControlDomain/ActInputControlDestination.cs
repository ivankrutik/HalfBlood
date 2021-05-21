// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActInputControlDestination.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the ActInputControlDestination type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using UI.Entities.CertificateQualityDomain;
using UI.Entities.CertificateQualityDomain.ManufacturersCertificateDomain;

namespace UI.Entities.PlanReceiptOrderDomain.CertificateQualityDomain.ActInputControlDomain
{
    using Halfblood.Common;

    
    using UI.Entities.CommonDomain;

    /// <summary>
    /// The act input control destination.
    /// </summary>
    public class ActInputControlDestination
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ActInputControlDestination"/> class.
        /// </summary>
        /// <param name="rn">
        /// The rn.
        /// </param>
        public ActInputControlDestination(long rn)
        {
            this.RN = rn;
        }

        public ActInputControlDestination()
        {
            
        }

        public long RN
        {
            get;
            set;
        }
        public string Note
        {
            get;
            set;
        }
        public ActInputControlDestinationState State
        {
            get;
            set;
        }
        public DateTime? StateDate
        {
            get;
            set;
        }
        public User Creator
        {
            get;
            set;
        }
        public User UserWhichSetState
        {
            get;
            set;
        }
        public CertificateQuality CertificateQuality
        {
            get;
            set;
        }
        public DictionaryPass DICPASS
        {
            get;
            set;
        }
    }
}
