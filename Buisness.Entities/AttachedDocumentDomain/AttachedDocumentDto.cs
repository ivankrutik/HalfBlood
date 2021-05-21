// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AttachedDocumentDto.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The attached document dto.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Entities.AttachedDocumentDomain
{
    using System;
    using System.ComponentModel;
    using Halfblood.Common;

    /// <summary>
    /// The attached document DTO.
    /// </summary>
    [RelationEntityToDto(NamesOfSectionSystem.ATTACHED_DOCUMENT)]
    public class AttachedDocumentDto : IDto<long>, INotifyPropertyChanged
    {
        public CatalogDto Catalog { get; set; }
        public string Code { get; set; }
        public string Note { get; set; }
        public AttachedDocumentTypeDto DocumentType { get; set; }
        public long Rn { get; set; }
        public IDto<long> Document { get; set; }
        public byte[] Content { get; set; }
        public byte[] ContentThumbnail { get; set; }
        
        public DateTime LoadDate { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        object IHasUid.Rn { get { return Rn; } }
    }
}