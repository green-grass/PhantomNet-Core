using System;
using System.Linq;

namespace PhantomNet
{
    public static class StringExtensions
    {
        public static string ToPascalCase(this string source)
        {
            if (source == null)
            {
                return source;
            }

            if (source.Length == 1)
            {
                return source.ToUpper();
            }

            var words = source.Split(new char[0], StringSplitOptions.RemoveEmptyEntries)
                              .Select(x => $"{x.Substring(0, 1).ToUpper()}{x.Substring(1)}")
                              .ToArray();

            return string.Join(string.Empty, words);
        }

        public static string ToCamelCase(this string source)
        {
            if (source == null)
            {
                return source;
            }

            if (source.Length == 1)
            {
                return source.ToLower();
            }

            var words = source.Split(new char[0], StringSplitOptions.RemoveEmptyEntries)
                              .Select(x => $"{x.Substring(0, 1).ToUpper()}{x.Substring(1)}")
                              .ToArray();

            if (words.Length > 0)
            {
                words[0] = $"{words[0].Substring(0, 1).ToLower()}{words[0].Substring(1)}";
            }

            return string.Join(string.Empty, words);
        }
    }
}
