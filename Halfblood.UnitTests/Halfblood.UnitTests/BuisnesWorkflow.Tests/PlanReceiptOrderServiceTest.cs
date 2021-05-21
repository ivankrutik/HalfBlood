using System.Collections.Generic;
using System.Linq;
using Buisness.Entities.PlanReceiptOrderDomain;
using NUnit.Framework;
using ServiceContracts.PlanReceiptOrderDomain;

namespace Halfblood.UnitTests.BuisnesWorkflow.Tests
{
    public class PlanReceiptOrderServiceTest : TestBase
    {
        [Test]
        public void GetPlanReceipOrder()
        {
            _helper.CreateCoordinatorOfServices(serviceScope =>
            {
                IPlanReceiptOrderService service = serviceScope.CreatePlanService();
                var filterDto = new PlanReceiptOrderDto();
                const int skip = 0;
                const int take = 0;
                int total;

                IEnumerable<PlanReceiptOrderDto> result =
                    service.GetPlanReceiptOrderFilter(filterDto, skip, take, out total);

                Assert.That(result.Any(), Is.True);
            });
        }
        [Test]
        public void Create()
        {
            OnTestOfCreate(service =>
                service.AddPlanReceiptOrder(SampleEntityDto.CreatePlanReceiptOrder()));
        }
    }
}