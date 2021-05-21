// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FakeManufacturersCertificateService.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the FakeManufacturersCertificateService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Linq;
using Buisness.Filters;
using Halfblood.Common;
using ParusModelLite.CertificateQualityDomain.ManufacturersCertificateDomain;
using QuickGenerate;

namespace Halfblood.Test.MockObjects
{
    using System;
    using System.Collections.Generic;

    using Buisness.Entities.CertificateQualityDomain;
    using Buisness.Entities.CertificateQualityDomain.ManufacturersCertificateDomain;
    using FizzWare.NBuilder;

    using ServiceContracts.Facades;

    public class FakeManufacturersCertificateService : IManufacturersCertificateService
    {
        public virtual IList<CertificateQualityDto> GetCertificatesQualityFilter(CertificateQualityFilter filter)
        {
            return Builder<CertificateQualityDto>.CreateListOfSize(10)
                .All()
                .With(x => x.ChemicalIndicatorValues, Builder<ChemicalIndicatorValueDto>.CreateListOfSize(10).Build())
                .Build();
        }

        public IList<MechanicIndicatorValueDto> GetMechanicIndicatorValueFilter(MechanicIndicatorValueFilter filter)
        {
            return Builder<MechanicIndicatorValueDto>.CreateListOfSize(10).Build();
        }

        public void UpdateMechanicIndicatorValue(MechanicIndicatorValueDto entity)
        {
            throw new NotImplementedException();
        }

        public MechanicIndicatorValueDto InsertMechanicIndicatorValue(MechanicIndicatorValueDto entity)
        {
            throw new NotImplementedException();
        }

        public IList<ChemicalIndicatorValueDto> GetChemicalIndicatorValueFilter(ChemicalIndicatorValueFilter filter)
        {
            return
                Builder<ChemicalIndicatorValueDto>.CreateListOfSize(50)
                .TheFirst(1)
                .With(x => x.ChemicalIndicator, new DictionaryChemicalIndicatorDto { Name = "H2SO5" })
                .TheNext(1)
                .With(x => x.ChemicalIndicator, new DictionaryChemicalIndicatorDto { Name = "Сера" })
                .TheNext(1)
                .With(x => x.ChemicalIndicator, new DictionaryChemicalIndicatorDto { Name = "Водород" })
                .All()
                .With(x => x.ChemicalIndicator, new DictionaryChemicalIndicatorDto { Name = "H2SO4" })
                .Build();
        }

        public void UpdateChemicalIndicatorValue(ChemicalIndicatorValueDto entity)
        {
            throw new NotImplementedException();
        }

        public ChemicalIndicatorValueDto InsertChemicalIndicatorValue(ChemicalIndicatorValueDto entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateCertificateQuality(CertificateQualityDto entity)
        {
            throw new NotImplementedException();
        }

        public CertificateQualityDto InsertCertificateQuality(CertificateQualityDto entity)
        {
            throw new NotImplementedException();
        }

        public IList<CertificateQualityLiteDto> GetCertificatesQualityFilterForView(CertificateQualityFilter filter)
        {

            return Builder<CertificateQualityLiteDto>.CreateListOfSize(10)
                .All()
               .Build();
        }

        public IList<CertificateQualityRestLiteDto> GetCertificatesQualityRestFilterForView(CertificateQualityFilter filter)
        {

            return Builder<CertificateQualityRestLiteDto>.CreateListOfSize(10)
                .All()
               .Build();
        }

        public virtual PassDto InsertPass(PassDto passDto)
        {
            throw new NotImplementedException();
        }

        public virtual void RemovePass(PassDto passDto)
        {
            throw new NotImplementedException();
        }

        public virtual void UpdatePass(PassDto pass)
        {
            throw new NotImplementedException();
        }

        public void SetStatus(long rn, QualityCertificateState state)
        {
            throw new NotImplementedException();
        }

        public virtual CertificateQualityDto AddCertificatQuality(CertificateQualityDto certificat)
        {
            throw new NotImplementedException();
        }
        public virtual void RemoveCertificatQuality(CertificateQualityDto certificat)
        {
            throw new NotImplementedException();
        }
        public virtual void UpdateCertificatQuality(CertificateQualityDto certificat)
        {
            throw new NotImplementedException();
        }

        public virtual IList<PassDto> GetPass(PassFilter filter)
        {
            var result = new DomainGenerator()
                .With<PassDto>(x => x.For(c => c.Rn, (long)0, val => val + 1))
                .Many<PassDto>(10).ToList();

            return result;
        }

    }
}
