// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IHasDocument.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   The HasDocument interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using UI.Entities.CertificateQualityDomain.ManufacturersCertificateDomain;

namespace UI.Entities.AttachedDocumentDomain
{
    using System.Collections.Generic;

    /// <summary>
    /// The HasDocument interface.
    /// </summary>
    public interface IHasDocument : IUiEntity
    {
        /// <summary>
        /// Gets the documents.
        /// </summary>
        IList<CertificateQualityAttachedDocument> Documents { get; }
    }
}
