using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace PhantomNet
{
    public class StringProcessor
    {
        public string TrimStringByWord(string source, int maxLength)
        {
            if (source == null)
            {
                return null;
            }

            var ret = source;
            if (ret.Trim().Length > maxLength)
            {
                ret = ret.Trim().Substring(0, maxLength);
                if (!ret.EndsWith(" ") && source[maxLength] != ' ' && (ret = ret.Trim()).Contains(" "))
                {
                    ret = ret.Substring(0, ret.LastIndexOf(' ')).Trim();
                }
                ret = string.Format("{0}...", ret.Trim());
            }
            return ret;

        }

        public string RemoveHtmlTags(string source)
        {
            if (source == null)
            {
                return null;
            }

            // Faster than using regular expression
            source = source.Replace("&nbsp;", " ")
                       .Replace("<br>", "\n")
                       .Replace("<br />", "\n")
                       .Replace("<p", "\n<p")
                       .Replace("<div", "\n<div");
            char[] array = new char[source.Length];
            int arrayIndex = 0;
            bool inside = false;

            for (int i = 0; i < source.Length; i++)
            {
                char let = source[i];
                if (let == '<')
                {
                    inside = true;
                    continue;
                }
                if (let == '>')
                {
                    inside = false;
                    continue;
                }
                if (!inside)
                {
                    array[arrayIndex] = let;
                    arrayIndex++;
                }
            }
            return new string(array, 0, arrayIndex);
        }

        public string ToAscii(string source)
        {
            if (source == null)
            {
                return null;
            }

            string unicode = "áàảãạăắằẳẵặâấầẩẫậéèẻẽẹêếềểễệíìỉĩịóòỏõọôốồổỗộơớờởỡợúùủũụưứừửữựýỳỷỹỵÁÀẢÃẠĂẮẰẲẴẶÂẤẦẨẪẬÉÈẺẼẸÊẾỀỂỄỆÍÌỈĨỊÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢÚÙỦŨỤƯỨỪỬỮỰÝỲỶỸỴđĐ",
                     ascii = "aaaaaaaaaaaaaaaaaeeeeeeeeeeeiiiiiooooooooooooooooouuuuuuuuuuuyyyyyAAAAAAAAAAAAAAAAAEEEEEEEEEEEIIIIIOOOOOOOOOOOOOOOOOUUUUUUUUUUUYYYYYdD";

            for (var i = 0; i < unicode.Length; i++)
            {
                source = source.Replace(unicode[i], ascii[i]);
            }
            return source;
        }

        public string ToUrlFriendly(string source)
        {
            if (source == null)
            {
                return null;
            }

            source = ToAscii(source).Trim().ToLower();
            source = source.Replace(' ', '-');
            source = source.Replace("&nbsp;", "-");
            source = new Regex("[^0-9a-z-]").Replace(source, string.Empty);
            while (source.IndexOf("--") > -1)
            {
                source = source.Replace("--", "-");
            }
            return source;

        }

        public string ProcessTagsForSaving(IEnumerable<string> tags)
        {
            return tags == null || tags.Count() == 0 ? null : string.Join("\n", tags.Select(x => x.Trim()));
        }

        public IEnumerable<string> ProcessTagsForEditting(string tags)
        {
            return (string.IsNullOrWhiteSpace(tags) ? string.Empty : tags).Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
        }

        public string ProcessTagsForDisplaying(string tags)
        {
            return string.Join(", ", ProcessTagsForEditting(tags));
        }
    }
}
