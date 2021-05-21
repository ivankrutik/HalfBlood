// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RepositoryTest.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the RepositoryTest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.UnitTests.RepositoryTests
{
    using Buisness.Components;

    using NHibernate;

    using NUnit.Framework;

    using ParusModel.Entities.PlanReceiptOrderDomain;

    using Rhino.Mocks;

    /// <summary>
    /// The repository test.
    /// </summary>
    public class RepositoryTest
    {
        [Test]
        public void Test()
        {
            var session = MockRepository.GenerateMock<ISession>();
            session.Stub(x => x.IsOpen).Return(true);

            var factory = new RepositoryFactory(session);
            var repository = factory.Create<PlanCertificate>();

            Assert.That(repository, Is.InstanceOf<PlanCertificateRepository>());
        }
    }
}
