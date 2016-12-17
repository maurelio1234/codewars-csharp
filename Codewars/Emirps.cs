using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codewars.Emirps
{
    public class Emirps
    {
        private static HashSet<long> knownEmirps = new HashSet<long>();
        private static long largestEmirp = -1;
        private static long largestPrime = -1;

        public static void UpdateEmirps(long n)
        {
            if (largestPrime == -1)
            {
               // generate all primes from 2 to n
            } else
            {
                // generate all primes from largestPrime to n
            }

            // remove all non emirp from the list :)
            
            // merge new list with old list
            // update lastPrime & largestEmirp

        }

        public static long[] FindEmirp(long n)
        {
            UpdateEmirps(n);
            var result = knownEmirps.Where(i => i < n);
            if (result.Count() == 0)
            {
                return new long[] { 0, 0, 0 };
            }
            else
            {
                return new long[]
                {
                    result.Count(),
                    result.Max(),
                    result.Sum()
                };
            }

        }
    }

    [TestFixture]
    public static class EmirpsTests
    {
        private static string Array2String(long[] list)
        {
            return "[" + string.Join(", ", list) + "]";
        }
        private static void testing(string actual, string expected)
        {
            Assert.AreEqual(expected, actual);
        }
        public static void tests(long[] list1, long[][] results)
        {
            for (int i = 0; i < list1.Length; i++)
                testing(EmirpsTests.Array2String(Emirps.FindEmirp(list1[i])), EmirpsTests.Array2String(results[i]));
            return;
        }
        [Test]
        public static void test1()
        {
            Console.WriteLine("Basic Tests FindEmirp");
            long[] l = new long[] { 50, 100, 200, 500, 750, 1000 };
            long[][] r = new long[][] { new long[] {4, 37, 98}, new long[] {8, 97, 418}, new long[] {15, 199, 1489}, new long[] {20, 389, 3232},
            new long[] {25, 743, 6857}, new long[] {36, 991, 16788} };
            tests(l, r);
        }
    }

}
