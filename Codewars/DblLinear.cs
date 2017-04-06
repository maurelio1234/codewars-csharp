using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codewars.DblLinear
{
    public class DoubleLinear 
    {
        
        public static int DblLinear (int n) 
        {
            var elements = new List<int>();
            var processedElements = 0;

            elements.Add(1);

            do
            {
                if (processedElements >= n)
                {
                    return elements[n];
                } else
                {
                    var x = elements[processedElements];
                    var y = 2 * x + 1;
                    var z = 3 * x + 1;
                    AddElement(elements, y);
                    AddElement(elements, z);
                    processedElements++;
                }
            } while (true);
        }

        private static void AddElement(List<int> elements, int y)
        {
            var index = elements.BinarySearch(y);
            if (index<0)
            {
                elements.Insert(~index, y);
            }
        }
    }

    [TestFixture]
    public static class DoubleLinearTests 
    {

        private static void testing(int actual, int expected) 
        {
            Assert.AreEqual(expected, actual);
        }

    [Test]
        public static void test1() 
        {
            Console.WriteLine("Fixed Tests DblLinear");
            testing(DoubleLinear.DblLinear(10), 22);
            testing(DoubleLinear.DblLinear(20), 57);
            testing(DoubleLinear.DblLinear(30), 91);
            testing(DoubleLinear.DblLinear(50), 175);
        }  
        
    }
}
