// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IActSelectionOfProbeFilterViewModel.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The ActSelectionOfProbeFilterViewModel interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


using Buisness.Filters;

namespace UI.Infrastructure.ViewModels.Filters
{
    using Buisness.Entities.CertificateQualityDomain.ActSelectionProbeDomain;
    using ReactiveUI;

    /// <summary>
    /// The ActSelectionOfProbeFilterViewModel interface.
    /// </summary>
    public interface IActSelectionOfProbeFilterForView : IFilterViewModel<ActSelectionOfProbeFilter, ActSelectionOfProbeDto>, IReactiveNotifyPropertyChanged
    {
    }
}
