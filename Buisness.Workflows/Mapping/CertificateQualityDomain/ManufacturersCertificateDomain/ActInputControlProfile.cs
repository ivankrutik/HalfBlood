// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActInputControlProfile.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the ActInputControlProfile type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Workflows.Mapping.CertificateQualityDomain.ManufacturersCertificateDomain
{
    using AutoMapper;

    using Buisness.Entities.CertificateQualityDomain;
    using Buisness.Entities.CertificateQualityDomain.ActInputControlDomain;

    using Halfblood.Common.Mappers;

    using ParusModel.Entities.CertificateQualityDomain.ActInputControlDomain;

    /// <summary>
    /// The act input control profile.
    /// </summary>
    public class ActInputControlProfile : Profile
    {
        protected override void Configure()
        {
            this.CreateActInputControl();
            this.CreateTheMoveAct();
            this.CreateConclusion();
            this.CreateConclusionEssential();
            this.CreateActInputControlTechnicalState();
            this.CreateSolutionByNote();
            this.CreateApplySolutionByRemark();
            this.CreateQualityStateControlOfTheMake();
            this.CreateQualityStateControlOfTheMakeSignature();
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
