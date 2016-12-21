using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codewars
{
    public class IntPart
    {
        public static string Part(long n)
        {
            var prod = ComputeProd(n);
            var stats = ComputeStats(prod.ToList());
            return string.Format("Range: {0} Average: {1:F2} Median: {2:F2}", stats.Item1, stats.Item2, stats.Item3);
        }

        private static Tuple<long, float, float> ComputeStats(List<long> prod)
        {
            prod.Sort();
            var range = prod.Last() - prod.First();
            var mean = (float)prod.Average();
            var median = prod.Count % 2 == 0 ?
                            (prod[prod.Count / 2] + prod[prod.Count / 2 - 1]) / 2.0f
                            : (float)prod[prod.Count / 2];
            return Tuple.Create(range, mean, median);
        }

        private static HashSet<long> ComputeProd(long n)
        {
            var result = new HashSet<long>();
            for(long i=1;i<n;++i)
            {
                // n = i + (n-i)
                // prod n = prod i X prod i
                var prodLeft = ComputeProd(i);
                var prodRight = ComputeProd(n - i);
                foreach(var left in prodLeft)
                {
                    foreach(var right in prodRight)
                    {
                        result.Add(left * right);
                    }
                }
            }
            result.Add(n); // for n+0
            return result;
        }
    }

    [TestFixture]
    public class IntPartTests
    {

        [Test]
        public void Test1()
        {
            Console.WriteLine("****** Basic Tests Small Numbers");
            Assert.AreEqual("Range: 5 Average: 3.50 Median: 3.50", IntPart.Part(5));
            Assert.AreEqual("Range: 1 Average: 1.50 Median: 1.50", IntPart.Part(2));
            Assert.AreEqual("Range: 2 Average: 2.00 Median: 2.00", IntPart.Part(3));
            Assert.AreEqual("Range: 3 Average: 2.50 Median: 2.50", IntPart.Part(4));
        }
    }

}
