using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters.Csv;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using System;

namespace Kuchulem.DotNet.Extensions.Benchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = ManualConfig
                .Create(DefaultConfig.Instance)
                .AddExporter(new CsvExporter(CsvSeparator.Semicolon, SummaryStyle.Default));

            var slugSummary = BenchmarkRunner.Run<SlugLinq_Vs_SlugRegexp_Benchmark>(config);
            var forEachSulmmary = BenchmarkRunner.Run<ForEachLinq_vs_ForEachLoop>(config);

            Console.WriteLine(slugSummary.LogFilePath);
        }
    }
}
