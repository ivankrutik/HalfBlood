// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IChangeGroupStateViewModel.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the IChangeGroupStateViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Infrastructure.ViewModels.PlanReceiptOrderDomain
{
    using System.Collections.Generic;
    using System.Windows.Input;

    using Buisness.Entities.CommonDomain;
    using Buisness.Filters;

    using ReactiveUI;

    using UI.Entities.CommonDomain;
    using UI.Entities.PlanReceiptOrderDomain;

    /// <summary>
    /// The ChangeGroupStateViewModel interface.
    /// </summary>
    public interface IChangeGroupStateViewModel : IRoutableViewModel
    {
        /// <summary>
        /// Gets the filtering object.
        /// </summary>
        IFilterViewModel<PersonalAccountFilter, PersonalAccountDto> FilteringObject { get; }
            
        /// <summary>
        /// Gets the change group status.
        /// </summary>
        ICommand ChangeGroupStatusCommand { get; }

        /// <summary>
        /// Gets or sets the personal account.
        /// </summary>
        PersonalAccount SelectedPersonalAccount { get; set; }

        /// <summary>
        /// Gets or sets the plan receipt order.
        /// </summary>
        IList<PlanReceiptOrder> SelectedPlanReceiptOrders { get; }

        /// <summary>
        /// Gets a value indicating whether is busy.
        /// </summary>
        bool IsBusy { get; }

        /// <summary>
        /// The set plan receipt orders.
        /// </summary>
        /// <param name="planReceiptOrders">
        /// The plan receipt orders.
        /// </param>
        void SetPlanReceiptOrders(IList<PlanReceiptOrder> planReceiptOrders);
    }
}
