using BenchmarkDotNet.Running;
using System;

namespace Kuchulem.DotNet.Extensions.Benchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<SlugLinq_Vs_SlugRegexp_Benchmark>();
        }
    }
}
