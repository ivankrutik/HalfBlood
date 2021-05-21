// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PlanCertificateMessageHandler.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   The plan certificate message handler.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.ProcessComponents.HandlersMessage
{
    using System;
    using System.ComponentModel.Composition;

    using ReactiveUI;

    using UI.Entities.CommonDomain;
    using UI.Entities.PlanReceiptOrderDomain;
    using UI.Infrastructure;
    using UI.Infrastructure.Messages;
    using UI.Entities.CertificateQualityDomain.ActSelectionOfProbeDomain;

    public abstract class EditableMessageHandler<TEntity> : MessageHandlerBase
    {
        protected EditableMessageHandler(IMessenger messenger)
            : base(messenger)
        {
        }

        public override void Init(IMessageBus messageBus)
        {
            Disposables.Add(
                messageBus.Listen<AddedEntityMessage<TEntity>>()
                    .Subscribe(msg => this.HandlingMessage(msg, EditState.Insert)));
            Disposables.Add(
                messageBus.Listen<UpdatedEntityMessage<TEntity>>()
                    .Subscribe(msg => this.HandlingMessage(msg, EditState.Edit)));
        }

        protected virtual void HandlingMessage(IMessage<TEntity> message, EditState editState)
        {
            this.ShowMessage(editState);
        }
    }

    [Export(typeof(IHandlerMessage))]
    public class PlanCertificateMessageHandler : EditableMessageHandler<PlanCertificate>
    {
        [ImportingConstructor]
        public PlanCertificateMessageHandler(IMessenger messenger)
            : base(messenger)
        {
        }
    }

    [Export(typeof(IHandlerMessage))]
    public class PersonalAccountMessageHandler : EditableMessageHandler<PersonalAccount>
    {
        [ImportingConstructor]
        public PersonalAccountMessageHandler(IMessenger messenger)
            : base(messenger)
        {
        }
    }

    [Export(typeof(IHandlerMessage))]
    public class PlanReceiptOrderPersonalAccountMessageHandler : EditableMessageHandler<PlanReceiptOrderPersonalAccount>
    {
        [ImportingConstructor]
        public PlanReceiptOrderPersonalAccountMessageHandler(IMessenger messenger)
            : base(messenger)
        {
        }
    }

    [Export(typeof(IHandlerMessage))]
    public class ActSelectionOfProbeMessageHandler : EditableMessageHandler<ActSelectionOfProbe>
    {
        [ImportingConstructor]
        public ActSelectionOfProbeMessageHandler(IMessenger messenger)
            : base(messenger)
        {
        }
    }

    [Export(typeof(IHandlerMessage))]
    public class ActSelectionOfProbeDepartmentMessageHandler : EditableMessageHandler<ActSelectionOfProbeDepartment>
    {
        [ImportingConstructor]
        public ActSelectionOfProbeDepartmentMessageHandler(IMessenger messenger)
            : base(messenger)
        {
        }
    }
    [Export(typeof(IHandlerMessage))]
    public class ActSelectionOfProbeDepartmentRequirementMessageHandler : EditableMessageHandler<ActSelectionOfProbeDepartmentRequirement>
    {
        [ImportingConstructor]
        public ActSelectionOfProbeDepartmentRequirementMessageHandler(IMessenger messenger)
            : base(messenger)
        {
        }
    }
}
