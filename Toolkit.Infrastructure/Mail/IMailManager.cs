namespace Toolkit.Infrastructure.Mail
{
    public interface IMailManager
    {
        void SendMail(Letter letter);
    }
}
