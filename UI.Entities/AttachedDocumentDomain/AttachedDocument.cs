// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AttachedDocument.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the AttachedDocument type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Entities.AttachedDocumentDomain
{
    using System;
    using System.Drawing;

    public class AttachedDocument : EntityBase<AttachedDocument>
    {
        private IUiEntity _parent;
        private string _code;
        private string _note;
        private byte[] _content;
        private byte[] _contentThumbnail;
        private AttachedDocumentType _documentType;
        private DateTime _loadDate;

        public AttachedDocument()
        {
        }
        public AttachedDocument(long rn)
        {
            this.Rn = rn;
        }

        public IUiEntity Parent
        {
            get { return this._parent; }
            set
            {
                this._parent = value;
                this.OnPropertyChanged();
            }
        }
        public string Code
        {
            get { return this._code; }
            set
            {
                this._code = value;
                this.OnPropertyChanged();
            }
        }
        public string Note
        {
            get { return this._note; }
            set
            {
                this._note = value;
                this.OnPropertyChanged();
            }
        }
        public byte[] Content
        {
            get { return this._content; }
            set
            {
               this._content = value;
                this.OnPropertyChanged();
            }
        }

        public byte[] ContentThumbnail
        {
            get { return this._contentThumbnail; }
            set
            {
                this._contentThumbnail = value;
                this.OnPropertyChanged();
            }
        }

        public AttachedDocumentType DocumentType
        {
            get { return this._documentType; }
            set
            {
                this._documentType = value;
                this.OnPropertyChanged();
            }
        }
        public DateTime LoadDate
        {
            get { return this._loadDate; }
            set
            {
                this._loadDate = value;
                this.OnPropertyChanged();
            }
        }

        public override string ToString()
        {
            return Code;
        }
    }
}