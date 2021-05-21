// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PlanCertificateViewModel.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The plan certificate view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.ProcessComponents.PlanReceiptOrderDomain.PlanCertificateDomain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Linq;
    using System.Reactive.Linq;
    using System.Threading.Tasks;
    using System.Windows.Input;

    using Buisness.Entities.CommonDomain;
    using Buisness.Filters;

    using Halfblood.Common;
    using Halfblood.Common.Helpers;
    using Halfblood.Common.Log;
    using Halfblood.Common.Mappers;

    using ParusModelLite.PlanReceiptOrderDomain;

    using ReactiveUI;

    using ServiceContracts;
    using ServiceContracts.Facades;

    using UI.Entities.CommonDomain;
    using UI.Entities.PlanReceiptOrderDomain;
    using UI.Infrastructure;
    using UI.Infrastructure.ViewModels;
    using UI.Infrastructure.ViewModels.Filters;
    using UI.Infrastructure.ViewModels.PlanReceiptOrderDomain;

    [Export(typeof(IPlanCertificateViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class PlanCertificateViewModel : ReactiveObject, IPlanCertificateViewModel
    {
        #region private fields
        private readonly IRoutableViewModelManager _routableViewModelManager;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IFilterViewModelFactory _filterViewModelFactory;
        private readonly IInitializationManager _initializationManager;
        private PlanCertificateLiteDto _selectedPlanCertificate;
        private PersonalAccountOfPlanReceiptOrderLiteDto _selectedPlanReceiptOrderPersonalAccount;
        private ReactiveCommand _preparingEditablePersonalAccountCommand;
        private ReactiveCommand _preparingAddingPersonalAccountCommand;
        private ReactiveCommand _preparingRemovingPersonalAccountCommand;
        private ReactiveCommand _preparingEditablePlanCertificateCommand;
        private ReactiveCommand _preparingCopyPlanCertificateCommand;
        private ReactiveCommand _preparingAddingPlanCertificateCommand;
        private ReactiveCommand _preparingRemovingPlanCertificateCommand;
        private ReactiveCommand _preparingForStatusPersonalAccountCommand;
        private ReactiveCommand _preparingForStatusPlanCertificateCommand;
        private IFilterViewModel<PlanCertificateFilter, PlanCertificateLiteDto> _planCertificateFilterViewModel;
        private IFilterViewModel<PlanReceiptOrderPersonalAccountFilter, PersonalAccountOfPlanReceiptOrderLiteDto> _personalAccountFilterViewModel;
        private PlanReceiptOrderLiteDto _selectedPlanReceiptOrder;
        private bool _isBusy;
        #endregion

        [ImportingConstructor]
        public PlanCertificateViewModel(
            IScreen screen,
            IRoutableViewModelManager routableViewModelManager,
            IUnitOfWorkFactory unitOfWorkFactory,
            IFilterViewModelFactory filterViewModelFactory,
            IInitializationManager initializationManager)
        {
            HostScreen = screen;
            _routableViewModelManager = routableViewModelManager;
            _unitOfWorkFactory = unitOfWorkFactory;
            _filterViewModelFactory = filterViewModelFactory;
            _initializationManager = initializationManager;
        }

        ~PlanCertificateViewModel()
        {
            LogManager.Log.Debug("PlanCertificateViewModel IS DESTROYED");
        }

        public bool IsBusy
        {
            get { return _isBusy; }
            private set { this.RaiseAndSetIfChanged(ref _isBusy, value); }
        }
        public string UrlPathSegment
        {
            get { return "/PlanCertificatView"; }
        }
        public IScreen HostScreen
        {
            get;
            private set;
        }
        public IFilterViewModel<PlanCertificateFilter, PlanCertificateLiteDto> PlanCertificateFilterViewModel
        {
            get
            {
                return _planCertificateFilterViewModel
                       ?? (_planCertificateFilterViewModel =
                           _filterViewModelFactory.Create<PlanCertificateFilter, PlanCertificateLiteDto>());
            }
        }
        public IFilterViewModel<PlanReceiptOrderPersonalAccountFilter, PersonalAccountOfPlanReceiptOrderLiteDto> PersonalAccountFilterViewModel
        {
            get
            {
                return _personalAccountFilterViewModel
                       ?? (_personalAccountFilterViewModel =
                           _filterViewModelFactory
                               .Create<PlanReceiptOrderPersonalAccountFilter, PersonalAccountOfPlanReceiptOrderLiteDto>());
            }
        }
        public ICommand PreparingForStatusPlanCertificateCommand
        {
            get
            {
                if (_preparingForStatusPlanCertificateCommand == null)
                {
                    var observable =
                        this.WhenAny(
                            x => x.SelectedPlanReceiptOrder,
                            x => x.SelectedPlanCertificate,
                            x => x.IsBusy,
                            (planReceiptOrder, planCertificate, isBusy) =>
                            planReceiptOrder.Value != null && planCertificate.Value != null && !isBusy.Value)
                            .StartWith(SelectedPlanReceiptOrder != null && !IsBusy && SelectedPlanCertificate != null);

                    _preparingForStatusPlanCertificateCommand = new ReactiveCommand(observable);
                    _preparingForStatusPlanCertificateCommand.Subscribe(
                        items =>
                        {
                            var collection = items as IEnumerable<PlanCertificateLiteDto>;

                            if (collection == null)
                            {
                                throw new ArgumentException(
                                    "The command parameter must be type of {0}".StringFormat(
                                        typeof(IList<PlanCertificateLiteDto>)));
                            }

                            if (!collection.Any())
                            {
                                return;
                            }

                            var viewModel = this._routableViewModelManager.Get<IStatusPlanCertificateViewModel>();
                            viewModel.SetActionObjectCollection(collection.Select(x => new PlanCertificate(x.Rn)).ToList());
                            HostScreen.Router.Navigate.Execute(viewModel);
                        });
                }

                return _preparingForStatusPlanCertificateCommand;
            }
        }
        public ICommand PreparingForStatusPersonalAccountCommand
        {
            get
            {
                if (_preparingForStatusPersonalAccountCommand == null)
                {
                    var observable =
                        this.WhenAny(
                            x => x.SelectedPlanReceiptOrder,
                            x => x.SelectedPlanCertificate,
                            x => x.IsBusy,
                            (planReceiptOrder, planCertificate, isBusy) =>
                            new { PRO = planReceiptOrder.Value, PC = planCertificate.Value, IsBusy = isBusy })
                            .Select(x => x.PRO != null && !IsBusy)
                            .StartWith(SelectedPlanReceiptOrder != null && !IsBusy);

                    _preparingForStatusPersonalAccountCommand = GetCommandStatusPersonalAccountCommand(observable);
                }
                return _preparingForStatusPersonalAccountCommand;
            }
        }
        public ICommand PreparingEditablePlanCertificateCommand
        {
            get
            {
                if (_preparingEditablePlanCertificateCommand == null)
                {
                    var observable =
                        this.WhenAny(
                            x => x.SelectedPlanReceiptOrder,
                            x => x.SelectedPlanCertificate,
                            x => x.IsBusy,
                            (planReceiptOrder, planCertificate, isBusy) =>
                            new { PRO = planReceiptOrder.Value, PC = planCertificate.Value, IsBusy = isBusy })
                            .Select(
                                x =>
                                x.PRO != null && !IsBusy && x.PC != null)
                            .StartWith(
                                SelectedPlanReceiptOrder != null && !IsBusy && SelectedPlanCertificate != null);

                    _preparingEditablePlanCertificateCommand = this.GetCommandEditablePlanCertificate(EditState.Edit, observable);
                }

                return _preparingEditablePlanCertificateCommand;
            }
        }
        public ICommand PreparingCopyPlanCertificateCommand
        {
            get
            {
                if (_preparingCopyPlanCertificateCommand == null)
                {
                    var observable =
                        this.WhenAny(
                            x => x.SelectedPlanReceiptOrder,
                            x => x.SelectedPlanCertificate,
                            x => x.IsBusy,
                            (planReceiptOrder, planCertificate, isBusy) =>
                            new { PRO = planReceiptOrder.Value, PC = planCertificate.Value, IsBusy = isBusy })
                            .Select(x => x.PRO != null && !IsBusy)
                            .StartWith(SelectedPlanReceiptOrder != null && !IsBusy);

                    _preparingCopyPlanCertificateCommand = this.GetCommandEditablePlanCertificate(EditState.Clone, observable);
                }

                return _preparingCopyPlanCertificateCommand;
            }
        }
        public ICommand PreparingAddingPlanCertificateCommand
        {
            get
            {
                if (_preparingAddingPlanCertificateCommand == null)
                {
                    var canExecute =
                        this.WhenAny(x => x.SelectedPlanReceiptOrder, x => x.Value)
                            .Select(pro => pro != null)
                            .StartWith(SelectedPlanReceiptOrder != null);

                    _preparingAddingPlanCertificateCommand = this.GetCommandEditablePlanCertificate(EditState.Insert, canExecute);
                }

                return _preparingAddingPlanCertificateCommand;
            }
        }
        public ICommand PreparingRemovingPlanCertificateCommand
        {
            get
            {
                if (_preparingRemovingPlanCertificateCommand == null)
                {
                    var observable =
                        this.WhenAny(x => x.SelectedPlanCertificate, x => x.Value)
                            .Select(x => x != null && x.Rn != 0)
                            .StartWith(SelectedPlanCertificate != null && SelectedPlanCertificate.Rn > 0);

                    _preparingRemovingPlanCertificateCommand = GetCommandRemovePlanCertificate(observable);
                }

                return _preparingRemovingPlanCertificateCommand;
            }
        }
        public ICommand PreparingEditablePersonalAccountCommand
        {
            get
            {
                if (_preparingEditablePersonalAccountCommand == null)
                {
                    var observable =
                        this.WhenAny(
                            x => x.SelectedPlanCertificate,
                            x => x.SelectedPlanReceiptOrderPersonalAccount,
                            x => x.IsBusy,
                            (planCertificate, planReceiptOrderPersonalAccount, isBusy) =>
                            new
                                {
                                    PC = planCertificate.Value,
                                    PCA = planReceiptOrderPersonalAccount.Value,
                                    IsBusy = isBusy
                                })
                            .Select(
                                x =>
                                x.PC != null && x.PCA != null && !IsBusy
                                && x.PCA.State != PlanReceiptOrderPersonalAccountState.Confirm)
                            .StartWith(
                                SelectedPlanCertificate != null && !IsBusy
                                && SelectedPlanReceiptOrderPersonalAccount != null
                                && SelectedPlanReceiptOrderPersonalAccount.State
                                != PlanReceiptOrderPersonalAccountState.Confirm);

                    _preparingEditablePersonalAccountCommand = GetCommandPersonalAccount(
                        EditState.Edit, observable);
                }

                return _preparingEditablePersonalAccountCommand;
            }
        }
        public ICommand PreparingAddingPersonalAccountCommand
        {
            get
            {
                return _preparingAddingPersonalAccountCommand
                       ?? (_preparingAddingPersonalAccountCommand = GetCommandPersonalAccount(EditState.Insert));
            }
        }
        public ICommand PreparingRemovingPersonalAccountCommand
        {
            get
            {
                if (_preparingRemovingPersonalAccountCommand == null)
                {
                    var observable =
                        this.WhenAny(x => x.SelectedPlanReceiptOrderPersonalAccount, x => x.Value)
                            .Select(x => x != null && x.Rn != 0 && x.State != PlanReceiptOrderPersonalAccountState.Confirm)
                            .StartWith(SelectedPlanReceiptOrderPersonalAccount != null);
                    _preparingRemovingPersonalAccountCommand = GetCommandRemovePersonalAccount(observable);
                }

                return _preparingRemovingPersonalAccountCommand;
            }
        }
        public PlanCertificateLiteDto SelectedPlanCertificate
        {
            get { return _selectedPlanCertificate; }
            set
            {
                this.RaiseAndSetIfChanged(ref _selectedPlanCertificate, value);
                OnSelectedPlanCertificate(value);
            }
        }
        public PlanReceiptOrderLiteDto SelectedPlanReceiptOrder
        {
            get { return _selectedPlanReceiptOrder; }
            set
            {
                this.RaiseAndSetIfChanged(ref _selectedPlanReceiptOrder, value);
                OnSelectedPlanReceiptOrder(value);
            }
        }
        public PersonalAccountOfPlanReceiptOrderLiteDto SelectedPlanReceiptOrderPersonalAccount
        {
            get { return _selectedPlanReceiptOrderPersonalAccount; }
            set { this.RaiseAndSetIfChanged(ref _selectedPlanReceiptOrderPersonalAccount, value); }
        }

        private void OnSelectedPlanReceiptOrder(PlanReceiptOrderLiteDto planReceiptOrder)
        {
            if (planReceiptOrder == null)
            {
                if (PlanCertificateFilterViewModel.Result != null)
                {
                    PlanCertificateFilterViewModel.Result.Clear();
                }

                return;
            }

            PlanCertificateFilterViewModel.Filter.RnPlanReceiptOrder = planReceiptOrder.Rn;
            PlanCertificateFilterViewModel.InvokeCommand.Execute(null);
        }
        private void OnSelectedPlanCertificate(PlanCertificateLiteDto planCertificate)
        {
            if (planCertificate == null)
            {
                if (PersonalAccountFilterViewModel.Result != null)
                {
                    PersonalAccountFilterViewModel.Result.Clear();
                }

                return;
            }

            PersonalAccountFilterViewModel.Filter.PlanCertificate.Rn = planCertificate.Rn;
            PersonalAccountFilterViewModel.InvokeCommand.Execute(null);
        }
        private PlanReceiptOrderPersonalAccount PreparingEditablePersonalAccount(EditState editState)
        {
            if (editState == EditState.Edit)
            {
                using (IUnitOfWork unitOfWork = _unitOfWorkFactory.Create())
                {
                    var service = unitOfWork.Create<IPlanReceiptOrderService>();

                    var d = service.GetPlanReceiptOrderPersonalAccountWithoutPlanCertificate(
                        SelectedPlanReceiptOrderPersonalAccount.Rn);
                    var f = d.MapTo<PlanReceiptOrderPersonalAccount>();
                    f.PlanCertificate = new PlanCertificate(SelectedPlanCertificate.Rn);
                    return f;
                }
            }

            return new PlanReceiptOrderPersonalAccount
            {
                PlanCertificate = new PlanCertificate(SelectedPlanCertificate.Rn)
            };
        }
        private PlanCertificate PreparingEditablePlanCertificate(EditState editState)
        {
            if (editState == EditState.Edit || editState == EditState.Clone)
            {
                using (IUnitOfWork unitOfWork = _unitOfWorkFactory.Create())
                {
                    var service = unitOfWork.Create<IPlanReceiptOrderService>();
                    var d = service.GetPlanCertificate(SelectedPlanCertificate.Rn);
                    var planCertificate = d.MapTo<PlanCertificate>();

                    return planCertificate;
                }
            }

            return new PlanCertificate { PlanReceiptOrder = new PlanReceiptOrder(SelectedPlanReceiptOrder.Rn) };
        }
        private ReactiveCommand GetCommandEditablePlanCertificate(EditState editState, IObservable<bool> canExecute = null)
        {
            var command = new ReactiveCommand(canExecute);
            command.RegisterAsyncFunction(
                _ =>
                {
                    var result = PreparingEditablePlanCertificate(editState);
                    var viewModel = _routableViewModelManager.Get<IEditablePlanCertificateViewModel>();

                    if (editState == EditState.Clone)
                    {
                        var obj = result.ClearValues();
                        viewModel.SetEditableObject(obj, editState);
                    }

                    if (editState == EditState.Edit)
                    {
                        viewModel.SetEditableObject(result, editState);
                    }

                    if (editState == EditState.Insert)
                    {
                        result.CertificateQuality.CreatorFactory =
                            new User(SelectedPlanReceiptOrder.RnContractor)
                            {
                                OrganizationName = SelectedPlanReceiptOrder.Contractor
                            };
                        viewModel.SetEditableObject(result, editState);
                    }

                    Task task = _initializationManager.InitViewModel(viewModel);
                    task.Wait();

                    return viewModel;
                })
                .ObserveOnUiSafeScheduler()
                .Subscribe(viewModel => this.HostScreen.Router.Navigate.Execute(viewModel));

            command.ThrownExceptions.Subscribe(this.OnError);
            command.IsExecuting.Subscribe(isExecuting => IsBusy = isExecuting);
            return command;
        }
        private ReactiveCommand GetCommandStatusPersonalAccountCommand(IObservable<bool> canExecute = null)
        {
            var command = new ReactiveCommand(canExecute);
            command.Subscribe(items => {
                var collection = items as IEnumerable<PersonalAccountOfPlanReceiptOrderLiteDto>;

                if (collection == null) {
                    throw new ArgumentException(
                        "The command parameter must be type of {0}".StringFormat(
                            typeof(IList<PersonalAccountOfPlanReceiptOrderLiteDto>)));
                }

                if (!collection.Any()) {
                    return;
                }

                var viewModel = this._routableViewModelManager.Get<IStatusPersonalAccountViewModel>();
                viewModel.SetActionObjectCollection(collection.MapTo<PlanReceiptOrderPersonalAccount>());
                HostScreen.Router.Navigate.Execute(viewModel);
            });

            command.ThrownExceptions.Subscribe(this.OnError);
            command.IsExecuting.Subscribe(isBusy => IsBusy = isBusy);
            return command;
        }
        private ReactiveCommand GetCommandPersonalAccount(EditState editState, IObservable<bool> canExecute = null)
        {
            var command = new ReactiveCommand(canExecute);
            command.RegisterAsyncFunction(_ => this.PreparingEditablePersonalAccount(editState))
                .ObserveOnUiSafeScheduler()
                .Subscribe(
                    result =>
                    {
                        var viewModel = this._routableViewModelManager.Get<IEditablePersonalAccountViewModel>();
                        result.CountByDocument = _selectedPlanCertificate.CountByDocument;
                        if ((!string.IsNullOrWhiteSpace(this.SelectedPlanReceiptOrder.MemoContractor))
                            && (result.PersonalAccount == null))
                        {
                            viewModel.UserContractor = new UserDto
                            {
                                TableNumber = SelectedPlanReceiptOrder.MemoContractor
                            };
                        }

                        result.CountFact = _selectedPlanCertificate.CountFact;
                        viewModel.SetEditableObject(result, editState);
                        viewModel.Measure = this.SelectedPlanCertificate.Measure;
                        HostScreen.Router.Navigate.Execute(viewModel);
                    });

            command.ThrownExceptions.Subscribe(this.OnError);
            command.IsExecuting.Subscribe(isExecuting => IsBusy = isExecuting);
            return command;
        }
        private ReactiveCommand GetCommandRemovePlanCertificate(IObservable<bool> canExecute = null)
        {
            var command = new ReactiveCommand(canExecute);
            command.RegisterAsyncAction(_ => RemovePlanCertificate())
                .Subscribe(result => PlanCertificateFilterViewModel.Result.Remove(SelectedPlanCertificate));

            command.ThrownExceptions.Subscribe(this.OnError);
            command.IsExecuting.Subscribe(isExecuting => IsBusy = isExecuting);
            return command;
        }
        private ReactiveCommand GetCommandRemovePersonalAccount(IObservable<bool> canExecute = null)
        {
            var command = new ReactiveCommand(canExecute);
            command.RegisterAsyncAction(_ => RemovePersonalAccount())
                .Subscribe(
                    result => PersonalAccountFilterViewModel.Result.Remove(SelectedPlanReceiptOrderPersonalAccount));

            command.ThrownExceptions.Subscribe(this.OnError);
            command.IsExecuting.Subscribe(isExecuting => IsBusy = isExecuting);
            return command;
        }
        private void RemovePlanCertificate()
        {
            using (IUnitOfWork unitOfWork = _unitOfWorkFactory.Create())
            {
                var service = unitOfWork.Create<IPlanReceiptOrderService>();
                service.RemovePlanCertificate(SelectedPlanCertificate.Rn);

                unitOfWork.Commit();
            }
        }
        private void RemovePersonalAccount()
        {
            using (IUnitOfWork unitOfWork = _unitOfWorkFactory.Create())
            {
                var service = unitOfWork.Create<IPlanReceiptOrderService>();
                service.RemovePlanReceiptOrderPersonalAccount(SelectedPlanReceiptOrderPersonalAccount.Rn);

                unitOfWork.Commit();
            }
        }
        private void OnError(Exception exception)
        {
            UserError.Throw("Подготовка к добавлению/редактированию", exception);
        }
    }
}