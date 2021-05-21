// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPlanCertificateViewModel.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   The PlanCertificateViewModel interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Infrastructure.ViewModels.PlanReceiptOrderDomain
{
    using System.Windows.Input;

    using Buisness.Filters;

    using ParusModelLite.PlanReceiptOrderDomain;

    using ReactiveUI;

    /// <summary>
    /// The PlanCertificateViewModel interface.
    /// </summary>
    public interface IPlanCertificateViewModel : IRoutableViewModel
    {
        /// <summary>
        /// Gets a value indicating whether is busy.
        /// </summary>
        bool IsBusy { get; }

        /// <summary>
        /// Gets the preparing editable plan certificate command.
        /// </summary>
        ICommand PreparingEditablePlanCertificateCommand { get; }

        /// <summary>
        /// Gets the preparing copy plan certificate command.
        /// </summary>
        ICommand PreparingCopyPlanCertificateCommand { get; }

        /// <summary>
        /// Gets the preparing adding plan certificate command.
        /// </summary>
        ICommand PreparingAddingPlanCertificateCommand { get; }

        /// <summary>
        /// Gets the preparing removing plan certificate command.
        /// </summary>
        ICommand PreparingRemovingPlanCertificateCommand { get; }

        /// <summary>
        /// Gets the preparing editable personal account command.
        /// </summary>
        ICommand PreparingEditablePersonalAccountCommand { get; }

        /// <summary>
        /// Gets the preparing adding personal account command.
        /// </summary>
        ICommand PreparingAddingPersonalAccountCommand { get; }

        /// <summary>
        /// Gets the preparing removing personal account command.
        /// </summary>
        ICommand PreparingRemovingPersonalAccountCommand { get; }

        /// <summary>
        /// Gets the plan certificate filter view model.
        /// </summary>
        IFilterViewModel<PlanCertificateFilter, PlanCertificateLiteDto> PlanCertificateFilterViewModel { get; }

        /// <summary>
        /// Gets the personal account filter view model.
        /// </summary>
        IFilterViewModel<PlanReceiptOrderPersonalAccountFilter, PersonalAccountOfPlanReceiptOrderLiteDto> PersonalAccountFilterViewModel { get; }

        /// <summary>
        /// Gets the preparing for status plan receipt order command.
        /// </summary>
        ICommand PreparingForStatusPlanCertificateCommand { get; }

        /// <summary>
        /// Gets the preparing for status plan receipt order command.
        /// </summary>
        ICommand PreparingForStatusPersonalAccountCommand { get; }

        /// <summary>
        /// Gets the selected plan certificate.
        /// </summary>
        PlanCertificateLiteDto SelectedPlanCertificate { get; set; }

        /// <summary>
        /// Gets or sets the selected plan receipt order.
        /// </summary>
        PlanReceiptOrderLiteDto SelectedPlanReceiptOrder { get; set; }

        /// <summary>
        /// Gets or sets the selected plan receipt order personal account.
        /// </summary>
        PersonalAccountOfPlanReceiptOrderLiteDto SelectedPlanReceiptOrderPersonalAccount { get; set; }
    }
}
