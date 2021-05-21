// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEditablePersonalAccountViewModel.cs" company="VZ">
//   maratoss && offan && icesun
// </copyright>
// <summary>
//   Defines the IEditablePersonalAccountViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



namespace UI.Infrastructure.ViewModels.ActSelectionOfProbeDomain
{
    using ReactiveUI;

    using System;
    using UI.Entities.CertificateQualityDomain.ActSelectionOfProbeDomain;
    using ParusModelLite.CertificateQualityDomain.ManufacturersCertificateDomain;

    public interface IEditableActSelectionOfProbeViewModel : IEditableViewModel<ActSelectionOfProbe>, IRoutableViewModel, IDisposable, IHasAccessCatalog
    {
        IGetCatalogAccess GetCatalogAccess { get; }

        CertificateQualityLiteDto CertificateQuality { get; set; }
    }
}
