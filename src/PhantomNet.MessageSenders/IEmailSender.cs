﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhantomNet.MessageSenders
{
    public interface IEmailSender<out TMarker> : IEmailSender { }

    public interface IEmailSender
    {
        Task SendEmailAsync(
            string senderName, string senderEmail, string receiverName, string receiverEmail,
            string subject, string templateName, IDictionary<string, string> replacements);

        Task SendEmailAsync(
            string senderName, string senderEmail, string receiverName, string receiverEmail,
            string subject, string body);
    }
}
