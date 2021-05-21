// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AttachedDocumentProfile.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the AttachedDocumentProfile type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Buisness.Entities.CertificateQualityDomain.ManufacturersCertificateDomain;
using UI.Entities.CertificateQualityDomain.ManufacturersCertificateDomain;

namespace UI.ProcessComponents.Mappings
{
    using AutoMapper;
    using Buisness.Entities.AttachedDocumentDomain;
    using Entities.AttachedDocumentDomain;
    using Halfblood.Common.Mappers;

    /// <summary>
    /// The attached document profile.
    /// </summary>
    [AutoMapperProfile]
    public class AttachedDocumentProfile : Profile
    {
        protected override void Configure()
        {
            CreateAttachedDocument();
            CreateAttachedDocumentType();
        }

        private void CreateAttachedDocument()
        {
            Mapper.CreateMap<AttachedDocument, AttachedDocumentDto>()
                .ForMember(x => x.DocumentType, o => o.MapFrom(x => x.DocumentType))
                .ForMember(x => x.Content, o => o.MapFrom(x => x.Content))
                .ForMember(x => x.Note, o => o.MapFrom(x => x.Note))
                .ForMember(x => x.Catalog, o => o.MapFrom(x => x.Catalog))
                .ForMember(x => x.Code, o => o.MapFrom(x => x.Code))
                .ForMember(x => x.Document, o => o.ResolveUsing(x => new CertificateQualityDto { Rn = x.Parent.Rn }))
                .ForMember(x => x.LoadDate, o => o.MapFrom(x => x.LoadDate))
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn));
            Mapper.CreateMap<AttachedDocumentDto, AttachedDocument>()
                .ForMember(x => x.DocumentType, o => o.MapFrom(x => x.DocumentType))
                .ForMember(x => x.Content, o => o.MapFrom(x => x.Content))
                .ForMember(x => x.ContentThumbnail, o => o.MapFrom(x => x.ContentThumbnail))
                .ForMember(x => x.Note, o => o.MapFrom(x => x.Note))
                .ForMember(x => x.Catalog, o => o.MapFrom(x => x.Catalog))
                .ForMember(x => x.Code, o => o.MapFrom(x => x.Code))
                .ForMember(x => x.Parent, o => o.ResolveUsing(x => new CertificateQuality { Rn = x.Document.Rn }))
                .ForMember(x => x.LoadDate, o => o.MapFrom(x => x.LoadDate))
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn));
        }

        private void CreateAttachedDocumentType()
        {
            Mapper.CreateMap<AttachedDocumentType, AttachedDocumentTypeDto>()
                .ForMember(x => x.Catalog, o => o.MapFrom(x => x.Catalog))
                .ForMember(x => x.Code, o => o.MapFrom(x => x.Code))
                .ForMember(x => x.Name, o => o.MapFrom(x => x.Name))
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn));
            Mapper.CreateMap<AttachedDocumentTypeDto, AttachedDocumentType>()
                .ForMember(x => x.Catalog, o => o.MapFrom(x => x.Catalog))
                .ForMember(x => x.Code, o => o.MapFrom(x => x.Code))
                .ForMember(x => x.Name, o => o.MapFrom(x => x.Name))
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn));
        }
    }
}
