// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CuttingOrderService.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the CuttingOrderService Type2.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Workflows.Services
{
    using System;
    using System.Collections.Generic;

    using Buisness.Entities.CuttingOrderDomain;
    using Buisness.Filters;

    using Halfblood.Common;

    using NHibernate.Helper.Filter;
    using NHibernate.Helper.Filter.Specification;
    using NHibernate.Helper.Repository;
    using NHibernate.Helper.Service;

    using ParusModel.Entities.CuttingOrderDomain;

    using ParusModelLite.CuttingOrderDomain;

    using ServiceContracts.Facades;

    [Register(typeof(ICuttingOrderService))]
    public class CuttingOrderService : ServiceBase, ICuttingOrderService
    {
        public CuttingOrderService(
            IRepositoryFactory repositoryFactory,
            IFilterStrategyFactory filterStrategyFactory)
            : base(repositoryFactory, filterStrategyFactory)
        {
        }

        #region CuttingOrder

        public CuttingOrderDto AddCuttingOrder(CuttingOrderDto cuttingOrder)
        {
            return AddEntity<CuttingOrder, CuttingOrderDto>(cuttingOrder);
        }

        public void UpdateCuttingOrder(CuttingOrderDto cuttingOrder)
        {
            UpdateEntity<CuttingOrder, CuttingOrderDto>(cuttingOrder);
        }

        public void RemoveCuttingOrder(CuttingOrderDto cuttingOrder)
        {
            RemoveEntity<CuttingOrder, CuttingOrderDto>(cuttingOrder);
        }

        public IList<CuttingOrderDto> GetCuttingOrderFilter(CuttingOrderFilter filter)
        {
            //var ret = ExecuteStoreProcedure<CuttingOrder>(new GetLastMoveCuttingOrder());
            return GetEntities<CuttingOrderFilter, CuttingOrder, CuttingOrderDto>(filter,
                query => query.FetchEager(x => x.Department)
                    .FetchEager(x => x.Creator)
                    .FetchEager(x => x.District)
                    .FetchEager(x => x.Inspector)
                    //.FetchEager(x => x.Moves)
                    //.FetchEager(x => x.Specifications)
                    .FetchEager(x => x.Storekeeper));
        }

        public IList<CuttingOrderLiteDto> GetCuttingOrderForView(CuttingOrderFilter filter)
        {
            throw new NotImplementedException();
        }

        public CuttingOrderDto GetCuttingOrder(long id)
        {
            CuttingOrderDto result = GetEntity<CuttingOrder, CuttingOrderDto>(id);
            return result;
        }

        #endregion;

        #region CuttingOrderMove

        public CuttingOrderMoveDto AddCuttingOrderMove(CuttingOrderMoveDto cuttingOrderMove)
        {
            return AddEntity<CuttingOrderMove, CuttingOrderMoveDto>(cuttingOrderMove);
        }

        public void UpdateCuttingOrderMove(CuttingOrderMoveDto cuttingOrderMove)
        {
            UpdateEntity<CuttingOrderMove, CuttingOrderMoveDto>(cuttingOrderMove);
        }

        public void RemoveCuttingOrderMove(CuttingOrderMoveDto cuttingOrderMove)
        {
            RemoveEntity<CuttingOrderMove, CuttingOrderMoveDto>(cuttingOrderMove);
        }

        public IList<CuttingOrderMoveDto> GetCuttingOrderMoveFilter(CuttingOrderMoveFilter filter)
        {
            return GetEntities<CuttingOrderMoveFilter, CuttingOrderMove, CuttingOrderMoveDto>(filter);
        }

        public CuttingOrderMoveDto GetCuttingOrderMove(long id)
        {
            CuttingOrderMoveDto result = GetEntity<CuttingOrderMove, CuttingOrderMoveDto>(id);
            return result;
        }

        #endregion;

        #region CuttingOrderSpecification

        public CuttingOrderSpecificationDto AddCuttingOrderSpecification(CuttingOrderSpecificationDto cuttingOrderSpecification)
        {
            return AddEntity<CuttingOrderSpecification, CuttingOrderSpecificationDto>(cuttingOrderSpecification);
        }

        public void UpdateCuttingOrderSpecification(CuttingOrderSpecificationDto cuttingOrderSpecification)
        {
            UpdateEntity<CuttingOrderSpecification, CuttingOrderSpecificationDto>(cuttingOrderSpecification);
        }

        public void RemoveCuttingOrderSpecification(CuttingOrderSpecificationDto cuttingOrderSpecification)
        {
            RemoveEntity<CuttingOrderSpecification, CuttingOrderSpecificationDto>(cuttingOrderSpecification);
        }

        public IList<CuttingOrderSpecificationDto> GetCuttingOrderSpecificationFilter(CuttingOrderSpecificationFilter filter)
        {
            return GetEntities<CuttingOrderSpecificationFilter, CuttingOrderSpecification, CuttingOrderSpecificationDto>(filter);
        }

        public CuttingOrderSpecificationDto GetCuttingOrderSpecification(long id)
        {
            CuttingOrderSpecificationDto result = GetEntity<CuttingOrderSpecification, CuttingOrderSpecificationDto>(id);
            return result;
        }

        #endregion;

        #region Sample

        public SampleDto AddSample(SampleDto sample)
        {
            return AddEntity<Sample, SampleDto>(sample);
        }

        public void UpdateSample(SampleDto sample)
        {
            UpdateEntity<Sample, SampleDto>(sample);
        }

        public void RemoveSample(SampleDto sample)
        {
            RemoveEntity<Sample, SampleDto>(sample);
        }

        public IList<SampleDto> GetSampleFilter(SampleFilter filter)
        {
            return GetEntities<SampleFilter, Sample, SampleDto>(filter);
        }

        public SampleDto GetSample(long id)
        {
            SampleDto result = GetEntity<Sample, SampleDto>(id);
            return result;
        }

        #endregion;

        #region SampleCertification

        public SampleCertificationDto AddSampleCertification(SampleCertificationDto sampleCertification)
        {
            return AddEntity<SampleCertification, SampleCertificationDto>(sampleCertification);
        }

        public void UpdateSampleCertification(SampleCertificationDto sampleCertification)
        {
            UpdateEntity<SampleCertification, SampleCertificationDto>(sampleCertification);
        }

        public void RemoveSampleCertification(SampleCertificationDto sampleCertification)
        {
            RemoveEntity<SampleCertification, SampleCertificationDto>(sampleCertification);
        }

        public IList<SampleCertificationDto> GetSampleCertificationFilter(SampleCertificationFilter filter)
        {
            return GetEntities<SampleCertificationFilter, SampleCertification, SampleCertificationDto>(filter);
        }

        public SampleCertificationDto GetSampleCertification(long id)
        {
            SampleCertificationDto result = GetEntity<SampleCertification, SampleCertificationDto>(id);
            return result;
        }

        #endregion;

        #region Certification

        public CertificationDto AddCertification(CertificationDto certification)
        {
            return AddEntity<Certification, CertificationDto>(certification);
        }

        public void UpdateCertification(CertificationDto certification)
        {
            UpdateEntity<Certification, CertificationDto>(certification);
        }

        public void RemoveCertification(CertificationDto certification)
        {
            RemoveEntity<Certification, CertificationDto>(certification);
        }

        public IList<CertificationDto> GetCertificationFilter(CertificationFilter filter)
        {
            return GetEntities<CertificationFilter, Certification, CertificationDto>(filter);
        }

        public CertificationDto GetCertification(long id)
        {
            CertificationDto result = GetEntity<Certification, CertificationDto>(id);
            return result;
        }

        #endregion;
    }
}
