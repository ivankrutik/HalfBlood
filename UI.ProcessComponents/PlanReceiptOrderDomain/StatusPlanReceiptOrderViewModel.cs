// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StatusPlanReceiptOrderViewModel.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the StatusPlanReceiptOrderViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.ProcessComponents.PlanReceiptOrderDomain
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

    /// <summary>
    /// The status plan receipt order view model.
    /// </summary>
    [Export(typeof(IStatusPlanReceiptOrderViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class StatusPlanReceiptOrderViewModel
        : PolicyActionViewModelBase<PlanReceiptOrder, PlanReceiptOrderState>, IStatusPlanReceiptOrderViewModel
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private IList<PlanReceiptOrder> _planReceiptOrders;

        [ImportingConstructor]
        public StatusPlanReceiptOrderViewModel(
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
            get { return "/StatusPlanReceiptOrderView"; }
        }
        public new IScreen HostScreen
        {
            get { return base.HostScreen; }
        }
        public IList<PlanReceiptOrder> PlanReceiptOrders
        {
            get { return this._planReceiptOrders; }
            private set { this.RaiseAndSetIfChanged(ref _planReceiptOrders, value); }
        }

        public void SetActionObjectCollection(IList<PlanReceiptOrder> objects)
        {
            Contract.Requires(objects != null, "objects must be not null");

            if (IsBusy)
            {
                throw new InvalidOperationException("Can't set object while operation changed status is active");
            }

            PlanReceiptOrders = objects;
        }
        public override void SetActionObject(PlanReceiptOrder @object)
        {
            PlanReceiptOrders = new List<PlanReceiptOrder> { @object };
        }

        protected override Unit DoLoad()
        {
            using (IUnitOfWork unitOfWork = this._unitOfWorkFactory.Create())
            {
                var service = unitOfWork.Create<IPlanReceiptOrderService>();

                foreach (PlanReceiptOrder planReceiptOrder in PlanReceiptOrders)
                {
                    service.SetStatePlanReceiptOrder(planReceiptOrder.Rn, this.State);
                }

                unitOfWork.Commit();
            }

            return Unit.Default;
        }
        protected override void Complete()
        {
            if (this.MessageBus != null)
            {
                foreach (PlanReceiptOrder planReceiptOrder in PlanReceiptOrders)
                {
                    this.MessageBus.SendMessage(new UpdateStateMessage<PlanReceiptOrder>(planReceiptOrder));
                }
            }

            if (HostScreen != null)
            {
                this.HostScreen.Router.NavigateBack.Execute(null);
            }
        }
    }
}