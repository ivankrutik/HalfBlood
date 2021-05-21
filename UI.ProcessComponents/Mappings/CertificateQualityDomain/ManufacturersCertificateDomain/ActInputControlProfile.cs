// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActInputControlProfile.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the ActInputControlProfile type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.ProcessComponents.Mappings.CertificateQualityDomain.ManufacturersCertificateDomain
{
    using AutoMapper;

    using Buisness.Entities.CertificateQualityDomain;
    using Buisness.Entities.CertificateQualityDomain.ActInputControlDomain;

    using Halfblood.Common.Mappers;

    using Entities.PlanReceiptOrderDomain;
    using Entities.PlanReceiptOrderDomain.CertificateQualityDomain;
    using Entities.PlanReceiptOrderDomain.CertificateQualityDomain.ActInputControlDomain;

    [AutoMapperProfile]
    public class ActInputControlProfile : Profile
    {
        protected override void Configure()
        {
            CreateActInputControl();
            CreateTheMoveAct();
            CreateConclusion();
            CreateConclusionEssential();
            CreateActInputControlTechnicalState();
            CreateSolutionByNote();
            CreateApplySolutionByRemark();
            CreateQualityStateControlOfTheMake();
            CreateQualityStateControlOfTheMakeSignature();
        }



        private void CreateActInputControl()
        {
            Mapper.CreateMap<ActInputControl, ActInputControlDto>();
            Mapper.CreateMap<ActInputControlDto, ActInputControl>()
                .IgnoreAllNonExisting();
        }

        private void CreateTheMoveAct()
        {
            Mapper.CreateMap<TheMoveAct, TheMoveActDto>();
            Mapper.CreateMap<TheMoveActDto, TheMoveAct>()
                .IgnoreAllNonExisting();
        }
        private void CreateConclusion()
        {
            Mapper.CreateMap<Conclusion, ConclusionDto>();
            Mapper.CreateMap<ConclusionDto, Conclusion>()
                .IgnoreAllNonExisting();
        }
        private void CreateConclusionEssential()
        {
            Mapper.CreateMap<ConclusionEssential, ConclusionEssentialDto>();
            Mapper.CreateMap<ConclusionEssentialDto, ConclusionEssential>()
                .IgnoreAllNonExisting();
        }
        private void CreateActInputControlTechnicalState()
        {
            Mapper.CreateMap<ActInputControlTechnicalState, ActInputControlTechnicalStateDto>();
            Mapper.CreateMap<ActInputControlTechnicalStateDto, ActInputControlTechnicalState>()
                .IgnoreAllNonExisting();
        }

        private void CreateSolutionByNote()
        {
            Mapper.CreateMap<SolutionByNote, SolutionByNoteDto>();
            Mapper.CreateMap<SolutionByNoteDto, SolutionByNote>()
                .IgnoreAllNonExisting();
        }
        private void CreateApplySolutionByRemark()
        {
            Mapper.CreateMap<ApplySolutionByRemark, ApplySolutionByRemarkDto>();
            Mapper.CreateMap<ApplySolutionByRemarkDto, ApplySolutionByRemark>()
                .IgnoreAllNonExisting();
        }
        private void CreateQualityStateControlOfTheMake()
        {
            Mapper.CreateMap<QualityStateControlOfTheMake, QualityStateControlOfTheMakeDto>();
            Mapper.CreateMap<QualityStateControlOfTheMakeDto, QualityStateControlOfTheMake>()
                .IgnoreAllNonExisting();
        }
        private void CreateQualityStateControlOfTheMakeSignature()
        {
            Mapper.CreateMap<QualityStateControlOfTheMakeSignatureDto, QualityStateControlOfTheMakeSignature>();
            Mapper.CreateMap<QualityStateControlOfTheMakeSignature, QualityStateControlOfTheMakeSignatureDto>()
                .IgnoreAllNonExisting();
        }
    }
}
