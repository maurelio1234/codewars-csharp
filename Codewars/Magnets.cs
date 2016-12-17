using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codewars.Magnets
{
    public class Magnets
    {
        private static double v(int k, int n)
        {
            return 1 / (k * Math.Pow(n+1, 2*k));
        }

        public static double Doubles(int maxk, int maxn)
        {
            double sum = 0;
            for(int k=1;k<=maxk;k++)
            {
                for(int n=1;n<=maxn;++n)
                {
                    sum += v(k, n);
                }
            }
            return sum;
        }
    }

    [TestFixture]
    public static class MagnetsTests
    {

        private static Random rnd = new Random();
        private static void assertFuzzyEquals(double act, double exp)
        {
            bool inrange = Math.Abs(act - exp) <= 1e-6;
            if (inrange == false)
            {
                string specifier = "#0.000000";
                Console.WriteLine(
                    "At 1e-6: Expected must be " + exp.ToString(specifier) + ", but got " + act.ToString(specifier));
            }
            Assert.AreEqual(true, inrange);
        }

        [Test]
        public static void test1()
        {
            Console.WriteLine("Fixed Tests: Doubles");
            assertFuzzyEquals(Magnets.Doubles(1, 10), 0.5580321939764581); // 0.5580321939764581
            assertFuzzyEquals(Magnets.Doubles(10, 1000), 0.6921486500921933); // 0.6921486500921933
            assertFuzzyEquals(Magnets.Doubles(10, 10000), 0.6930471674194457); // 0.6930471674194457
            assertFuzzyEquals(Magnets.Doubles(20, 10000), 0.6930471955575918); // 0.6930471955575918
        }
    }
}
