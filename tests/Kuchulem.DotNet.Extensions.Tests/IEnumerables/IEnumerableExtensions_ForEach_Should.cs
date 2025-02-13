﻿using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Kuchulem.DotNet.Extensions.Tests.IEnumerables
{
    class IEnumerableExtensions_ForEach_Should
    {
        [Test]
        public void RunActionOnAllElements()
        {
            var list = new[] { "1", "2", "3" } as IEnumerable<string>;
            var ints = new List<int>();
            var expected = new List<int> { 1, 2, 3 };
            list.ForEach(s => ints.Add(int.Parse(s)));

            Assert.That(!ints.Any(i => !expected.Contains(i)) && !expected.Any(i => !ints.Contains(i)));
        }

        [Test]
        public void DoNotRunActionOnEmptyList()
        {
            var list = System.Array.Empty<string>() as IEnumerable<string>;
            var executed = false;
            var expected = false;
            list.ForEach(s => executed = true);

            Assert.That(expected ==  executed);
        }
    }
}
