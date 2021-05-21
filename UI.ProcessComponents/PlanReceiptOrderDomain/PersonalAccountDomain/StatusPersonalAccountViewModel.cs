// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StatusPlanReceiptOrderViewModel.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the StatusPlanReceiptOrderViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.ProcessComponents.PlanReceiptOrderDomain.PersonalAccountDomain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Diagnostics.Contracts;
    using System.Reactive;

    using Halfblood.Common;

    using ReactiveUI;

    using ServiceContracts;
    using ServiceContracts.Facades;

    using UI.Entities.PlanReceiptOrderDomain;
    using UI.Infrastructure;
    using UI.Infrastructure.Messages;
    using UI.Infrastructure.ViewModels.PlanReceiptOrderDomain;
    using UI.ProcessComponents.EditViewModels;

    [Export(typeof(IStatusPersonalAccountViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class StatusPersonalAccountViewModel
        : PolicyActionViewModelBase<PlanReceiptOrderPersonalAccount, PlanReceiptOrderPersonalAccountState>, IStatusPersonalAccountViewModel
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private IList<PlanReceiptOrderPersonalAccount> _planReceiptOrderPersonalAccount;

        [ImportingConstructor]
        public StatusPersonalAccountViewModel(
            IScreen screen,
            IRoutableViewModelManager routableViewModelManager,
            IUnitOfWorkFactory unitOfWorkFactory,
            IMessageBus messageBus)
            : base(screen, messageBus)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public string UrlPathSegment
        {
            get { return "/StatusPersonalAccountView"; }
        }
        public new IScreen HostScreen
        {
            get { return base.HostScreen; }
        }
        public IList<PlanReceiptOrderPersonalAccount> PlanReceiptOrderPersonalAccounts
        {
            get { return this._planReceiptOrderPersonalAccount; }
            private set { this.RaiseAndSetIfChanged(ref _planReceiptOrderPersonalAccount, value); }
        }

        public void SetActionObjectCollection(IList<PlanReceiptOrderPersonalAccount> objects)
        {
            Contract.Requires(objects != null, "objects must be not null");

            if (IsBusy)
            {
                throw new InvalidOperationException("Can't set object while operation changed status is active");
            }

            PlanReceiptOrderPersonalAccounts = objects;
        }
        public override void SetActionObject(PlanReceiptOrderPersonalAccount @object)
        {
            PlanReceiptOrderPersonalAccounts = new List<PlanReceiptOrderPersonalAccount> { @object };
        }

        protected override Unit DoLoad()
        {
            using (IUnitOfWork unitOfWork = this._unitOfWorkFactory.Create())
            {
                var service = unitOfWork.Create<IPlanReceiptOrderService>();

                foreach (PlanReceiptOrderPersonalAccount planReceiptOrderPersonalAccount in PlanReceiptOrderPersonalAccounts)
                {
                    service.SetStatusPersonalAccount(planReceiptOrderPersonalAccount.Rn, this.State);
                }

                unitOfWork.Commit();
            }

            return Unit.Default;
        }
        protected override void Complete()
        {
            if (this.MessageBus != null)
            {
                foreach (PlanReceiptOrderPersonalAccount planReceiptOrderPersonalAccount in PlanReceiptOrderPersonalAccounts)
                {
                    this.MessageBus.SendMessage(
                        new UpdateStateMessage<PlanReceiptOrderPersonalAccount>(planReceiptOrderPersonalAccount));
                }
            }

            if (HostScreen != null)
            {
                this.HostScreen.Router.NavigateBack.Execute(null);
            }
        }
    }
}