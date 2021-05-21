// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEditableSampleSertificationViewModel.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the IEditableSampleCertificationViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Infrastructure.ViewModels.CuttingOrderDomain
{
    using ReactiveUI;

    using UI.Entities.CuttingOrderDomain;

    /// <summary>
    /// The EditableSampleCertificationViewModel interface.
    /// </summary>
    public interface IEditableSampleCertificationViewModel : IRoutableViewModel,
                                                             IEditableViewModel<SampleCertification>,
                                                             IHasAccessCatalog
    {
    }
}
