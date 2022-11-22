using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Kuchulem.DotNet.Extensions.Benchmarks
{
    public class SlugLinq_Vs_SlugRegexp_Benchmark
    {
        private readonly string input = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam sit amet finibus dui.";

        [Benchmark]
        public string SlugWithLinqFinalizeWithRegex()
        {
            return Regex.Replace(new StringBuilder().Append(input.Select(c =>
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.LetterNumber)
                    return '-';
                return c;
            }).ToArray()).ToString(), "-+", "-");
        }

        [Benchmark]
        public string SlugWithLinqFinalizeWithOpitmizedRegex()
        {
            return Regex.Replace(new StringBuilder().Append(input.Select(c =>
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.LetterNumber)
                    return '-';
                return c;
            }).ToArray()).ToString(), "-{1,}", "-");
        }

        [Benchmark]
        public string SlugWithLinqFinalizeWithLoop()
        {
            var str = new StringBuilder().Append(input.Select(c =>
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.LetterNumber)
                    return '-';
                return c;
            }).ToArray()).ToString();

            while (str.Contains("--"))
                str = str.Replace("--", "-");

            return str;
        }

        [Benchmark]
        public string SlugWithRegexp()
        {
            return Regex.Replace(input, "([^\\w\\d]+)", "-");
        }
    }
}
