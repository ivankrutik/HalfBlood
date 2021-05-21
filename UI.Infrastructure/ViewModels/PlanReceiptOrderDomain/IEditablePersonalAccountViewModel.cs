// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEditablePersonalAccountViewModel.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the IEditablePersonalAccountViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Infrastructure.ViewModels.PlanReceiptOrderDomain
{
    using System;

    using Buisness.Entities.CommonDomain;
    using Buisness.Filters;

    using ReactiveUI;

    using UI.Entities.PlanReceiptOrderDomain;
    using UI.Infrastructure.ViewModels.ContractDomain;

    /// <summary>
    /// The EditPersonalAccountViewModel interface.
    /// </summary>
    public interface IEditablePersonalAccountViewModel : IEditableViewModel<PlanReceiptOrderPersonalAccount>, IRoutableViewModel, IDisposable
    {
        /// <summary>
        /// Gets the personal account filter view model.
        /// </summary>
        IFilterViewModel<PersonalAccountFilter, PersonalAccountDto> PersonalAccountFilterViewModel { get; }

        /// <summary>
        /// Gets the contract view model.
        /// </summary>
        IContractViewModel ContractViewModel { get; }

        /// <summary>
        /// Gets or sets the user contractor.
        /// </summary>
        UserDto UserContractor { get; set; }

        /// <summary>
        /// Gets or sets the measure.
        /// </summary>
        string Measure { get; set; }
    }
}
