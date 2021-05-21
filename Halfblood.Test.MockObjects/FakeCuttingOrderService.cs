// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FakeCuttingOrderService.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the FakeCuttingOrderService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Buisness.Entities;
using Buisness.Filters;

namespace Halfblood.Test.MockObjects
{
    using System.Collections.Generic;

    using Buisness.Entities.CommonDomain;
    using Buisness.Entities.CuttingOrderDomain;
    using FizzWare.NBuilder;

    using ParusModelLite.CuttingOrderDomain;

    using ServiceContracts.Facades;

    /// <summary>
    /// The fake cutting order service.
    /// </summary>
    public class FakeCuttingOrderService : ICuttingOrderService
    {
        #region CuttingOrder

        /// <summary>
        /// The add cutting order.
        /// </summary>
        /// <param name="cuttingOrder">
        /// The cutting order.
        /// </param>
        /// <returns>
        /// The <see cref="CuttingOrderDto"/>.
        /// </returns>
        public CuttingOrderDto AddCuttingOrder(CuttingOrderDto cuttingOrder)
        {
            cuttingOrder.Rn = 629;
            cuttingOrder.Catalog = new CatalogDto(1007318777);
            return cuttingOrder;
        }

        public void UpdateCuttingOrder(CuttingOrderDto cuttingOrder)
        {
            return;
        }

        public void RemoveCuttingOrder(CuttingOrderDto cuttingOrder)
        {
            return;
        }

        public IList<CuttingOrderDto> GetCuttingOrderFilter(CuttingOrderFilter filter)
        {
            return Builder<CuttingOrderDto>
                                .CreateListOfSize(10)
                                .All()
                                .With(x => x.Creator, Builder<UserDto>.CreateNew().Build())
                                .With(x => x.Inspector, Builder<UserDto>.CreateNew().Build())
                                .With(x => x.Storekeeper, Builder<UserDto>.CreateNew().Build())
                                .With(x => x.Department, Builder<StaffingDivisionDto>.CreateNew().Build())
                                .With(x => x.District, Builder<StaffingDivisionDto>.CreateNew().Build())
                                .Build();
        }


        public IList<CuttingOrderLiteDto> GetCuttingOrderForView(CuttingOrderFilter filter)
        {
            return Builder<CuttingOrderLiteDto>
                             .CreateListOfSize(10)
                             .All()
                             .Build();
        }

        public CuttingOrderDto GetCuttingOrder(long id)
        {
            return Builder<CuttingOrderDto>.CreateNew().Build();
        }

        #endregion

        #region CuttingOrderMove

        public CuttingOrderMoveDto AddCuttingOrderMove(CuttingOrderMoveDto cuttingOrderMove)
        {
            cuttingOrderMove.Rn = 629;
            cuttingOrderMove.Catalog = new CatalogDto(1007318777);
            return cuttingOrderMove;
        }

        public void UpdateCuttingOrderMove(CuttingOrderMoveDto cuttingOrderMove)
        {
            return;
        }

        public void RemoveCuttingOrderMove(CuttingOrderMoveDto cuttingOrderMove)
        {
            return;
        }

        public IList<CuttingOrderMoveDto> GetCuttingOrderMoveFilter(CuttingOrderMoveFilter filter)
        {
            return Builder<CuttingOrderMoveDto>.CreateListOfSize(5).Build();
        }

        public CuttingOrderMoveDto GetCuttingOrderMove(long id)
        {
            return Builder<CuttingOrderMoveDto>.CreateNew().Build();
        }

        #endregion

        #region CuttingOrderSpecification

        public CuttingOrderSpecificationDto AddCuttingOrderSpecification(CuttingOrderSpecificationDto cuttingOrderSpecification)
        {
            cuttingOrderSpecification.Rn = 629;
            cuttingOrderSpecification.Catalog = new CatalogDto(1007318777);
            return cuttingOrderSpecification;
        }

        public void UpdateCuttingOrderSpecification(CuttingOrderSpecificationDto cuttingOrderSpecification)
        {
            return;
        }

        public void RemoveCuttingOrderSpecification(CuttingOrderSpecificationDto cuttingOrderSpecification)
        {
            return;
        }

        public IList<CuttingOrderSpecificationDto> GetCuttingOrderSpecificationFilter(CuttingOrderSpecificationFilter filter)
        {
            return Builder<CuttingOrderSpecificationDto>.CreateListOfSize(5).Build();
        }

        public CuttingOrderSpecificationDto GetCuttingOrderSpecification(long id)
        {
            return Builder<CuttingOrderSpecificationDto>.CreateNew().Build();
        }

        #endregion

        #region Sample

        public SampleDto AddSample(SampleDto sample)
        {
            sample.Rn = 629;
            sample.Catalog = new CatalogDto(1007318777);
            return sample;
        }

        public void UpdateSample(SampleDto sample)
        {
            return;
        }

        public void RemoveSample(SampleDto sample)
        {
            return;
        }

        public IList<SampleDto> GetSampleFilter(SampleFilter filter)
        {
            return Builder<SampleDto>.CreateListOfSize(5).Build();
        }

        public SampleDto GetSample(long id)
        {
            return Builder<SampleDto>.CreateNew().Build();
        }

        #endregion

        #region SampleCertification

        public SampleCertificationDto AddSampleCertification(SampleCertificationDto sampleCertification)
        {
            sampleCertification.Rn = 629;
            sampleCertification.Catalog = new CatalogDto(1007318777);
            return sampleCertification;
        }

        public void UpdateSampleCertification(SampleCertificationDto sampleCertification)
        {
            return;
        }

        public void RemoveSampleCertification(SampleCertificationDto sampleCertification)
        {
            return;
        }

        public IList<SampleCertificationDto> GetSampleCertificationFilter(SampleCertificationFilter filter)
        {
            return Builder<SampleCertificationDto>.CreateListOfSize(5).Build();
        }

        public SampleCertificationDto GetSampleCertification(long id)
        {
            return Builder<SampleCertificationDto>.CreateNew().Build();
        }

        #endregion

        #region Certification

        public CertificationDto AddCertification(CertificationDto certification)
        {
            certification.Rn = 629;
            certification.Catalog = new CatalogDto(1007318777);
            return certification;
        }

        public void UpdateCertification(CertificationDto certification)
        {
            return;
        }

        public void RemoveCertification(CertificationDto certification)
        {
            return;
        }

        public IList<CertificationDto> GetCertificationFilter(CertificationFilter filter)
        {
            return Builder<CertificationDto>.CreateListOfSize(5).Build();
        }

        public CertificationDto GetCertification(long id)
        {
            return Builder<CertificationDto>.CreateNew().Build();
        }

        #endregion


    }
}
