// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PlanReceipOrderViewModelTest.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the PlanReceipOrderViewModelTest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.ViewModels.Test.PlanReceiptOrderDomain
{
    using Halfblood.Test.MockObjects;
    using NUnit.Framework;

    using Rhino.Mocks;

    using UI.Infrastructure;
    using UI.Infrastructure.ViewModels.PlanReceiptOrderDomain;
    using UI.ProcessComponents.PlanReceiptOrderDomain;

    public class PlanReceipOrderViewModelTest : TestBase
    {
        [Test]
        public void Create()
        {
            IPlanReceiptOrderViewModel vm = CreateViewModel();

            Assert.That(vm, Is.Not.Null);
            Assert.That(vm, Is.InstanceOf<PlanReceiptOrderViewModel>());
        }

        public static IPlanReceiptOrderViewModel CreateViewModel()
        {
            return new PlanReceiptOrderViewModel(
                       new FakeScreen(),
                       new FakeMessenger(),
                       MockRepository.GenerateStub<IRoutableViewModelManager>(),
                       new FakeUnitOfWorkFactory());
        }
    }
}