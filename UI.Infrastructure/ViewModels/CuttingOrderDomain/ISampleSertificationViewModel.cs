// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISampleSertificationViewModel.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the ISampleCertificationViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Buisness.Filters;

namespace UI.Infrastructure.ViewModels.CuttingOrderDomain
{
    using System.Windows.Input;

    using Buisness.Entities.CuttingOrderDomain;
    using ReactiveUI;

    using UI.Entities.CuttingOrderDomain;

    /// <summary>
    /// The SampleCertificationViewModel interface.
    /// </summary>
    public interface ISampleCertificationViewModel : IRoutableViewModel
    {
        /// <summary>
        /// Gets a value indicating whether is busy.
        /// </summary>
        bool IsBusy { get; }

        /// <summary>
        /// Gets or sets the selected sample.
        /// </summary>
        Sample SelectedSample { get; set; }

        /// <summary>
        /// Gets or sets the selected plan receipt order.
        /// </summary>
        SampleCertification SelectedSampleCertification { get; set; }

        /// <summary>
        /// Gets the preparing for edit plan receipt order command.
        /// </summary>
        ICommand PreparingForEditSampleCertificationCommand { get; }

        /// <summary>
        /// Gets the preparing for status sample certification command.
        /// </summary>
        ICommand PreparingForStatusSampleCertificationCommand { get; }

        /// <summary>
        /// Gets the sample certification filter view model.
        /// </summary>
        IFilterViewModel<SampleCertificationFilter, SampleCertificationDto> SampleCertificationFilterViewModel { get; }
    }
}
