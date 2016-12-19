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
            var maxa = (long)Math.Sqrt(n);

            // iterate over divisors of n
            for(long a=1;a<=maxa;++a)
            {
                if (n%a==0)
                {
                    var b = n / a;
                    // n = a*b
                    // a=x+2y b=x-2y
                    // x = a-2y
                    // b = a-2y-2y = a-4y
                    // y = (b-a)/-4
                    var y0 = (b - a) / -4;
                    var x0 = a - 2 * y0;
                    if (((x0+2*y0)*(x0-2*y0) == n) && x0>=0 && y0>=0)
                    {
                        solutions.Add(Tuple.Create(x0, y0));
                    }
                    var y1 = (a - b) / -4;
                    var x1 = b - 2 * y1;
                    if (a!=b && ((x1+2*y1)*(x1-2*y1) == n) && x1>=0 && y1>=0)
                    {
                        solutions.Add(Tuple.Create(x1, y1));
                    }
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
