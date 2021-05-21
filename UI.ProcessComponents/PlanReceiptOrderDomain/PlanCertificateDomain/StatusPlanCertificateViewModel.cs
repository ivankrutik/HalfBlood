// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StatusPlanCertificateViewModel.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the StatusPlanCertificateViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.ProcessComponents.PlanReceiptOrderDomain.PlanCertificateDomain
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
    using UI.Infrastructure.Messages;
    using UI.Infrastructure.ViewModels.PlanReceiptOrderDomain;
    using UI.ProcessComponents.EditViewModels;

    [Export(typeof(IStatusPlanCertificateViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class StatusPlanCertificateViewModel
        : PolicyActionViewModelBase<PlanCertificate, PlanCertificateState>, IStatusPlanCertificateViewModel
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private IList<PlanCertificate> _planCertificates;

        [ImportingConstructor]
        public StatusPlanCertificateViewModel(
            IScreen screen,
            IUnitOfWorkFactory unitOfWorkFactory,
            IMessageBus messageBus)
            : base(screen, messageBus)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public IList<PlanCertificate> PlanCertificates
        {
            get { return this._planCertificates; }
            private set { this.RaiseAndSetIfChanged(ref _planCertificates, value); }
        }
        public string UrlPathSegment
        {
            get;
            private set;
        }
        public new IScreen HostScreen
        {
            get { return base.HostScreen; }
        }

        public void SetActionObjectCollection(IList<PlanCertificate> objects)
        {
            Contract.Requires(objects != null, "objects must be not null");

            if (IsBusy)
            {
                throw new InvalidOperationException("Can't set object while operation of changed status is active");
            }

            PlanCertificates = objects;
        }
        public override void SetActionObject(PlanCertificate @object)
        {
            PlanCertificates = new List<PlanCertificate> { @object };
        }

        protected override Unit DoLoad()
        {
            using (IUnitOfWork unitOfWork = this._unitOfWorkFactory.Create())
            {
                var service = unitOfWork.Create<IPlanReceiptOrderService>();

                foreach (PlanCertificate planCertificate in PlanCertificates)
                {
                    service.SetStatusPlanCertificate(planCertificate.Rn, State);
                }

                unitOfWork.Commit();
            }

            return Unit.Default;
        }
        protected override void Complete()
        {
            if (this.MessageBus != null)
            {
                foreach (PlanCertificate planCertificate in PlanCertificates)
                {
                    this.MessageBus.SendMessage(new UpdateStateMessage<PlanCertificate>(planCertificate));
                }
            }

            if (HostScreen != null)
            {
                this.HostScreen.Router.NavigateBack.Execute(null);
            }
        }
    }
}
