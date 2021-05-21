// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FakeCertificateQualityService.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the FakeCertificateQualityService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.Test.MockObjects
{
    using System;
    using System.Collections.Generic;

    using Buisness.Entities.CertificateQualityDomain;
    using Buisness.Entities.CertificateQualityDomain.ManufacturersCertificateDomain;
    using Buisness.Entities.CommonDomain;
    using Buisness.Filters;

    using FizzWare.NBuilder;

    using ParusModelLite.CertificateQualityDomain.ManufacturersCertificateDomain;
    using ParusModelLite.CertificateQualityDomain.WarehouseQualityCertificateDomain;

    using QuickGenerate;
    using QuickGenerate.Primitives;

    using ServiceContracts.Facades;

    /// <summary>
    /// The fake certificate quality service.
    /// </summary>
    public class FakeCertificateQualityService : ICertificateQualityService
    {
        public IList<WarehouseQualityCertificateRestLiteDto> GetWarehouseQualityCertificatesBy(CertificateQualityRestLiteDto certificateQuality)
        {
            throw new NotImplementedException();
        }

        public CertificateQualityDto GetCertificateQualityByWarehouse(long rn)
        {
            return Builder<CertificateQualityDto>.CreateNew().With(x => x.Rn, rn).Build();
        }

        public IList<DictionaryPassDto> GetDictionaryPass(DictionaryPassFilter filter)
        {
            var result = new DomainGenerator()
                .With<DictionaryPassDto>(x => x.For(c => c.Rn, (long)0, val => val + 1))
                .With<DictionaryPassDto>(x => x.For(c => c.MemoPass, new StringGenerator(5, 7, 'N', 'U')))
                .With<DictionaryPassDto>(x => x.For(c => c.Pass, new StringGenerator(5, 7, 'N', 'U')))
          .Many<DictionaryPassDto>(10);
            return new List<DictionaryPassDto>(result);
        }

        public IList<DictionaryChemicalIndicatorDto> GetDictionaryChemicalIndicator(DictionaryChemicalIndicatorFilter filter)
        {
            var result = new DomainGenerator()
               .With<DictionaryChemicalIndicatorDto>(x => x.For(c => c.Rn, (long)0, val => val + 1))
               .With<DictionaryChemicalIndicatorDto>(x => x.For(c => c.Name, new StringGenerator(5, 7, 'N', 'U')))
               .With<DictionaryChemicalIndicatorDto>(x => x.For(c => c.Code, new StringGenerator(5, 7, 'N', 'U')))
         .Many<DictionaryChemicalIndicatorDto>(10);
            return new List<DictionaryChemicalIndicatorDto>(result);

        }

        public IList<DictionaryMechanicalIndicatorDto> GetDictionaryMechanicalIndicator(DictionaryMechanicalIndicatorFilter filter)
        {
            var result = new DomainGenerator()
               .With<DictionaryMechanicalIndicatorDto>(x => x.For(c => c.Rn, (long)0, val => val + 1))
               .With<DictionaryMechanicalIndicatorDto>(x => x.For(c => c.Name, new StringGenerator(5, 7, 'N', 'U')))
               .With<DictionaryMechanicalIndicatorDto>(x => x.For(c => c.Code, new StringGenerator(5, 7, 'N', 'U')))
         .Many<DictionaryMechanicalIndicatorDto>(10);
            return new List<DictionaryMechanicalIndicatorDto>(result);
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
            return 123456;
        }

        public void RemoveWarehouseQualityCertificate(long Rn)
        {
           
        }
    }
}
