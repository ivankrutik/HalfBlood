// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDocumentManagerViewModel.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   The DocumentManagerViewModel interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using UI.Entities.CertificateQualityDomain.ManufacturersCertificateDomain;

namespace UI.Infrastructure.ViewModels
{
    using System;
    using System.Drawing;
    using System.Windows.Input;

    using ReactiveUI;

    using UI.Entities.AttachedDocumentDomain;
    using UI.Infrastructure.ViewModels.AttachedDocumentDomain;

    public interface IDocumentManagerViewModel : IRoutableViewModel, IDisposable
    {
        bool IsBusy { get; }
        IObservable<Image> ImageChangedNotification { get; }
        IGetImageViewModel GetImageViewModel { get; }
        IEditImageViewModel EditImageViewModel { get; }
        ManageImageMode ManageImageMode { get; }
        CertificateQualityAttachedDocument InsertingDocument { get; }
        ICommand BeginInsertCommand { get; }
        ICommand ApplyInsertCommand { get; }
        ICommand CancelInsertCommand { get; }
        ICommand RemoveDocumentCommand { get; }
        bool IsInserting { get; }

        void InitDocument(Action<CertificateQualityAttachedDocument> action);
        void SetHasDocument(IHasDocument hasDocument);
    }
}