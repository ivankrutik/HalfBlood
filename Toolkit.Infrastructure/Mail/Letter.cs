namespace Toolkit.Infrastructure.Mail
{
    using System;

    public class Letter 
    {
        public String Address { get; set; }
        public String Messages { get; set; }
        public String RecipientName { get; set; }
        public String Sender { get; set; }
        public String SenderName { get; set; }
        public String Subject { get; set; }
    }
}