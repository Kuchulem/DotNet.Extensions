using System;
using System.Collections.Generic;

namespace Kuchulem.DotNet.Extensions.Strings
{
    /// <summary>
    /// Static class providing extension methods for strings
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Splint a string in chumnks of the same size.
        /// </summary>
        /// <param name="str"><em>this</em> the string to split in chunks</param>
        /// <param name="maxChunkSize">The maximum number of chunks to create</param>
        /// <returns></returns>
        public static IEnumerable<string> ToChunks(this string str, int maxChunkSize)
        {
            if (!string.IsNullOrEmpty(str))
                for (int i = 0; i < str.Length; i += maxChunkSize)
                    yield return str.Substring(i, Math.Min(maxChunkSize, str.Length - i));
        }
    }
}
