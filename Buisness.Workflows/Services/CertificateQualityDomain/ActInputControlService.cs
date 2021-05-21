// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActInputControlService.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the ActInputControlService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Workflows.Services.CertificateQualityDomain
{
    using System;
    using System.Collections.Generic;

    using Buisness.Entities.CertificateQualityDomain;
    using Buisness.Entities.CertificateQualityDomain.ActInputControlDomain;
    using Buisness.Filters;

    using Halfblood.Common;

    using NHibernate.Helper.Filter;
    using NHibernate.Helper.Repository;
    using NHibernate.Helper.Service;

    using ParusModel.Entities.CertificateQualityDomain.ActInputControlDomain;

    using ServiceContracts.Facades;

    [Register(typeof(IActInputControlService))]
    public class ActInputControlService : ServiceBase, IActInputControlService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ActInputControlService"/> class.
        /// </summary>
        /// <param name="repositoryFactory">
        /// The repository factory.
        /// </param>
        /// <param name="filterStrategyFactory">
        /// The filter strategy factory.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// </exception>
        public ActInputControlService(
             IRepositoryFactory repositoryFactory,  
             IFilterStrategyFactory filterStrategyFactory)
            : base(repositoryFactory, filterStrategyFactory)
        {
        }

        public virtual IList<ActInputControlDto> GetActsInputControlFilter(ActInputControlFilter filter)
        {
            return this.GetEntities<ActInputControlFilter, ActInputControl, ActInputControlDto>(filter);
        }

        public virtual ActInputControlDto AddActInputControl(ActInputControlDto entity)
        {
            return this.AddEntity<ActInputControl, ActInputControlDto>(entity);
        }

        public virtual void UpdateActInputControl(ActInputControlDto entity)
        {
            this.UpdateEntity<ActInputControl, ActInputControlDto>(entity);
        }

        public virtual void RemoveActInputControl(ActInputControlDto entity)
        {
            this.RemoveEntity<ActInputControl, ActInputControlDto>(entity);
        }
        public virtual ActInputControlTechnicalStateDto InsertActInputControlTechnicalState(ActInputControlTechnicalStateDto entity)
        {
            return this.AddEntity<ActInputControlTechnicalState, ActInputControlTechnicalStateDto>(entity);
        }

        public virtual void RemoveActInputControlTechnicalState(ActInputControlTechnicalStateDto entity)
        {
            this.RemoveEntity<ActInputControlTechnicalState, ActInputControlTechnicalStateDto>(entity);
        }

        public virtual void UpdateActInputControlTechnicalState(ActInputControlTechnicalStateDto entity)
        {
            this.UpdateEntity<ActInputControlTechnicalState, ActInputControlTechnicalStateDto>(entity);
        }
        public virtual IList<TheMoveActDto> GetTheMoveActFilter(TheMoveActFilter filter)
        {
            return this.GetEntities<TheMoveActFilter, TheMoveAct, TheMoveActDto>(filter);
        }

        public virtual TheMoveActDto AddTheMoveAct(TheMoveActDto entity)
        {
            return this.AddEntity<TheMoveAct, TheMoveActDto>(entity);
        }

        public virtual void RemoveTheMoveAct(TheMoveActDto entity)
        {
            this.RemoveEntity<TheMoveAct, TheMoveActDto>(entity);
        }

        public virtual void UpdateTheMoveAct(TheMoveActDto entity)
        {
            this.UpdateEntity<TheMoveAct, TheMoveActDto>(entity);
        }

        public virtual ConclusionDto AddConclusion(ConclusionDto entity)
        {
            return this.AddEntity<Conclusion, ConclusionDto>(entity);
        }

        public virtual ConclusionEssentialDto AddConclusionEssential(ConclusionEssentialDto entity)
        {
            return this.AddEntity<ConclusionEssential, ConclusionEssentialDto>(entity);
        }

        public virtual IList<ConclusionDto> GetConclusionFilter(ConclusionFilter filter)
        {
            return this.GetEntities<ConclusionFilter, Conclusion, ConclusionDto>(filter);
        }

        public virtual IList<ConclusionEssentialDto> GetConclusionEssentialFilter(ConclusionEssentialFilter filter)
        {
            return this.GetEntities<ConclusionEssentialFilter, ConclusionEssential, ConclusionEssentialDto>(filter);
        }

        public virtual void RemoveConclusion(ConclusionDto entity)
        {
            this.RemoveEntity<Conclusion, ConclusionDto>(entity);
        }

        public virtual void RemoveConclusionEssential(ConclusionEssentialDto entity)
        {
            this.UpdateEntity<ConclusionEssential, ConclusionEssentialDto>(entity);
        }

        public virtual void UpdateConclusion(ConclusionDto entity)
        {
            this.UpdateEntity<Conclusion, ConclusionDto>(entity);
        }

        public virtual void UpdateConclusionEssential(ConclusionEssentialDto entity)
        {
            this.UpdateEntity<ConclusionEssential, ConclusionEssentialDto>(entity);
        }
        public virtual ApplySolutionByRemarkDto InsertApplySolutionByRemark(ApplySolutionByRemarkDto entity)
        {
            return this.AddEntity<ApplySolutionByRemark, ApplySolutionByRemarkDto>(entity);
        }

        public virtual void RemoveApplySolutionByRemark(ApplySolutionByRemarkDto entity)
        {
            this.RemoveEntity<ApplySolutionByRemark, ApplySolutionByRemarkDto>(entity);
        }

        public virtual void UpdateApplySolutionByRemark(ApplySolutionByRemarkDto entity)
        {
            this.UpdateEntity<ApplySolutionByRemark, ApplySolutionByRemarkDto>(entity);
        }

        public virtual IList<QualityStateControlOfTheMakeDto> GetQualityStateControlOfTheMakeFilter(
            QualityStateControlOfTheMakeFilter filter)
        {
            return this.GetEntities<QualityStateControlOfTheMakeFilter, QualityStateControlOfTheMake, QualityStateControlOfTheMakeDto>(filter);
        }

        public virtual QualityStateControlOfTheMakeDto InsertQualityStateControlOfTheMake(QualityStateControlOfTheMakeDto entity)
        {
            return this.AddEntity<QualityStateControlOfTheMake, QualityStateControlOfTheMakeDto>(entity);
        }

        public virtual void RemoveQualityStateControlOfTheMake(QualityStateControlOfTheMakeDto entity)
        {
            this.RemoveEntity<QualityStateControlOfTheMake, QualityStateControlOfTheMakeDto>(entity);
        }

        public virtual void UpdateQualityStateControlOfTheMake(QualityStateControlOfTheMakeDto entity)
        {
            this.UpdateEntity<QualityStateControlOfTheMake, QualityStateControlOfTheMakeDto>(entity);
        }

        public virtual IList<QualityStateControlOfTheMakeSignatureDto>
            GetQualityStateControlOfTheMakeSignatureFilter(
            QualityStateControlOfTheMakeSignatureFilter filter)
        {
            return this.GetEntities<QualityStateControlOfTheMakeSignatureFilter, QualityStateControlOfTheMakeSignature, QualityStateControlOfTheMakeSignatureDto>(filter);
        }

        public virtual SolutionByNoteDto InsertSolutionByNote(SolutionByNoteDto entity)
        {
            return this.AddEntity<SolutionByNote, SolutionByNoteDto>(entity);
        }

        public virtual void RemoveSolutionByNote(SolutionByNoteDto entity)
        {
            this.RemoveEntity<SolutionByNote, SolutionByNoteDto>(entity);
        }

        public virtual void UpdateSolutionByNote(SolutionByNoteDto entity)
        {
            this.UpdateEntity<SolutionByNote, SolutionByNoteDto>(entity);
        }

        public virtual QualityStateControlOfTheMakeSignatureDto InsertQualityStateControlOfTheMakeSignature(
            QualityStateControlOfTheMakeSignatureDto entity)
        {
            return this.AddEntity<QualityStateControlOfTheMakeSignature, QualityStateControlOfTheMakeSignatureDto>(entity);
        }

        public virtual void RemoveQualityStateControlOfTheMakeSignature(QualityStateControlOfTheMakeSignatureDto entity)
        {
            this.RemoveEntity<QualityStateControlOfTheMakeSignature, QualityStateControlOfTheMakeSignatureDto>(entity);
        }

        public virtual void UpdateQualityStateControlOfTheMakeSignature(QualityStateControlOfTheMakeSignatureDto entity)
        {
            this.UpdateEntity<QualityStateControlOfTheMakeSignature, QualityStateControlOfTheMakeSignatureDto>(entity);
        }
    }
}
