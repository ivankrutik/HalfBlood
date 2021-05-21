// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AccessTests.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the AccessTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Buisness.Entities.CommonDomain;

namespace Halfblood.UnitTests.ClientTests
{
    using FizzWare.NBuilder;

    using Halfblood.Common;

    using NUnit.Framework;

    using Rhino.Mocks;

    using ServiceContracts;
    using ServiceContracts.Facades;

    using UI.Entities.PlanReceiptOrderDomain;
    using UI.ProcessComponents.FilterViewModels.CommonDomain;

    /// <summary>
    /// The access tests.
    /// </summary>
    [TestFixture]
    public class AccessTests : TestBase
    {
        [Test]
        public void Load()
        {
            var unitOfWork = MockRepository.GenerateStub<IUnitOfWork>();
            var service = MockRepository.GenerateStub<IPolicyService>();
            var unitOfWorkFactory = MockRepository.GenerateStub<IUnitOfWorkFactory>();
            unitOfWorkFactory.Stub(uowFact => uowFact.Create()).Return(unitOfWork);

            unitOfWork.Stub(uow => uow.Create<IPolicyService>()).Return(service);

            service.Stub(svc => svc.GetCatalogHierarchical(typeof(PlanReceiptOrder), TypeActionInSystem.NonStandardAction))
                   .Return(Builder<CatalogHierarchical>.CreateNew().Build());
            var loader = new GetCatalogAccess(unitOfWorkFactory);
            loader.LoadForEntity<PlanReceiptOrder>(TypeActionInSystem.NonStandardAction);
        }

    }
}