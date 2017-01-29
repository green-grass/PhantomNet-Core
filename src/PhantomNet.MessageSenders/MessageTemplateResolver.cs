using System;
using System.Globalization;
using System.IO;

namespace PhantomNet.MessageSenders
{
    public class MessageTemplateResolver : IMessageTemplateResolver
    {
        protected string Language => CultureInfo.CurrentCulture.TwoLetterISOLanguageName;

        public string ResolveTemplate(string location, string templateName)
        {
            if (string.IsNullOrWhiteSpace(location))
            {
                throw new ArgumentNullException(nameof(location));
            }
            if (string.IsNullOrWhiteSpace(templateName))
            {
                throw new ArgumentNullException(nameof(templateName));
            }

            var path = $"{location}/{Language}/{templateName}.html";
            if (!File.Exists(path))
            {
                path = $"{location}/{templateName}.html";
            }

            try
            {
                return File.ReadAllText(path);
            }
            catch
            {
                throw new IOException(Strings.FormatTemplateReadingError(templateName, location));
            }
        }
    }
}
