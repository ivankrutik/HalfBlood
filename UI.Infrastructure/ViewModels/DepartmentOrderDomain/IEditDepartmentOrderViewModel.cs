// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEditDepartmentOrderViewModel.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the IEditDepartmentOrderViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Buisness.Entities.CommonDomain;

namespace UI.Infrastructure.ViewModels.DepartmentOrderDomain
{
    using System.Windows.Input;

    using Buisness.Filters;

    using ParusModelLite.CertificateQualityDomain.ManufacturersCertificateDomain;
    using ParusModelLite.DepartmentOrderDomain;

    using ReactiveUI;

    using UI.Entities.DepartmentOrderDomain;

    public interface IEditDepartmentOrderViewModel : IRoutableViewModel,
                                                     IEditableViewModel<DepartmentOrder>,
                                                     IHasAccessCatalog
    {
        ICommand NavigateToFindCertificateCommand { get; }
        IFilterViewModel<GoodsManagerFilter, GoodsManagerDto> GoodsManagerFilterObject { get; }
        IFilterViewModel<DepartmentOrderFilter, DepartmentOrderLiteDto> DepartmentOrderFilteringObject { get; }
        IFilterViewModel<CertificateQualityFilter, CertificateQualityLiteDto> CertificateQualityFilteringObject { get; }
        CertificateQualityLiteDto SelectedCertificate { get; set; }
    }
}