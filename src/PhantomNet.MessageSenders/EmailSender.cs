using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;

namespace PhantomNet.MessageSenders
{
    public class EmailSender<TMarker> : EmailSender, IEmailSender<TMarker>
    {
        public EmailSender(
            IMessageTemplateResolver<TMarker> messageTemplateResolver,
            IOptions<EmailSenderOptions<TMarker>> emailSenderOptions)
            : base(messageTemplateResolver, emailSenderOptions)
        { }
    }

    public class EmailSender : IEmailSender
    {
        public EmailSender(
            IMessageTemplateResolver messageTemplateResolver,
            IOptions<EmailSenderOptions> emailSenderOptions)
        {
            if (messageTemplateResolver == null)
            {
                throw new ArgumentNullException(nameof(messageTemplateResolver));
            }
            if (emailSenderOptions == null)
            {
                throw new ArgumentNullException(nameof(emailSenderOptions));
            }

            TemplateResolver = messageTemplateResolver;
            TemplatesLocation = emailSenderOptions.Value.TemplatesLocation;
            Smtp = emailSenderOptions.Value.Smtp;
        }

        protected IMessageTemplateResolver TemplateResolver { get; }

        protected string TemplatesLocation { get; }

        protected EmailSenderOptions.SmtpOptions Smtp { get; }

        public Task SendEmailAsync(
            string senderName, string senderEmail, string receiverName, string receiverEmail,
            string subject, string templateName, IDictionary<string, string> replacements)
        {
            var template = TemplateResolver.ResolveTemplate(TemplatesLocation, templateName);
            var body = template;
            foreach (var key in replacements.Keys)
            {
                body = body.Replace($"{{{key}}}", replacements[key]);
            }

            return SendEmailAsync(senderName, senderEmail, receiverName, receiverEmail, subject, body);
        }

        public async Task SendEmailAsync(
            string senderName, string senderEmail, string receiverName, string receiverEmail,
            string subject, string body)
        {
            var mailMessage = new MimeMessage();
            mailMessage.From.Add(new MailboxAddress(senderName, senderEmail));
            mailMessage.To.Add(new MailboxAddress(receiverName, receiverEmail));
            mailMessage.Subject = subject;

            mailMessage.Body = new TextPart("html") {
                Text = body
            };

            using (var client = new SmtpClient())
            {
                client.Connect(Smtp.Host, Smtp.Port, Smtp.UseSsl);

                // Note: since we don't have an OAuth2 token, disable
                // the XOAUTH2 authentication mechanism.
                client.AuthenticationMechanisms.Remove("XOAUTH2");

                // Note: only needed if the SMTP server requires authentication
                client.Authenticate(Smtp.Username, Smtp.Password);

                await client.SendAsync(mailMessage);
                client.Disconnect(true);
            }
        }
    }
}
