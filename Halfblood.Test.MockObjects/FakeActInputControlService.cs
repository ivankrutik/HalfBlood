// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FakeActInputControlService.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the FakeActInputControlService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Buisness.Filters;

namespace Halfblood.Test.MockObjects
{
    using System;
    using System.Collections.Generic;

    using Buisness.Entities.CertificateQualityDomain;
    using Buisness.Entities.CertificateQualityDomain.ActInputControlDomain;
    using Buisness.Entities.PlanReceiptOrderDomain;

    using FizzWare.NBuilder;

    using ServiceContracts.Facades;

    public class FakeActInputControlService : IActInputControlService
    {
        public virtual IList<ActInputControlDto> GetActsInputControlFilter(ActInputControlFilter filter)
        {
            return Builder<ActInputControlDto>.CreateListOfSize(10).Build();
        }

        public virtual ActInputControlDto AddActInputControl(ActInputControlDto entity)
        {
            throw new NotImplementedException();
        }

        public virtual void UpdateActInputControl(ActInputControlDto entity)
        {
            throw new NotImplementedException();
        }

        public virtual void RemoveActInputControl(ActInputControlDto entity)
        {
            throw new NotImplementedException();
        }
        public virtual ActInputControlDestinationDto InsertActInputControlDestination(ActInputControlDestinationDto entity)
        {
            throw new NotImplementedException();
        }

        public virtual IList<ActInputControlDestinationDto> GetActInputControlDetinationFilter(
            ActInputControlDestinationDto filter, int skip, int take, out int total)
        {
            throw new NotImplementedException();
        }

        public virtual void UpdateActInputControlDestination(ActInputControlDestinationDto entity)
        {
            throw new NotImplementedException();
        }

        public virtual void RemoveActInputControlDestination(ActInputControlDestinationDto entity)
        {
            throw new NotImplementedException();
        }

        public virtual void UpdateActInputControlTechnicalState(ActInputControlTechnicalStateDto entity)
        {
            throw new NotImplementedException();
        }

            public virtual ActInputControlTechnicalStateDto InsertActInputControlTechnicalState(ActInputControlTechnicalStateDto entity)
        {
            throw new NotImplementedException();
        }

        public virtual void RemoveActInputControlTechnicalState(ActInputControlTechnicalStateDto entity)
        {
            throw new NotImplementedException();
        }

        public virtual IList<TheMoveActDto> GetTheMoveActFilter(TheMoveActFilter filter)
        {
            throw new NotImplementedException();
        }

        public virtual TheMoveActDto AddTheMoveAct(TheMoveActDto actMove)
        {
            throw new NotImplementedException();
        }

        public virtual void UpdateTheMoveAct(TheMoveActDto actMove)
        {
            throw new NotImplementedException();
        }

        public virtual void RemoveTheMoveAct(TheMoveActDto actMove)
        {
            throw new NotImplementedException();
        }

        public virtual IList<ConclusionDto> GetConclusionFilter(ConclusionFilter filter)
        {
            throw new NotImplementedException();
        }

        public virtual ConclusionDto AddConclusion(ConclusionDto con)
        {
            throw new NotImplementedException();
        }

        public virtual void UpdateConclusion(ConclusionDto con)
        {
            throw new NotImplementedException();
        }

        public virtual void RemoveConclusion(ConclusionDto con)
        {
            throw new NotImplementedException();
        }

        public virtual IList<ConclusionEssentialDto> GetConclusionEssentialFilter(ConclusionEssentialFilter filter)
        {
            throw new NotImplementedException();
        }

        public virtual ConclusionEssentialDto AddConclusionEssential(ConclusionEssentialDto con)
        {
            throw new NotImplementedException();
        }

        public virtual void UpdateConclusionEssential(ConclusionEssentialDto con)
        {
            throw new NotImplementedException();
        }

        public virtual void RemoveConclusionEssential(ConclusionEssentialDto con)
        {
            throw new NotImplementedException();
        }
        public virtual ApplySolutionByRemarkDto InsertApplySolutionByRemark(ApplySolutionByRemarkDto solution)
        {
            throw new NotImplementedException();
        }

        public virtual void RemoveApplySolutionByRemark(ApplySolutionByRemarkDto solution)
        {
            throw new NotImplementedException();
        }

        public virtual void UpdateApplySolutionByRemark(ApplySolutionByRemarkDto solution)
        {
            throw new NotImplementedException();
        }

        public virtual IList<QualityStateControlOfTheMakeDto> GetQualityStateControlOfTheMakeFilter(
            QualityStateControlOfTheMakeFilter filter)
        {
            throw new NotImplementedException();
        }

        public virtual void UpdateQualityStateControlOfTheMake(QualityStateControlOfTheMakeDto des)
        {
            throw new NotImplementedException();
        }

        public virtual void RemoveQualityStateControlOfTheMake(QualityStateControlOfTheMakeDto des)
        {
            throw new NotImplementedException();
        }

        public virtual QualityStateControlOfTheMakeDto InsertQualityStateControlOfTheMake(QualityStateControlOfTheMakeDto des)
        {
            throw new NotImplementedException();
        }

        public virtual SolutionByNoteDto InsertSolutionByNote(SolutionByNoteDto solution)
        {
            throw new NotImplementedException();
        }

        public virtual void RemoveSolutionByNote(SolutionByNoteDto solution)
        {
            throw new NotImplementedException();
        }

        public virtual void UpdateSolutionByNote(SolutionByNoteDto solution)
        {
            throw new NotImplementedException();
        }

        public virtual IList<QualityStateControlOfTheMakeSignatureDto> GetQualityStateControlOfTheMakeSignatureFilter(
            QualityStateControlOfTheMakeSignatureFilter filter)
        {
            throw new NotImplementedException();
        }

        public virtual void UpdateQualityStateControlOfTheMakeSignature(QualityStateControlOfTheMakeSignatureDto des)
        {
            throw new NotImplementedException();
        }

        public virtual void RemoveQualityStateControlOfTheMakeSignature(QualityStateControlOfTheMakeSignatureDto des)
        {
            throw new NotImplementedException();
        }

        public virtual QualityStateControlOfTheMakeSignatureDto InsertQualityStateControlOfTheMakeSignature(
            QualityStateControlOfTheMakeSignatureDto des)
        {
            throw new NotImplementedException();
        }
    }
}
