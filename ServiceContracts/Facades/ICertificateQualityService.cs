// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICertificateQualityService.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The CertificateQualityService interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ServiceContracts.Facades
{
    using System;
    using System.Collections.Generic;

    using Buisness.Entities.CertificateQualityDomain;
    using Buisness.Entities.CertificateQualityDomain.ManufacturersCertificateDomain;
    using Buisness.Entities.CommonDomain;
    using Buisness.Filters;

    using ParusModelLite.CertificateQualityDomain.ManufacturersCertificateDomain;
    using ParusModelLite.CertificateQualityDomain.WarehouseQualityCertificateDomain;

    public interface ICertificateQualityService
    {
        IList<DictionaryPassDto> GetDictionaryPass(DictionaryPassFilter filter);

        IList<DictionaryChemicalIndicatorDto> GetDictionaryChemicalIndicator(DictionaryChemicalIndicatorFilter filter);

        IList<DictionaryMechanicalIndicatorDto> GetDictionaryMechanicalIndicator(
            DictionaryMechanicalIndicatorFilter filter);

        IList<WarehouseQualityCertificateRestLiteDto> GetWarehouseQualityCertificatesBy(
            CertificateQualityRestLiteDto certificateQuality);

        CertificateQualityDto GetCertificateQualityByWarehouse(long rn);

        long TakeMaterial(
            decimal quantity,
            DateTime dateOfBook,
            string numberOfBook,
            StoreGasStationOilDepotDto storeGasStationOilDepot,
            CertificateQualityRestLiteDto certificateQuality,
            EmployeeDto controller,
            EmployeeDto customer);

        void RemoveWarehouseQualityCertificate(long rn);
    }
}
