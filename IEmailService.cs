using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smtp_client
{
    public interface IEmailService
    {
        void Send(SmtpMessage emailMessage);
        //List<SmtpMessage> ReceiveEmail(int macCount = 10);
    }
}
