// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEditablePlanReceiptOrderViewModel.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the IEditablePlanReceiptOrderViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Infrastructure.ViewModels.PlanReceiptOrderDomain
{
    using System;

    using Buisness.Entities;
    using Buisness.Entities.CommonDomain;
    using Buisness.Filters;

    using ParusModelLite.CommonDomain;

    using ReactiveUI;

    using UI.Entities.PlanReceiptOrderDomain;

    /// <summary>
    /// The AddPlanReceiptOrderViewModel interface.
    /// </summary>
    public interface IEditablePlanReceiptOrderViewModel : IRoutableViewModel,
                                                          IEditableViewModel<PlanReceiptOrder>,
                                                          IHasAccessCatalog,
                                                          IDisposable
    {
        /// <summary>
        /// Gets the ground receipt type of document filter view model.
        /// </summary>
        IFilterViewModel<TypeOfDocumentFilter, TypeOfDocumentDto> GroundReceiptTypeOfDocumentFilterViewModel { get; }

        /// <summary>
        /// Gets the user contractor filter view model.
        /// </summary>
        IFilterViewModel<UserFilter, UserDto> UserContractorFilterViewModel { get; }

        /// <summary>
        /// Gets the ground doc type of document filter view model.
        /// </summary>
        IFilterViewModel<TypeOfDocumentFilter, TypeOfDocumentDto> GroundDocTypeOfDocumentFilterViewModel { get; }

        /// <summary>
        /// Gets the gas station oil depot filter view model.
        /// </summary>
        IFilterViewModel<StoreGasStationOilDepotFilter, StoreLiteDto> GasStationOilDepotFilterViewModel { get; }
    }
}