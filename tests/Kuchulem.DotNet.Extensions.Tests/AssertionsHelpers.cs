using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kuchulem.DotNet.Extensions.Tests
{
    internal static class AssertionsHelpers
    {
        public static bool ArraysAreEqual<T>(IEnumerable<T> expected, IEnumerable<T> assertion)
        {
            return
                expected.Count() == assertion.Count() &&
                !expected.Any(e => !assertion.Contains(e)) &&
                !assertion.Any(a => !expected.Contains(a));
        }
    }
}
