namespace Halfblood.AcceptanceTests.Integration
{
    using System.Linq;

    using Buisness.Filters;

    using NUnit.Framework;

    using ReactiveUI;

    using Rhino.Mocks;

    using UI.Infrastructure.ViewModels;

    public class DeliveryHistoryViewModelTest
    {
        public void Test()
        {
            var viewModel = MockRepository.GenerateStub<IDeliveryHistoryViewModel>();
            viewModel.DeliveryHistorySearcher.Wait();

            Assert.That(viewModel.DeliveryHistorySearcher.Result, Is.Not.Null);
            Assert.IsTrue(viewModel.DeliveryHistorySearcher.Result.Any());
        }
    }

    public interface IDeliveryHistoryViewModel : IRoutableViewModel
    {
        IFilterViewModel<EmptyFilter, string> DeliveryHistorySearcher { get; set; }
    }
}
