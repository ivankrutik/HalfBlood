namespace UI.Infrastructure.ViewModels.ActSelectionOfProbeDomain
{
    using System;
    using Buisness.Entities.CommonDomain;
    using Buisness.Filters;
    using ReactiveUI;
    using UI.Entities.CertificateQualityDomain.ActSelectionOfProbeDomain;


    public interface IEditableActSelectionOfProbeDepartmentViewModel : IRoutableViewModel,
                                                          IEditableViewModel<ActSelectionOfProbeDepartment>,
                                                          IHasAccessCatalog,
                                                          IDisposable
    {
        IFilterViewModel<StaffingDivisionFilter,StaffingDivisionDto> StaffingDivisionReceiver { get; }
        IFilterViewModel<StaffingDivisionFilter, StaffingDivisionDto> StaffingDivisionMakingSample { get; }
    }
}