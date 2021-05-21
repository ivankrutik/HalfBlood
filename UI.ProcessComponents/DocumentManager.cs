// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DocumentManager.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the DocumentManager type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using UI.Entities.CertificateQualityDomain.ManufacturersCertificateDomain;

namespace UI.ProcessComponents
{
    using System;
    using System.ComponentModel.Composition;
    using System.Diagnostics.Contracts;

    using ReactiveUI;

    using UI.Entities.AttachedDocumentDomain;
    using UI.Infrastructure;

    /// <summary>
    /// The document manager.
    /// </summary>
    [Export(typeof(IDocumentManager))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class DocumentManager : ReactiveObject, IDocumentManager
    {
        private CertificateQualityAttachedDocument _insertingDocument;
        private bool _isInserting;
        private IHasDocument _hasDocument;
        private Func<CertificateQualityAttachedDocument, bool> _canInsert;
        private CertificateQualityAttachedDocument _oldInsertingDocument;

        public CertificateQualityAttachedDocument InsertingDocument
        {
            get { return this._insertingDocument; }
            private set { this.RaiseAndSetIfChanged(ref this._insertingDocument, value); }
        }
        public bool IsInserting
        {
            get { return this._isInserting; }
            private set { this.RaiseAndSetIfChanged(ref this._isInserting, value); }
        }
        public IHasDocument HasDocument
        {
            get { return this._hasDocument; }
            protected set { this.RaiseAndSetIfChanged(ref this._hasDocument, value); }
        }

        public void BeginInsert()
        {
            if (HasDocument == null)
            {
                throw new ArgumentNullException("HasDocument must be not null");
            }

            this.InsertingDocument = new CertificateQualityAttachedDocument();
            this.InitDocument(this.InsertingDocument);
            this.IsInserting = true;
        }
        public bool ApplyInsert()
        {
            if ((this.InsertingDocument == null || this.InsertingDocument.Content == null) && !this.CanInsert())
            {
                return false;
            }

            InsertingDocument.Parent = HasDocument;
            this.HasDocument.Documents.Add(this.InsertingDocument);
            this.OnReset();

            return true;
        }
        public void CancelInsert()
        {
            this.OnReset();
        }
        public void SetHasDocument(IHasDocument hasDocument)
        {
            Contract.Requires(hasDocument != null, "The HasDocument objetc must be not null");

            this.HasDocument = hasDocument;
        }

        public void DeletingDocument(CertificateQualityAttachedDocument attachedDocument)
        {
            if (this.HasDocument == null)
            {
                throw new ArgumentNullException("HaveDocument");
            }

            this.HasDocument.Documents.Remove(attachedDocument);
        }
        public void SetCanInsert(Func<CertificateQualityAttachedDocument, bool> canInsert)
        {
            _canInsert = canInsert;
        }
        public bool CanInsert()
        {
            if (_canInsert == null)
            {
                return true;
            }

            return _canInsert(this.InsertingDocument);
        }

        protected virtual void Reset() { /*TO DO*/ }
        protected virtual void InitDocument(CertificateQualityAttachedDocument attachedDocument)
        {
            attachedDocument.Parent = this.HasDocument;

            if (this._oldInsertingDocument != null)
            {
                attachedDocument.DocumentType = this._oldInsertingDocument.DocumentType;
                attachedDocument.Catalog = this._oldInsertingDocument.Catalog;
            }             
        }

        private void OnReset()
        {
            this._oldInsertingDocument = this.InsertingDocument;
            this.InsertingDocument = null;
            this.IsInserting = false;
            
            // _canInsert = null;
            // this._hasDocument = null;
            this.Reset();
        }
    }
}
