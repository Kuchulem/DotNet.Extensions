using NUnit.Framework;

namespace Kuchulem.DotNet.Extensions.Tests.Strings
{
    class StringExtensions_ToSlug_Should
    {
        [Test]
        public void ProvideDefaultSlug()
        {
            var input = "Rédaction d'une chaîne de charactères accentuée";
            var expected = "redaction-d-une-chaine-de-characteres-accentuee";

            Assert.Equals(expected, input.ToSlug());
        }

        [Test]
        public void ProvideDefaultSlugRemovingPunctuation()
        {
            var input = "Rédaction d'une chaîne de charactères accentuée !";
            var expected = "redaction-d-une-chaine-de-characteres-accentuee--";

            Assert.Equals(expected, input.ToSlug());
        }

        [Test]
        public void ProvideSlugRemovingMultipleSpacings()
        {
            var input = "Rédaction d'une chaîne de charactères accentuée !";
            var expected = "redaction-d-une-chaine-de-characteres-accentuee-";

            Assert.Equals(expected, input.ToSlug(StringExtensions.StringToSlugOptions.ReduceSpacingChars));
        }

        [Test]
        public void ProvideSlugWithUnderscores()
        {
            var input = "Rédaction d'une chaîne de charactères accentuée !";
            var expected = "redaction_d_une_chaine_de_characteres_accentuee_";

            Assert.Equals(expected, input.ToSlug(StringExtensions.StringToSlugOptions.ReduceSpacingChars, '_'));
        }

        [Test]
        public void ProvideUppercaseSlugWithUnderscores()
        {
            var input = "Rédaction d'une chaîne de charactères accentuée !";
            var expected = "REDACTION_D_UNE_CHAINE_DE_CHARACTERES_ACCENTUEE_";

            Assert.Equals(expected, input.ToSlug(StringExtensions.StringToSlugOptions.ReduceSpacingChars | StringExtensions.StringToSlugOptions.Capitalize, '_'));
        }
    }
}
