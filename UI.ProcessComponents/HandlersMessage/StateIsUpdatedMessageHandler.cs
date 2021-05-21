namespace UI.ProcessComponents.HandlersMessage
{
    using System;
    using System.ComponentModel.Composition;

    using ReactiveUI;

    using UI.Entities;
    using UI.Entities.PlanReceiptOrderDomain;
    using UI.Infrastructure;
    using UI.Infrastructure.Messages;

    [Export(typeof(IHandlerMessage))]
    public class StateIsUpdatedMessageHandler : MessageHandlerBase
    {
        [ImportingConstructor]
        public StateIsUpdatedMessageHandler(IMessenger messenger)
            : base(messenger)
        {
        }

        public override void Init(IMessageBus messageBus)
        {
            Disposables.Add(messageBus.Listen<UpdateStateMessage<PlanReceiptOrder>>().Subscribe(HandleMessage));
            Disposables.Add(messageBus.Listen<UpdateStateMessage<PlanCertificate>>().Subscribe(HandleMessage));
            Disposables.Add(messageBus.Listen<UpdateStateMessage<PlanReceiptOrderPersonalAccount>>().Subscribe(HandleMessage));
        }

        private void HandleMessage<T>(UpdateStateMessage<T> message)
            where T : class, IUiEntity, IHasState
        {
            ShowMessage("Статус успешно обновлен");
        }
    }
}
