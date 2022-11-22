using System;
using System.Collections.Generic;
using System.Text;

namespace Kuchulem.DotNet.Extensions.Helpers
{
    internal static class StringToChunkHelper
    {
        internal static IEnumerable<string> StringListToChunks(IEnumerable<string> strings, int maxChunkSize, bool wholeWords)
        {
            foreach (var str in strings)
                foreach (var chunk in str.ToChunks(maxChunkSize, wholeWords))
                    yield return chunk;
        }

        internal static IEnumerable<string> StringToChunksWordFriendly(string str, int maxChunkSize)
        {
            var current = "";
            var words = str.Trim().Split(' ');
            foreach (var word in words)
            {
                var space = string.IsNullOrEmpty(current) ? "" : " ";
                if (current.Length + word.Length + space.Length > maxChunkSize)
                {
                    if (!string.IsNullOrEmpty(current))
                        foreach (var chunk in current.ToChunks(maxChunkSize, false))
                            yield return chunk;
                    current = word;
                }
                else
                {
                    current += space + word;
                }
            }

            yield return current;
        }

        internal static IEnumerable<string> StringToChunks(string str, int maxChunkSize)
        {
            for (int i = 0; i < str.Length; i += maxChunkSize)
                yield return str.Substring(i, Math.Min(maxChunkSize, str.Length - i));
        }
    }
}
