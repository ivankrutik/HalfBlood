// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StepBase.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the StepBase type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.AcceptanceTests.Steps
{
    using Halfblood.Loader;
    using System.Reactive.Concurrency;

    public abstract class StepBase
    {
        protected Bootstrapper Bootstrapper;

        protected StepBase()
        {
            this.Bootstrapper = new Bootstrapper(Scheduler.Default);
        }
    }
}