// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestBase.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the TestBase type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.ViewModels.Test
{
    using System.Reactive.Concurrency;
    using System.Reactive.Linq;

    using UI.ProcessComponents.Mappings;

    /// <summary>
    /// The test base.
    /// </summary>
    public abstract class TestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestBase"/> class.
        /// </summary>
        protected TestBase()
        {
            this.ConfigureAutoMapper();
            RxExtension.UiSafeScheduler = Scheduler.Default;
        }

        /// <summary>
        /// The configure auto mapper.
        /// </summary>
        private void ConfigureAutoMapper()
        {
            new ProfilesLauncher().LoadProfiles();
        }
    }
}
