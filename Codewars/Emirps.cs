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
            var count = 0L;
            var max = 0L;
            var sum = 0L;

            var nonPrimes = new HashSet<long>();

            for(int i=2;i<n;i++)
            {
                // ok, i is prime
                if (!nonPrimes.Contains(i))
                {
                    // is it a emirp?
                    var r = Reverse(i);
                    if (r!=i && r%2!=0) // not a palindrome and reverse not even
                                        // so, we have a chance
                    {
                        var maxDivisor = Math.Sqrt(r);
                        var isPrime = true;
                        for(int k=3;k<=maxDivisor;k+=2)
                        {
                            if (r%k==0)
                            {
                                nonPrimes.Add(r); // we found a non prime
                                isPrime = false;
                                break;
                            }
                        }
                        if (isPrime)
                        {
                            // is is an empirp!!
                            sum += i;
                            count += 1;
                            max = Math.Max(max, i);
                        }
                    }
                    // j = i*2,3,... = multiples of i, they are not prime
                    for(int j=i*2;j<n;j+=i)
                    {
                        // we found out a non prime, it is a multiple of a prime
                        if (!nonPrimes.Contains(j))
                        {
                            nonPrimes.Add(j);
                        }
                    }
                }
                // remove smaller numbers from the set, to save memory
                nonPrimes.Remove(i);
            }

            return new long[]
            {
                count,
                max,
                sum
            };
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
        private static void testing(long n, string actual, string expected)
        {
            Assert.AreEqual(expected, actual, "n="+n);
        }
        public static void tests(long[] list1, long[][] results)
        {
            for (int i = 0; i < list1.Length; i++)
                testing(list1[i], EmirpsTests.Array2String(Emirps.FindEmirp(list1[i])), EmirpsTests.Array2String(results[i]));
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
