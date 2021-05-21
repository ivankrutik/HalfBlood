// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDocumentManager.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the IDocumentManager type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using UI.Entities.CertificateQualityDomain.ManufacturersCertificateDomain;

namespace UI.Infrastructure
{
    using System;

    using UI.Entities.AttachedDocumentDomain;

    /// <summary>
    /// The DocumentManager interface.
    /// </summary>
    public interface IDocumentManager
    {
        CertificateQualityAttachedDocument InsertingDocument { get; }
        bool IsInserting { get; }
        IHasDocument HasDocument { get; }

        void BeginInsert();
        bool ApplyInsert();
        void CancelInsert();

        void SetHasDocument(IHasDocument hasDocument);
        void DeletingDocument(CertificateQualityAttachedDocument attachedDocument);
        void SetCanInsert(Func<CertificateQualityAttachedDocument, bool> canInsert);
    }
}
