using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codewars.ProdFib
{
    public class ProdFib
    {
        public static ulong[] productFib(ulong prod)
        {
            ulong fn = 1;
            ulong fn1 = 1;

            while(true)
            {
                if (fn*fn1 > prod)
                {
                    return new ulong[] { fn, fn1, 0 };
                } else if (fn*fn1 == prod)
                {
                    return new ulong[] { fn, fn1, 1 };
                } else
                {
                    ulong fn2 = fn + fn1;
                    fn = fn1;
                    fn1 = fn2;
                }
            }
        }
    }

    [TestFixture]
    public class ProdFibTests
    {

        [Test]
        public void Test1()
        {
            ulong[] r = new ulong[] { 55, 89, 1 };
            Assert.AreEqual(r, ProdFib.productFib(4895));
        }
    }
}
