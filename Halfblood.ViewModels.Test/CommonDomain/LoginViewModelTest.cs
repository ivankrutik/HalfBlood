// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LogInTest.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The log in test.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.ViewModels.Test.CommonDomain
{
    using System.Reactive.Linq;

    using Halfblood.Common.Connection;
    using Halfblood.Test.MockObjects;
    using NUnit.Framework;
    using ReactiveUI;
    using Rhino.Mocks;

    using UI.Infrastructure;
    using UI.ProcessComponents;

    [TestFixture]
    public class LogInTest : TestBase
    {
        [Test]
        public void LogInViewModel()
        {
            var connection = MockRepository.GenerateMock<IConnection>();

            var viewModel = new LoginViewModel(
                connection,
                new FakeScreen(),
                MockRepository.GenerateStub<IMessageBus>(),
                MockRepository.GenerateStub<IRoutableViewModelManager>());
            viewModel.AuthorizationMetadata.Login = "login";
            viewModel.AuthorizationMetadata.Password = "password";
            viewModel.AuthorizationMetadata.Database = "dbName";

            AsyncTestHelper.ExecuteOperationTest(
                () => viewModel,
                vm => vm.WhenAny(x => x.IsConnecting, x => x.Value).Skip(1).Where(isConnecting => !isConnecting),
                vm => { },
                vm => vm.AuthorizeCommand.Execute(null));
        }
    }
}
