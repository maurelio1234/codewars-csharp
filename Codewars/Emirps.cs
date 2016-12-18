using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Codewars.Emirps
{
    public class Emirps
    {

        public static long[] FindEmirp(long n)
        {
            var result = ComputeEmirpsUpTo(n).Where(i => i < n);
            return new long[]
            {
                result.Count(),
                result.Max(),
                result.Sum()
            };
        }

        private static long largestKnownEmirp = -1;
        private static HashSet<long> memoizedEmirps = new HashSet<long>();

        public static HashSet<long> ComputeEmirpsUpTo(long n)
        {
            var primes = GetPrimesThatMayBeEmirpsUpTo(n);
            var emirps = memoizedEmirps;
            var largestKnownEmirpBeforeFor = largestKnownEmirp;

            foreach(var p in primes)
            {
                // avoid recomputing reverse and emirps
                if (p>largestKnownEmirpBeforeFor && !emirps.Contains(p)) {
                    long r = Reverse(p);

                    // a emirp is a non-palindrome prime with a prime reverse
                    if (p!=r && primes.Contains(r))
                    {
                        emirps.Add(p);
                        emirps.Add(r);

                        // r is larger then p, otherwise we would have added it already when we found p
                        largestKnownEmirp = Math.Max(largestKnownEmirp, r);
                    }
                }
            }
            return emirps;
        }

        private static HashSet<long> GetPrimesThatMayBeEmirpsUpTo(long n)
        {
            return SieveOfErasthostenes(GetMaxEmirpLessThan(n));
        }

        private static long largestKnownPrime = 7;
        private static HashSet<long> memoizedPrimes = new HashSet<long>();

        private static HashSet<long> SieveOfErasthostenes(long n)
        {
            // naive implementation of sieve or eratosthenes
            var primes = memoizedPrimes;
            primes.Add(2);
            primes.Add(3);
            primes.Add(5);
            for (long i = largestKnownPrime; i < n; ++i)
            {
                if (i % 2 != 0 && i % 3 != 0 && i % 5 != 0)
                {
                    primes.Add(i);
                }
            }
            for (long i = 8; i < n; ++i)
            {
                if (primes.Contains(i))
                {
                    primes.RemoveWhere(e => e != i && e % i == 0);
                    largestKnownPrime = Math.Max(largestKnownPrime, n);
                }
            }
            return primes;
        }

        // returns the max number obtained by reversing numbers up to n
        // naive implementation, generate a 99...99 with the same number of digits
        // as n
        private static long GetMaxEmirpLessThan(long n)
        {
            var r = 0;
            while(n>0)
            {
                r = r * 10 + 9;
                n /= 10;
            }
            return r;
        }

        private static long Reverse(long l)
        {
            var r = 0L;
            while(l>0)
            {
                r = r * 10 + l % 10;
                l /= 10;
            }
            return r;
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
        public static void EmirpsTest()
        {
            Console.WriteLine("Basic Tests FindEmirp");
            long[] l = new long[] { 50, 100, 200, 500, 750, 1000 };
            long[][] r = new long[][] { new long[] {4, 37, 98}, new long[] {8, 97, 418}, new long[] {15, 199, 1489}, new long[] {20, 389, 3232},
            new long[] {25, 743, 6857}, new long[] {36, 991, 16788} };
            tests(l, r);
        }
    }

}
