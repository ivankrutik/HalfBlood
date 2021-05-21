using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Buisness.Entities.Common;
using Buisness.Entities.PlanReceiptOrderDomain;
using Buisness.Entities.PlanReceiptOrderDomain.CertificateQuality.ActInputControl;
using NUnit.Framework;
using ParusModel.WorkOrderDomain;
using ParusModel.WorkOrderDomain.ActInputControlDomain;
using ServiceContracts.PlanReceiptOrderDomain;

namespace Halfblood.UnitTests.BuisnesWorkflow.Tests
{
    public class ActInputControlTest : TestBase
    {
        [Test]
        public void InsertActInputControl()
        {
            OnTestOfCreate(service =>
                service.AddActInputControl(SampleEntityDto.CreateActInputControl()));
        }
        [Test]
        public void GetActsInputControl()
        {
            var rn = _nhHelper.Create<ActInputControl>(Mapper.Map<ActInputControl>(SampleEntityDto.CreateActInputControl()), true);
            _helper.CreateCoordinatorOfServices(serviceScope =>
            {
                IPlanReceiptOrderService service = serviceScope.CreatePlanService();
                var filterDto = new ActInputControlDto();
                filterDto.RN = rn;
                const int skip = 0;
                const int take = 0;
                int total;


                IEnumerable<ActInputControlDto> result =
                    service.GetActsInputControlFilter(filterDto, skip, take, out total);

                Assert.That(result, Is.Not.Null);
            });
        }
        [Test]
        public void UpdateActInputControl()
        {
            ActInputControlDto act = SampleEntityDto.CreateActInputControl();
            OnTestOfUpdate<ActInputControlDto, ActInputControl>(
                ref act,
                service => {  service.UpdateActInputControl(act); },
                (dto, entity) => dto.Note == entity.Note);
        }
        [Test]
        public void RemoveActInputControl()
        {
            ActInputControlDto act = SampleEntityDto.CreateActInputControl();
            OnTestOfRemove<ActInputControlDto, ActInputControl>(
                ref act,
                service => service.RemoveActInputControl(act));
        }
        [Test]
        public void GetTheMoveAct()
        {
            var rn = _nhHelper.Create<TheMoveAct>(Mapper.Map<TheMoveAct>(SampleEntityDto.CreateTheMoveAct()));
            _helper.CreateCoordinatorOfServices(serviceScope =>
            {
                var actm = new TheMoveActDto { RN = rn };
                IPlanReceiptOrderService service = serviceScope.CreatePlanService();
                const int skip = 0;
                const int take = 0;
                int total;

                var result = service.GetTheMoveActFilter(actm, skip, take, out total);
                Assert.That(result.Any(), Is.True);
            });
        }
        [Test]
        public void InsertTheMoveAct()
        {
            OnTestOfCreate(service =>
                service.AddTheMoveAct(SampleEntityDto.CreateTheMoveAct()));
        }
        [Test]
        public void RemoveTheMoveAct()
        {
            TheMoveActDto theMove = SampleEntityDto.CreateTheMoveAct();
            OnTestOfRemove<TheMoveActDto, TheMoveAct>(
                ref theMove,
                service => service.RemoveTheMoveAct(theMove));
        }
        [Test]
        public void GetConclusionEssential()
        {
            var rn = _nhHelper.Create<ConclusionEssential>(Mapper.Map<ConclusionEssential>(SampleEntityDto.CreateConclusionEssential()), true);
            _helper.CreateCoordinatorOfServices(serviceScope =>
            {
                IPlanReceiptOrderService service = serviceScope.CreatePlanService();
                var filterDto = new ConclusionEssentialDto();
                filterDto.RN = rn;
                const int skip = 0;
                const int take = 0;
                int total;


                IEnumerable<ConclusionEssentialDto> result =
                    service.GetConclusionEssentialFilter(filterDto, skip, take, out total);

                Assert.That(result, Is.Not.Null);
            });
        }
        [Test]
        public void InsertAconclusionEssential()
        {
            OnTestOfCreate(service =>
                service.AddConclusionEssential(SampleEntityDto.CreateConclusionEssential()));
        }
        [Test]
        public void UpdateConclusionEssential()
        {
            ConclusionEssentialDto conclusion = SampleEntityDto.CreateConclusionEssential();
            OnTestOfUpdate<ConclusionEssentialDto, ConclusionEssential>(
                ref conclusion,
                service => { conclusion.CreationDate = new DateTime(2099, 1, 2); service.UpdateConclusionEssential(conclusion); },
                (dto, entity) => dto.CreationDate == entity.CreationDate);
        }
        [Test]
        public void RemoveConclusionEssential()
        {
            ConclusionEssentialDto conclusion = SampleEntityDto.CreateConclusionEssential();
            OnTestOfRemove<ConclusionEssentialDto, ConclusionEssential>(
                ref conclusion,
                service => service.RemoveConclusionEssential(conclusion));
        }
        [Test]
        public void GetConclusion()
        {
            var rn = _nhHelper.Create<Conclusion>(Mapper.Map<Conclusion>(SampleEntityDto.CreateConclusion()), true);
            _helper.CreateCoordinatorOfServices(serviceScope =>
            {
                IPlanReceiptOrderService service = serviceScope.CreatePlanService();
                var filterDto = new ConclusionDto();
                filterDto.RN = rn;
                const int skip = 0;
                const int take = 0;
                int total;


                IEnumerable<ConclusionDto> result =
                    service.GetConclusionFilter(filterDto, skip, take, out total);

                Assert.That(result, Is.Not.Null);
            });
        }
        [Test]
        public void InsertConclusion()
        {
            OnTestOfCreate(service =>
                service.AddConclusion(SampleEntityDto.CreateConclusion()));
        }
        [Test]
        public void UpdateConclusion()
        {
            ConclusionDto conclusion = SampleEntityDto.CreateConclusion();
            OnTestOfUpdate<ConclusionDto, Conclusion>(
                ref conclusion,
                service => { conclusion.NOTE = "new note!!!!!"; service.UpdateConclusion(conclusion); },
                (dto, entity) => dto.NOTE == entity.Note);
        }
        [Test]
        public void RemoveConclusion()
        {
            ConclusionDto conclusion = SampleEntityDto.CreateConclusion();
            OnTestOfRemove<ConclusionDto, Conclusion>(
                ref conclusion,
                service => service.RemoveConclusion(conclusion));
        }
        [Test]
        public void GetActInputControlDestination()
        {
            var rn = _nhHelper.Create<Destination>(Mapper.Map<Destination>(SampleEntityDto.CreateActInputControlDestinationDto()), true);
            _helper.CreateCoordinatorOfServices(serviceScope =>
            {
                IPlanReceiptOrderService service = serviceScope.CreatePlanService();
                var filterDto = new ActInputControlDestinationDto();
                filterDto.RN = rn;
                const int skip = 0;
                const int take = 0;
                int total;


                IEnumerable<ActInputControlDestinationDto> result =
                    service.GetActInputControlDetinationFilter(filterDto, skip, take, out total);

                Assert.That(result.Any(), Is.True);
            });
        }
        [Test]
        public void InsertActInputControlDestination()
        {
            OnTestOfCreate(service =>
                service.InsertActInputControlDestination(
                    SampleEntityDto.CreateActInputControlDestinationDto()));
        }
        [Test]
        public void UpdateActInputControlDestination()
        {
            ActInputControlDestinationDto destination = SampleEntityDto.CreateActInputControlDestinationDto();
            OnTestOfUpdate<ActInputControlDestinationDto, Destination>(
                ref destination,
                service => { destination.Note = "new note!!!!!"; service.UpdateActInputControlDestination(destination); },
                (dto, entity) => dto.Note == entity.Note);
        }
        [Test]
        public void RemoveActInputControlDestination()
        {
            ActInputControlDestinationDto destination = SampleEntityDto.CreateActInputControlDestinationDto();
            OnTestOfRemove<ActInputControlDestinationDto, Destination>(
                ref destination,
                service => service.RemoveActInputControlDestination(destination));
        }
        [Test]
        public void GetQualityStateControlOfTheMake()
        {
            var rn = _nhHelper.Create<QualityStateControlOfTheMake>(Mapper.Map<QualityStateControlOfTheMake>(SampleEntityDto.CreateQualityStateControlOfTheMake()), true);
            _helper.CreateCoordinatorOfServices(serviceScope =>
            {
                IPlanReceiptOrderService service = serviceScope.CreatePlanService();
                var filterDto = new QualityStateControlOfTheMakeDto();
                filterDto.RN = rn;
                const int skip = 0;
                const int take = 0;
                int total;

                IEnumerable<QualityStateControlOfTheMakeDto> result =
                    service.GetQualityStateControlOfTheMakeFilter(filterDto, skip, take, out total);

                Assert.That(result.Any(), Is.True);
            });
        }
        [Test]
        public void InsertQualityStateControlOfTheMake()
        {
            OnTestOfCreate(service =>
                service.InsertQualityStateControlOfTheMake(
                    SampleEntityDto.CreateQualityStateControlOfTheMake()));
        }
        [Test]
        public void UpdateQualityStateControlOfTheMake()
        {
            QualityStateControlOfTheMakeDto quality = SampleEntityDto.CreateQualityStateControlOfTheMake();
            OnTestOfUpdate<QualityStateControlOfTheMakeDto, QualityStateControlOfTheMake>(
                ref quality,
                service => { quality.Note = "new note!!!!!"; service.UpdateQualityStateControlOfTheMake(quality); },
                (dto, entity) => dto.Note == entity.Note);
        }
        [Test]
        public void RemoveQualityStateControlOfTheMake()
        {
            QualityStateControlOfTheMakeDto destination = SampleEntityDto.CreateQualityStateControlOfTheMake();
            OnTestOfRemove<QualityStateControlOfTheMakeDto, QualityStateControlOfTheMake>(
                ref destination,
                service => service.RemoveQualityStateControlOfTheMake(destination));
        }
        [Test]
        public void GetQualityStateControlOfTheMakeSignature()
        {
            var rn = _nhHelper.Create<QualityStateControlOfTheMakeSignature>(Mapper.Map<QualityStateControlOfTheMakeSignature>(SampleEntityDto.CreateQualityStateControlOfTheMakeSignature()), true);
            _helper.CreateCoordinatorOfServices(serviceScope =>
            {
                IPlanReceiptOrderService service = serviceScope.CreatePlanService();
                var filterDto = new QualityStateControlOfTheMakeSignatureDto();
                filterDto.RN = rn;
                const int skip = 0;
                const int take = 0;
                int total;


                IEnumerable<QualityStateControlOfTheMakeSignatureDto> result =
                    service.GetQualityStateControlOfTheMakeSignatureFilter(filterDto, skip, take, out total);

                Assert.That(result.Any(), Is.True);
            });
        }
        [Test]
        public void InsertQualityStateControlOfTheMakeSignature()
        {
            OnTestOfCreate(service =>
                service.InsertQualityStateControlOfTheMakeSignature(
                    SampleEntityDto.CreateQualityStateControlOfTheMakeSignature()));
        }
        [Test]
        public void UpdateQualityStateControlOfTheMakeSignature()
        {
            QualityStateControlOfTheMakeSignatureDto quality = SampleEntityDto.CreateQualityStateControlOfTheMakeSignature();
            OnTestOfUpdate<QualityStateControlOfTheMakeSignatureDto, QualityStateControlOfTheMakeSignature>(
                ref quality, 
                service => {
                    quality.CreationDate = new DateTime(2013, 1, 1); 
                    service.UpdateQualityStateControlOfTheMakeSignature(quality); },
                (dto, entity) => dto.CreationDate == entity.CreationDate);
        }
        [Test]
        public void RemoveQualityStateControlOfTheMakeSignature()
        {
            QualityStateControlOfTheMakeSignatureDto destination = SampleEntityDto.CreateQualityStateControlOfTheMakeSignature();
            OnTestOfRemove<QualityStateControlOfTheMakeSignatureDto, QualityStateControlOfTheMakeSignature>(
                ref destination,
                service => service.RemoveQualityStateControlOfTheMakeSignature(destination));
        }
    }
}
