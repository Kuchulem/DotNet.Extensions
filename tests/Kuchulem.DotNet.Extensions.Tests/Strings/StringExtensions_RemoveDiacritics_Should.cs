using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kuchulem.DotNet.Extensions.Tests.Strings
{
    class StringExtensions_RemoveDiacritics_Should
    {
        [Test]
        public void RemoveDiacriticsFromString()
        {
            var input = "ÀÁÂÃÄÅ"+
                "ÈÉÊË" + 
                "ÌÍÎÏ" + 
                "Ñ" + 
                "ÒÓÔÕÖ" + 
                "ÙÚÛÜ" + 
                "Ý" + 
                "àáâãäåà" +
                "èéêë" + 
                "ìíîï" +
                "ñ" +
                "òóôõö" +
                "ùúûü" +
                "ýÿ" +
                "ĀāĂăĄą" + 
                "ĆćĈĉĊċČč" +
                "Ďď" +
                "ĒēĔĕĖėĘęĚě" +
                "ĜĝĞğĠġĢģ" +
                "Ĥĥ" +
                "ĨĩĪīĬĭĮįİ" +
                "Ĵĵ" +
                "ĹĺĻļĽľ" +
                "ŃńŅņŇň" +
                "ŌōŎŏŐő" +
                "ŔŕŖŗŘř" +
                "ŚśŜŝŞşŠš" +
                "ŢţŤť" +
                "ŨũŪūŬŭŮůŰűŲų" +
                "Ŵŵ" +
                "ŶŷŸ" +
                "ŹźŻżŽž";

            var expected = "AAAAAA" +
                "EEEE" +
                "IIII" +
                "N" +
                "OOOOO" +
                "UUUU" +
                "Y" +
                "aaaaaaa" +
                "eeee" +
                "iiii" +
                "n" +
                "ooooo" +
                "uuuu" +
                "yy" +
                "AaAaAa" +
                "CcCcCcCc" +
                "Dd" +
                "EeEeEeEeEe" +
                "GgGgGgGg" +
                "Hh" +
                "IiIiIiIiI" +
                "Jj" +
                "LlLlLl" +
                "NnNnNn" +
                "OoOoOo" +
                "RrRrRr" +
                "SsSsSsSs" +
                "TtTt" +
                "UuUuUuUuUuUu" +
                "Ww" +
                "YyY" +
                "ZzZzZz";

            Assert.That(expected == input.RemoveDiacritics());
        }

        [Test]
        public void PreserveSpacesAndSpecialChars()
        {
            var input = "Du chocolat à été mangé  en dehors de la table !\n" +
                "Je me demande : Qui est le petit monstre qui à pût faire ça ?";

            var expected = "Du chocolat a ete mange  en dehors de la table !\n" +
                "Je me demande : Qui est le petit monstre qui a put faire ca ?";

            Assert.That(expected == input.RemoveDiacritics());
        }
    }
}
