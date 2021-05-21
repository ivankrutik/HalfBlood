namespace UI.Infrastructure.Messages
{
    public class AuthentificationCompletedMessage : IMessage
    {
        private static readonly AuthentificationCompletedMessage _message = new AuthentificationCompletedMessage();

        public static AuthentificationCompletedMessage Create
        {
            get { return _message; }
        }
    }
}
