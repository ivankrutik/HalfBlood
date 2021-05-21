// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CoordinatorTest.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the CoordinatorTest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.UnitTests.Coordinator
{
    using Buisness.Workflows;
    using NhConnection.Infrasctructure;

    using NUnit.Framework;

    using Rhino.Mocks;

    using ServiceContracts;

    /// <summary>
    /// The unit test.
    /// </summary>
    [TestFixture]
    public class CoordinatorTest
    {
        [Test]
        public void CreateCoordinatorFactory()
        {
            var coordinator = new UnitOfWorkFactory(MockRepository.GenerateStub<INhConnection>());
            Assert.That(coordinator, Is.Not.Null);
        }

        [Test]
        public void CreateCoordinatorOfServices()
        {
            var coordinator = new UnitOfWorkFactory(new FakeNhConnection());
            IUnitOfWork unitOfSerice = coordinator.Create();

            Assert.That(unitOfSerice, Is.Not.Null);
            Assert.That(unitOfSerice, Is.InstanceOf<UnitOfWork>());
        }
    }
}