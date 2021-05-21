// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PlanReceiptOrderViewModel.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the PlanReceiptOrderViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.ProcessComponents.PlanReceiptOrderDomain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Linq;
    using System.Reactive.Linq;
    using System.Windows;
    using System.Windows.Input;

    using Halfblood.Common;
    using Halfblood.Common.Helpers;
    using Halfblood.Common.Log;
    using Halfblood.Common.Mappers;

    using ParusModelLite.PlanReceiptOrderDomain;

    using ReactiveUI;

    using ServiceContracts;
    using ServiceContracts.Facades;

    using UI.Entities.PlanReceiptOrderDomain;
    using UI.Infrastructure;
    using UI.Infrastructure.ViewModels.Filters;
    using UI.Infrastructure.ViewModels.PlanReceiptOrderDomain;

    [PartCreationPolicy(CreationPolicy.NonShared)]
    [Export(typeof(IPlanReceiptOrderViewModel))]
    public class PlanReceiptOrderViewModel : ReactiveObject, IPlanReceiptOrderViewModel
    {
        #region private fields
        private readonly IRoutableViewModelManager _routableViewModelManager;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IMessenger _messenger;
        private ReactiveCommand _preparingForEditPlanReceipOrderCommand;
        private ReactiveCommand _preparingForAddPlanReceipOrderCommand;
        private ReactiveCommand _preparingForRemovePlanReceipOrderCommand;
        private ReactiveCommand _preparingForStatusPlanReceipOrderCommand;
        private ReactiveCommand _preparingChangeGroupStateCommand;
        private PlanReceiptOrderLiteDto _selectedPlanReceiptOrder;
        private IProFilterViewModel _planReceiptOrderFilterViewModel;
        private bool _isBusy;
        #endregion

        ~PlanReceiptOrderViewModel()
        {
            LogManager.Log.Debug("PlanReceiptOrderViewModel IS DESTROYED");
        }

        [ImportingConstructor]
        public PlanReceiptOrderViewModel(
            IScreen screen,
            IMessenger messenger,
            IRoutableViewModelManager routableViewModelManager,
            IUnitOfWorkFactory unitOfWorkFactory)
        {
            HostScreen = screen;
            _messenger = messenger;
            _routableViewModelManager = routableViewModelManager;
            _unitOfWorkFactory = unitOfWorkFactory;
            Binding();
        }

        public bool IsBusy
        {
            get { return this._isBusy; }
            private set { this.RaiseAndSetIfChanged(ref _isBusy, value); }
        }
        public IScreen HostScreen
        {
            get;
            private set;
        }
        public string UrlPathSegment
        {
            get { return "/PlanReceipOrderView"; }
        }
        public IProFilterViewModel PlanReceiptOrderFilterViewModel
        {
            get
            {
                return _planReceiptOrderFilterViewModel
                       ?? (_planReceiptOrderFilterViewModel = _routableViewModelManager.Get<IProFilterViewModel>());
            }
        }
        public PlanReceiptOrderLiteDto SelectedPlanReceiptOrder
        {
            get { return this._selectedPlanReceiptOrder; }
            set { this.RaiseAndSetIfChanged(ref this._selectedPlanReceiptOrder, value); }
        }
        public ICommand PreparingChangeGroupStateCommand
        {
            get
            {
                if (this._preparingChangeGroupStateCommand == null)
                {
                    _preparingChangeGroupStateCommand = new ReactiveCommand(Observable.Return(true));
                    _preparingChangeGroupStateCommand.ObserveOnUiSafeScheduler().Subscribe(
                        items =>
                            {
                                var collection = items as IEnumerable<PlanReceiptOrderLiteDto>;

                                if (collection == null)
                                {
                                    throw new ArgumentException(
                                        "The command parameter must be type of {0}".StringFormat(
                                            typeof(IList<PlanReceiptOrderLiteDto>)));
                                }

                                if (!collection.Any())
                                {
                                    return;
                                }

                                var viewModel = this._routableViewModelManager.Get<IChangeGroupStateViewModel>();
                                viewModel.SetPlanReceiptOrders(collection.MapTo<PlanReceiptOrder>());
                                HostScreen.Router.Navigate.Execute(viewModel);
                            });
                }

                return this._preparingChangeGroupStateCommand;
            }
        }
        public ICommand PreparingForEditPlanReceiptOrderCommand
        {
            get
            {
                if (this._preparingForEditPlanReceipOrderCommand == null)
                {
                    var observable =
                        this.WhenAny(x => x.SelectedPlanReceiptOrder, x => x.Value)
                            .Select(x => x != null && x.Rn > 0 && x.State != PlanReceiptOrderState.Confirm)
                            .StartWith(
                                SelectedPlanReceiptOrder != null && SelectedPlanReceiptOrder.Rn > 0
                                && this._selectedPlanReceiptOrder.State != PlanReceiptOrderState.Confirm);

                    _preparingForEditPlanReceipOrderCommand = GetCommandEditablePlanReceiptOrder(
                        EditState.Edit,
                        observable);
                }

                return this._preparingForEditPlanReceipOrderCommand;
            }
        }
        public ICommand PreparingForAddPlanReceiptOrderCommand
        {
            get
            {
                return this._preparingForAddPlanReceipOrderCommand
                       ?? (this._preparingForAddPlanReceipOrderCommand = this.GetCommandEditablePlanReceiptOrder(EditState.Insert));
            }
        }
        public ICommand PreparingForStatusPlanReceiptOrderCommand
        {
            get
            {
                return this._preparingForStatusPlanReceipOrderCommand
                       ?? (this._preparingForStatusPlanReceipOrderCommand = this.GetCommandStatus());
            }
        }
        public ICommand PreparingForRemovePlanReceiptOrderCommand
        {
            get
            {
                if (this._preparingForRemovePlanReceipOrderCommand == null)
                {
                    var observable =
                        this.WhenAny(x => x.SelectedPlanReceiptOrder, x => x.Value)
                            .Select(x => x != null && x.Rn != 0 && this._selectedPlanReceiptOrder.State != PlanReceiptOrderState.Confirm)
                            .StartWith(
                                SelectedPlanReceiptOrder != null && SelectedPlanReceiptOrder.Rn > 0
                                && SelectedPlanReceiptOrder.State != PlanReceiptOrderState.Confirm);

                    this._preparingForRemovePlanReceipOrderCommand = this.GetCommandRemovePlanReceiptOrder(observable);
                }

                return this._preparingForRemovePlanReceipOrderCommand;
            }
        }

        private PlanReceiptOrder PreparingEditablePlanReceiptOrder(EditState editState)
        {
            if (editState == EditState.Edit)
            {
                using (IUnitOfWork unitOfWork = this._unitOfWorkFactory.Create())
                {
                    var service = unitOfWork.Create<IPlanReceiptOrderService>();
                    return
                        service.GetPlanReceiptOrderWithoutPlanCertificateDto(this.SelectedPlanReceiptOrder.Rn)
                            .MapTo<PlanReceiptOrder>();
                }
            }

            return new PlanReceiptOrder();
        }
        private ReactiveCommand GetCommandEditablePlanReceiptOrder(EditState editState, IObservable<bool> canExecute = null)
        {
            var command = new ReactiveCommand(canExecute);
            command.RegisterAsyncFunction(_ => this.PreparingEditablePlanReceiptOrder(editState)).Subscribe(
                result =>
                {
                    var viewModel = this._routableViewModelManager.Get<IEditablePlanReceiptOrderViewModel>();
                    viewModel.SetEditableObject(result, editState);
                    this.HostScreen.Router.Navigate.Execute(viewModel);
                });

            command.ThrownExceptions.Subscribe(this.OnError);
            command.IsExecuting.Subscribe(isExecuting => IsBusy = isExecuting);
            return command;
        }
        private ReactiveCommand GetCommandStatus(IObservable<bool> canExecute = null)
        {
            var command = new ReactiveCommand(canExecute);
            command.Subscribe(result => {
                var collection = result as IEnumerable<PlanReceiptOrderLiteDto>;

                if (collection == null)
                {
                    throw new ArgumentException(
                        "The command parameter must be type of {0}".StringFormat(
                            typeof(IList<PlanReceiptOrderLiteDto>)));
                }

                if (!collection.Any())
                {
                    return;
                }

                var viewModel = this._routableViewModelManager.Get<IStatusPlanReceiptOrderViewModel>();
                viewModel.SetActionObjectCollection(collection.MapTo<PlanReceiptOrder>());
                this.HostScreen.Router.Navigate.Execute(viewModel);
            });

            command.ThrownExceptions.Subscribe(this.OnError);
            return command;
        }
        private ReactiveCommand GetCommandRemovePlanReceiptOrder(IObservable<bool> canExecute = null)
        {
            var command = new ReactiveCommand(canExecute);

            command.RegisterAsync(_ => 
                _messenger.AskToObservable(
                    "Удалить?",
                    MessageBoxButton.YesNo,
                    result => {
                        if (result == MessageBoxResult.Yes) {
                            PlanReceiptOrderLiteDto removingItem = SelectedPlanReceiptOrder;

                            if (removingItem == null) {
                                return;
                            }

                            RemovePlanReceiptOrder(removingItem.Rn);
                            PlanReceiptOrderFilterViewModel.Result.Remove(removingItem);
                        }
                    })).Subscribe();

            command.ThrownExceptions.Subscribe(OnError);
            command.IsExecuting.Subscribe(isExecuting => IsBusy = isExecuting);
            return command;
        }
        private void OnError(Exception exception)
        {
            UserError.Throw("Подготовка к добавлению/редактированию", exception);
        }
        private void RemovePlanReceiptOrder(long rn)
        {
            using (IUnitOfWork unitOfWork = this._unitOfWorkFactory.Create())
            {
                var service = unitOfWork.Create<IPlanReceiptOrderService>();
                service.RemovePlanReceiptOrder(rn);

                unitOfWork.Commit();
            }
        }
        private void Binding()
        {
            this.WhenAny(x => x.PlanReceiptOrderFilterViewModel.IsBusy).Subscribe(isBusy => IsBusy = isBusy);
        }
    }
}