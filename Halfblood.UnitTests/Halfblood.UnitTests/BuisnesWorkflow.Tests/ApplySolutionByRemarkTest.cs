using System;
using Buisness.Entities.PlanReceiptOrderDomain;
using NUnit.Framework;
using ParusModel.WorkOrderDomain.ActInputControlDomain;

namespace Halfblood.UnitTests.BuisnesWorkflow.Tests
{
    public class ApplySolutionByRemarkTest : TestBase
    {
        [Test]
        public void Create()
        {
            OnTestOfCreate(service =>
                service.InsertApplySolutionByRemark(SampleEntityDto.CreateApplySolutionByRemarkDto()));
        }
        [Test]
        public void Remove()
        {
            ApplySolutionByRemarkDto solution = SampleEntityDto.CreateApplySolutionByRemarkDto();
            OnTestOfRemove<ApplySolutionByRemarkDto, ApplySolutionByRemark>(
                ref solution,
                service => service.RemoveApplySolutionByRemark(solution));
        }
        [Test]
        public void Update()
        {
            ApplySolutionByRemarkDto solution = SampleEntityDto.CreateApplySolutionByRemarkDto();
            OnTestOfUpdate<ApplySolutionByRemarkDto, ApplySolutionByRemark>(
                ref solution,
                service => { solution.CreationDate = new DateTime(2999, 1, 1); service.UpdateApplySolutionByRemark(solution); },
                (dto, entity) => dto.CreationDate == entity.CreationDate);
        }
    }
}
