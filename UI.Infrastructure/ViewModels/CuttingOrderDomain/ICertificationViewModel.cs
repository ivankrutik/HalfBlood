// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICertificationViewModel.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the ICertificationViewModel type.
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
    /// The certification view model interface.
    /// </summary>
    public interface ICertificationViewModel : IRoutableViewModel
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
        /// Gets or sets the selected certification.
        /// </summary>
        Certification SelectedCertification { get; set; }

        /// <summary>
        /// Gets the preparing for edit plan receipt order command.
        /// </summary>
        ICommand PreparingForEditCertificationCommand { get; }

        /// <summary>
        /// Gets the preparing for status certification command.
        /// </summary>
        ICommand PreparingForStatusCertificationCommand { get; }

        /// <summary>
        /// Gets the certification filter view model.
        /// </summary>
        IFilterViewModel<CertificationFilter, CertificationDto> CertificationFilterViewModel { get; }
    }
}
