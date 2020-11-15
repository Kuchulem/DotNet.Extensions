using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace Kuchulem.DotNet.Extensions.IEnumerables
{
    public static class IEnumerableExtensions
    {
        public static void ForEach<TSource>(this IEnumerable<TSource> source, Action<TSource> action)
        {
            if (action is null)
                return;

            foreach (TSource item in source)
                action.Invoke(item);
        }
    }
}
