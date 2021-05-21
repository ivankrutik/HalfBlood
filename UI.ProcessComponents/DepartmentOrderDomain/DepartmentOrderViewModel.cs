// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DepartmentOrderViewModel.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the DepartmentOrderViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.ProcessComponents.DepartmentOrderDomain
{
    using System;
    using System.ComponentModel.Composition;
    using System.Reactive.Linq;
    using System.Windows.Input;

    using Halfblood.Common.Mappers;

    using ParusModelLite.DepartmentOrderDomain;

    using ReactiveUI;

    using ServiceContracts;
    using ServiceContracts.Facades;

    using UI.Entities.DepartmentOrderDomain;
    using UI.Infrastructure;
    using UI.Infrastructure.ViewModels.DepartmentOrderDomain;
    using UI.Infrastructure.ViewModels.Filters;

    [Export(typeof(IDepartmentOrderViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class DepartmentOrderViewModel : ReactiveObject, IDepartmentOrderViewModel
    {
        #region private fields
        private readonly IRoutableViewModelManager _routableViewModelManager;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private ReactiveCommand _preparingForEditDepartmentOrderCommand;
        private ReactiveCommand _preparingForAddDepartmentOrderCommand;
        private ReactiveCommand _preparingForRemoveDepartmentOrderCommand;
        private ReactiveCommand _preparingForStatusDepartmentOrderCommand;
        private DepartmentOrderLiteDto _selectedDepartmentOrder;
        private IDepartmentOrderFilterViewModel _departmentOrderFilteringObject;
        private bool _isBusy;
        #endregion

        [ImportingConstructor]
        public DepartmentOrderViewModel(
            IScreen screen,
            IRoutableViewModelManager routableViewModelManager,
            IUnitOfWorkFactory unitOfWorkFactory,
            IMessageBus messageBus)
        {
            HostScreen = screen;
            _unitOfWorkFactory = unitOfWorkFactory;
            _routableViewModelManager = routableViewModelManager;
        }

        public IScreen HostScreen { get; private set; }
        public string UrlPathSegment
        {
            get { return "/PlanReceipOrderView"; }
        }
        public bool IsBusy
        {
            get { return this._isBusy; }
            private set { this.RaiseAndSetIfChanged(ref _isBusy, value); }
        }
        public DepartmentOrderLiteDto SelectedDepartmentOrder
        {
            get { return _selectedDepartmentOrder; }
            set { this.RaiseAndSetIfChanged(ref _selectedDepartmentOrder, value); }
        }
        public ICommand PreparingForEditDepartmentOrderCommand
        {
            get
            {
                if (_preparingForEditDepartmentOrderCommand == null)
                {
                    var observable =
                        this.WhenAny(x => x.SelectedDepartmentOrder, x => x.Value)
                            .Select(x => x != null && x.Rn != 0)
                            .StartWith(SelectedDepartmentOrder != null);
                    _preparingForEditDepartmentOrderCommand = this.GetEditCommand(EditState.Edit, observable);
                }

                return _preparingForEditDepartmentOrderCommand;
            }
        }
        public ICommand PreparingForAddDepartmentOrderCommand
        {
            get
            {
                return _preparingForAddDepartmentOrderCommand
                       ?? (_preparingForAddDepartmentOrderCommand = this.GetEditCommand(EditState.Insert));
            }
        }
        public ICommand PreparingForStatusDepartmentOrderCommand
        {
            get
            {
                return _preparingForStatusDepartmentOrderCommand
                       ?? (_preparingForStatusDepartmentOrderCommand = new ReactiveCommand(Observable.Empty<bool>()));
            }
        }
        public ICommand PreparingForRemoveDepartmentOrderCommand
        {
            get
            {
                if (_preparingForRemoveDepartmentOrderCommand == null)
                {
                    var observable =
                        this.WhenAny(x => x.SelectedDepartmentOrder, x => x.Value)
                            .Select(x => x != null && x.Rn != 0)
                            .StartWith(SelectedDepartmentOrder != null);
                    _preparingForRemoveDepartmentOrderCommand = GetCommandRemoveDepartmentOrder(observable);
                }

                return _preparingForRemoveDepartmentOrderCommand;
            }
        }
        public IDepartmentOrderFilterViewModel DepartmentOrderFilteringObject
        {
            get
            {
                return _departmentOrderFilteringObject
                       ?? (_departmentOrderFilteringObject =
                           _routableViewModelManager.Get<IDepartmentOrderFilterViewModel>());
            }
        }

        private DepartmentOrder PreparingEditableDepartmentOrder(EditState editState)
        {
            if (editState == EditState.Edit)
            {
                using (IUnitOfWork unitOfWork = _unitOfWorkFactory.Create())
                {
                    var service = unitOfWork.Create<IDepartmentOrderService>();
                    var planReceiptOrder =
                        service.GetDepartmentOrder(SelectedDepartmentOrder.Rn);

                    return planReceiptOrder.MapTo<DepartmentOrder>();
                }
            }

            return new DepartmentOrder();
        }
        private ReactiveCommand GetEditCommand(EditState editState, IObservable<bool> canExecute = null)
        {
            var command = new ReactiveCommand(canExecute ?? this.WhenAny(x => x.IsBusy, x => !x.Value));
            command.RegisterAsyncFunction(
                _ =>
                    {
                        var departmentOrder = PreparingEditableDepartmentOrder(editState);
                        var viewModel = _routableViewModelManager.Get<IEditDepartmentOrderViewModel>();
                        viewModel.SetEditableObject(departmentOrder, editState);

                        return viewModel;
                    }).Subscribe(viewModel => this.HostScreen.Router.Navigate.Execute(viewModel));

            command.IsExecuting.Subscribe(isExecuting => IsBusy = isExecuting);

            return command;
        }
        private ReactiveCommand GetCommandRemoveDepartmentOrder(IObservable<bool> canExecute = null)
        {
            var command = new ReactiveCommand(canExecute);
            command.RegisterAsyncAction(_ => RemoveDepartmentOrder()).Subscribe(
                result =>
                {
                    throw new NotImplementedException();
                    //Result.Remove(SelectedDepartmentOrder);
                });

            return command;
        }
        private void RemoveDepartmentOrder()
        {
            using (IUnitOfWork unitOfWork = _unitOfWorkFactory.Create())
            {
                var service = unitOfWork.Create<IDepartmentOrderService>();
                service.RemoveDepartmentOrder(SelectedDepartmentOrder.Rn);
            }
        }

        public void EnteredBarcode(string barcode)
        {
        }
    }
}