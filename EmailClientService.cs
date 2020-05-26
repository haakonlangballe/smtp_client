using System;
using System.Collections.Generic;
using System.Linq;
using MimeKit;
using MailKit;

namespace smtp_client
{
    public class EmailClientService : IEmailService
    {
        private readonly IEmailConfiguration emailConfiguration;
        private readonly MailKit.Net.Smtp.SmtpClient smtpClient;

        public EmailClientService(IEmailConfiguration EmailConfiguration)
        {
            smtpClient = new MailKit.Net.Smtp.SmtpClient();
        }

        public void Connect()
        {
            try
            {
                smtpClient.Connect("localhost", 0, MailKit.Security.SecureSocketOptions.None);
                //emailClient.Connect(_emailConfiguration.SmtpServer, _emailConfiguration.SmtpPort, false);
            }
            catch (MailKit.Security.SslHandshakeException ex)
            {
                Console.WriteLine("Connect failed: ", ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Connect failed: ", ex.Message);
            }
        }

        public bool IsConnected()
        {
            return smtpClient.IsConnected;
        }

        public bool IsAuthenticated()
        {
            return smtpClient.IsAuthenticated;
        }
        public bool IsSecure()
        {
            return smtpClient.IsSecure;
        }
        public void Authenticate()
        {
            smtpClient.AuthenticationMechanisms.Remove("XOAUTH2");
            try
            {
                smtpClient.Authenticate(emailConfiguration.SmtpUsername, emailConfiguration.SmtpPassword);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Authentication failed: {0}", ex.Message);
            }
            Console.WriteLine("Client is authenticated: {0}", smtpClient.IsConnected);
        }

        public void Send(SmtpMessage message)
        {
            try
            {
                smtpClient.Send(message.mimeMessage);
                Console.WriteLine("Message sent");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Message send failed: {0}", ex.Message);
            }
        }
        public void Disconnect()
        {
            try
            {
                smtpClient.Disconnect(true);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Disconnect failed: {0}", ex.Message);
            }
        }
        public List<EmailMessage> ReceiveEmail(int maxCount = 10)
        {
            throw new NotImplementedException();
        }
        public void oldSend(SmtpMessage smtpMessage)
        {
            using (var emailClient = new MailKit.Net.Smtp.SmtpClient())
            {
                try
                {
                    emailClient.Connect("localhost", 0, MailKit.Security.SecureSocketOptions.None);
                    //emailClient.Connect(_emailConfiguration.SmtpServer, _emailConfiguration.SmtpPort, false);
                }
                catch (MailKit.Security.SslHandshakeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.WriteLine("Client is connected: {0}", emailClient.IsConnected);

                emailClient.AuthenticationMechanisms.Remove("XOAUTH2");
                emailClient.Authenticate(emailConfiguration.SmtpUsername, emailConfiguration.SmtpPassword);
                Console.WriteLine("Client is {0}", emailClient.IsConnected);
                emailClient.Send(smtpMessage.mimeMessage);
                emailClient.Disconnect(true);
            }
        }
    }
}
