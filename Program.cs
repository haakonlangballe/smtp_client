using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smtp_client
{
    class Program
    {
        static void Main(string[] args)
        {

            //EmailMessage msg = new EmailMessage();
            //msg.ToAddresses.Add(new EmailAddress() { Name = "haakon", Address = "haakonstilbud@gmail.com" });
            //msg.FromAddresses.Add(new EmailAddress() { Name = "haakon", Address = "haakon.langballe@abgsc.no" });
            //msg.Subject = "Demo message";


            var clientService = new SmtpClient();
            clientService.emailClient.Connect();
            if (clientService.emailClient.IsConnected() == false)
            {
                Console.WriteLine("Client is not connected");
                return;
            }

            clientService.emailClient.Authenticate();
            if (clientService.emailClient.IsAuthenticated() == false)
            {
                Console.WriteLine("Client is not authenticated");
                clientService.emailClient.Disconnect();
                return;
            }

            for (int ix = 0; ix < 100; ix++)
            {
                var message = new SmtpMessage();
                message.CreateMessage(); //create MimeMessage
                message.mimeMessage.Sender = new MimeKit.MailboxAddress("haakon", "haakonstilbud@gmail.com");
                message.mimeMessage.To.Add(new MimeKit.MailboxAddress("haakon", "haakonstilbud@gmail.com"));
                message.mimeMessage.From.Add(new MimeKit.MailboxAddress("haakon", "haakon.langballe@abgsc.no"));
                message.mimeMessage.Subject = "Demo mail nr: " + ix;


                clientService.emailClient.Send(message);
            }
            clientService.emailClient.Disconnect();
        }
    }
}
