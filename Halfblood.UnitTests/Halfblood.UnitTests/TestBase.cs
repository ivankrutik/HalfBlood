// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestBase.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the TestBase type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.UnitTests
{
    using System.Reactive.Concurrency;
    using System.Reactive.Linq;

    using Buisness.Workflows;

    using NHibernate.Helper.Filter;
    using NHibernate.Helper.Filter.Specification;

    using UI.ProcessComponents.Mappings;

    /// <summary>
    /// The test base.
    /// </summary>
    public abstract class TestBase
    {
        /// <summary>
        /// Initializes static members of the <see cref="TestBase"/> class.
        /// </summary>
        static TestBase()
        {
            QueryOverExtension.SetFilterStrategyFactory(new FilterStrategyFactory());
            RxExtension.UiSafeScheduler = Scheduler.Default;
            new ProfilesLauncher().LoadProfiles();
            new ConfigureWorkflow().LoadProfiles(null);
        }
    }
}
