using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Codewars.Dioph
{
    public class Dioph
    {
        public static string solEquaStr(long n)
        {
            var solutions = new List<Tuple<long, long>>();
            var minx = (long)Math.Sqrt(n) - 1;
            var maxx = (n / 2) + 2;

            maxx += n % 2 + maxx % 2;
            for(long x=maxx;x>=minx;x--)
            {
                var y = (long)Math.Sqrt((n - x * x) / -4.0d);

                if ((x - 2 * y) * (x + 2 * y) == n)
                {
                    solutions.Add(Tuple.Create(x, y));
                    x /= 2;
                    x += n % 2 + x % 2;
                }
            }
            return "[" 
                + string.Join(", ", solutions.Select(t=>"["+t.Item1+", "+t.Item2+"]")) 
                + "]";
        }
    }

    [TestFixture]
    public class DiophTests
    {

        [Test]
        public void Test1()
        {
            Assert.AreEqual("[[3, 1]]", Dioph.solEquaStr(5));
        }
        [Test]
        public void Test2()
        {
            Assert.AreEqual("[[4, 1]]", Dioph.solEquaStr(12));
        }
        [Test]
        public void Test3()
        {
            Assert.AreEqual("[[7, 3]]", Dioph.solEquaStr(13));
        }
        [Test]
        public void Test4()
        {
            Assert.AreEqual("[[4, 0]]", Dioph.solEquaStr(16));
        }
        [Test]
        public void Test5()
        {
            Assert.AreEqual("[[45003, 22501], [9003, 4499], [981, 467], [309, 37]]", Dioph.solEquaStr(90005));
        }
        [Test]
        public void Test6()
        {
            Assert.AreEqual("[]", Dioph.solEquaStr(90003));
        }
    }
}
