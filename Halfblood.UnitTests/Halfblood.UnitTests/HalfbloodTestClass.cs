using NHibernate;
using NUnit.Framework;
using ServiceContracts.PlanReceiptOrderDomain;

namespace Halfblood.UnitTests
{
    public class BuildConnectionToDb
    {
        private readonly BuildConnectionHelper _helper;

        public BuildConnectionToDb()
        {
            log4net.Config.XmlConfigurator.Configure();

            _helper = new BuildConnectionHelper();
        }

        [Test]
        public void CreateNHInitializer()
        {
            using (ISessionFactory sessionFactory = _helper.CreateMockSessionFactory())
            {
                Assert.That(sessionFactory, Is.Not.Null);
            }
        }
        [Test]
        public void CreateFactoryOfServiceScopeFactory()
        {
            _helper.CreateCoordinatorFactory(scope => Assert.That(scope, Is.Not.Null));
        }
        [Test]
        public void CreateServiceScopeFactory()
        {
            _helper.CreateCoordinatorOfServices(factory => Assert.That(factory, Is.Not.Null));
        }
        [Test]
        public void CreatePlanReceiptOrderService()
        {
            _helper.CreateCoordinatorOfServices(serviceScope =>
            {
                IPlanReceiptOrderService service = serviceScope.CreatePlanService();
                Assert.That(service, Is.Not.Null);
            });
        }
    }
}
