using Kuchulem.DotNet.Extensions.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Kuchulem.DotNet.Extensions
{
    /// <summary>
    /// Static class providing extension methods for strings
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Default char separator for slug
        /// </summary>
        public const char DefaultSlugReplacingChar = '-';

        /// <summary>
        /// Options applied to the <see cref="StringExtensions.ToSlug(string, StringToSlugOptions, string)"/> method.<br/>
        /// As this is a flag, multiple options can be applied.
        /// </summary>
        [Flags]
        public enum StringToSlugOptions
        {
            /// <summary>
            /// No options are applied, default values will be used :
            /// <list type="bullet">
            /// <item>
            ///  Spacing chars not reduced : multiple spacing chars are allowed
            /// </item>
            /// <item>
            ///  Lower case applied to the whole string
            /// </item>
            /// </list>
            /// </summary>
            None,
            /// <summary>
            /// Reduces the spacing chars, multiple occurrences of the separation
            /// character will be replaced by a single one.
            /// </summary>
            ReduceSpacingChars,
            /// <summary>
            /// The resulting slug will be in upper case letters, instead of
            /// lower case.
            /// </summary>
            Capitalize
        }

        /// <summary>
        /// Splint a string in chunks of the same size.
        /// </summary>
        /// <param name="str"><em>this</em> the string to split in chunks</param>
        /// <param name="maxChunkSize">The maximum number of chunks to create</param>
        /// <param name="wholeWorlds">True to avoid splitting in worlds</param>
        /// <returns></returns>
        public static IEnumerable<string> ToChunks(this string str, int maxChunkSize, bool wholeWorlds = false)
        {
            if (string.IsNullOrEmpty(str))
                return Array.Empty<string>();

            var lines = str.Trim().Split('\n');

            if (lines.Length > 1)
            {
                return StringToChunkHelper.StringListToChunks(lines, maxChunkSize, wholeWorlds);
            }
            else
            {
                var line = lines.First();
                if (wholeWorlds)
                    return StringToChunkHelper.StringToChunksWordFriendly(line, maxChunkSize);
                else
                    return StringToChunkHelper.StringToChunks(str, maxChunkSize);
            }
        }

        /// <summary>
        /// Removes all diacritics from a string.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string RemoveDiacritics(this string str)
        {
            var normalized = str.Normalize(NormalizationForm.FormD);

            var chars = normalized
                .Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                .ToArray();

            return new StringBuilder().Append(chars).ToString().Normalize(NormalizationForm.FormC);
        }

        /// <summary>
        /// Turns the string into a slug. A slug is a normalized version of the string that can be
        /// used in URLs without encoding it.
        /// </summary>
        /// <param name="input">The input string</param>
        /// <param name="options">Options to be applied during conversion. see <see cref="StringToSlugOptions"/></param>
        /// <param name="spacingChar">The char used as separator, by default the - (dash) character is used.</param>
        /// <returns></returns>
        public static string ToSlug(this string input, StringToSlugOptions options = StringToSlugOptions.None, char spacingChar = DefaultSlugReplacingChar)
        {
            var normalized = input.RemoveDiacritics();

            normalized = options.HasFlag(StringToSlugOptions.Capitalize) ? normalized.ToUpperInvariant() : normalized.ToLowerInvariant();

            var allowedChars = new[] { UnicodeCategory.LowercaseLetter, UnicodeCategory.UppercaseLetter, UnicodeCategory.DecimalDigitNumber };

            var slug = new StringBuilder().Append(normalized.Select(c =>
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (!allowedChars.Contains(unicodeCategory))
                    return spacingChar;
                return c;
            }).ToArray()).ToString();

            if (options.HasFlag(StringToSlugOptions.ReduceSpacingChars))
                slug = Regex.Replace(slug, $"{spacingChar}+", $"{spacingChar}");

            return slug;
        }

        public static double Calculate(this string input, params int[] replaces)
        {
            return Convert.ToDouble(new DataTable().Compute(string.Format(input, [.. replaces]), null));
        }
    }
}
