// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FilterService.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the FilterService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.UnitTests.FilteringStarategy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Buisness.Components;
    using Buisness.Entities.CommonDomain;
    using Buisness.Filters;
    using Buisness.Workflows.Mapping;
    using Buisness.Workflows.Services;

    using Halfblood.Common;

    using NHibernate.Helper.Filter;

    using NUnit.Framework;

    using Rhino.Mocks;

    using ServiceContracts;

    using UI.Infrastructure.ViewModels;
    using UI.ProcessComponents.FilterViewModels;

    public class FilterServiceTest : TestBase
    {
        [Test]
        public void CreateFilterViewModel()
        {
            IFilterViewModel<UserFilter, UserDto> viewModel =
                new FilterViewModelFactory(MockRepository.GenerateStub<IUnitOfWorkFactory>())
                    .Create<UserFilter, UserDto>();

            Assert.That(viewModel, Is.Not.Null);
        }

        [Test, TestCaseSource("GetAllRelationDtosWithEntities")]
        public void FilteringAll(Type type)
        {
            var filterService = new FilteringService(new RepositoryFactory(new FakeSession()), new FilterStrategyFactory());
            filterService.Filtering(type, null);
        }

        [Test]
        public void FilterService()
        {
            var filterService = new FilteringService(new RepositoryFactory(new FakeSession()), new FilterStrategyFactory());
            IList<IDto> result = filterService.Filtering(typeof(UserDto), new UserFilter());

            Assert.That(result, Is.Not.Null);
        }

        private IEnumerable<Type> GetAllRelationDtosWithEntities()
        {
#if !RELEASE
            return BusinessRelation.Instance.Dictionary.Select(keyValuePair => keyValuePair.Key);
#elif RELEASE
            return Enumerable.Empty<Type>();
#endif
        }
    }
}