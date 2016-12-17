using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Codewars.RotateArray
{
    public class Kata
    {
        public static object[] Rotate(object[] array, int n)
        {
            var rotatedArray = new object[array.Length];
            for(int i=0; i < array.Length; i++)
            {
                rotatedArray[positiveMod(i + n, array.Length)] = array[i];
            }
            return rotatedArray;
        }

        private static int positiveMod(int n, int x)
        {
            return ((n % x) + x) % x;
        }
    }

    [TestFixture]
    public class KataTest
    {
        [Test]
        public void BasicTests()
        {
            var data = new object[] { 1, 2, 3, 4, 5 };

            Assert.AreEqual(new object[] { 5, 1, 2, 3, 4 }, Kata.Rotate(data, 1));
            Assert.AreEqual(new object[] { 4, 5, 1, 2, 3 }, Kata.Rotate(data, 2));
            Assert.AreEqual(new object[] { 3, 4, 5, 1, 2 }, Kata.Rotate(data, 3));
            Assert.AreEqual(new object[] { 2, 3, 4, 5, 1 }, Kata.Rotate(data, 4));
            Assert.AreEqual(new object[] { 1, 2, 3, 4, 5 }, Kata.Rotate(data, 5));

            Assert.AreEqual(new object[] { 1, 2, 3, 4, 5 }, Kata.Rotate(data, 0));

            Assert.AreEqual(new object[] { 2, 3, 4, 5, 1 }, Kata.Rotate(data, -1));
            Assert.AreEqual(new object[] { 3, 4, 5, 1, 2 }, Kata.Rotate(data, -2));
            Assert.AreEqual(new object[] { 4, 5, 1, 2, 3 }, Kata.Rotate(data, -3));
            Assert.AreEqual(new object[] { 5, 1, 2, 3, 4 }, Kata.Rotate(data, -4));
            Assert.AreEqual(new object[] { 1, 2, 3, 4, 5 }, Kata.Rotate(data, -5));

            Assert.AreEqual(new object[] { 'c', 'a', 'b' }, Kata.Rotate(new object[] { 'a', 'b', 'c' }, 1));
            Assert.AreEqual(new object[] { 3.0, 1.0, 2.0 }, Kata.Rotate(new object[] { 1.0, 2.0, 3.0 }, 1));
            Assert.AreEqual(new object[] { false, true, true }, Kata.Rotate(new object[] { true, true, false }, 1));

            Assert.AreEqual(new object[] { 4, 5, 1, 2, 3 }, Kata.Rotate(data, 7));
            Assert.AreEqual(new object[] { 5, 1, 2, 3, 4 }, Kata.Rotate(data, 11));
            Assert.AreEqual(new object[] { 3, 4, 5, 1, 2 }, Kata.Rotate(data, 12478));
        }
    }
}
