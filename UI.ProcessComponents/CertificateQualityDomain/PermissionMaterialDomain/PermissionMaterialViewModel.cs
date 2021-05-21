namespace UI.ProcessComponents.CertificateQualityDomain.PermissionMaterialDomain
{
    using Buisness.Entities.PermissionMaterialDomain;
    using Buisness.Filters;
    using Halfblood.Common;
    using Halfblood.Common.Mappers;
    using ParusModelLite.CertificateQualityDomain.PermissionMaterialDomain;
    using ReactiveUI;
    using ServiceContracts;
    using ServiceContracts.Facades;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Linq;
    using System.Reactive;
    using System.Reactive.Linq;
    using System.Reactive.Subjects;
    using System.Windows.Input;
    using UI.Entities.PermissionMaterialDomain;
    using UI.Infrastructure;
    using UI.Infrastructure.ViewModels;
    using UI.Infrastructure.ViewModels.Filters;
    using UI.Infrastructure.ViewModels.PermissionMaterialDomain;
    using UI.ProcessComponents.FilterViewModels.CertificateQualityDomain.PermissionMaterialDomain;
    using UI.ProcessComponents.Helpers;

    [Export(typeof(IPermissionMaterialViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class PermissionMaterialViewModel : ReactiveObject, IPermissionMaterialViewModel
    {
        #region private fields
        private PermissionMaterialLiteDto _selectedPermissionMaterial;
        private PermissionMaterialExtensionDto _selectedPermissionMaterialEx;
        private bool _isBusy;

        private readonly IRoutableViewModelManager _routableViewModelManager;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IFilterViewModelFactory _filterViewModelFactory;
        private readonly IMessageBus _messageBus;
        private readonly DisposableObject _disposables = new DisposableObject();
        private readonly Subject<Unit> _disposableNotification = new Subject<Unit>();

        private ReactiveCommand _preparingForStatusPermissionMaterialCommand;
        private ReactiveCommand _preparingForEditPermissionMaterialCommand;
        private ReactiveCommand _preparingForRemovingPermissionMaterialCommand;

        private ReactiveCommand _preparingForAddingPermissionMaterialExCommand;
        private ReactiveCommand _preparingForEditPermissionMaterialExCommand;
        private ReactiveCommand _preparingForRemovingPermissionMaterialExCommand;

        private IPermissionMaterialFilterViewModel _filterViewModel;
        private IFilterViewModel<PermissionMaterialUserFilter, PermissionMaterialUserDto> _permissionMaterialUserFilterViewModel;
        private IFilterViewModel<PermissionMaterialExtensionFilter, PermissionMaterialExtensionDto> _permissionMaterialExtensionFilterViewModel;
        #endregion


        [ImportingConstructor]
        public PermissionMaterialViewModel(
            IScreen screen,
            IMessenger messenger,
            IMessageBus messageBus,
            IUnitOfWorkFactory unitOfWorkFactory,
            IFilterViewModelFactory filterViewModelFactory,
            IRoutableViewModelManager routableViewModelManager
            )
        {
            HostScreen = screen;
            _messageBus = messageBus;
            _unitOfWorkFactory = unitOfWorkFactory;
            _filterViewModelFactory = filterViewModelFactory;
            _routableViewModelManager = routableViewModelManager;
            _disposables.Add(ListenMessage().Concat(Binding()));

            PermissionMaterialFilterViewModel.InvokeCommand.Execute(null);
        }

        public bool IsBusy
        {
            get { return _isBusy; }
            private set { this.RaiseAndSetIfChanged(ref _isBusy, value); }
        }
        public IScreen HostScreen { get; private set; }
        public string UrlPathSegment
        {
            get { return "/PermissionMaterialView"; }
        }


        // selected =================================================================================
        public PermissionMaterialLiteDto SelectedPermissionMaterial
        {
            get { return _selectedPermissionMaterial; }
            set
            {
                this.RaiseAndSetIfChanged(ref _selectedPermissionMaterial, value);
                OnSelectedPermissionMaterial(value);
            }
        }
        public PermissionMaterialExtensionDto SelectedPermissionMaterialEx
        {
            get { return _selectedPermissionMaterialEx; }
            set
            {
                this.RaiseAndSetIfChanged(ref _selectedPermissionMaterialEx, value);
                OnSelectedPermissionMaterialEx(value);
            }
        }
        private void OnSelectedPermissionMaterial(PermissionMaterialLiteDto permissionMaterial)
        {
            if (permissionMaterial == null) { return; }

            PermissionMaterialUserFilterViewModel.Filter.PermissionMaterial.Rn = permissionMaterial.Rn;
            PermissionMaterialUserFilterViewModel.InvokeCommand.Execute(null);

            PermissionMaterialExtensionFilterViewModel.Filter.PermissionMaterial.Rn = permissionMaterial.Rn;
            PermissionMaterialExtensionFilterViewModel.InvokeCommand.Execute(null);
        }
        private void OnSelectedPermissionMaterialEx(PermissionMaterialExtensionDto permissionMaterialExtension)
        { }


        // filter ===================================================================================
        public IPermissionMaterialFilterViewModel PermissionMaterialFilterViewModel
        {
            get
            {
                return _filterViewModel ??
                       (_filterViewModel = new PermissionMaterialFilterViewModel(_unitOfWorkFactory));
            }
        }
        public IFilterViewModel<PermissionMaterialUserFilter, PermissionMaterialUserDto> PermissionMaterialUserFilterViewModel
        {
            get
            {
                return _permissionMaterialUserFilterViewModel ??
                       (_permissionMaterialUserFilterViewModel =
                           _filterViewModelFactory.Create<PermissionMaterialUserFilter, PermissionMaterialUserDto>());
            }
        }
        public IFilterViewModel<PermissionMaterialExtensionFilter, PermissionMaterialExtensionDto> PermissionMaterialExtensionFilterViewModel
        {
            get
            {
                return _permissionMaterialExtensionFilterViewModel ??
                       (_permissionMaterialExtensionFilterViewModel =
                           _filterViewModelFactory
                               .Create<PermissionMaterialExtensionFilter, PermissionMaterialExtensionDto>());
            }
        }


        // change status pm =========================================================================
        public ICommand PreparingForStatusPermissionMaterialCommand
        {
            get
            {
                if (_preparingForStatusPermissionMaterialCommand == null)
                {
                    var observable =
                        this.WhenAny(x => x.SelectedPermissionMaterial, x => x.Value)
                            .Select(x => x != null && x.Rn != 0)
                            .StartWith(SelectedPermissionMaterial != null);
                    _preparingForStatusPermissionMaterialCommand = GetCommandStatusPermissionMaterial(observable);
                }

                return _preparingForStatusPermissionMaterialCommand;
            }
        }
        private ReactiveCommand GetCommandStatusPermissionMaterial(IObservable<bool> canExecute = null)
        {
            var command = new ReactiveCommand(canExecute);
            command.Subscribe(
                result =>
                {
                    var collection = PermissionMaterialUserFilterViewModel.Result as IEnumerable<PermissionMaterialUserDto>;

                    collection = collection.Where(x => x.PermissionMaterial.Rn == SelectedPermissionMaterial.Rn);

                    if (!collection.Any())
                    {
                        return;
                    }


                    //var viewModel = _routableViewModelManager.Get<IStatusPermissionMaterialUserViewModel>();
                    //viewModel.SetActionObjectCollection(collection.MapTo<PermissionMaterialUser>());
                });

            return command;
        }


        // edit pm ==================================================================================
        public ICommand PreparingForEditPermissionMaterialCommand
        {
            get
            {
                if (_preparingForEditPermissionMaterialCommand == null)
                {
                    var observable =
                        this.WhenAny(x => x.SelectedPermissionMaterial, x => x.Value)
                            .Select(x => x != null && x.Rn != 0)
                            .StartWith(SelectedPermissionMaterial != null);
                    _preparingForEditPermissionMaterialCommand = GetCommandEditPermisionMaterial(EditState.Edit, observable);
                }

                return _preparingForEditPermissionMaterialCommand;
            }
        }
        private ReactiveCommand GetCommandEditPermisionMaterial(EditState editState, IObservable<bool> canExecute = null)
        {
            var command = new ReactiveCommand(canExecute);
            command.RegisterAsyncFunction(
                _ => new { PermissionMaterial = PreparingForEditablePermissionMaterial(editState), EditState = editState })
            .Subscribe(
                    result =>
                    {
                        var viewModel = _routableViewModelManager.Get<IEditablePermissionMaterialViewModel>();
                        viewModel.SetEditableObject(result.PermissionMaterial, result.EditState);

                        HostScreen.Router.Navigate.Execute(viewModel);
                    });

            command.IsExecuting.Subscribe(isExecuting => IsBusy = isExecuting);
            return command;
        }
        private PermissionMaterial PreparingForEditablePermissionMaterial(EditState editState)
        {
            if (editState == EditState.Edit)
            {
                using (var unitOfWork = _unitOfWorkFactory.Create())
                {
                    var service = unitOfWork.Create<IPermissionMaterialService>();
                    var permissionMaterial = service.GetPermissionMaterial(SelectedPermissionMaterial.Rn).MapTo<PermissionMaterial>();
                    return permissionMaterial;
                }
            }

            return new PermissionMaterial();
        }


        // remove pm ================================================================================
        public ICommand PreparingForRemovingPermissionMaterialCommand
        {
            get
            {
                if (_preparingForRemovingPermissionMaterialCommand == null)
                {
                    var observable =
                        this.WhenAny(x => x.SelectedPermissionMaterial, x => x.Value)
                            .Select(x => x != null && x.Rn != 0)
                            .StartWith(SelectedPermissionMaterial != null);
                    _preparingForRemovingPermissionMaterialCommand = GetCommandRemovePermisionMaterial(observable);
                }

                return _preparingForRemovingPermissionMaterialCommand;
            }
        }
        private ReactiveCommand GetCommandRemovePermisionMaterial(IObservable<bool> canExecute = null)
        {
            var command = new ReactiveCommand(canExecute);

            command.RegisterAsyncAction(_ => RemovePermissionMaterial(SelectedPermissionMaterial.Rn))
                .Subscribe(
                    result => PermissionMaterialFilterViewModel.Result.Remove(SelectedPermissionMaterial));

            command.IsExecuting.Subscribe(isExecuting => IsBusy = isExecuting);
            return command;
        }
        private void RemovePermissionMaterial(long rn)
        {
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                var service = unitOfWork.Create<IPermissionMaterialService>();
                service.RemovePermissionMaterial(rn);

                unitOfWork.Commit();
            }
        }


        // add pme ==================================================================================
        public ICommand PreparingForAddingPermissionMaterialExCommand
        {
            get
            {
                return _preparingForAddingPermissionMaterialExCommand
                       ?? (_preparingForAddingPermissionMaterialExCommand = GetCommandEditPermisionMaterialEx(EditState.Insert));
            }
        }


        // edit pme =================================================================================
        public ICommand PreparingForEditPermissionMaterialExCommand
        {
            get
            {
                if (_preparingForEditPermissionMaterialExCommand == null)
                {
                    var observable =
                        this.WhenAny(x => x.SelectedPermissionMaterialEx, x => x.Value)
                            .Select(x => x != null && x.Rn != 0)
                            .StartWith(SelectedPermissionMaterial != null);
                    _preparingForEditPermissionMaterialExCommand = GetCommandEditPermisionMaterialEx(EditState.Edit, observable);
                }

                return _preparingForEditPermissionMaterialExCommand;
            }
        }
        private ReactiveCommand GetCommandEditPermisionMaterialEx(EditState editState, IObservable<bool> canExecute = null)
        {
            var command = new ReactiveCommand(canExecute);
            command.RegisterAsyncFunction(
                _ => new { PermissionMaterialExtension = PreparingForEditablePermissionMaterialEx(editState), EditState = editState })
                .Subscribe(
                    result =>
                    {
                        var viewModel = _routableViewModelManager.Get<IEditablePermissionMaterialExtensionViewModel>();
                        viewModel.SetEditableObject(result.PermissionMaterialExtension, result.EditState);

                        HostScreen.Router.Navigate.Execute(viewModel);
                    });

            command.IsExecuting.Subscribe(isExecuting => IsBusy = isExecuting);
            return command;
        }
        private PermissionMaterialExtension PreparingForEditablePermissionMaterialEx(EditState editState)
        {

            if (editState == EditState.Edit)
            {
                using (var unitOfWork = _unitOfWorkFactory.Create())
                {
                    var service = unitOfWork.Create<IPermissionMaterialService>();
                    var permissionMaterialEx = service.GetPermissionMaterialExtension(SelectedPermissionMaterialEx.Rn).MapTo<PermissionMaterialExtension>();
                    return permissionMaterialEx;
                }
            }

            return new PermissionMaterialExtension(SelectedPermissionMaterial.Rn);
        }


        // remove pme ===============================================================================
        public ICommand PreparingForRemovingPermissionMaterialExCommand
        {
            get
            {
                if (_preparingForRemovingPermissionMaterialExCommand == null)
                {
                    var observable =
                        this.WhenAny(x => x.SelectedPermissionMaterialEx, x => x.Value)
                            .Select(x => x != null && x.Rn != 0)
                            .StartWith(SelectedPermissionMaterialEx != null);
                    _preparingForRemovingPermissionMaterialExCommand = GetCommandRemovePermisionMaterialEx(observable);
                }

                return _preparingForRemovingPermissionMaterialExCommand;
            }
        }
        private ReactiveCommand GetCommandRemovePermisionMaterialEx(IObservable<bool> canExecute = null)
        {
            var command = new ReactiveCommand(canExecute);

            command.RegisterAsyncAction(_ => RemovePermissionMaterialEx(SelectedPermissionMaterialEx.Rn))
                .Subscribe(
                    result => PermissionMaterialExtensionFilterViewModel.Result.Remove(SelectedPermissionMaterialEx));

            command.IsExecuting.Subscribe(isExecuting => IsBusy = isExecuting);
            return command;
        }
        private void RemovePermissionMaterialEx(long rn)
        {
            using (IUnitOfWork unitOfWork = _unitOfWorkFactory.Create())
            {
                var service = unitOfWork.Create<IPermissionMaterialService>();
                service.RemovePermissionMaterialExtension(rn);

                unitOfWork.Commit();
            }
        }


        public void Dispose()
        {
            _disposables.Dispose();
            _disposableNotification.OnNext(Unit.Default);
        }
        private IEnumerable<IDisposable> ListenMessage()
        {
            yield return
                _messageBus.ListenAddedMessage<PermissionMaterial, PermissionMaterialLiteDto>(
                    this.WhenAny(x => x.PermissionMaterialFilterViewModel.Result));
            yield return
                _messageBus.ListenAddedMessage<PermissionMaterialUser, PermissionMaterialUserDto>(
                    this.WhenAny(x => x.PermissionMaterialUserFilterViewModel.Result));
            yield return
                _messageBus.ListenAddedMessage<PermissionMaterialExtension, PermissionMaterialExtensionDto>(
                    this.WhenAny(x => x.PermissionMaterialExtensionFilterViewModel.Result));
            yield return
                _messageBus.ListenAddedMessage<PermissionMaterialExtensionUser, PermissionMaterialExtensionUserDto>(
                    this.WhenAny(x => x.SelectedPermissionMaterialEx.PmeUsers));

            yield return
                _messageBus.ListenUpdatedMessage<PermissionMaterial, PermissionMaterialLiteDto>(
                    this.WhenAny(x => x.PermissionMaterialFilterViewModel.Result));
            yield return
                _messageBus.ListenUpdatedMessage<PermissionMaterialUser, PermissionMaterialUserDto>(
                    this.WhenAny(x => x.PermissionMaterialUserFilterViewModel.Result));
            yield return
                _messageBus.ListenUpdatedMessage<PermissionMaterialExtension, PermissionMaterialExtensionDto>(
                    this.WhenAny(x => x.PermissionMaterialExtensionFilterViewModel.Result));
            yield return
                _messageBus.ListenUpdatedMessage<PermissionMaterialExtensionUser, PermissionMaterialExtensionUserDto>(
                    this.WhenAny(x => x.SelectedPermissionMaterialEx.PmeUsers));
        }
        private IEnumerable<IDisposable> Binding()
        {
            yield return
                this.WhenAny(x => x.PermissionMaterialFilterViewModel.IsBusy).Subscribe(isBusy => IsBusy = isBusy);
        }
    }
}