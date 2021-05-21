// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HostScreen.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the HostScreen type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.Navigation.Screens
{
    using System.ComponentModel.Composition;

    using Halfblood.Common.Navigations;

    using ReactiveUI;

    /// <summary>
    /// The host screen adapter.
    /// </summary>
    [Export(typeof(IScreen))]
    public class HostScreen : IScreen
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HostScreen"/> class.
        /// </summary>
        /// <param name="router">
        /// The router.
        /// </param>
        [ImportingConstructor]
        public HostScreen(IRoutingState router)
        {
            Router = router;
        }

        /// <summary>
        /// Gets the router.
        /// </summary>
        public IRoutingState Router { get; private set; }
    }

    /// <summary>
    /// The owner host screen.
    /// </summary>
    [Export(typeof(IOwnerHostScreen))]
    public class OwnerHostScreen : IOwnerHostScreen
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OwnerHostScreen"/> class.
        /// </summary>
        /// <param name="router">
        /// The router.
        /// </param>
        [ImportingConstructor]
        public OwnerHostScreen(IRoutingState router)
        {
            Router = router;
        }

        /// <summary>
        /// Gets the router.
        /// </summary>
        public IRoutingState Router { get; private set; }
    }

    /// <summary>
    /// The owner host screen.
    /// </summary>
    [Export(typeof(ITitleBarHostScreen))]
    public class TitleBarScreen : ITitleBarHostScreen
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TitleBarScreen"/> class.
        /// </summary>
        /// <param name="router">
        /// The router.
        /// </param>
        [ImportingConstructor]
        public TitleBarScreen(IRoutingState router)
        {
            Router = router;
        }

        /// <summary>
        /// Gets the router.
        /// </summary>
        public IRoutingState Router { get; private set; }
    }
}
