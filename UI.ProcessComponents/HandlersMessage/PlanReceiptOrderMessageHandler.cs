// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PlanReceiptOrderMessageHandler.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the PlanReceiptOrderMessageHandler type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.ProcessComponents.HandlersMessage
{
    using System;
    using System.ComponentModel.Composition;

    using Halfblood.Common.Helpers;

    using ReactiveUI;

    using UI.Entities.PlanReceiptOrderDomain;
    using UI.Infrastructure;
    using UI.Infrastructure.Messages;

    /// <summary>
    /// The plan receipt order message handler.
    /// </summary>
    [Export(typeof(IHandlerMessage))]
    public class PlanReceiptOrderMessageHandler : MessageHandlerBase
    {
        [ImportingConstructor]
        public PlanReceiptOrderMessageHandler(IMessenger messenger)
            : base(messenger)
        {
        }

        public override void Init(IMessageBus messageBus)
        {
            Disposables.Add(
                messageBus.Listen<AddedEntityMessage<PlanReceiptOrder>>().Subscribe(this.HandlingAddedMessage));
            Disposables.Add(
                messageBus.Listen<UpdatedEntityMessage<PlanReceiptOrder>>().Subscribe(this.HandlingUpdatedMessage));
        }

        private void HandlingUpdatedMessage(UpdatedEntityMessage<PlanReceiptOrder> message)
        {
            this.ShowMessage(
                EditState.Edit,
                "Документ {0}-{1} успешно обновлен".StringFormat(message.Entity.Pref, message.Entity.Numb));
        }

        private void HandlingAddedMessage(AddedEntityMessage<PlanReceiptOrder> message)
        {
            this.ShowMessage(
                EditState.Edit,
                "Документ {0}-{1} успешно добавлен".StringFormat(message.Entity.Pref, message.Entity.Numb));
        }
    }
}
