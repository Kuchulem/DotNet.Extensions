using NUnit.Framework;
using System.Linq;

namespace Kuchulem.DotNet.Extensions.Tests.Strings
{
    class StringExtensions_ToChunk_Should
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
        public void ProvideAcceptableChunksWithLines()
        {
            // 120 characters, should provide :
            // - Lorem ipsum dolor si
            // - t amet,
            // - consectetur adipisci
            // - ng elit.
            // - Vivamus ut libero at
            // -  metus scelerisque
            // - volutpat at turpis d
            // - uis.
            var str = "Lorem ipsum dolor sit amet,\nconsectetur adipiscing elit.\nVivamus ut libero at metus scelerisque\nvolutpat at turpis duis.";

            var chunks = str.ToChunks(20);
            var expected = new[]
            {
                "Lorem ipsum dolor si",
                "t amet,",
                "consectetur adipisci",
                "ng elit.",
                "Vivamus ut libero at",
                " metus scelerisque",
                "volutpat at turpis d",
                "uis."
            };

            Assert.AreEqual(expected.Length, chunks.Count());

            for (var i = 0; i < chunks.Count(); i++)
                Assert.AreEqual(expected[i], chunks.ElementAt(i));
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
            var wordsChunks = str.ToChunks(20, true);

            Assert.IsEmpty(chunks);
            Assert.IsEmpty(wordsChunks);
        }

        [Test]
        public void ProvideEmptyListForNullString()
        {
            string str = null;

            var chunks = str.ToChunks(20);
            var wordsChunks = str.ToChunks(20, true);

            Assert.IsEmpty(chunks);
            Assert.IsEmpty(wordsChunks);
        }

        [Test]
        public void ProvideAcceptableWordFirendlyChunks()
        {
            // 120 characters, should provide 
            // - Lorem ipsum dolor
            // - sit amet,
            // - consectetur
            // - adipiscing elit.
            // - Vivamus ut libero at
            // - metus scelerisque
            // - volutpat at turpis
            // - duis.
            var str = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus ut libero at metus scelerisque volutpat at turpis duis.";

            var chunks = str.ToChunks(20, true);
            var expected = new[]
            {
                "Lorem ipsum dolor",
                "sit amet,",
                "consectetur",
                "adipiscing elit.",
                "Vivamus ut libero at",
                "metus scelerisque",
                "volutpat at turpis",
                "duis."
            };

            Assert.AreEqual(expected.Length, chunks.Count());

            for (var i = 0; i < chunks.Count(); i++)
                Assert.AreEqual(expected[i], chunks.ElementAt(i));
        }

        [Test]
        public void ProvideAcceptableWordFirendlyChunksWithLines()
        {
            // 120 characters, should provide 
            // - Lorem ipsum
            // - dolor sit amet,
            // - consectetur
            // - adipiscing elit.
            // - Vivamus ut libero at
            // - metus
            // - scelerisque volutpat
            // - at turpis duis.
            var str = "Lorem ipsum\ndolor sit amet, consectetur adipiscing elit.\nVivamus ut libero at metus\nscelerisque volutpat at turpis duis.";

            var chunks = str.ToChunks(20, true);
            var expected = new[]
            {
                "Lorem ipsum",
                "dolor sit amet,",
                "consectetur",
                "adipiscing elit.",
                "Vivamus ut libero at",
                "metus",
                "scelerisque volutpat",
                "at turpis duis."
            };

            Assert.AreEqual(expected.Length, chunks.Count());

            for (var i = 0; i < chunks.Count(); i++)
                Assert.AreEqual(expected[i], chunks.ElementAt(i));
        }
    }
}
