using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codewars.CountBits
{
    public class Kata
    {

      public static int CountBits(int n)
      {
            var count = 0;
            for (int bit = 0; bit < 32; ++bit)
                if ((n & (1 << bit)) != 0)
                    count++;
            return count;
      }

    }

    [TestFixture]
    class BitCounting
    {
        [Test]
        public void CountBits()
        {
            Assert.AreEqual(0, Kata.CountBits(0));
            Assert.AreEqual(1, Kata.CountBits(4));
            Assert.AreEqual(3, Kata.CountBits(7));
            Assert.AreEqual(2, Kata.CountBits(9));
            Assert.AreEqual(2, Kata.CountBits(10));
        }
    }
}
