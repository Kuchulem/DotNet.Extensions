using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace Kuchulem.DotNet.Extensions.IEnumerables
{
    public static class IEnumerableExtensions
    {
        /// <summary>
        /// Applies an action to each element of the IEnumerable
        /// </summary>
        /// <typeparam name="TSource">The type of objects to enumerate</typeparam>
        /// <param name="source">The IEnumerable instance</param>
        /// <param name="action">The action to apply to all enumerated elements</param>
        public static void ForEach<TSource>(this IEnumerable<TSource> source, Action<TSource> action)
        {
            if (action is null)
                return;

            source.Select(item =>
            {
                action(item);
                return item;
            }).ToArray();
        }
    }
}
