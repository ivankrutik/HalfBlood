// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AttachedDocumentViewModel.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the AttachedDocumentViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.ProcessComponents.PlanReceiptOrderDomain.PlanCertificateDomain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Linq;
    using System.Reactive;
    using System.Reactive.Linq;
    using System.Reactive.Subjects;
    using System.Text.RegularExpressions;

    using Buisness.Entities.CommonDomain;

    using Halfblood.Common;
    using Halfblood.Common.Log;

    using ReactiveUI;

    using ServiceContracts;
    using ServiceContracts.Facades;

    using UI.Entities.AttachedDocumentDomain;
    using UI.Entities.CommonDomain;
    using UI.Infrastructure;
    using UI.Infrastructure.ViewModels;

    [Export(typeof(IAttachedDocumentViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class AttachedDocumentViewModel : ReactiveObject, IAttachedDocumentViewModel
    {
        #region PRIVATE FIELDS
        private readonly IRoutableViewModelManager _viewModelManager;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly DisposableObject _disposableObject = new DisposableObject();
        private readonly Subject<Unit> _disposedNotification = new Subject<Unit>();
        private AttachedDocument _selectedDocument;
        private IHasDocument _hasDocument;
        private IList<AttachedDocumentType> _attachedDocumentTypes;
        private IGetCatalogAccess _getAccess;
        private IDocumentManagerViewModel _documentManagerViewModel;
        private bool _isBusy;
        #endregion

        ~AttachedDocumentViewModel()
        {
            LogManager.Log.Debug("AttachedDocumentViewModel IS DESTROYED");
        }

        [ImportingConstructor]
        public AttachedDocumentViewModel(
            IScreen screen,
            IRoutableViewModelManager viewModelManager,
            IUnitOfWorkFactory unitOfWorkFactory,
            IGetCatalogAccess getCatalogAccess)
        {
            HostScreen = screen;
            _viewModelManager = viewModelManager;
            _unitOfWorkFactory = unitOfWorkFactory;
            _getAccess = getCatalogAccess;
            CatalogAccess.LoadForEntity(typeof(AttachedDocument), TypeActionInSystem.TheStandardAddition);

            _disposableObject.Add(this.Binding());
        }

        public bool IsBusy
        {
            get { return _isBusy; }
            private set { this.RaiseAndSetIfChanged(ref _isBusy, value); }
        }
        public IDocumentManagerViewModel DocumentManagerViewModel
        {
            get
            {
                if (this._documentManagerViewModel == null)
                {
                    _documentManagerViewModel =
                        _viewModelManager.Get<IDocumentManagerViewModel>(_disposedNotification);
                    _documentManagerViewModel.InitDocument(
                        document =>
                        {
                            if (document.DocumentType == null && 
                                AttachedDocumentTypes != null && 
                                AttachedDocumentTypes.Any())
                            {
                                document.DocumentType =
                                    AttachedDocumentTypes.FirstOrDefault(
                                        x => Regex.Replace(x.Code.Trim(), @"\s+", " ") == "Сертификат ЗИ");
                            }

                            if (document.Catalog == null)
                            {
                                CatalogAccess.GetInvokedTask().Wait();

                                var collection =
                                    CatalogAccess.Result.Union(CatalogAccess.Result.SelectMany(x => x.Childs));
                                CatalogHierarchical selectCatalog = collection.FirstOrDefault(x => x.IsAccess);
                                if (selectCatalog != null)
                                {
                                    document.Catalog = new Catalog(selectCatalog.Rn) { Name = selectCatalog.Name };
                                }
                            }
                        });
                }

                return this._documentManagerViewModel;
            }
        }
        public IList<AttachedDocumentType> AttachedDocumentTypes
        {
            get { return this._attachedDocumentTypes; }
            set { this.RaiseAndSetIfChanged(ref _attachedDocumentTypes, value); }
        }
        public IGetCatalogAccess CatalogAccess
        {
            get { return _getAccess; }
            private set { this.RaiseAndSetIfChanged(ref _getAccess, value); }
        }
        public AttachedDocument SelectedDocument
        {
            get { return this._selectedDocument; }
            set { this.RaiseAndSetIfChanged(ref this._selectedDocument, value); }
        }
        public IHasDocument HasDocument
        {
            get { return this._hasDocument; }
            private set { this.RaiseAndSetIfChanged(ref _hasDocument, value); }
        }
        public string UrlPathSegment
        {
            get;
            private set;
        }
        public IScreen HostScreen
        {
            get;
            private set;
        }

        public void Dispose()
        {
            _disposableObject.Dispose();
            _hasDocument = null;
            _disposedNotification.OnNext(Unit.Default);
        }
        public void SetHasDocument(IObservable<IHasDocument> hasDocument)
        {
            _disposableObject.Add(hasDocument.Subscribe(doc => HasDocument = doc));
        }
        public void SetHasDocument(IHasDocument hasDocument)
        {
            SetHasDocument(Observable.Return(hasDocument));
        }

        private IEnumerable<IDisposable> Binding()
        {
            yield return DocumentManagerViewModel.WhenAnyValue(x => x.IsBusy).Subscribe(isBusy => IsBusy = isBusy);

            yield return
                this.WhenAnyValue(x => x.HasDocument)
                    .Where(doc => doc != null)
                    .Subscribe(DocumentManagerViewModel.SetHasDocument);

            yield return
                this.WhenAny(x => x.SelectedDocument).Where(doc => doc != null && doc.Content == null).Subscribe(
                    doc =>
                    {
                        var loader = new AsyncRunner<byte[]>();
                        loader.RegisterFunction(
                            () =>
                            {
                                using (IUnitOfWork unitOfWork = this._unitOfWorkFactory.Create())
                                {
                                    var service = unitOfWork.Create<IAttachedDocumentService>();
                                    return service.GetContent(doc.Rn);
                                }
                            });
                        var bytes = loader.GetInvokedTask().Result;
                        if (bytes == null || bytes.Length == 0)
                        {
                            doc.Content = null;
                        }
                        else
                        {
                            doc.Content = bytes;
                        }
                    });
        }
    }
}