namespace UI.Infrastructure.ViewModels.ActSelectionOfProbeDomain
{
    using System;
    using ReactiveUI;
    using UI.Entities.CertificateQualityDomain.ActSelectionOfProbeDomain;


    public interface IEditableActSelectionOfProbeDepartmentRequirementViewModel : IRoutableViewModel,
                                                          IEditableViewModel<ActSelectionOfProbeDepartmentRequirement>,
                                                          IDisposable
    {
    }
}