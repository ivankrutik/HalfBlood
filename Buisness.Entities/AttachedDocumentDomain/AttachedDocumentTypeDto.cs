// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AttachedDocumentTypeDto.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the AttachedDocumentTypeDto type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Entities.AttachedDocumentDomain
{
    using System;
    using System.ComponentModel;

    using Halfblood.Common;

    /// <summary>
    ///     The attached document type DTO.
    /// </summary>
    public class AttachedDocumentTypeDto : IDto<long>, INotifyPropertyChanged
    {
        public CatalogDto Catalog { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public long Rn { get; set; }
        object IHasUid.Rn { get { return Rn; } }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public override string ToString()
        {
            return string.Format("{0} ({1})", Code, Name);
        }

        public override bool Equals(object obj)
        {

            if (obj is AttachedDocumentTypeDto == false) return false;
            if (Object.ReferenceEquals(this, obj)) return true;

            if (Object.ReferenceEquals(this, null) || Object.ReferenceEquals(obj, null))
                return false;

            var value = obj as AttachedDocumentTypeDto;

            return this.Rn == value.Rn;
        }
        public override int GetHashCode()
        {
            return Rn.GetHashCode();
        }
    }
}