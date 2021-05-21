// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISampleViewModel.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the ISampleViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Buisness.Filters;

namespace UI.Infrastructure.ViewModels.CuttingOrderDomain
{
    using System.Windows.Input;
    using ParusModelLite.CuttingOrderDomain;

    using ReactiveUI;

    using UI.Entities.CuttingOrderDomain;

    /// <summary>
    /// The SampleViewModel interface.
    /// </summary>
    public interface ISampleViewModel : IRoutableViewModel
    {
        /// <summary>
        /// Gets a value indicating whether is busy.
        /// </summary>
        bool IsBusy { get; }

        /// <summary>
        /// Gets or sets the selected cuttingOrderSpecification.
        /// </summary>
        CuttingOrderSpecification SelectedCuttingOrderSpecification { get; set; }
        
        /// <summary>
        /// Gets or sets the selected sample.
        /// </summary>
        Sample SelectedSample { get; set; }

        /// <summary>
        /// Gets the preparing for edit plan receipt order command.
        /// </summary>
        ICommand PreparingForEditSampleCommand { get; }

        /// <summary>
        /// Gets the preparing for status sample command.
        /// </summary>
        ICommand PreparingForStatusSampleCommand { get; }

        /// <summary>
        /// Gets the sample filter view model.
        /// </summary>
        IFilterViewModel<SampleFilter, SampleLiteDto> SampleFilterViewModel { get; }
    }
}
