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
            var orderedLowercase = str.ToLower().OrderBy(c => c);
            var countDuplicates = 0;
            var countOccurrenciesCurrentCharacter = 1;
            char? previousElement = null;
            var firstElement = true;

            foreach(var currentElement in orderedLowercase)
            {
                if (firstElement)
                {
                    firstElement = false;
                }
                else
                {
                    if (currentElement == previousElement.Value)
                    {
                        countOccurrenciesCurrentCharacter ++;

                        if (countOccurrenciesCurrentCharacter == 2)
                        {
                            countDuplicates ++;
                        }
                    }
                    else
                    {
                        countOccurrenciesCurrentCharacter = 1;
                    }
                }
                previousElement = currentElement;
            }
            return countDuplicates;
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
