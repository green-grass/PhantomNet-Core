using System;
using System.Collections.Generic;
using System.Linq;

namespace PhantomNet
{
    public class TagProcessor
    {
        public string ProcessTagsForSaving(IEnumerable<string> tags)
        {
            return tags == null || tags.Select(x => x.Trim()).Count() == 0 ? null : $"\n{string.Join("\n", tags.Select(x => x.Trim()))}\n";
        }

        public IEnumerable<string> ProcessTagsForEditting(string tags)
        {
            return (string.IsNullOrWhiteSpace(tags) ? string.Empty : tags).Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
        }

        public string ProcessTagsForDisplaying(string tags)
        {
            return string.Join(", ", ProcessTagsForEditting(tags));
        }

        public string UrlEncodeTag(string tag)
        {
            return tag?.Replace(" ", "-");
        }

        public string UrlDecodeTag(string tag)
        {
            return tag?.Replace("-", " ");
        }

        public string HtmlDecodeTag(string tag)
        {
            return tag?.Replace("_", "-");
        }
    }
}
