// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IContractViewModel.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the IContractViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Infrastructure.ViewModels.ContractDomain
{
    using Buisness.Filters;

    using ParusModelLite.ContractDomain;
    using ReactiveUI;

    /// <summary>
    /// The ContractViewModel interface.
    /// </summary>
    public interface IContractViewModel : IRoutableViewModel
    {
        /// <summary>
        /// Gets a value indicating whether is busy.
        /// </summary>
        bool IsBusy { get; }

        /// <summary>
        /// Gets or sets the selected plan receipt order.
        /// </summary>
        ContractLiteDto SelectedSContract { get; set; }

        /// <summary>
        /// Gets or sets the selected plan receipt order.
        /// </summary>
        StagesOfTheContractLiteDto SelectedStagesOfTheContract { get; set; }

        /// <summary>
        /// Gets the plan Contract DTO filter view model.
        /// </summary>
        IFilterViewModel<ContractFilter, ContractLiteDto> ContractFilterViewModel { get; }
        
        /// <summary>
        /// Gets the plan StagesOfTheContract DTO filter view model.
        /// </summary>
        IFilterViewModel<StagesOfTheContractFilter, StagesOfTheContractLiteDto> StagesOfTheContractFilterViewModel { get; }

        /// <summary>
        /// Gets the plan PlanAndSpecification DTO filter view model.
        /// </summary>
        IFilterViewModel<PlanAndSpecificationFilter, PlanAndSpecificationLiteDto> PlanAndSpecificationFilterViewModel { get; }
    }
}
