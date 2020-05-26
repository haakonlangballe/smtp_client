using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smtp_client
{
    public class SmtpClient
    {
        EmailConfguration emailConfiguration;
        public EmailClientService emailClient;
        public SmtpClient()
        {
            emailConfiguration = new EmailConfguration();
            //emailConfiguration.AddSMTP("192.168.200.12", 25, "Anonymous", "haakon.langballe@abgsc.no");
            emailConfiguration.AddSMTP("localhost", 25, "Anonymous", "haakon.langballe@abgsc.no");
            emailClient = new EmailClientService(emailConfiguration);


        }
    }
}
