// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AttachedDocumentProfile.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The attached document profile.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


using Buisness.Entities.CertificateQualityDomain.ManufacturersCertificateDomain;

namespace Buisness.Workflows.Mapping
{
    using System;

    using AutoMapper;

    using Buisness.Entities.AttachedDocumentDomain;
    using Buisness.Workflows.Helper;

    using Halfblood.Common;
    using Halfblood.Common.Mappers;
    using Halfblood.Common.Helpers.FileManagers.Converters;

    using ParusModel.Entities.AttachedDocumentDomain;

    /// <summary>
    /// The attached document profile.
    /// </summary>
    [AutoMapperProfile]
    public class AttachedDocumentProfile : Profile
    {
        protected override void Configure()
        {
            CreateFileLink();
            CreateFLinkType();
        }

        private void CreateFileLink()
        {
            Mapper.CreateMap<AttachedDocument, AttachedDocumentDto>()
                .ForMember(x => x.DocumentType, o => o.MapFrom(x => x.AttachedDocumentType))
                .ForMember(x => x.Catalog, o => o.MapFrom(x => x.Catalog))
                .ForMember(x => x.Code, o => o.MapFrom(x => x.Code))
                .ForMember(x => x.LoadDate, o => o.MapFrom(x => x.LoadDate))
                .ForMember(x => x.Document, o => o.ResolveUsing(x => new CertificateQualityDto { Rn = x.Document}))
                .ForMember(x => x.ContentThumbnail, o => o.ResolveUsing(x =>
                {
                    var imageThumbnail = ImagesConverter.ToImage(x.BData).ThumbnailImage();
                    return imageThumbnail != null ? ImagesConverter.ToByteArray(imageThumbnail) : null;
                }))
                .ForMember(x => x.Note, o => o.MapFrom(x => x.Note))
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn));
            Mapper.CreateMap<AttachedDocumentDto, AttachedDocument>()
                .ForMember(x => x.AttachedDocumentType, o => o.MapFrom(x => x.DocumentType))
                .ForMember(x => x.Catalog, o => o.MapFrom(x => x.Catalog))
                .ForMember(x => x.LoadDate, o => o.MapFrom(x => x.LoadDate))
                .ForMember(x => x.Code, o => o.MapFrom(x => x.Code))
                .ForMember(x => x.BData, o => o.MapFrom(x => x.Content))
                .ForMember(x => x.Document, o => o.ResolveUsing(x => x.Document.Rn ))
                .ForMember(x => x.Note, o => o.MapFrom(x => x.Note))
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn));
        }

        private void CreateFLinkType()
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
