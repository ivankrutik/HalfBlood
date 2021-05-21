// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ChangeGroupStateViewModel.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the ChangeGroupStateViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.ProcessComponents.PlanReceiptOrderDomain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using System.Reactive.Linq;
    using System.Windows.Input;

    using Buisness.Entities.CommonDomain;
    using Buisness.Entities.PlanReceiptOrderDomain;
    using Buisness.Filters;

    using Halfblood.Common.Mappers;

    using ReactiveUI;

    using ServiceContracts;
    using ServiceContracts.Facades;

    using UI.Entities.CommonDomain;
    using UI.Entities.PlanReceiptOrderDomain;
    using UI.Infrastructure;
    using UI.Infrastructure.ViewModels;
    using UI.Infrastructure.ViewModels.Filters;
    using UI.Infrastructure.ViewModels.PlanReceiptOrderDomain;
    using UI.Resources;

    /// <summary>
    /// The change group state view model.
    /// </summary>
    [Export(typeof(IChangeGroupStateViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ChangeGroupStateViewModel : ReactiveObject, IChangeGroupStateViewModel
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IMessenger messenger;
        private ReactiveCommand _changeGroupStatusCommand;
        private PersonalAccount selectedPersonalAccount;
        private IList<PlanReceiptOrder> _selectedPlanReceiptOrders;
        private bool _isBusy;

        [ImportingConstructor]
        public ChangeGroupStateViewModel(
            IScreen screen,
            IUnitOfWorkFactory unitOfWorkFactory,
            IFilterViewModelFactory filterViewModelFactory,
            IMessenger messenger)
        {
            this.HostScreen = screen;
            this._unitOfWorkFactory = unitOfWorkFactory;
            this.messenger = messenger;
            this.FilteringObject = filterViewModelFactory.Create<PersonalAccountFilter, PersonalAccountDto>();
        }

        public string UrlPathSegment { get; private set; }
        public IScreen HostScreen { get; private set; }
        public bool IsBusy
        {
            get { return this._isBusy; }
            private set { this.RaiseAndSetIfChanged(ref _isBusy, value); }
        }
        public PersonalAccount SelectedPersonalAccount
        {
            get { return this.selectedPersonalAccount; }
            set { this.RaiseAndSetIfChanged(ref this.selectedPersonalAccount, value); }
        }
        public IList<PlanReceiptOrder> SelectedPlanReceiptOrders
        {
            get { return this._selectedPlanReceiptOrders; }
            private set { this.RaiseAndSetIfChanged(ref this._selectedPlanReceiptOrders, value); }
        }
        public ICommand ChangeGroupStatusCommand
        {
            get
            {
                if (this._changeGroupStatusCommand == null)
                {
                    var canExecuteObserve =
                        this.WhenAny(
                            x => x.SelectedPersonalAccount,
                            x => x.SelectedPlanReceiptOrders,
                            (pa, pro) =>
                            pa.Value != null && pro.Value != null && pa.Value.Rn > 0 && !pro.Value.Any(x => x.Rn <= 0))
                            .StartWith(
                                this.SelectedPersonalAccount != null && this.SelectedPlanReceiptOrders != null
                                && this.SelectedPersonalAccount.Rn > 0
                                && !this.SelectedPlanReceiptOrders.Any(x => x.Rn <= 0));

                    this._changeGroupStatusCommand = new ReactiveCommand(canExecuteObserve);
                    this._changeGroupStatusCommand.RegisterAsyncAction(
                        _ => this.SetGroupPersonalAccountPlanReceiptOrder(),
                        RxApp.MainThreadScheduler)
                        .ObserveOnUiSafeScheduler()

                        .Subscribe(
                            _ =>
                                {
                                    this.messenger.Add(CustomMessages.SetStateIsSuccessfull);
                                    HostScreen.Router.NavigateBack.Execute(null);
                                });

                    _changeGroupStatusCommand.IsExecuting.Subscribe(isBusy => IsBusy = isBusy);
                }

                return this._changeGroupStatusCommand;
            }
        }
        public IFilterViewModel<PersonalAccountFilter, PersonalAccountDto>
            FilteringObject { get; private set; }

        public void SetPlanReceiptOrders(IList<PlanReceiptOrder> planReceiptOrders)
        {
            Contract.Requires(planReceiptOrders != null, "Items must be not null");
            this.SelectedPlanReceiptOrders = planReceiptOrders;
        }

        private void SetGroupPersonalAccountPlanReceiptOrder()
        {
            using (IUnitOfWork unitOfWork = _unitOfWorkFactory.Create())
            {
                var service = unitOfWork.Create<IPlanReceiptOrderService>();

                foreach (PlanReceiptOrder order in SelectedPlanReceiptOrders)
                {
                    service.SetGroupPersonalAccountPlanReceiptOrder(
                        order.MapTo<PlanReceiptOrderDto>(),
                        this.SelectedPersonalAccount.MapTo<PersonalAccountDto>());
                }

                unitOfWork.Commit();
            }
        }
    }
}
