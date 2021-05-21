// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IAttachedDocumentViewModel.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   The AttachedDocumentViewer interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Infrastructure.ViewModels
{
    using System;
    using System.Collections.Generic;

    using ReactiveUI;

    using UI.Entities.AttachedDocumentDomain;

    public enum ManageImageMode
    {
        None,
        Inserting,
        ImageEditing,
        Apply,
        Cancelling
    }

    public interface IAttachedDocumentViewModel : IRoutableViewModel, IDisposable
    {
        bool IsBusy { get; }
        IDocumentManagerViewModel DocumentManagerViewModel { get; }
        IHasDocument HasDocument { get; }
        AttachedDocument SelectedDocument { get; set; }
        IList<AttachedDocumentType> AttachedDocumentTypes { get; }
        IGetCatalogAccess CatalogAccess { get; }
        void SetHasDocument(IObservable<IHasDocument> hasDocument);
        void SetHasDocument(IHasDocument hasDocument);
    }
}
