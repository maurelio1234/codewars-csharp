using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codewars
{
    [TestFixture]
    public class Kata
    {

      public static int DuplicateCount(string str)
      {
            return str
                .ToLower()
                .GroupBy(c => c)
                .Aggregate(0, (current, next) => current + (next.Count() > 1 ? 1 : 0));
      }
     
     [Test]
      public void KataTests()
      {
        Assert.AreEqual(0, Kata.DuplicateCount(""));
        Assert.AreEqual(0, Kata.DuplicateCount("abcde"));
        Assert.AreEqual(2, Kata.DuplicateCount("aabbcde"));
        Assert.AreEqual(0, Kata.DuplicateCount("a"));
        Assert.AreEqual(1, Kata.DuplicateCount("aa"));
        Assert.AreEqual(2, Kata.DuplicateCount("aabBcde"), "should ignore case");
        Assert.AreEqual(1, Kata.DuplicateCount("Indivisibility"));
        Assert.AreEqual(2, Kata.DuplicateCount("Indivisibilities"), "characters may not be adjacent");
      }
    }
}
