using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kuchulem.DotNet.Extensions.Tests.Strings
{
    public class StringExtensions_Calculate_Should
    {
        [Test]
        public void CalculateAnAddition()
        {
            var input = "1 + 2";
            var expected = 3.0;
            Assert.That(input.Calculate() == expected);
        }

        [Test]
        public void CalculateASubtraction()
        {
            var input = "1 - 2";
            var expected = -1.0;
            Assert.That(input.Calculate() == expected);
        }

        [Test]
        public void CalculateAMultiplication()
        {
            var input = "1 * 2";
            var expected = 2.0;
            Assert.That(input.Calculate() == expected);
        }

        [Test]
        public void CalculateADivision()
        {
            var input = "1 / 2";
            var expected = 0.5;
            Assert.That(input.Calculate() == expected);
        }

        [Test]
        public void RespectCalculationOrders()
        {
            var input = "1 + 2 * 3";
            var expected = 7.0;
            Assert.That(input.Calculate() == expected);
        }

        [Test]
        public void AcceptParenthesis()
        {
            var input = "(1 + 2) * 3";
            var expected = 9.0;
            Assert.That(input.Calculate() == expected);
        }

        [Test]
        public void UsePlaceholders()
        {
            var input = "({0} + 2) * {1}";
            var expected = 9.0;
            Assert.That(input.Calculate(1, 3) == expected);
        }
    }
}
