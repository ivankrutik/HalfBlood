// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IManufacturersCertificateService.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the IManufacturersCertificateService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using Buisness.Filters;
using Halfblood.Common;
using ParusModelLite.CertificateQualityDomain.ManufacturersCertificateDomain;

namespace ServiceContracts.Facades
{
    using System.Collections.Generic;
    using Buisness.Entities.CertificateQualityDomain.ManufacturersCertificateDomain;

    /// <summary>
    /// The ManufacturersCertificateService interface.
    /// </summary>
    public interface IManufacturersCertificateService
    {
        /// <summary>
        /// The get certificates quality filter.
        /// </summary>
        /// <param name="filter">
        /// The filter.
        /// </param>
        /// <returns>
        /// The <see cref="IList"/>.
        /// </returns>
        IList<CertificateQualityDto> GetCertificatesQualityFilter(CertificateQualityFilter filter);

        /// <summary>
        /// The get mechanic indicator value filter.
        /// </summary>
        /// <param name="filter">
        /// The filter.
        /// </param>
        /// <returns>
        /// The <see cref="IList"/>.
        /// </returns>
        IList<MechanicIndicatorValueDto> GetMechanicIndicatorValueFilter(MechanicIndicatorValueFilter filter);

        /// <summary>
        /// The update mechanic indicator value.
        /// </summary>
        /// <param name="entity">
        /// The mechanic indicator value.
        /// </param>
        void UpdateMechanicIndicatorValue(MechanicIndicatorValueDto entity);

        /// <summary>
        /// The insert mechanic indicator value.
        /// </summary>
        /// <param name="mechanicIndicatorValue">
        /// The mechanic indicator value.
        /// </param>
        /// <returns>
        /// The <see cref="MechanicIndicatorValueDto"/>.
        /// </returns>
        MechanicIndicatorValueDto InsertMechanicIndicatorValue(MechanicIndicatorValueDto entity);

        /// <summary>
        /// The get chemical indicator value filter.
        /// </summary>
        /// <param name="filter">
        /// The filter.
        /// </param>
        /// <returns>
        /// The <see cref="IList"/>.
        /// </returns>
        IList<ChemicalIndicatorValueDto> GetChemicalIndicatorValueFilter(ChemicalIndicatorValueFilter filter);

        /// <summary>
        /// The update chemical indicator value.
        /// </summary>
        /// <param name="entity">
        /// The chemical indicator value.
        /// </param>
        void UpdateChemicalIndicatorValue(ChemicalIndicatorValueDto entity);

        /// <summary>
        /// The insert chemical indicator value.
        /// </summary>
        /// <param name="entity">
        /// The chemical indicator value.
        /// </param>
        /// <returns>
        /// The <see cref="ChemicalIndicatorValueDto"/>.
        /// </returns>
        ChemicalIndicatorValueDto InsertChemicalIndicatorValue(ChemicalIndicatorValueDto entity);

        /// <summary>
        /// The update certificate quality.
        /// </summary>
        /// <param name="entity">
        /// The certificate quality.
        /// </param>
        void UpdateCertificateQuality(CertificateQualityDto entity);

        /// <summary>
        /// The insert certificate quality.
        /// </summary>
        /// <param name="entity">
        /// The certificate quality.
        /// </param>
        /// <returns>
        /// The <see cref="CertificateQualityDto"/>.
        /// </returns>
        CertificateQualityDto InsertCertificateQuality(CertificateQualityDto entity);
        
        
        IList<CertificateQualityLiteDto> GetCertificatesQualityFilterForView(CertificateQualityFilter filter);
        IList<CertificateQualityRestLiteDto> GetCertificatesQualityRestFilterForView(CertificateQualityFilter filter);
        

        IList<PassDto> GetPass(PassFilter filter);
        PassDto InsertPass(PassDto entity);
        void RemovePass(PassDto entity);
        void UpdatePass(PassDto entity);

        void SetStatus(long rn, QualityCertificateState state);
    }
}
