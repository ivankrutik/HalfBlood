// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DocumentManagerViewModel.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the DocumentManagerViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



namespace UI.ProcessComponents.AttachedDocumentDomain
{
    using Halfblood.Common.Log;
    using UI.Entities.CertificateQualityDomain.ManufacturersCertificateDomain;

    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.Composition;
    using System.Diagnostics.Contracts;
    using System.Drawing;
    using System.Reactive;
    using System.Reactive.Linq;
    using System.Reactive.Subjects;
    using System.Windows.Input;

    using FluentValidation;

    using Halfblood.Common;

    using ReactiveUI;
    using Infrastructure;
    using Infrastructure.ViewModels;
    using Infrastructure.ViewModels.AttachedDocumentDomain;
    using Halfblood.Common.Helpers.FileManagers.Converters;

    [Export(typeof(IDocumentManagerViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class DocumentManagerViewModel : DocumentManager, IDocumentManagerViewModel
    {
        #region private fields
        private readonly DisposableObject _disposableObject = new DisposableObject();
        private readonly Subject<Unit> _disposedNotification = new Subject<Unit>();
        private readonly IRoutableViewModelManager _routableViewModelManager;
        private readonly IValidator<CertificateQualityAttachedDocument> _validator;
        private readonly Subject<Image> _imageChangedNotification = new Subject<Image>();
        private Action<CertificateQualityAttachedDocument> _action;
        private IEditImageViewModel _editImageViewModel;
        private IGetImageViewModel _getImageViewModel;
        private ManageImageMode _manageImageMode;
        private ReactiveCommand _beginInsertCommand;
        private ReactiveCommand _applyInsertCommand;
        private ReactiveCommand _cancelAddingCommand;
        private ReactiveCommand _removeDocumentCommand;
        private bool _isBusy;

        #endregion

        ~DocumentManagerViewModel()
        {
            LogManager.Log.Debug("DocumentManagerViewModel IS DESTROYED");
        }

        [ImportingConstructor]
        public DocumentManagerViewModel(
            IRoutableViewModelManager routableViewModelManager,
            IValidatorFactory validatorFactory)
        {
            _routableViewModelManager = routableViewModelManager;
            _validator = validatorFactory.GetValidator<CertificateQualityAttachedDocument>();
            _disposableObject.Add(Binding());
            ApplyInsertCommand = CreateApplyCommand();
        }

        public IObservable<Image> ImageChangedNotification
        {
            get { return _imageChangedNotification; }
        }
        public IGetImageViewModel GetImageViewModel
        {
            get
            {
                return _getImageViewModel
                       ?? (_getImageViewModel = _routableViewModelManager.Get<IGetImageViewModel>(_disposedNotification));
            }
        }
        public IEditImageViewModel EditImageViewModel
        {
            get
            {
                return _editImageViewModel
                       ?? (_editImageViewModel = _routableViewModelManager.Get<IEditImageViewModel>(_disposedNotification));
            }
        }
        public ManageImageMode ManageImageMode
        {
            get { return _manageImageMode; }
            private set { this.RaiseAndSetIfChanged(ref _manageImageMode, value); }
        }
        public ICommand BeginInsertCommand
        {
            get
            {
                if (_beginInsertCommand == null)
                {
                    _beginInsertCommand =
                        new ReactiveCommand(this.WhenAny(x => x.HasDocument, x => x.Value != null));

                    _beginInsertCommand.Subscribe(
                        _ =>
                        {
                            BeginInsert();
                            ManageImageMode = ManageImageMode.Inserting;
                        });
                }

                return _beginInsertCommand;
            }
        }
        public ICommand ApplyInsertCommand
        {
            get { return _applyInsertCommand; }
            private set
            {
                if (_applyInsertCommand != null)
                {
                    _applyInsertCommand.Dispose();
                }

                _applyInsertCommand = (ReactiveCommand)value;
                this.RaisePropertyChanged();
            }
        }
        public ICommand CancelInsertCommand
        {
            get
            {
                if (_cancelAddingCommand == null)
                {
                    _cancelAddingCommand = new ReactiveCommand(this.WhenAny(x => x.IsInserting));

                    _cancelAddingCommand.ObserveOnUiSafeScheduler().Subscribe(
                        _ =>
                        {
                            CancelInsert();
                            ManageImageMode = ManageImageMode.Cancelling;
                        });
                }

                return _cancelAddingCommand;
            }
        }
        public ICommand RemoveDocumentCommand
        {
            get
            {
                if (_removeDocumentCommand == null)
                {
                    _removeDocumentCommand =
                        new ReactiveCommand(
                            this.WhenAny(x => x.HasDocument, x => x.Value != null && x.Value.Documents != null));

                    _removeDocumentCommand.Subscribe(
                        selectedDocument => DeletingDocument((CertificateQualityAttachedDocument)selectedDocument));
                }

                return _removeDocumentCommand;
            }
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
        public bool IsBusy
        {
            get { return _isBusy; }
            private set { this.RaiseAndSetIfChanged(ref _isBusy, value); }
        }
        public void InitDocument(Action<CertificateQualityAttachedDocument> action)
        {
            Contract.Requires(action != null, "The action must be not null");
            _action = action;
        }
        public void Dispose()
        {
            if (_beginInsertCommand != null)
            {
                _beginInsertCommand.Dispose();
                _beginInsertCommand = null;
            }

            if (_applyInsertCommand != null)
            {
                _applyInsertCommand.Dispose();
                _applyInsertCommand = null;
            }

            if (_cancelAddingCommand != null)
            {
                _cancelAddingCommand.Dispose();
                _cancelAddingCommand = null;
            }

            if (_removeDocumentCommand != null)
            {
                _removeDocumentCommand.Dispose();
                _removeDocumentCommand = null;
            }

            _disposableObject.Dispose();

            HasDocument = null;
            _disposedNotification.OnNext(Unit.Default);
        }

        protected override void Reset()
        {
            base.Reset();
            ApplyInsertCommand = CreateApplyCommand();
        }
        protected override void InitDocument(CertificateQualityAttachedDocument attachedDocument)
        {
            base.InitDocument(attachedDocument);
            if (_action != null)
            {
                _action(attachedDocument);
            }
        }

        private ReactiveCommand CreateApplyCommand()
        {
            var applyCanExecuteObservable = this.WhenAnyValue(x => x.IsInserting)
                .CombineLatest(
                    this.WhenAnyValue(x => x.InsertingDocument).Select(
                        doc =>
                        {
                            if (doc != null)
                            {
                                return
                                    Observable
                                        .FromEventPattern<PropertyChangedEventHandler, PropertyChangedEventArgs>(
                                            h => doc.PropertyChanged += h,
                                            h => doc.PropertyChanged -= h)
                                .Select(_ => true);
                            }

                            return Observable.Return(false);
                        }).Concat(),
                    (left, right) => left && right)
                .StartWith(
                    InsertingDocument != null && _validator.Validate(InsertingDocument).IsValid && IsInserting);

            var command = new ReactiveCommand(applyCanExecuteObservable);

            command.Subscribe(
                _ =>
                {
                    if (!ApplyInsert())
                    {
                        LogManager.Log.Debug("!_documentManager.ApplyInsert()");
                    }
                    else
                    {
                        ManageImageMode = ManageImageMode.Apply;
                    }
                });

            return command;
        }
        private IEnumerable<IDisposable> Binding()
        {
            yield return GetImageViewModel.WhenAnyValue(x => x.IsBusy).Subscribe(isBusy => IsBusy = isBusy);

            yield return GetImageViewModel.ReadingFileCompletedNotification.Subscribe(
                _ =>
                {
                    Image image = GetImageViewModel.Image;

                    var imageThumbnail = image.ThumbnailImage();

                    InsertingDocument.Content = ImagesConverter.ToByteArray(image);
                    InsertingDocument.ContentThumbnail = imageThumbnail != null ? ImagesConverter.ToByteArray(imageThumbnail) : null;
                    EditImageViewModel.SetImage(image);
                    ManageImageMode = ManageImageMode.ImageEditing;
                    _imageChangedNotification.OnNext(image);
                });

            yield return EditImageViewModel.ImageTransformedNotification.Subscribe(
                image =>
                {
                    InsertingDocument.Content = ImagesConverter.ToByteArray(image);
                    _imageChangedNotification.OnNext(image);
                });
        }
    }
}