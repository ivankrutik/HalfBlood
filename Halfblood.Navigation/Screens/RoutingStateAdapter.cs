// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RoutingStateAdapter.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The routing state adapter.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.Navigation.Screens
{
    using System.ComponentModel.Composition;

    using ReactiveUI;

    /// <summary>
    /// The routing state adapter.
    /// </summary>
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [Export(typeof(IRoutingState))]
    public class RoutingStateAdapter : RoutingState
    {
    }
}