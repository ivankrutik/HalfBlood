using System;
using Buisness.Entities.PlanReceiptOrderDomain;
using Halfblood.Common;
using NUnit.Framework;
using ServiceContracts.PlanReceiptOrderDomain;
using TechTalk.SpecFlow;

namespace Halfblood.UnitTests.BuisnesWorkflow.Tests.StoredProcedure
{
    [Binding]
    public class PlanReceipOrderSteps
    {
        private PlanReceiptOrderDto _planReceiptOrder;
        private PlanReceiptOrderState _state;
        private BuildConnectionHelper _helper;
        private bool _result;

        public PlanReceipOrderSteps()
        {
            _helper = new BuildConnectionHelper();
        }

        [SetUp]
        public void SetUp()
        {
            _helper = new BuildConnectionHelper();
            //_planReceiptOrder = new PlanReceiptOrderDto { RN = 1007334626 };
        }
        [Given(@"Беру ППО с RN равным (.*)")]
        public void GivenБеруППОСRNРавным(int p0)
        {
            _planReceiptOrder = new PlanReceiptOrderDto { RN = p0 };
        }

        [Given(@"Беру устанавливаемое состояние '(.*)'")]
        public void GivenБеруУстанавливаемоеСостояние(string p0)
        {
            _state = (PlanReceiptOrderState)Enum.Parse(typeof(PlanReceiptOrderState), p0);
        }

        [When(@"Нажимаю изменить")]
        public void WhenНажимаюИзменить()
        {
            _helper.CreateCoordinatorOfServices(serviceScope =>
            {
                IPlanReceiptOrderService service = serviceScope.CreatePlanService();
                try
                {
                    service.PlanReceiptOrderChangeState(_planReceiptOrder, _state);
                    _result = true;
                }
                catch (Exception exc)
                {
                    _result = false;
                }
                finally
                {
                    serviceScope.Rollback();
                }
            });
        }

        [Then(@"Хочу увидеть сообщение '(.*)'")]
        public void ThenХочуУвидетьСообщение(string p0)
        {
            Assert.AreEqual(_result, bool.Parse(p0));
        }
    }
}
