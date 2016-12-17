using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codewars.IntTriangles
{
    public class IntTriangles
    {
        // Integer triangles with 120° angle are such that a² + ab + b² = c²
        // http://www.had2know.com/academics/integer-triangles-120-degree-angle.html
        public static int GiveTriang(int per)
        {
            var count = 0;
            for(var a = 1; a < per; a++)
            {
                for(var b = a+1; a+b < per; b++)
                {
                    var left = a * a + a * b + b * b;
                    var c = (int)Math.Sqrt(left);
                    if (left == c*c && c > b && a+b+c <= per)
                    {
                        count++;
                    }
                }
            }
            return count;
        }
    }

    [TestFixture]
    public static class IntTrianglesTests
    {
        private static void testing(int actual, int expected)
        {
            Assert.AreEqual(expected, actual);
        }
        public static void tests(int[] list1, int[] results)
        {
            for (int i = 0; i < list1.Length; i++)
                testing(IntTriangles.GiveTriang(list1[i]), results[i]);
            return;
        }
        [Test]
        public static void test1()
        {
            Console.WriteLine("Basic Tests");
            int[] list1 = new int[] { 5, 15, 30, 50, 80, 90, 100, 150, 180, 190 };
            int[] results = new int[] { 0, 1, 3, 5, 11, 13, 14, 25, 32, 35 };
            tests(list1, results);
        }
    }
}
