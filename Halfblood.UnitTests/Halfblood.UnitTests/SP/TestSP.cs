// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestSP.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the TestSP type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.UnitTests.SP
{
    using System;
    using System.Collections.Generic;

    using Buisness.Components.StoredProcedure;
    using Buisness.Components.StoredProcedure.Common;
    using Buisness.Components.StoredProcedure.PlanReceiptOrderDomain;

    using Halfblood.Common;
    using Halfblood.UnitTests.BuisnesWorkflow.Tests;

    using NHibernate.Helper.Filter.Specification;

    using NUnit.Framework;

    using ParusModel.Entities;
    using ParusModel.Entities.CertificateQualityDomain.ManufacturersCertificateDomain;
    using ParusModel.Entities.ExpenditureInvoiceDomain;
    using ParusModel.Entities.PlanReceiptOrderDomain;

    public class TestSP : AutoRollbackFixtureEx
    {
        [Test]
        public void GetMemo()
        {
            var sp = new GetMemoCode("Contractor", "rn", 264799417, "agnabbr");
            var memo = Session.ExecuteSp(sp).UniqueResult<string>();
            Assert.That(memo, Is.EqualTo("0013796"));
            Assert.That(memo, Is.EqualTo("0013796"));
        }

        [Test]
        public void SetStatusPCO()
        {
            var entity = Session.QueryOver<PlanReceiptOrder>().Take(1).SingleOrDefault<PlanReceiptOrder>();
            var sp = new PlanReceiptOrderSetState(entity, PlanReceiptOrderState.Confirm);
            Session.ExecuteSp(sp).ExecuteUpdate();
        }

        [Test]
        public void SetStatusPCOSertificat()
        {
            var entity = Session.QueryOver<PlanCertificate>().Take(1).SingleOrDefault<PlanCertificate>();
            var sp = new PlanCertificateSetStateSP(entity, PlanCertificateState.Close);
            Session.ExecuteSp(sp).UniqueResult();
        }

        [Test]
        public void SetStatusPlanReceiptOrderPersonalAccount()
        {
            var entity = Session.QueryOver<PlanReceiptOrderPersonalAccount>().SingleOrDefault<PlanReceiptOrderPersonalAccount>();
            var sp = new PersonalAccountSetStateSP(
               entity,
                PlanReceiptOrderPersonalAccountState.Close);
            Session.ExecuteSp(sp).UniqueResult();
        }

        [Test]
        public void GetAgnlistWithDepartmentTest()
        {
            var sp = new GetAgnlistWithDepartment();
            var result = (IList<object>)Session.ExecuteSp(sp).List()[0];

            Assert.That(((Contractor)result[0]).Rn, Is.EqualTo(275137236));
            Assert.That(result[1], Is.EqualTo("136/69 Склад №469"));
            Assert.That(result[2], Is.EqualTo("136/69"));
        }

        [Test]
        public void GetCertificateQualityByWarehouse()
        {
            var sp = new GetCertificateQualitySP(100);
            var result = Session.ExecuteSp(sp).UniqueResult<CertificateQuality>();

            Assert.That(result, Is.Not.Null);
        }
        [Test]
        public void CreditSlipSetState()
        {
            var entity = SampleEntity.CreateCreditSlipSpecification(null, Session);
            entity.CreditSlip.WorkDate = entity.CreditSlip.INDOCDATE;
            Session.Save(entity);
            var sp = new CreditSlipSetStateSP(entity.CreditSlip, CreditSlipState.FulfilledPlan);
            var result = Session.ExecuteSp(sp).ExecuteUpdate();

            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void ChangeStatusExpenditureInvoice()
        {
            var entity =
                Session.QueryOver<ExpenditureInvoice>()
                    .Where(x => x.Status == InvoiceForTransmissionInUnitState.NotWork)
                    .Where(x => x.InStatus == InvoiceForTransmissionInUnitInState.Not)
                    .Take(1)
                    .UnderlyingCriteria.UniqueResult<ExpenditureInvoice>();

            var sp = new ChangeStatusExpenditureInvoiceSP(
                entity,
                InvoiceForTransmissionInUnitState.WorkFact,
                InvoiceForTransmissionInUnitInState.Yes,
                new DateTime(2013, 12, 2),
                new DateTime(2013, 12, 2));

            var result = Session.ExecuteSp(sp).ExecuteUpdate();

            Assert.That(result, Is.Not.Null);
        }
    }
}