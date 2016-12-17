using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codewars.SimplePigLatin
{
    public class Kata
    {
        public static string PigIt(string str)
        {
            return str
                .Split(new char[] { ' ' })
                .Select(word => word.Substring(1)+word.ElementAt(0)+"ay")
                .Aggregate((current, next) => current + " " + next);
        }
    }

    [TestFixture]
    public class KataTest
    {
        [Test]
        public void KataTests()
        {
            Assert.AreEqual("igPay atinlay siay oolcay", Kata.PigIt("Pig latin is cool"));
            Assert.AreEqual("hisTay siay ymay tringsay", Kata.PigIt("This is my string"));
            Assert.AreEqual("eMay", Kata.PigIt("Me"));
            Assert.AreEqual("May", Kata.PigIt("M"));
        }
    }
}
