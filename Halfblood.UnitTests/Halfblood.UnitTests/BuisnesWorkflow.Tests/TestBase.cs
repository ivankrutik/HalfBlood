using System;
using AutoMapper;
using Buisness.Entities;
using Buisness.Workflows.Mapping;
using DataAccessLogicComponents.Infrastructure;
using NHibernate;
using NUnit.Framework;
using ServiceContracts.PlanReceiptOrderDomain;

namespace Halfblood.UnitTests.BuisnesWorkflow.Tests
{
    [Obsolete(@"Сделать в сетапе забивание данных, и потом их удаление и не создавать в тестах данные")]
    public abstract class TestBase : IDisposable
    {
        protected NhHelper _nhHelper;
        protected BuildConnectionHelper _helper;
        private ISessionFactory _sessionFactory;

        ~TestBase()
        {
            Dispose();
        }
        public TestBase()
        {
            log4net.Config.XmlConfigurator.Configure();

            _helper = new BuildConnectionHelper();
            _sessionFactory = 
                _helper.CreateMockSessionFactory();
                       //.InsertDataParusModel();
        }

        [SetUp]
        public virtual void SetUp()
        {
            _nhHelper = new NhHelper(_sessionFactory);
            Mapper.AddProfile<CommonProfile>();
            Mapper.AddProfile<PlanReceiptOrderProfile>();
        }
        [TearDown]
        public virtual void TearDown()
        {
            _nhHelper.Dispose();
        }
        public void Dispose()
        {
            _nhHelper.Dispose();
            _sessionFactory.Dispose();
        }
        protected void OnTestOfCreate<TDto>(Func<IPlanReceiptOrderService, TDto> insertAction)
            where TDto : IDto
        {
            _helper.CreateCoordinatorOfServices(serviceScope =>
            {
                IPlanReceiptOrderService service = serviceScope.CreatePlanService();
                TDto dto = insertAction(service);

                Assert.That(dto.RN, Is.GreaterThan(0));
                serviceScope.Rollback();
            });
        }
        protected void OnTestOfRemove<TDto, TEntity>(ref TDto dto, Action<IPlanReceiptOrderService> removeAction)
            where TDto : IDto
            where TEntity : class, IEntity<long>
        {
            TEntity sourceSolution = Mapper.Map<TEntity>(dto);
            _nhHelper.Create(sourceSolution, false);
            dto = Mapper.Map<TDto>(sourceSolution);

            _helper.CreateCoordinatorOfServices(serviceScope =>
            {
                IPlanReceiptOrderService service = serviceScope.CreatePlanService();
                removeAction(service);
            });
            var pass = _nhHelper.Get<TEntity>(dto.RN);
            Assert.That(pass, Is.Null);
        }
        protected void OnTestOfUpdate<TDto, TEntity>(
            ref TDto dto, 
            Action<IPlanReceiptOrderService> updateAction, 
            Func<TDto, TEntity, bool> isEquals)
            where TDto : IDto
            where TEntity : class, IEntity<long>
        {
            TEntity sourceSolution = Mapper.Map<TEntity>(dto);
            _nhHelper.Create(sourceSolution, false);
            dto = Mapper.Map<TDto>(sourceSolution);

            _helper.CreateCoordinatorOfServices(serviceScope =>
            {
                //dto.Note = "new note!!!";
                IPlanReceiptOrderService service = serviceScope.CreatePlanService();
                updateAction(service);
            });

            var result = _nhHelper.Get<TEntity>(dto.RN);
            Assert.That(isEquals(dto, result), Is.True);
        }
    }
}