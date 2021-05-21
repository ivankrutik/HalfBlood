// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProFilterViewModelTest.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the ProFilterViewModelTest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.ViewModels.Test.PlanReceiptOrderDomain.FilterViewModelTest
{
    using System.Reactive.Linq;
    using Halfblood.Test.MockObjects;
    using NUnit.Framework;
    using ReactiveUI;

    using UI.Infrastructure.ViewModels.Filters;
    using UI.ProcessComponents.FilterViewModels.CertificateQualityDomain;

    /// <summary>
    /// The pro filter view model test.
    /// </summary>
    public class ProFilterViewModelTest : TestBase
    {
        [Test]
        public void Create()
        {
            IProFilterViewModel viewModel = this.CreateViewModel();
            Assert.That(viewModel, Is.Not.Null);
            Assert.That(viewModel, Is.InstanceOf<ProFilterViewModel>());
        }

        [Test]
        public void Filtering()
        {
            var viewModel = this.CreateViewModel();

            AsyncTestHelper.ExecuteOperationTest(
                () => viewModel,
                vm => vm.WhenAny(x => x.IsBusy, x => x.Value).Skip(1).Where(isBusy => !isBusy),
                vm =>
                {
                    Assert.That(vm.Result, Is.Not.Null);
                    Assert.That(vm.Result.Count, Is.EqualTo(10));
                },
                vm => vm.InvokeCommand.Execute(null));
        }

        private IProFilterViewModel CreateViewModel()
        {
            return new ProFilterViewModel(new FakeScreen(), new FakeUnitOfWorkFactory());
        }
    }
}
