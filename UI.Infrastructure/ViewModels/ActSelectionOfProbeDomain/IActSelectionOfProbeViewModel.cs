// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IActSelectionOfProbeViewModel.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The i act selection of probe view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Infrastructure.ViewModels.ActSelectionOfProbeDomain
{
    using Buisness.Filters;

    using System.Windows.Input;

    using ParusModelLite.CertificateQualityDomain.ActSelectionOfProbeDomain;

    using ReactiveUI;

    /// <summary>
    /// The i act selection of probe view model.
    /// </summary>
    public interface IActSelectionOfProbeViewModel : IRoutableViewModel
    {
        IFilterViewModel<ActSelectionOfProbeFilter, ActSelectionOfProbeLiteDto> ActSelectionOfProbeFilter { get; }

        /// <summary>
        /// Gets or sets the selected making sample.
        /// </summary>
        ActSelectionOfProbeDepartmentLiteDto SelectedActSelectionOfProbeDepartment { get; set; }

        /// <summary>
        /// Gets or sets the selected act selection of probe destination.
        /// </summary>
        ActSelectionOfProbeLiteDto SelectedActSelectionOfProbe { get; set; }

        /// <summary>
        /// Gets or sets the selected requiremens.
        /// </summary>
        ActSelectionOfProbeDepartmentRequirementLiteDto SelectedActSelectionOfProbeDepartmentRequirement { get; set; }

       

        ICommand PreparingForEditActSelectionOfProbeCommand { get; }
        ICommand PreparingForRemoveActSelectionOfProbeCommand { get; }

        ICommand PrepatingForAddActSelectionOfProbeDepartmentCommand { get; }
        ICommand PrepatingForEditActSelectionOfProbeDepartmentCommand { get; }
        ICommand PrepatingForRemoveActSelectionOfProbeDepartmentCommand { get; }

        ICommand PrepatingForAddActSelectionOfProbeDepartmentRequirementCommand { get; }
        ICommand PrepatingForEditActSelectionOfProbeDepartmentRequirementCommand { get; }
        ICommand PrepatingForRemoveActSelectionOfProbeDepartmentRequirementCommand { get; }
        ICommand PrinterLabelForActSelectionOfProbeDepartmentCommand { get; }
    }
}
