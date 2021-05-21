// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IStatusPersonalAccountViewModel.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the IStatusPersonalAccountViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Infrastructure.ViewModels.PlanReceiptOrderDomain
{
    using System.Collections.Generic;

    using Halfblood.Common;

    using JetBrains.Annotations;

    using ReactiveUI;

    using UI.Entities.PlanReceiptOrderDomain;

    /// <summary>
    /// The StatusPersonalAccountViewModel interface.
    /// </summary>
    public interface IStatusPersonalAccountViewModel : IRoutableViewModel,
                                                       IChangeStateViewModel<PlanReceiptOrderPersonalAccount, PlanReceiptOrderPersonalAccountState>
    {
        /// <summary>
        /// The set action object collection.
        /// </summary>
        /// <param name="objects">
        /// The objects.
        /// </param>
        void SetActionObjectCollection([NotNull] IList<PlanReceiptOrderPersonalAccount> objects);
    }
}