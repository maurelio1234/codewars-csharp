using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Codewars.Mix
{
    public class Mixing
    {
        public static string Mix(string s1, string s2)
        {
            var s1Counts = CountLetters(s1);
            var s2Counts = CountLetters(s2);

            var comparisson = CompareCounts(s1Counts, s2Counts);

            var comparissonStr = comparisson.Select(t => t.Item1 + ":" + t.Item2).ToList();
            comparissonStr.Sort(CompareStr);

            return string.Join("/", comparissonStr);
        }

        private static int CompareStr(string x, string y)
        {
            if (x.Length != y.Length) return -x.Length.CompareTo(y.Length);
            else if (x[0] != y[0])
            {
                // the right order is 1, 2, =;
                // so I replace = by 3.
                var x0 = x[0];
                var y0 = y[0];
                if (x0 == '=') x0 = '3';
                if (y0 == '=') y0 = '3';
                return x0.CompareTo(y0);
            }
            else return x.CompareTo(y);
        }

        // lists are ordered by char
        private static IList<Tuple<char, string>> CompareCounts(IEnumerable<Tuple<char, int>> s1Counts, IEnumerable<Tuple<char, int>> s2Counts)
        {
            var compare = new List<Tuple<char, string>>();

            var s1Enumerable = s1Counts.GetEnumerator();
            var s2Enumerable = s2Counts.GetEnumerator();

            var s1over = !s1Enumerable.MoveNext();
            var s2over = !s2Enumerable.MoveNext();

            while(!s1over || !s2over)
            {
                if (!s1over && !s2over)
                {
                    if (s1Enumerable.Current.Item1 == s2Enumerable.Current.Item1)
                    {
                        if (s1Enumerable.Current.Item2 == s2Enumerable.Current.Item2)
                        {
                            compare.Add(Tuple.Create('=', 
                                MultiplyChar(s1Enumerable.Current.Item1, 
                                s1Enumerable.Current.Item2)));
                        }
                        else if (s1Enumerable.Current.Item2 > s2Enumerable.Current.Item2)
                        {
                            compare.Add(Tuple.Create('1', 
                                MultiplyChar(s1Enumerable.Current.Item1, 
                                s1Enumerable.Current.Item2)));
                        } else
                        {
                            compare.Add(Tuple.Create('2', 
                                MultiplyChar(s2Enumerable.Current.Item1, 
                                s2Enumerable.Current.Item2)));
                        }

                        s1over = !s1Enumerable.MoveNext();
                        s2over = !s2Enumerable.MoveNext();
                    }
                    else if (s1Enumerable.Current.Item1 < s2Enumerable.Current.Item1)
                    {
                        compare.Add(Tuple.Create('1', 
                            MultiplyChar(s1Enumerable.Current.Item1, 
                            s1Enumerable.Current.Item2)));
                        s1over = !s1Enumerable.MoveNext();
                    }
                    else
                    {
                        compare.Add(Tuple.Create('2', 
                            MultiplyChar(s2Enumerable.Current.Item1, 
                            s2Enumerable.Current.Item2)));
                        s2over = !s2Enumerable.MoveNext();
                    }
                }
                else if (!s1over)
                {
                    compare.Add(Tuple.Create('1', 
                        MultiplyChar(s1Enumerable.Current.Item1, 
                        s1Enumerable.Current.Item2)));
                    s1over = !s1Enumerable.MoveNext();
                }
                else if (!s2over)
                {
                    compare.Add(Tuple.Create('2', 
                        MultiplyChar(s2Enumerable.Current.Item1, 
                        s2Enumerable.Current.Item2)));
                    s2over = !s2Enumerable.MoveNext();
                }
            }

            return compare;
        }

        private static IEnumerable<Tuple<char, int>> CountLetters(string s)
        {
            for(char c='a';c<='z';++c)
            {
                var count = s.Count(p => p == c);
                if (count > 1)
                {
                    yield return Tuple.Create(c, count);
                }
            }
        }

        private static string MultiplyChar(char c, int t)
        {
            var r = "";
            while (t-- > 0) r += c;
            return r;
        }
    }

    [TestFixture]
    public static class MixingTests
    {

        [Test]
        public static void test1()
        {
            Assert.AreEqual("2:eeeee/2:yy/=:hh/=:rr", Mixing.Mix("Are they here", "yes, they are here"));
            Assert.AreEqual("1:ooo/1:uuu/2:sss/=:nnn/1:ii/2:aa/2:dd/2:ee/=:gg",
                    Mixing.Mix("looping is fun but dangerous", "less dangerous than coding"));
            Assert.AreEqual("1:aaa/1:nnn/1:gg/2:ee/2:ff/2:ii/2:oo/2:rr/2:ss/2:tt",
                    Mixing.Mix(" In many languages", " there's a pair of functions"));
            Assert.AreEqual("1:ee/1:ll/1:oo", Mixing.Mix("Lords of the Fallen", "gamekult"));
            Assert.AreEqual("", Mixing.Mix("codewars", "codewars"));
            Assert.AreEqual("1:nnnnn/1:ooooo/1:tttt/1:eee/1:gg/1:ii/1:mm/=:rr",
                    Mixing.Mix("A generation must confront the looming ", "codewarrs"));
        }
    }
}
