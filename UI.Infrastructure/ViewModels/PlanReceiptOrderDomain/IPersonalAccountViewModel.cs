// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPersonalAccountViewModel.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the IPersonalAccountViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Infrastructure.ViewModels.PlanReceiptOrderDomain
{
    using System.Windows.Input;

    using ReactiveUI;

    using UI.Entities.PlanReceiptOrderDomain;
    using UI.Infrastructure.ViewModels.Filters;

    /// <summary>
    /// The PersonalAccountViewModel interface.
    /// </summary>
    public interface IPersonalAccountViewModel : IRoutableViewModel
    {
        /// <summary>
        /// Gets the preparing for edit personal account command.
        /// </summary>
        ICommand PreparingEditablePersonalAccountCommand { get; }

        /// <summary>
        /// Gets the selected plan receipt order personal account.
        /// </summary>
        PlanReceiptOrderPersonalAccount SelectedPlanReceiptOrderPersonalAccount { get; }

        /// <summary>
        /// Gets the personal account filter.
        /// </summary>
        IPlanReceiptOrderPersonalAccountFilterViewModel PlanReceiptOrderPersonalAccountFilter { get; }
    }
}