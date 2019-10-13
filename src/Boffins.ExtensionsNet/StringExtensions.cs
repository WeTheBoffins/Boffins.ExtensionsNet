using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;

namespace Boffins.ExtensionsNet
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmptyOrWhiteSpace(this string input)
        {
            return string.IsNullOrWhiteSpace(input);
        }

        public static string Strip(this string source, char character)
        {
            return source.Replace(character.ToString(), string.Empty);
        }

        public static string Strip(this string source, params char[] chars)
        {
            return chars.Aggregate(source, (current, c) => current.Replace(c.ToString(), newValue: string.Empty));
        }

        public static SecureString ToSecureString(this string source)
        {
            var secureString = new SecureString();
            source.ToCharArray().ToList().ForEach(secureString.AppendChar);

            return secureString;
        }

        public static IEnumerable<string> SplitAndTrim(this string source, params char[] separators)
        {
            return source.SplitAndTrim(false, separators);
        }

        public static IEnumerable<string> SplitAndTrim(this string source, bool shouldRemoveEmptyStrings,
            params char[] separators)
        {
            return source
                .Trim()
                .Split(separators, StringSplitOptions.RemoveEmptyEntries)
                .Select(s => s.Trim())
                .Where(x => !shouldRemoveEmptyStrings || !x.Equals(string.Empty));
        }
    }
}