namespace Toolkit.Mail
{
    using System.ComponentModel.Composition;
    using System.Net.Mail;
    using System.Text;
    using Infrastructure.Mail;

    [PartCreationPolicy(CreationPolicy.NonShared)]
    [Export(typeof(IMailManager))]
    public class MailManager : IMailManager
    {
        private readonly string _host;
        private readonly int _port;

        public MailManager(string host = "localmail.vz", int port = 25)
        {
            _host = host;
            _port = port;
        }
        public void SendMail(Letter letter)
        {
            using (var client = new SmtpClient())
            {
                var from = new MailAddress(letter.Sender);
                var to = new MailAddress(letter.Address);
                var message = new MailMessage(from, to)
                {
                    Body = letter.Messages,
                    BodyEncoding = Encoding.UTF8,
                    Subject = letter.Subject,
                    SubjectEncoding = Encoding.UTF8
                };
                client.Host = _host;
                client.Port = _port;
                client.Send(message);
            }
        }
    }
}
