// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CertificateQualityService.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the CertificateQualityService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Workflows.Services.CertificateQualityDomain
{
    using System;
    using System.Collections.Generic;

    using Buisness.Components.StoredProcedure.Common;
    using Buisness.Entities.CertificateQualityDomain;
    using Buisness.Entities.CertificateQualityDomain.ManufacturersCertificateDomain;
    using Buisness.Entities.CommonDomain;
    using Buisness.Filters;
    using Buisness.Workflows.Managers.ExpenditureInvoiceDomain;

    using Halfblood.Common;
    using Halfblood.Common.Mappers;

    using NHibernate.Helper.Filter;
    using NHibernate.Helper.Repository;
    using NHibernate.Helper.Service;

    using ParusModel.Entities.CertificateQualityDomain;
    using ParusModel.Entities.CertificateQualityDomain.ManufacturersCertificateDomain;
    using ParusModelLite.CertificateQualityDomain.ManufacturersCertificateDomain;
    using ParusModelLite.CertificateQualityDomain.WarehouseQualityCertificateDomain;

    using ServiceContracts.Facades;
    using StoreGasStationOilDepot = ParusModel.Entities.StoreGasStationOilDepot;

    [Register(typeof(ICertificateQualityService))]
    public class CertificateQualityService : ServiceBase, ICertificateQualityService
    {
        public CertificateQualityService(
            IRepositoryFactory repositoryFactory,
            IFilterStrategyFactory filterStrategyFactory)
            : base(repositoryFactory, filterStrategyFactory)
        {
        }

        public IList<DictionaryPassDto> GetDictionaryPass(DictionaryPassFilter filter)
        {
            return this.GetEntities<DictionaryPassFilter, DictionaryPass, DictionaryPassDto>(filter);
        }
        public IList<DictionaryChemicalIndicatorDto> GetDictionaryChemicalIndicator(DictionaryChemicalIndicatorFilter filter)
        {
            return this.GetEntities<DictionaryChemicalIndicatorFilter, DictionaryChemicalIndicator, DictionaryChemicalIndicatorDto>(filter);
        }
        public IList<DictionaryMechanicalIndicatorDto> GetDictionaryMechanicalIndicator(DictionaryMechanicalIndicatorFilter filter)
        {
            return this.GetEntities<DictionaryMechanicalIndicatorFilter, DictionaryMechanicalIndicator, DictionaryMechanicalIndicatorDto>(filter);
        }
        public long TakeMaterial(
            decimal quantity,
            DateTime dateOfBook,
            string numberOfBook,
            StoreGasStationOilDepotDto storeGasStationOilDepot,
            CertificateQualityRestLiteDto certificateQuality,
            EmployeeDto controller,
            EmployeeDto customer)
        {
            var man = new ExpenditureInvoiceManager(RepositoryFactory);
            return man.TakeMaterial(
                quantity,
                dateOfBook,
                numberOfBook,
                storeGasStationOilDepot.MapTo<StoreGasStationOilDepot>(),
                certificateQuality.Rn,
                controller,
                customer);
        }

        public void RemoveWarehouseQualityCertificate(long rn)
        {
            var man =new ExpenditureInvoiceManager(RepositoryFactory);
            man.Remove(rn);
        }

        public CertificateQualityDto GetCertificateQualityByWarehouse(long rn)
        {
            var certificateQuality =
                RepositoryFactory.Create<CertificateQuality>()
                    .ExecuteSPUniqueResult<CertificateQuality>(new GetCertificateQualitySP(rn));

            return certificateQuality.MapTo<CertificateQualityDto>();
        }
        public IList<WarehouseQualityCertificateRestLiteDto> GetWarehouseQualityCertificatesBy(
            CertificateQualityRestLiteDto certificateQuality)
        {
            var result =
                RepositoryFactory.Create<WarehouseQualityCertificateLiteDto>()
                    .ExecuteSPResultList<WarehouseQualityCertificateLiteDto>(
                        new GetWarehouseQualityCertificate(certificateQuality.Rn));

            return result.MapTo<WarehouseQualityCertificateRestLiteDto>();
        }
    }
}
