// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IStatusPlanCertificateViewModel.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the IStatusPlanCertificateViewModel type.
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
    /// The StatusPlanCertificateViewModel interface.
    /// </summary>
    public interface IStatusPlanCertificateViewModel : IRoutableViewModel,
                                                       IChangeStateViewModel<PlanCertificate, PlanCertificateState>
    {
        /// <summary>
        /// The set action object collection.
        /// </summary>
        /// <param name="objects">
        /// The objects.
        /// </param>
        void SetActionObjectCollection([NotNull] IList<PlanCertificate> objects);
    }
}
