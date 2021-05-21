using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Buisness.Entities.PlanReceiptOrderDomain;
using Buisness.Entities.PlanReceiptOrderDomain.CertificateQuality;
using NUnit.Framework;
using ParusModel.WorkOrderDomain;
using ParusModel.WorkOrderDomain.ActInputControlDomain;
using ServiceContracts.PlanReceiptOrderDomain;

namespace Halfblood.UnitTests.BuisnesWorkflow.Tests
{
    public class CertificatQualityTest : TestBase
    {
        [Test]
        public void GetCertificatesQuality()
        {
            _nhHelper.Create(Mapper.Map<CertificateQuality>(SampleEntityDto.CreateCertificateQuality()));

            _helper.CreateCoordinatorOfServices(serviceScope =>
            {
                IPlanReceiptOrderService service = serviceScope.CreatePlanService();
                var filterDto = new CertificateQualityDto();
                const int skip = 0;
                const int take = 0;
                int total;

                IEnumerable<CertificateQualityDto> result =
                    service.GetCertificatesQualityFilter(filterDto, skip, take, out total);

                Assert.That(result.Any(), Is.True);
                Assert.That(total, Is.GreaterThanOrEqualTo(1));
            });
        }


        public override void SetUp()
        {
            base.SetUp();

        }


        [Test]
        public void InsertCertificatQuality()
        {
            OnTestOfCreate(
                service => service.AddCertificatQuality(SampleEntityDto.CreateCertificateQuality()));
        }
        [Test]
        public void RemoveCertificatQuality()
        {
            CertificateQualityDto solution = SampleEntityDto.CreateCertificateQuality();
            OnTestOfRemove<CertificateQualityDto, CertificateQuality>(
                ref solution,
                service => service.RemoveCertificatQuality(solution));
        }
        [Test]
        public void UpdateCertificatQuality()
        {
            CertificateQualityDto solution = SampleEntityDto.CreateCertificateQuality();
            OnTestOfUpdate<CertificateQualityDto, CertificateQuality>(
                ref solution,
                service => { solution.GOSTCAST = "new note!!!!"; service.UpdateCertificatQuality(solution); },
                (dto, entity) => dto.GOSTCAST == entity.GOSTCAST);
        }
        [Test]
        public void GetCertificateQualityPass()
        {
            PassDto passDto = SampleEntityDto.CreatePassDto();
            passDto.RN = _nhHelper.Create(Mapper.Map<Pass>(passDto));

            _helper.CreateCoordinatorOfServices(serviceScope =>
            {
                IPlanReceiptOrderService service = serviceScope.CreatePlanService();
                var filterDto = new PassDto();
                const int skip = 0;
                const int take = 0;
                int total;

                IEnumerable<PassDto> result =
                    service.GetPass(filterDto, skip, take, out total);

                Assert.That(result.Any(), Is.True);
            });
        }
        [Test]
        public void InsertPass()
        {
            OnTestOfCreate(service =>
                service.InsertPass(SampleEntityDto.CreatePassDto()));
        }
        [Test]
        public void UpdatePass()
        {
            PassDto solution = SampleEntityDto.CreatePassDto();
            OnTestOfUpdate<PassDto, Pass>(
                ref solution,
                service => { solution.Note = "new note!!!!"; service.UpdatePass(solution); },
                (dto, entity) => dto.Note == entity.Note);
        }
        [Test]
        public void RemovePass()
        {
            PassDto solution = SampleEntityDto.CreatePassDto();
            OnTestOfRemove<PassDto, Pass>(
                ref solution,
                service => service.RemovePass(solution));
        }
    }
}