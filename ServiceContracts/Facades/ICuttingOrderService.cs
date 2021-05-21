// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICuttingOrderService.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The CuttingOrderService interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Buisness.Filters;

namespace ServiceContracts.Facades
{
    using System.Collections.Generic;

    using Buisness.Entities.CuttingOrderDomain;
    using ParusModelLite.CuttingOrderDomain;

    /// <summary>
    /// The CuttingOrderService interface.
    /// </summary>
    public interface ICuttingOrderService
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
        CuttingOrderDto AddCuttingOrder(CuttingOrderDto cuttingOrder);

        /// <summary>
        /// The update cutting order.
        /// </summary>
        /// <param name="cuttingOrder">
        /// The cutting order.
        /// </param>
        void UpdateCuttingOrder(CuttingOrderDto cuttingOrder);

        /// <summary>
        /// The remove cutting order.
        /// </summary>
        /// <param name="cuttingOrder">
        /// The cutting order.
        /// </param>
        void RemoveCuttingOrder(CuttingOrderDto cuttingOrder);

        /// <summary>
        /// The get cutting order filter.
        /// </summary>
        /// <param name="filter">
        /// The filter.
        /// </param>
        /// <returns>
        /// The <see cref="IList"/>.
        /// </returns>
        IList<CuttingOrderDto> GetCuttingOrderFilter(CuttingOrderFilter filter);

        /// <summary>
        /// The get cutting order for view.
        /// </summary>
        /// <param name="filter">
        /// The filter.
        /// </param>
        /// <returns>
        /// The <see cref="IList"/>.
        /// </returns>
        IList<CuttingOrderLiteDto> GetCuttingOrderForView(CuttingOrderFilter filter);

        /// <summary>
        /// The get cutting order.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="CuttingOrderDto"/>.
        /// </returns>
        CuttingOrderDto GetCuttingOrder(long id);
        #endregion

        #region CuttingOrderMove

        /// <summary>
        /// The add cutting order move.
        /// </summary>
        /// <param name="cuttingOrderMove">
        /// The cutting order move.
        /// </param>
        /// <returns>
        /// The <see cref="CuttingOrderMoveDto"/>.
        /// </returns>
        CuttingOrderMoveDto AddCuttingOrderMove(CuttingOrderMoveDto cuttingOrderMove);

        /// <summary>
        /// The update cutting order move.
        /// </summary>
        /// <param name="cuttingOrderMove">
        /// The cutting order move.
        /// </param>
        void UpdateCuttingOrderMove(CuttingOrderMoveDto cuttingOrderMove);

        /// <summary>
        /// The remove cutting order move.
        /// </summary>
        /// <param name="cuttingOrderMove">
        /// The cutting order move.
        /// </param>
        void RemoveCuttingOrderMove(CuttingOrderMoveDto cuttingOrderMove);

        /// <summary>
        /// The get cutting order move filter.
        /// </summary>
        /// <param name="filter">
        /// The filter.
        /// </param>
        /// <returns>
        /// The <see cref="IList"/>.
        /// </returns>
        IList<CuttingOrderMoveDto> GetCuttingOrderMoveFilter(CuttingOrderMoveFilter filter);

        /// <summary>
        /// The get cutting order move.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="CuttingOrderMoveDto"/>.
        /// </returns>
        CuttingOrderMoveDto GetCuttingOrderMove(long id);
        #endregion

        #region CuttingOrderSpecification

        /// <summary>
        /// The add cutting order specification.
        /// </summary>
        /// <param name="cuttingOrderSpecification">
        /// The cutting order specification.
        /// </param>
        /// <returns>
        /// The <see cref="CuttingOrderSpecificationDto"/>.
        /// </returns>
        CuttingOrderSpecificationDto AddCuttingOrderSpecification(CuttingOrderSpecificationDto cuttingOrderSpecification);

        /// <summary>
        /// The update cutting order specification.
        /// </summary>
        /// <param name="cuttingOrderSpecification">
        /// The cutting order specification.
        /// </param>
        void UpdateCuttingOrderSpecification(CuttingOrderSpecificationDto cuttingOrderSpecification);

        /// <summary>
        /// The remove cutting order specification.
        /// </summary>
        /// <param name="cuttingOrderSpecification">
        /// The cutting order specification.
        /// </param>
        void RemoveCuttingOrderSpecification(CuttingOrderSpecificationDto cuttingOrderSpecification);

        /// <summary>
        /// The get cutting order specification filter.
        /// </summary>
        /// <param name="filter">
        /// The filter.
        /// </param>
        /// <returns>
        /// The <see cref="IList"/>.
        /// </returns>
        IList<CuttingOrderSpecificationDto> GetCuttingOrderSpecificationFilter(CuttingOrderSpecificationFilter filter);

        /// <summary>
        /// The get cutting order specification.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="CuttingOrderSpecificationDto"/>.
        /// </returns>
        CuttingOrderSpecificationDto GetCuttingOrderSpecification(long id);
        #endregion

        #region Sample

        /// <summary>
        /// The add sample.
        /// </summary>
        /// <param name="sample">
        /// The sample.
        /// </param>
        /// <returns>
        /// The <see cref="SampleDto"/>.
        /// </returns>
        SampleDto AddSample(SampleDto sample);

        /// <summary>
        /// The update sample.
        /// </summary>
        /// <param name="sample">
        /// The sample.
        /// </param>
        void UpdateSample(SampleDto sample);

        /// <summary>
        /// The remove sample.
        /// </summary>
        /// <param name="sample">
        /// The sample.
        /// </param>
        void RemoveSample(SampleDto sample);

        /// <summary>
        /// The get sample filter.
        /// </summary>
        /// <param name="filter">
        /// The filter.
        /// </param>
        /// <returns>
        /// The <see cref="IList"/>.
        /// </returns>
        IList<SampleDto> GetSampleFilter(SampleFilter filter);

        /// <summary>
        /// The get sample.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="SampleDto"/>.
        /// </returns>
        SampleDto GetSample(long id);
        #endregion

        #region SampleCertification

        /// <summary>
        /// The add sample certification.
        /// </summary>
        /// <param name="sampleCertification">
        /// The sample certification.
        /// </param>
        /// <returns>
        /// The <see cref="SampleCertificationDto"/>.
        /// </returns>
        SampleCertificationDto AddSampleCertification(SampleCertificationDto sampleCertification);

        /// <summary>
        /// The update sample certification.
        /// </summary>
        /// <param name="sampleCertification">
        /// The sample certification.
        /// </param>
        void UpdateSampleCertification(SampleCertificationDto sampleCertification);

        /// <summary>
        /// The remove sample certification.
        /// </summary>
        /// <param name="sampleCertification">
        /// The sample certification.
        /// </param>
        void RemoveSampleCertification(SampleCertificationDto sampleCertification);

        /// <summary>
        /// The get sample certification filter.
        /// </summary>
        /// <param name="filter">
        /// The filter.
        /// </param>
        /// <returns>
        /// The <see cref="IList"/>.
        /// </returns>
        IList<SampleCertificationDto> GetSampleCertificationFilter(SampleCertificationFilter filter);

        /// <summary>
        /// The get sample certification.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="SampleCertificationDto"/>.
        /// </returns>
        SampleCertificationDto GetSampleCertification(long id);
        #endregion

        #region Certification

        /// <summary>
        /// The add certification.
        /// </summary>
        /// <param name="certification">
        /// The certification.
        /// </param>
        /// <returns>
        /// The <see cref="CertificationDto"/>.
        /// </returns>
        CertificationDto AddCertification(CertificationDto certification);

        /// <summary>
        /// The update certification.
        /// </summary>
        /// <param name="certification">
        /// The certification.
        /// </param>
        void UpdateCertification(CertificationDto certification);

        /// <summary>
        /// The remove certification.
        /// </summary>
        /// <param name="certification">
        /// The certification.
        /// </param>
        void RemoveCertification(CertificationDto certification);

        /// <summary>
        /// The get certification filter.
        /// </summary>
        /// <param name="filter">
        /// The filter.
        /// </param>
        /// <returns>
        /// The <see cref="IList"/>.
        /// </returns>
        IList<CertificationDto> GetCertificationFilter(CertificationFilter filter);

        /// <summary>
        /// The get certification.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="CertificationDto"/>.
        /// </returns>
        CertificationDto GetCertification(long id);
        #endregion
    }
}
