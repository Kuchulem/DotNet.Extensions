using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kuchulem.DotNet.Extensions.Benchmarks
{
    public class ForEachLinq_vs_ForEachLoop
    {
        private const int InputLength = 5 * 1024;
        private readonly byte[] input;

        public ForEachLinq_vs_ForEachLoop()
        {
            input = new byte[InputLength];
            var randomizer = new Random();
            randomizer.NextBytes(input);
        }

        private void Callback(byte b)
        {
            var r = b + 1;
        }

        [Benchmark]
        public void ForEachWithLinqSelect()
        {
            input.Select(b => {
                Callback(b);
                return b;
            });
        }

        [Benchmark]
        public void ForEachWithLoop()
        {
            foreach(var b in input)
                Callback(b);
        }
    }
}
