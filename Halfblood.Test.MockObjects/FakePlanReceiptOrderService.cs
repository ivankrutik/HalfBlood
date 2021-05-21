// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FakePlanReceiptOrderService.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The fake plan receipt order service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.Test.MockObjects
{
    using System;
    using System.Collections.Generic;

    using Buisness.Entities;
    using Buisness.Entities.CertificateQualityDomain.ManufacturersCertificateDomain;
    using Buisness.Entities.CommonDomain;
    using Buisness.Entities.PlanReceiptOrderDomain;
    using Buisness.Filters;

    using FizzWare.NBuilder;

    using Halfblood.Common;

    using ParusModelLite.PlanReceiptOrderDomain;

    using ServiceContracts.Facades;

    /// <summary>
    /// The fake plan receipt order service.
    /// </summary>
    public class FakePlanReceiptOrderService : IPlanReceiptOrderService
    {
        public virtual void PlanReceiptOrderChangeState(PlanReceiptOrderDto planReceiptOrder, PlanReceiptOrderState state)
        {
            throw new NotImplementedException();
        }
        public virtual PlanReceiptOrderDto AddPlanReceiptOrder(PlanReceiptOrderDto entity)
        {
            entity.Rn = 999;
            entity.Catalog = new CatalogDto(1007318777);
            return entity;
        }
        public IList<PersonalAccountOfPlanReceiptOrderLiteDto> GetPlanReceiptOrderPersonalAccountForViewFilter(PlanReceiptOrderPersonalAccountFilter filter)
        {
            return Builder<PersonalAccountOfPlanReceiptOrderLiteDto>.CreateListOfSize(10).Build();
        }

        public PlanReceiptOrderPersonalAccountWithoutPlanCertificateDto GetPlanReceiptOrderPersonalAccountWithoutPlanCertificate(
            long id)
        {
            return Builder<PlanReceiptOrderPersonalAccountWithoutPlanCertificateDto>.CreateNew().Do(x => x.Rn = id).Build();
        }

        public PlanReceiptOrderWithoutPlanCertificateDto GetPlanReceiptOrderWithoutPlanCertificateDto(long id)
        {
            return Builder<PlanReceiptOrderWithoutPlanCertificateDto>.CreateNew().Do(x => x.Rn = id).Build();
        }

        public PlanCertificateDto GetPlanCertificate(long id)
        {
            return
                Builder<PlanCertificateDto>.CreateNew()
                    .Do(x => x.Rn = id)
                    .With(x => x.CertificateQuality, Builder<CertificateQualityDto>.CreateNew().Build())
                    .Do(x => x.CertificateQuality.PlanCertificate = x)
                    .Build();
        }
        public PlanReceiptOrderDto GetPlanReceiptOrder(long id)
        {
            return Builder<PlanReceiptOrderDto>.CreateNew().With(x => x.Rn, id).Build();
        }
        public PlanReceiptOrderPersonalAccountDto GetPlanReceiptOrderPersonalAccount(long id)
        {
            return Builder<PlanReceiptOrderPersonalAccountDto>.CreateNew().With(x => x.Rn, id).Build();
        }
        public IList<PlanReceiptOrderLiteDto> GetPlanReceiptOrderForView(PlanReceiptOrderFilter filter)
        {
            return Builder<PlanReceiptOrderLiteDto>.CreateListOfSize(10).Build();
        }
        public virtual IList<PlanReceiptOrderDto> GetPlanReceiptOrderFilter(PlanReceiptOrderFilter filter)
        {
            return Builder<PlanReceiptOrderDto>.CreateListOfSize(10)
                                               .All()
                                               .With(x => x.Catalog, Builder<CatalogDto>.CreateNew().Build())
                                               .With(x => x.UserContractor, Builder<UserDto>.CreateNew().Build())
                                               .With(x => x.UserCreator, Builder<UserDto>.CreateNew().Build())
                                               .With(x => x.StaffingDivision, Builder<StaffingDivisionDto>.CreateNew().Build())
                                               .With(x => x.StoreGasStationOilDepot, Builder<StoreGasStationOilDepotDto>.CreateNew().Build())
                                               .With(x => x.GroundTypeOfDocument, Builder<TypeOfDocumentDto>.CreateNew().Build())
                                               .With(x => x.GroundReceiptTypeOfDocument, Builder<TypeOfDocumentDto>.CreateNew().Build())
                                               .Build();
        }
        public virtual IList<PlanCertificateDto> GetPlanCertificatFilter(PlanCertificateFilter filter)
        {
            return
                Builder<PlanCertificateDto>.CreateListOfSize(5)
                                           .All()
                                           .With(
                                               x => x.CertificateQuality,
                                               Builder<CertificateQualityDto>.CreateNew()
                                                                             .With(
                                                                                 x => x.ChemicalIndicatorValues,
                                                                                 Builder<ChemicalIndicatorValueDto>
                                                                                     .CreateListOfSize(10).Build())
                                                                             .Build())
                                           .Build();
        }
        public virtual void UpdatePlanReceiptOrder(PlanReceiptOrderDto entity)
        {
            //TO DO
        }
        public virtual IList<PlanReceiptOrderPersonalAccountDto> GetPlanReceiptOrderPersonalAccountFilter(
            PlanReceiptOrderPersonalAccountFilter filter)
        {
            return Builder<PlanReceiptOrderPersonalAccountDto>.CreateListOfSize(10).Build();
        }
        public virtual void UpdatePlanCertificate(PlanCertificateDto entity)
        {
        }
        public virtual void UpdatePersonalAccount(PlanReceiptOrderPersonalAccountDto entity)
        {
        }
        public virtual PlanCertificateDto AddPlanCertificate(PlanCertificateDto entity)
        {
            entity.Rn = 100;
            return entity;
        }
        public virtual PlanReceiptOrderPersonalAccountDto AddPlanReceiptOrderPersonalAccount(
            PlanReceiptOrderPersonalAccountDto entity)
        {
            entity.Rn = 999;
            return entity;
        }
        public IList<PlanCertificateLiteDto> GetPlanCertificateForViewFilter(PlanCertificateFilter filter)
        {
            return
                Builder<PlanCertificateLiteDto>.CreateListOfSize(5)
                                                  .Build();
        }

        public void SetStatePlanReceiptOrder(long id, PlanReceiptOrderState newState)
        {
        }

        public void SetStatePlanCertificate(long id, PlanCertificateState newState)
        {
        }

        public void SetStatusPersonalAccount(long id, PlanReceiptOrderPersonalAccountState newState)
        {
            
        }

        public void SetStatusPlanCertificate(long id, PlanCertificateState newState)
        {
        }

        public void SetGroupPersonalAccountPlanReceiptOrder(PlanReceiptOrderDto entity, PersonalAccountDto personalAccount)
        {
            throw new NotImplementedException();
        }

        public void SetGroupStatusPlanCertificate(PlanCertificateDto planCertificate, PersonalAccountDto personalAccount)
        {
        }

        public void SetGroupStatusPlanReceiptOrder(PlanReceiptOrderDto planReceiptOrderDto, PersonalAccountDto personalAccount)
        {
            
        }

        public void ClosePlanReceiptOrder(PlanReceiptOrderDto entity)
        {
            entity.State = PlanReceiptOrderState.Confirm;
        }

        public void RemovePlanReceiptOrder(long rn)
        {
        }

        public void RemovePlanCertificate(long  rn)
        {
        }

        public void RemovePlanReceiptOrderPersonalAccount(long rn)
        {
        }

        public virtual string FailedMethod()
        {
            throw new Exception("Fail!");
        }
    }
}
