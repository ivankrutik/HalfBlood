// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ManufacturersCertificateProfile.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the ManufacturersCertificateProfile type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.ProcessComponents.Mappings.CertificateQualityDomain.ManufacturersCertificateDomain
{
    using AutoMapper;
    using Buisness.Entities.CertificateQualityDomain.ManufacturersCertificateDomain;
    using Entities.CertificateQualityDomain.ManufacturersCertificateDomain;

    using Halfblood.Common;
    using Halfblood.Common.Mappers;

    using UI.Entities;

    using Buisness.Entities.AttachedDocumentDomain;
    using Halfblood.Common.Helpers.FileManagers.Converters;

    [AutoMapperProfile]
    public class ManufacturersCertificateProfile : Profile
    {
        protected override void Configure()
        {
            CreateCertificateQuality();
            CreateDestinahion();
            CreatePass();
            CreateMechanicIndicatorValue();
            CreateChemicalIndicatorValue();
        }

        private void CreateChemicalIndicatorValue()
        {
            Mapper.CreateMap<CertificateQualityAttachedDocument, AttachedDocumentDto>()
          .ForMember(x => x.DocumentType, o => o.MapFrom(x => x.DocumentType))
          .ForMember(x => x.Catalog, o => o.MapFrom(x => x.Catalog))
          .ForMember(x => x.LoadDate, o => o.MapFrom(x => x.LoadDate))
          .ForMember(x => x.Code, o => o.MapFrom(x => x.Code))
          .ForMember(x => x.Content, o => o.MapFrom(x => x.Content))
          .ForMember(x => x.Document, o => o.ResolveUsing(x => new CertificateQualityDto { Rn = x.Rn }))
                          .ForMember(x => x.ContentThumbnail, o => o.ResolveUsing(x =>
                          {
                              var imageThumbnail = ImagesConverter.ToImage(x.Content).ThumbnailImage();
                              return imageThumbnail != null ? ImagesConverter.ToByteArray(imageThumbnail) : null;
                          }))
          .ForMember(x => x.Note, o => o.MapFrom(x => x.Note))
          .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn));
            Mapper.CreateMap<AttachedDocumentDto, CertificateQualityAttachedDocument>()
                  .ForMember(x => x.DocumentType, o => o.MapFrom(x => x.DocumentType))
                .ForMember(x => x.Catalog, o => o.MapFrom(x => x.Catalog))
                .ForMember(x => x.LoadDate, o => o.MapFrom(x => x.LoadDate))
                .ForMember(x => x.Code, o => o.MapFrom(x => x.Code))
                .ForMember(x => x.Content, o => o.MapFrom(x => x.Content))
               // .ForMember(x => x.Parent, o => o.ResolveUsing(x => x.Document.Rn))
                .ForMember(x => x.Note, o => o.MapFrom(x => x.Note))
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn));

            Mapper.CreateMap<ChemicalIndicatorValue, ChemicalIndicatorValueDto>()
                .ForMember(x => x.CertificateQuality, o => o.MapFrom(x => x.CertificateQuality))
                .ForMember(x => x.ChemicalIndicator, o => o.MapFrom(x => x.DictChemicalIndicator))
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn))
                .ForMember(x => x.Value, o => o.MapFrom(x => x.Value));
            Mapper.CreateMap<ChemicalIndicatorValueDto, ChemicalIndicatorValue>()
                .ForMember(x => x.CertificateQuality, o => o.MapFrom(x => x.CertificateQuality))
                .ForMember(x => x.DictChemicalIndicator, o => o.MapFrom(x => x.ChemicalIndicator))
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn))
                .ForMember(x => x.Value, o => o.MapFrom(x => x.Value));
        }

        private void CreateMechanicIndicatorValue()
        {
            Mapper.CreateMap<MechanicIndicatorValue, MechanicIndicatorValueDto>()
                .ForMember(x => x.CertificateQuality, o => o.MapFrom(x => x.CertificateQuality))
                .ForMember(x => x.MechanicalIndicator, o => o.MapFrom(x => x.MechanicalIndicator))
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn))
                .ForMember(x => x.Value, o => o.MapFrom(x => x.Value));
            Mapper.CreateMap<MechanicIndicatorValueDto, MechanicIndicatorValue>()
                .ForMember(x => x.CertificateQuality, o => o.MapFrom(x => x.CertificateQuality))
                .ForMember(x => x.MechanicalIndicator, o => o.MapFrom(x => x.MechanicalIndicator))
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn))
                .ForMember(x => x.Value, o => o.MapFrom(x => x.Value));
        }

        private void CreatePass()
        {
            Mapper.CreateMap<Pass, PassDto>()
                .ForMember(x => x.Catalog, o => o.MapFrom(x => x.Catalog))
                .ForMember(x => x.CertificateQuality, o => o.MapFrom(x => x.CertificateQuality))
                .ForMember(x => x.CreationDate, o => o.MapFrom(x => x.CreationDate))
                .ForMember(x => x.DictionaryPass, o => o.MapFrom(x => x.DictionaryPass))
                .ForMember(x => x.Note, o => o.MapFrom(x => x.Note))
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn))
                .ForMember(x => x.State, o => o.MapFrom(x => x.State))
                .ForMember(x => x.StateDate, o => o.MapFrom(x => x.StateDate))
                .ForMember(x => x.UserCreator, o => o.MapFrom(x => x.UserCreator))
                .ForMember(x => x.UserWhichSetState, o => o.MapFrom(x => x.UserWhichSetState));
            Mapper.CreateMap<PassDto, Pass>()
                .ForMember(x => x.Catalog, o => o.MapFrom(x => x.Catalog))
                .ForMember(x => x.CertificateQuality, o => o.MapFrom(x => x.CertificateQuality))
                .ForMember(x => x.CreationDate, o => o.MapFrom(x => x.CreationDate))
                .ForMember(x => x.DictionaryPass, o => o.MapFrom(x => x.DictionaryPass))
                .ForMember(x => x.Note, o => o.MapFrom(x => x.Note))
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn))
                .ForMember(x => x.State, o => o.MapFrom(x => x.State))
                .ForMember(x => x.StateDate, o => o.MapFrom(x => x.StateDate))
                .ForMember(x => x.UserCreator, o => o.MapFrom(x => x.UserCreator))
                .ForMember(x => x.UserWhichSetState, o => o.MapFrom(x => x.UserWhichSetState));
        }

        private void CreateCertificateQuality()
        {
            Mapper.CreateMap<CertificateQuality, IDto>().As<CertificateQualityDto>();
            Mapper.CreateMap<CertificateQuality, IDto<long>>().As<CertificateQualityDto>();
            Mapper.CreateMap<CertificateQualityDto, IUiEntity>().As<CertificateQuality>();

            Mapper.CreateMap<CertificateQuality, CertificateQualityDto>()
                .ForMember(x => x.State, o => o.MapFrom(x => x.State))
                .ForMember(x => x.StateDate, o => o.MapFrom(x => x.StateDate))
                .ForMember(x => x.NomerCertificate, o => o.MapFrom(x => x.NumberOfCertificate))
                .ForMember(x => x.PlanCertificate, o => o.MapFrom(x => x.PlanCertificate))
                .ForMember(x => x.AgnlistCreatorFactory, o => o.MapFrom(x => x.CreatorFactory))
                .ForMember(x => x.Cast, o => o.MapFrom(x => x.Cast))
                .ForMember(x => x.Catalog, o => o.MapFrom(x => x.Catalog))
                .ForMember(x => x.ChemicalIndicatorValues, o => o.MapFrom(x => x.ChemicalIndicatorValues))
                .ForMember(x => x.CreationDate, o => o.MapFrom(x => x.CreationDate))
                .ForMember(x => x.Destinations, o => o.MapFrom(x => x.Destinations))
                .ForMember(x => x.FullRepresentation, o => o.MapFrom(x => x.FullRepresentation))
                .ForMember(x => x.GostMarka, o => o.MapFrom(x => x.GostCast))
                .ForMember(x => x.GostMix, o => o.MapFrom(x => x.GostMix))
                .ForMember(x => x.MakingDate, o => o.MapFrom(x => x.MakingDate))
                .ForMember(x => x.Marka, o => o.MapFrom(x => x.Marka))
                .ForMember(x => x.MechanicIndicatorValues, o => o.MapFrom(x => x.MechanicIndicatorValues))
                .ForMember(x => x.Mix, o => o.MapFrom(x => x.Mix))
                .ForMember(x => x.Note, o => o.MapFrom(x => x.Note))
                .ForMember(x => x.Numb, o => o.MapFrom(x => x.Numb))
                .ForMember(x => x.Pass, o => o.MapFrom(x => x.Pass))
                .ForMember(x => x.Passes, o => o.MapFrom(x => x.Passes))
                .ForMember(x => x.Pref, o => o.MapFrom(x => x.Pref))
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn))
                .ForMember(x => x.StandardSize, o => o.MapFrom(x => x.Sizes))
                .ForMember(x => x.AttachedDocuments, o => o.MapFrom(x => x.Documents))
                .ForMember(x => x.StorageDate, o => o.MapFrom(x => x.StorageDate))
                .ForMember(x => x.UserCreator, o => o.MapFrom(x => x.UserCreator));
            Mapper.CreateMap<CertificateQualityDto, CertificateQuality>()
                .ForMember(x => x.Documents, o => o.MapFrom(x => x.AttachedDocuments))
                .ForMember(x => x.NumberOfCertificate, o => o.MapFrom(x => x.NomerCertificate))
                .ForMember(x => x.PlanCertificate, o => o.MapFrom(x => x.PlanCertificate))
                .ForMember(x => x.CreatorFactory, o => o.MapFrom(x => x.AgnlistCreatorFactory))
                .ForMember(x => x.Cast, o => o.MapFrom(x => x.Cast))
                .ForMember(x => x.Catalog, o => o.MapFrom(x => x.Catalog))
                .ForMember(x => x.ChemicalIndicatorValues, o => o.MapFrom(x => x.ChemicalIndicatorValues))
                .ForMember(x => x.CreationDate, o => o.MapFrom(x => x.CreationDate))
                .ForMember(x => x.Destinations, o => o.MapFrom(x => x.Destinations))
                .ForMember(x => x.FullRepresentation, o => o.MapFrom(x => x.FullRepresentation))
                .ForMember(x => x.GostCast, o => o.MapFrom(x => x.GostMarka))
                .ForMember(x => x.GostMix, o => o.MapFrom(x => x.GostMix))
                .ForMember(x => x.MakingDate, o => o.MapFrom(x => x.MakingDate))
                .ForMember(x => x.Marka, o => o.MapFrom(x => x.Marka))
                .ForMember(x => x.MechanicIndicatorValues, o => o.MapFrom(x => x.MechanicIndicatorValues))
                .ForMember(x => x.Mix, o => o.MapFrom(x => x.Mix))
                .ForMember(x => x.Note, o => o.MapFrom(x => x.Note))
                .ForMember(x => x.Numb, o => o.MapFrom(x => x.Numb))
                .ForMember(x => x.Pass, o => o.MapFrom(x => x.Pass))
                .ForMember(x => x.Passes, o => o.MapFrom(x => x.Passes))
                .ForMember(x => x.Pref, o => o.MapFrom(x => x.Pref))
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn))
                .ForMember(x => x.Sizes, o => o.MapFrom(x => x.StandardSize))
                .ForMember(x => x.StorageDate, o => o.MapFrom(x => x.StorageDate))
                .ForMember(x => x.UserCreator, o => o.MapFrom(x => x.UserCreator));
        }

        private void CreateDestinahion()
        {
            Mapper.CreateMap<CertificateQualityAttachedDocument, CertificateQualityAttachedDocumentDto>()
                .ForMember(x => x.DocumentType, o => o.MapFrom(x => x.DocumentType))
                .ForMember(x => x.Content, o => o.MapFrom(x => x.Content))
                .ForMember(x => x.Note, o => o.MapFrom(x => x.Note))
                .ForMember(x => x.Catalog, o => o.MapFrom(x => x.Catalog))
                .ForMember(x => x.Code, o => o.MapFrom(x => x.Code))
                .ForMember(x => x.Document, o => o.ResolveUsing(x => new CertificateQualityDto { Rn = x.Parent.Rn }))
                .ForMember(x => x.LoadDate, o => o.MapFrom(x => x.LoadDate))
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn));
            Mapper.CreateMap<CertificateQualityAttachedDocumentDto, CertificateQualityAttachedDocument>()
                                .ForMember(x => x.DocumentType, o => o.MapFrom(x => x.DocumentType))
                .ForMember(x => x.Content, o => o.MapFrom(x => x.Content))
                .ForMember(x => x.ContentThumbnail, o => o.MapFrom(x => x.ContentThumbnail))
                .ForMember(x => x.Note, o => o.MapFrom(x => x.Note))
                .ForMember(x => x.Catalog, o => o.MapFrom(x => x.Catalog))
                .ForMember(x => x.Code, o => o.MapFrom(x => x.Code))
                .ForMember(x => x.Parent, o => o.ResolveUsing(x => new CertificateQuality { Rn = x.Document.Rn }))
                .ForMember(x => x.LoadDate, o => o.MapFrom(x => x.LoadDate))
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn));

            Mapper.CreateMap<Destination, DestinationDto>()
                .ForMember(x => x.CertificateQuality, o => o.MapFrom(x => x.CertificateQuality))
                .ForMember(x => x.DictionaryPass, o => o.MapFrom(x => x.DictionaryPass))
                .ForMember(x => x.Note, o => o.MapFrom(x => x.Note))
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn))
                .ForMember(x => x.State, o => o.MapFrom(x => x.State))
                .ForMember(x => x.StateDate, o => o.MapFrom(x => x.StateDate))
                .ForMember(x => x.UserCreator, o => o.MapFrom(x => x.UserCreator))
                .ForMember(x => x.UserWhichSetState, o => o.MapFrom(x => x.UserWhichSetState));
            Mapper.CreateMap<DestinationDto, Destination>()
                .ForMember(x => x.CertificateQuality, o => o.MapFrom(x => x.CertificateQuality))
                .ForMember(x => x.DictionaryPass, o => o.MapFrom(x => x.DictionaryPass))
                .ForMember(x => x.Note, o => o.MapFrom(x => x.Note))
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn))
                .ForMember(x => x.State, o => o.MapFrom(x => x.State))
                .ForMember(x => x.StateDate, o => o.MapFrom(x => x.StateDate))
                .ForMember(x => x.UserCreator, o => o.MapFrom(x => x.UserCreator))
                .ForMember(x => x.UserWhichSetState, o => o.MapFrom(x => x.UserWhichSetState));
        }
    }
}
