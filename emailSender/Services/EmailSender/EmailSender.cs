//add MimeKit and MailKit nuget package

using System;
using System.Data;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using MimeKit;

namespace emailSender.Services.EmailSender
{
    public class EmailSender : IEmailSender
    {
        private readonly IWebHostEnvironment _env;

        public EmailSender(IWebHostEnvironment env)
        {
            _env = env;
        }

        public async Task SendEmail(string senderName, string senderEmail, string senderPass, string title,
            string emailThem, string host, int port, bool ssl, string userName, string userEmail)
        {
            try
            {


                var message = new MimeMessage();

                var from = new MailboxAddress(senderName, senderEmail.Trim());
                message.From.Add(from);

                var to = new MailboxAddress(userName, userEmail.Trim());
                message.To.Add(to);

                message.Subject = title;
                var bodyBuilder = new BodyBuilder
                {
                    HtmlBody = emailThem,
                };

                message.Body = bodyBuilder.ToMessageBody();


                using var client = new SmtpClient();
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                if (_env.IsDevelopment())
                {
                    await client.ConnectAsync(host, port, ssl);
                }
                else
                {
                    await client.ConnectAsync(host);
                }

                await client.AuthenticateAsync(senderEmail.Trim(), senderPass);
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
            catch (Exception e)
            {
                throw new InvalidOperationException(e.Message);
            }


            //using var client = new SmtpClient();
            //await client.ConnectAsync(/*host*/host , /*port*/ port ,/*useSsl?*/ssl);
            //await client.AuthenticateAsync(/*userName*/senderEmail.Trim(),/*password*/senderPass.Trim());
            //await client.SendAsync(message);
            //await client.DisconnectAsync(/*quit*/true); 



        }


    }
}
