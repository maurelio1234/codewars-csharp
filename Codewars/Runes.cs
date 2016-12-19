using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Codewars.Runes
{
    public class Runes
    {
        public static int solveExpression(string expression)
        {
            int missingDigit = -1;

            foreach (var digit in GetPossibleDigits(expression))
            {
                if (TryDigit(digit, expression))
                {
                    missingDigit = digit;
                    break;
                }
            }
            return missingDigit;
        }

        private static IEnumerable<int> GetPossibleDigits(string expression)
        {
            for (int d = 0; d <= 9; ++d)
            {
                if (!expression.Contains((char)('0'+d)))
                {
                    yield return d;
                }
            }
        }

        private static bool TryDigit(int digit, string expression)
        {
            return ValidateExpresssion(expression.Replace('?', (char)('0' + digit)));
        }

        private static bool ValidateExpresssion(string v)
        {
            var pos = 0;
            var a = ReadNumber(v, ref pos);
            var op = v[pos++];
            var b = ReadNumber(v, ref pos);
            pos++; // skip the equality sign =
            var r = ReadNumber(v, ref pos);

            if (!a.HasValue || !b.HasValue || !r.HasValue) return false;

            switch(op)
            {
                case '+': return r == a + b;
                case '*': return r == a * b;
                case '-': return r == a - b;
            }
            return false;
        }

        private static int? ReadNumber(string v, ref int pos)
        {
            var minus = v[pos] == '-' ? -1 : 1;
            if (minus==-1) pos++;
            var start = pos;
            var length = 0;
            while (pos < v.Length && Char.IsDigit(v[pos]))
            {
                pos++;
                length++;
            }
            var numberStr = v.Substring(start, length);
            var number = int.Parse(numberStr);
            if (number == 0 && numberStr.Length != 1) return null;
            return minus * number;
        }
    }

    [TestFixture]
    public class RunesTest
    {
        [Test]
        public void testSample()
        {
            Assert.AreEqual(0, Runes.solveExpression("-5?*?=?"), "Answer for expression '-5?*-1=5?' ");
            Assert.AreEqual(2, Runes.solveExpression("1+1=?"), "Answer for expression '1+1=?' ");
            Assert.AreEqual(6, Runes.solveExpression("123*45?=5?088"), "Answer for expression '123*45?=5?088' ");
            Assert.AreEqual(0, Runes.solveExpression("-5?*-1=5?"), "Answer for expression '-5?*-1=5?' ");
            Assert.AreEqual(-1, Runes.solveExpression("19--45=5?"), "Answer for expression '19--45=5?' ");
            Assert.AreEqual(5, Runes.solveExpression("??*??=302?"), "Answer for expression '??*??=302?' ");
            Assert.AreEqual(2, Runes.solveExpression("?*11=??"), "Answer for expression '?*11=??' ");
        }
    }
}
