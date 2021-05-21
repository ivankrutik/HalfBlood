namespace UI.Infrastructure.Messages
{
    using Entities.AttachedDocumentDomain;

    public class SaveAttachedDocumentMessage : IMessage
    {
        public AttachedDocument AttachedDocument { get; set; }
    }
}

