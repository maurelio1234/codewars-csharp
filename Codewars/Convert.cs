using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codewars.Convert
{
    public class Kata
    {
        public string Convert(string input, string source, string target)
        {
            // to int
            var intVal = 0;
            foreach(var c in input)
            {
                intVal = intVal * source.Length + source.IndexOf(c);
            }

            // to target
            var targetString = "";

            do
            {
                targetString = target[intVal % target.Length] + targetString;
                intVal /= target.Length;
            } while (intVal > 0);

            return targetString;
        }
    }

    public class Alphabet
    {
        public const string BINARY = "01";
        public const string OCTAL = "01234567";
        public const string DECIMAL = "0123456789";
        public const string HEXA_DECIMAL = "0123456789abcdef";
        public const string ALPHA_LOWER = "abcdefghijklmnopqrstuvwxyz";
        public const string ALPHA_UPPER = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public const string ALPHA = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public const string ALPHA_NUMERIC = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
    }

    [TestFixture]
    public class ExampleTests
    {
        Kata k = new Kata();
        [Test]
        public void BetweenNumeralSystems()
        {
            Assert.AreEqual("1111", k.Convert("15", Alphabet.DECIMAL, Alphabet.BINARY), "\"15\" dec -> bin");
            Assert.AreEqual("17", k.Convert("15", Alphabet.DECIMAL, Alphabet.OCTAL), "\"15\" dec -> oct");
            Assert.AreEqual("10", k.Convert("1010", Alphabet.BINARY, Alphabet.DECIMAL), "\"1010\" bin -> dec");
            Assert.AreEqual("a", k.Convert("1010", Alphabet.BINARY, Alphabet.HEXA_DECIMAL), "\"1010\" bin -> hex");
        }

        [Test]
        public void BetweenOtherBases()
        {
            Assert.AreEqual("a", k.Convert("0", Alphabet.DECIMAL, Alphabet.ALPHA), "\"0\" dec -> alpha");
            Assert.AreEqual("bb", k.Convert("27", Alphabet.DECIMAL, Alphabet.ALPHA_LOWER), "\"27\" dec -> alpha lower");
            Assert.AreEqual("320048", k.Convert("hello", Alphabet.ALPHA_LOWER, Alphabet.HEXA_DECIMAL), "\"hello\" alpha lower -> hex");
            Assert.AreEqual("SAME", k.Convert("SAME", Alphabet.ALPHA_UPPER, Alphabet.ALPHA_UPPER), "\"SAME\" alpha upper -> alpha upper");
        }
    }
}
