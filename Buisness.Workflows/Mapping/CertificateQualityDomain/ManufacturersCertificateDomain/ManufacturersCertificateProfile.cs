// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ManufacturersCertificateProfile.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the ManufacturersCertificateProfileProfile type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Buisness.Workflows.Helper;
using Halfblood.Common.Helpers.FileManagers.Converters;

namespace Buisness.Workflows.Mapping.CertificateQualityDomain.ManufacturersCertificateDomain
{
    using AutoMapper;

    using Buisness.Entities.CertificateQualityDomain.ManufacturersCertificateDomain;

    using Halfblood.Common.Mappers;

    using ParusModel.Entities.CertificateQualityDomain.ManufacturersCertificateDomain;

    [AutoMapperProfile]
    public class ManufacturersCertificateProfileProfile : Profile
    {
        protected override void Configure()
        {
            this.CreateCertificateQuality();
            this.CreateDestinahion();
            this.CreatePass();
            this.CreateMechanicIndicatorValue();
            this.CreateChemicalIndicatorValue();
        }

        private void CreateChemicalIndicatorValue()
        {
            Mapper.CreateMap<ChemicalIndicatorValue, ChemicalIndicatorValueDto>()
                .ForMember(x => x.CertificateQuality, o => o.MapFrom(x => x.CertificateQuality))
                .ForMember(x => x.ChemicalIndicator, o => o.MapFrom(x => x.ChemicalIndicator))
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn))
                .ForMember(x => x.Value, o => o.MapFrom(x => x.Value));
            Mapper.CreateMap<ChemicalIndicatorValueDto, ChemicalIndicatorValue>()
                .ForMember(x => x.CertificateQuality, o => o.MapFrom(x => x.CertificateQuality))
                .ForMember(x => x.ChemicalIndicator, o => o.MapFrom(x => x.ChemicalIndicator))
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
                .ForMember(x => x.UserCreator, o => o.MapFrom(x => x.Creator))
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
                .ForMember(x => x.Creator, o => o.MapFrom(x => x.UserCreator))
                .ForMember(x => x.UserWhichSetState, o => o.MapFrom(x => x.UserWhichSetState));
        }

        private void CreateCertificateQuality()
        {

            Mapper.CreateMap<CertificateQualityAttachedDocument, CertificateQualityAttachedDocumentDto>()
                .ForMember(x => x.DocumentType, o => o.MapFrom(x => x.AttachedDocumentType))
                .ForMember(x => x.Catalog, o => o.MapFrom(x => x.Catalog))
                .ForMember(x => x.LoadDate, o => o.MapFrom(x => x.LoadDate))
                .ForMember(x => x.Code, o => o.MapFrom(x => x.Code))
                .ForMember(x => x.Content, o => o.MapFrom(x => x.BData))
                .ForMember(x => x.Document, o => o.ResolveUsing(x => new CertificateQualityDto { Rn = x.Rn }))
                                .ForMember(x => x.ContentThumbnail, o => o.ResolveUsing(x =>
                                {
                                    var imageThumbnail = ImagesConverter.ToImage(x.BData).ThumbnailImage();
                                    return imageThumbnail != null ? ImagesConverter.ToByteArray(imageThumbnail) : null;
                                }))
                .ForMember(x => x.Note, o => o.MapFrom(x => x.Note))
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn));
            Mapper.CreateMap<CertificateQualityAttachedDocumentDto, CertificateQualityAttachedDocument>()
                  .ForMember(x => x.AttachedDocumentType, o => o.MapFrom(x => x.DocumentType))
                .ForMember(x => x.Catalog, o => o.MapFrom(x => x.Catalog))
                .ForMember(x => x.LoadDate, o => o.MapFrom(x => x.LoadDate))
                .ForMember(x => x.Code, o => o.MapFrom(x => x.Code))
                .ForMember(x => x.BData, o => o.MapFrom(x => x.Content))
                .ForMember(x => x.Document, o => o.ResolveUsing(x => x.Document.Rn))
                .ForMember(x => x.Note, o => o.MapFrom(x => x.Note))
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn));

            Mapper.CreateMap<CertificateQuality, CertificateQualityDto>()
                  .ForMember(x => x.AttachedDocuments, o => o.MapFrom(x => x.AttachedDocuments))
                  .ForMember(x => x.Catalog, o => o.MapFrom(x => x.Catalog))
                  .ForMember(x => x.State, o => o.MapFrom(x => x.State))
                  .ForMember(x => x.StateDate, o => o.MapFrom(x => x.StateDate))
                  .ForMember(x => x.PlanCertificate, o => o.MapFrom(x => x.PlanCertificate))
                  .ForMember(x => x.AgnlistCreatorFactory, o => o.MapFrom(x => x.CreatorFactory))
                  .ForMember(x => x.Cast, o => o.MapFrom(x => x.Cast))
                  .ForMember(x => x.CreationDate, o => o.MapFrom(x => x.CreationDate))
                  .ForMember(x => x.Destinations, o => o.MapFrom(x => x.Destinations))
                  .ForMember(x => x.FullRepresentation, o => o.MapFrom(x => x.FullRepresentation))
                  .ForMember(x => x.GostMarka, o => o.MapFrom(x => x.GostMarka))
                  .ForMember(x => x.GostMix, o => o.MapFrom(x => x.GostMix))
                  .ForMember(x => x.MakingDate, o => o.MapFrom(x => x.MakingDate))
                  .ForMember(x => x.Marka, o => o.MapFrom(x => x.Marka))
                  .ForMember(x => x.Mix, o => o.MapFrom(x => x.Mix))
                  .ForMember(x => x.NomerCertificate, o => o.MapFrom(x => x.NomerCertificata))
                  .ForMember(x => x.Note, o => o.MapFrom(x => x.Note))
                  .ForMember(x => x.Numb, o => o.MapFrom(x => x.Numb))
                  .ForMember(x => x.Passes, o => o.MapFrom(x => x.Passes))
                  .ForMember(x => x.Pref, o => o.MapFrom(x => x.Pref))
                  .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn))
                  .ForMember(x => x.StandardSize, o => o.MapFrom(x => x.StandardSize))
                  .ForMember(x => x.StorageDate, o => o.MapFrom(x => x.StorageDate))
                  .ForMember(x => x.BoldId, o => o.MapFrom(x => x.BoldId))
                  .ForMember(x => x.IdMater, o => o.MapFrom(x => x.IdMater))
                  .ForMember(x => x.UserCreator, o => o.MapFrom(x => x.UserCreator));
            Mapper.CreateMap<CertificateQualityDto, CertificateQuality>()
                  .ForMember(x => x.AttachedDocuments, o => o.MapFrom(x => x.AttachedDocuments))
                  .ForMember(x => x.Catalog, o => o.MapFrom(x => x.Catalog))
                  .ForMember(x => x.State, o => o.MapFrom(x => x.State))
                  .ForMember(x => x.StateDate, o => o.MapFrom(x => x.StateDate))
                  .ForMember(x => x.PlanCertificate, o => o.MapFrom(x => x.PlanCertificate))
                  .ForMember(x => x.CreatorFactory, o => o.MapFrom(x => x.AgnlistCreatorFactory))
                  .ForMember(x => x.Cast, o => o.MapFrom(x => x.Cast))
                  .ForMember(x => x.CreationDate, o => o.MapFrom(x => x.CreationDate))
                  .ForMember(x => x.Destinations, o => o.MapFrom(x => x.Destinations))
                  .ForMember(x => x.FullRepresentation, o => o.MapFrom(x => x.FullRepresentation))
                  .ForMember(x => x.GostMarka, o => o.MapFrom(x => x.GostMarka))
                  .ForMember(x => x.GostMix, o => o.MapFrom(x => x.GostMix))
                  .ForMember(x => x.MakingDate, o => o.MapFrom(x => x.MakingDate))
                  .ForMember(x => x.Marka, o => o.MapFrom(x => x.Marka))
                  .ForMember(x => x.Mix, o => o.MapFrom(x => x.Mix))
                  .ForMember(x => x.NomerCertificata, o => o.MapFrom(x => x.NomerCertificate))
                  .ForMember(x => x.Note, o => o.MapFrom(x => x.Note))
                  .ForMember(x => x.Numb, o => o.MapFrom(x => x.Numb))
                  .ForMember(x => x.Passes, o => o.MapFrom(x => x.Passes))
                  .ForMember(x => x.Pref, o => o.MapFrom(x => x.Pref))
                  .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn))
                  .ForMember(x => x.BoldId, o => o.MapFrom(x => x.BoldId))
                  .ForMember(x => x.IdMater, o => o.MapFrom(x => x.IdMater))
                  .ForMember(x => x.StandardSize, o => o.MapFrom(x => x.StandardSize))
                  .ForMember(x => x.StorageDate, o => o.MapFrom(x => x.StorageDate))
                  .ForMember(x => x.UserCreator, o => o.MapFrom(x => x.UserCreator));

            //Mapper.CreateMap<CertificateQualityRestLiteDto, CertificateQuality>()
            //    .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn));
            //Mapper.CreateMap<CertificateQuality, CertificateQualityRestLiteDto>()
            //    .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn));
        }

        private void CreateDestinahion()
        {
            Mapper.CreateMap<Destination, DestinationDto>()
                .ForMember(x => x.CertificateQuality, o => o.MapFrom(x => x.CertificateQuality))
                .ForMember(x => x.DictionaryPass, o => o.MapFrom(x => x.DictionaryPass))
                .ForMember(x => x.Note, o => o.MapFrom(x => x.Note))
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn))
                .ForMember(x => x.State, o => o.MapFrom(x => x.State))
                .ForMember(x => x.StateDate, o => o.MapFrom(x => x.StateDate))
                .ForMember(x => x.UserCreator, o => o.MapFrom(x => x.Creator))
                .ForMember(x => x.UserWhichSetState, o => o.MapFrom(x => x.UserWhichSetState));
            Mapper.CreateMap<DestinationDto, Destination>()
                .ForMember(x => x.CertificateQuality, o => o.MapFrom(x => x.CertificateQuality))
                .ForMember(x => x.DictionaryPass, o => o.MapFrom(x => x.DictionaryPass))
                .ForMember(x => x.Note, o => o.MapFrom(x => x.Note))
                .ForMember(x => x.Rn, o => o.MapFrom(x => x.Rn))
                .ForMember(x => x.State, o => o.MapFrom(x => x.State))
                .ForMember(x => x.StateDate, o => o.MapFrom(x => x.StateDate))
                .ForMember(x => x.Creator, o => o.MapFrom(x => x.UserCreator))
                .ForMember(x => x.UserWhichSetState, o => o.MapFrom(x => x.UserWhichSetState));
        }
    }
}
