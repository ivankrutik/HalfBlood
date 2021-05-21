namespace UI.Infrastructure.Messages
{
    public class UILoadedMessage : IMessage
    {
        private static readonly UILoadedMessage message = new UILoadedMessage();

        public static UILoadedMessage Empty
        {
            get { return message; }
        }
    }

    public class AppIsUnloadedMessage : IMessage
    {
        private static readonly AppIsUnloadedMessage message = new AppIsUnloadedMessage();

        public static AppIsUnloadedMessage Empty
        {
            get { return message; }
        }
    }
}
