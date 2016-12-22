using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codewars.SimpleEncryption
{
    public class Kata
    {
        public static string Encrypt(string text, int n)
        {
            if (text == null || text.Length == 0 || n<=0)
            {
                return text;
            }
            var even = "";
            var odd = "";
            for(int i=0;i<text.Length;++i)
            {
                if (i%2==1)
                {
                    odd += text[i];
                }
                else
                {
                    even += text[i];
                }
            }
            var transformed = odd + even;
            return Encrypt(transformed, n-1);
        }

        public static string Decrypt(string encryptedText, int n)
        {
            if (encryptedText == null || encryptedText.Length == 0 || n<=0)
            {
                return encryptedText;
            }
            else
            {
                var split = encryptedText.Length / 2;
                var i = 0;
                var j = split;

                var decryptedText = "";
                while(i!=split || j!=encryptedText.Length)
                {
                    if (j<encryptedText.Length)
                    {
                        decryptedText += encryptedText[j];
                        j++;
                    }

                    if (i<split)
                    {
                        decryptedText += encryptedText[i];
                        i++;
                    }

                }
                return Decrypt(decryptedText, n-1);
            }
        }
    }

    public class SolutionTest
    {
        [Test]
        public void EncryptExampleTests()
        {
            Assert.AreEqual("This is a test!", Kata.Encrypt("This is a test!", 0));
            Assert.AreEqual("hsi  etTi sats!", Kata.Encrypt("This is a test!", 1));
            Assert.AreEqual("s eT ashi tist!", Kata.Encrypt("This is a test!", 2));
            Assert.AreEqual(" Tah itse sits!", Kata.Encrypt("This is a test!", 3));
            Assert.AreEqual("This is a test!", Kata.Encrypt("This is a test!", 4));
            Assert.AreEqual("This is a test!", Kata.Encrypt("This is a test!", -1));
            Assert.AreEqual("hskt svr neetn!Ti aai eyitrsig", Kata.Encrypt("This kata is very interesting!", 1));
        }

        [Test]
        public void DecryptExampleTests()
        {
            Assert.AreEqual("This is a test!", Kata.Decrypt("This is a test!", 0));
            Assert.AreEqual("This is a test!", Kata.Decrypt("hsi  etTi sats!", 1));
            Assert.AreEqual("This is a test!", Kata.Decrypt("s eT ashi tist!", 2));
            Assert.AreEqual("This is a test!", Kata.Decrypt(" Tah itse sits!", 3));
            Assert.AreEqual("This is a test!", Kata.Decrypt("This is a test!", 4));
            Assert.AreEqual("This is a test!", Kata.Decrypt("This is a test!", -1));
            Assert.AreEqual("This kata is very interesting!", Kata.Decrypt("hskt svr neetn!Ti aai eyitrsig", 1));
        }

        [Test]
        public void EmptyTests()
        {
            Assert.AreEqual("", Kata.Encrypt("", 0));
            Assert.AreEqual("", Kata.Decrypt("", 0));
        }

        [Test]
        public void NullTests()
        {
            Assert.AreEqual(null, Kata.Encrypt(null, 0));
            Assert.AreEqual(null, Kata.Decrypt(null, 0));
        }
    }
}
