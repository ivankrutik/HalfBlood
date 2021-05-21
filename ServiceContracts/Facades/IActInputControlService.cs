// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IActInputControlService.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the IActInputControlService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Buisness.Filters;

namespace ServiceContracts.Facades
{
    using System.Collections.Generic;

    using Buisness.Entities.CertificateQualityDomain;
    using Buisness.Entities.CertificateQualityDomain.ActInputControlDomain;
    using Buisness.Entities.PlanReceiptOrderDomain;

    /// <summary>
    /// The ActInputControlService interface.
    /// </summary>
    public interface IActInputControlService
    {
        IList<ActInputControlDto> GetActsInputControlFilter(ActInputControlFilter filter);
        ActInputControlDto AddActInputControl(ActInputControlDto entity);
        void UpdateActInputControl(ActInputControlDto entity);
        void RemoveActInputControl(ActInputControlDto entity);
        void UpdateActInputControlTechnicalState(ActInputControlTechnicalStateDto entity);
        ActInputControlTechnicalStateDto InsertActInputControlTechnicalState(ActInputControlTechnicalStateDto entity);
        void RemoveActInputControlTechnicalState(ActInputControlTechnicalStateDto entity);
        IList<TheMoveActDto> GetTheMoveActFilter(TheMoveActFilter filter);
        TheMoveActDto AddTheMoveAct(TheMoveActDto entity);
        void UpdateTheMoveAct(TheMoveActDto entity);
        void RemoveTheMoveAct(TheMoveActDto entity);
        IList<ConclusionDto> GetConclusionFilter(ConclusionFilter filter);
        ConclusionDto AddConclusion(ConclusionDto entity);
        void UpdateConclusion(ConclusionDto entity);
        void RemoveConclusion(ConclusionDto entity);
        IList<ConclusionEssentialDto> GetConclusionEssentialFilter(ConclusionEssentialFilter filter);
        ConclusionEssentialDto AddConclusionEssential(ConclusionEssentialDto entity);
        void UpdateConclusionEssential(ConclusionEssentialDto entity);
        void RemoveConclusionEssential(ConclusionEssentialDto entity);
        ApplySolutionByRemarkDto InsertApplySolutionByRemark(ApplySolutionByRemarkDto entity);
        void RemoveApplySolutionByRemark(ApplySolutionByRemarkDto entity);
        void UpdateApplySolutionByRemark(ApplySolutionByRemarkDto entity);
        IList<QualityStateControlOfTheMakeDto> GetQualityStateControlOfTheMakeFilter(QualityStateControlOfTheMakeFilter filter);
        void UpdateQualityStateControlOfTheMake(QualityStateControlOfTheMakeDto entity);
        void RemoveQualityStateControlOfTheMake(QualityStateControlOfTheMakeDto entity);
        QualityStateControlOfTheMakeDto InsertQualityStateControlOfTheMake(QualityStateControlOfTheMakeDto entity);
        SolutionByNoteDto InsertSolutionByNote(SolutionByNoteDto entity);
        void RemoveSolutionByNote(SolutionByNoteDto entity);
        void UpdateSolutionByNote(SolutionByNoteDto entity);
        IList<QualityStateControlOfTheMakeSignatureDto> GetQualityStateControlOfTheMakeSignatureFilter(QualityStateControlOfTheMakeSignatureFilter filter);
        void UpdateQualityStateControlOfTheMakeSignature(QualityStateControlOfTheMakeSignatureDto entity);
        void RemoveQualityStateControlOfTheMakeSignature(QualityStateControlOfTheMakeSignatureDto entity);
        QualityStateControlOfTheMakeSignatureDto InsertQualityStateControlOfTheMakeSignature(QualityStateControlOfTheMakeSignatureDto entity);
    }
}
