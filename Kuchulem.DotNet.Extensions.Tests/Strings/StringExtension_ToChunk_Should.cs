using NUnit.Framework;
using Kuchulem.DotNet.Extensions.Strings;
using System.Linq;

namespace Kuchulem.DotNet.Extensions.Tests.Strings
{
    class StringExtension_ToChunk_Should
    {
        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        public void ProvideAcceptableChunks()
        {
            // 120 characters, should provide 6 chunks of 20 characters each
            var str = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus ut libero at metus scelerisque volutpat at turpis duis.";

            var chunks = str.ToChunks(20);

            Assert.AreEqual(6, chunks.Count());

            foreach (var chunk in chunks)
                Assert.AreEqual(20, chunk.Length);
        }

        [Test]
        public void ProvideAShorterLastChunk()
        {
            // 118 characters, should provide 5 chunks of 20 characters and 1 of 18.
            var str = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus aliquam, justo eget pharetra laoreet, orci blandit.";

            var chunks = str.ToChunks(20);

            Assert.AreEqual(6, chunks.Count());

            for (var i = 0; i < 5; i++)
                Assert.AreEqual(20, chunks.ElementAt(i).Length);

            Assert.AreEqual(18, chunks.ElementAt(5).Length);
        }

        [Test]
        public void ProvideEmptyListForEmptyString()
        {
            var str = string.Empty;

            var chunks = str.ToChunks(20);

            Assert.IsEmpty(chunks);
        }

        [Test]
        public void ProvideEmptyListForNullString()
        {
            string str = null;

            var chunks = str.ToChunks(20);

            Assert.IsEmpty(chunks);
        }
    }
}
