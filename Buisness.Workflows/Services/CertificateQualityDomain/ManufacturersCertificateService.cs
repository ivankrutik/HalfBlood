// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ManufacturersCertificateService.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the ManufacturersCertificateService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Buisness.Components.StoredProcedure.ManufacturersCertificateDomain;

namespace Buisness.Workflows.Services.CertificateQualityDomain
{
    using System.Collections.Generic;

    using Buisness.Entities.CertificateQualityDomain.ManufacturersCertificateDomain;
    using Buisness.Filters;

    using Halfblood.Common;

    using NHibernate.Helper.Filter;
    using NHibernate.Helper.Repository;
    using NHibernate.Helper.Service;

    using ParusModel.Entities.CertificateQualityDomain.ManufacturersCertificateDomain;

    using ParusModelLite.CertificateQualityDomain.ManufacturersCertificateDomain;

    using ServiceContracts.Facades;

    /// <summary>
    /// The manufacturers certificate service.
    /// </summary>
    [Register(typeof(IManufacturersCertificateService))]
    public class ManufacturersCertificateService : ServiceBase, IManufacturersCertificateService
    {
        public ManufacturersCertificateService(
               IRepositoryFactory repositoryFactory,
               IFilterStrategyFactory filterStrategyFactory)
            : base(repositoryFactory, filterStrategyFactory)
        {
        }
        public IList<CertificateQualityDto> GetCertificatesQualityFilter(CertificateQualityFilter filter)
        {
            return this.GetEntities<CertificateQualityFilter, CertificateQuality, CertificateQualityDto>(filter); 
        }
        public virtual CertificateQualityDto AddCertificatQuality(CertificateQualityDto entity)
        {
            return this.AddEntity<CertificateQuality, CertificateQualityDto>(entity);
        }
        public void RemoveCertificatQuality(CertificateQualityDto entity)
        {
            this.RemoveEntity<CertificateQuality, CertificateQualityDto>(entity);
        }
        public void UpdateCertificatQuality(CertificateQualityDto entity)
        {
            this.UpdateEntity<CertificateQuality, CertificateQualityDto>(entity);
        }
        public IList<MechanicIndicatorValueDto> GetMechanicIndicatorValueFilter(MechanicIndicatorValueFilter filter)
        {
            return this.GetEntities<MechanicIndicatorValueFilter, MechanicIndicatorValue, MechanicIndicatorValueDto>(filter);
        }
        public void UpdateMechanicIndicatorValue(MechanicIndicatorValueDto entity)
        {
            this.UpdateEntity<MechanicIndicatorValue, MechanicIndicatorValueDto>(entity);
        }
        public MechanicIndicatorValueDto InsertMechanicIndicatorValue(MechanicIndicatorValueDto entity)
        {
            return this.AddEntity<MechanicIndicatorValue, MechanicIndicatorValueDto>(entity);
        }
        public IList<ChemicalIndicatorValueDto> GetChemicalIndicatorValueFilter(ChemicalIndicatorValueFilter filter)
        {
            return this.GetEntities<ChemicalIndicatorValueFilter, ChemicalIndicatorValue, ChemicalIndicatorValueDto>(filter);
        }
        public void UpdateChemicalIndicatorValue(ChemicalIndicatorValueDto entity)
        {
            this.UpdateEntity<ChemicalIndicatorValue, ChemicalIndicatorValueDto>(entity);
        }
        public ChemicalIndicatorValueDto InsertChemicalIndicatorValue(ChemicalIndicatorValueDto entity)
        {
            return this.AddEntity<ChemicalIndicatorValue, ChemicalIndicatorValueDto>(entity);
        }
        public void UpdateCertificateQuality(CertificateQualityDto entity)
        {
            this.UpdateEntity<CertificateQuality, CertificateQualityDto>(entity);
        }
        public CertificateQualityDto InsertCertificateQuality(CertificateQualityDto entity)
        {
            return this.AddEntity<CertificateQuality, CertificateQualityDto>(entity);
        }

        public IList<CertificateQualityLiteDto> GetCertificatesQualityFilterForView(CertificateQualityFilter filter)
        {
            return this.GetEntities<CertificateQualityFilter,CertificateQualityLiteDto>(filter);
        }

        public IList<CertificateQualityRestLiteDto> GetCertificatesQualityRestFilterForView(CertificateQualityFilter filter)
        {
            return this.GetEntities<CertificateQualityFilter, CertificateQualityRestLiteDto>(filter);
        }

        public virtual PassDto InsertPass(PassDto entity)
        {
            return this.AddEntity<Pass, PassDto>(entity);
        }
        public virtual void RemovePass(PassDto entity)
        {
            this.RemoveEntity<Pass, PassDto>(entity);
        }
        public virtual void UpdatePass(PassDto entity)
        {
            this.UpdateEntity<Pass, PassDto>(entity);
        }
        public virtual IList<PassDto> GetPass(PassFilter filter)
        {
            return this.GetEntities<PassFilter, Pass, PassDto>(filter);
        }

        public void SetStatus(long rn, QualityCertificateState state)
        {
            var _repository = RepositoryFactory.Create<CertificateQuality>();
            _repository.ExecuteSPUniqueResult<CertificateQuality>(new CertificateQualitySetStateSP(rn, state));
        }
    }
}
