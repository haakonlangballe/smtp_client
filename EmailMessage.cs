using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smtp_client
{
    public class EmailMessage
    {
        public EmailMessage()
        {
            ToAddresses = new List<EmailAddress>();
            FromAddresses = new List<EmailAddress>();
            Subject = string.Empty;
            Content = string.Empty;
        }
        public List<EmailAddress> ToAddresses;
        public List<EmailAddress> FromAddresses { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }

        //public MimeKit.SmtpMessage smtpMessage()
        //{
        //    return new 
        //}
    }

}
