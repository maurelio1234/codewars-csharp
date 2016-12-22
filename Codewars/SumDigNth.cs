using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codewars
{
    public class SumDigNth
    {

        public static long SumDigNthTerm(long initval, long[] patternl, int nthterm)
        {
            // compute term
            var term = initval;
            for(int i=2;i<=nthterm;++i)
            {
                var index = (i - 2)%patternl.Length;
                term += patternl[index];
            }

            // sum of digits
            var sumDigits = 0L;
            while(term>0)
            {
                sumDigits += term % 10;
                term /= 10;
            }
            return sumDigits;
        }
    }

    [TestFixture]
    public static class SumDigNthTests
    {
        private static void testing(long actual, long expected)
        {
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public static void test1()
        {
            Console.WriteLine("Basic Tests SumDigNthTerm");
            testing(SumDigNth.SumDigNthTerm(10, new long[] { 2, 1, 3 }, 6), 10);
            testing(SumDigNth.SumDigNthTerm(10, new long[] { 2, 1, 3 }, 15), 10);
            testing(SumDigNth.SumDigNthTerm(10, new long[] { 2, 1, 3 }, 50), 9);
            testing(SumDigNth.SumDigNthTerm(10, new long[] { 2, 1, 3 }, 78), 10);
            testing(SumDigNth.SumDigNthTerm(10, new long[] { 2, 1, 3 }, 157), 7);
        }
    }


}
