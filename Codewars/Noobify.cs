using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Codewars.Noobify
{
    public static class Kata
    {

        private static string ReplaceIgnoreCase(this string s, string pattern, string replacement)
            => Regex.Replace(s, pattern, replacement, RegexOptions.IgnoreCase);

        private static string Replace2(this string s)
            => s.ReplaceIgnoreCase("too", "2").ReplaceIgnoreCase("to", "2");

        private static string Replace4(this string s)
            => s.ReplaceIgnoreCase("fore", "4").ReplaceIgnoreCase("for", "4");

        private static string Replace00(this string s)
            => s.ReplaceIgnoreCase("oo", "00");

        private static string ReplaceWords(this string s)
            => s.Replace("know", "no")
            .Replace("have", "haz")
            .Replace("really", "rly")
            .Replace("people", "ppl")
            .Replace("please", "plz")
            .ReplaceIgnoreCase("you", "u") // spec not clear
            .ReplaceIgnoreCase("are", "r")
            .ReplaceIgnoreCase("be", "b");

        private static string ReplaceZ(this string s)
            => s.Replace("s", "z").Replace("S", "Z");

        private static string AddLOL(this string s)
            => (char.ToLower(s[0]) == 'w' ? "LOL " : "") + s;

        private static string AddOMG(this string s)
            // punctuaction doesn't count, the spec is not clear here
            => (s.Replace("!", "").Replace("?", "").Length >= 32 ?
                    s.StartsWith("LOL") ?
                        "LOL OMG" + s.Substring(3)
                        : "OMG " + s
                    : s);

        private static string MakeEvenWordsAllCaps(this string s)
        {
            var result = new List<string>();
            var even = false;

            foreach (var word in s.Split(new char[] { ' ' }))
            {
                if (even) result.Add(word.ToUpper());
                else result.Add(word);
                even = !even;
            }
            return string.Join(" ", result);
        }
        private static string MakeAllWordsAllCaps(this string s)
            => (char.ToLower(s[0]) == 'h') ? s.ToUpper() : s;

        private static string RemovePunctuation(this string s)
            => s.Replace(".", "").Replace(",", "").Replace("'", "");

        private static string ReplaceQuestionMarks(this string s)
        {
            var wordCount = s.Split(new char[] { ' ' }).Count();
            var questionMarks = new string(Enumerable.Repeat('?', wordCount).ToArray());
            return s.Replace("?", questionMarks);
        }

        private static string ReplaceExclamation(this string s)
        {
            var wordCount = s.Split(new char[] { ' ' }).Count();
            var exclamations = Enumerable.Repeat('!', wordCount).ToArray();
            for (int i = 0; i < exclamations.Length; ++i)
            {
                if (i % 2 == 1) exclamations[i] = '1';
            }
            return s.Replace("!", new string(exclamations));
        }

        public static string N00bify(string text)
        {
            return text
                .Replace2()
                .Replace4()
                .Replace00()
                .ReplaceWords()
                .ReplaceZ()
                .MakeAllWordsAllCaps()
                .RemovePunctuation()
                .AddLOL()
                .AddOMG()
                .MakeEvenWordsAllCaps()
                .ReplaceQuestionMarks()
                .ReplaceExclamation();
        }
    }

    [TestFixture]
    public static class CheckNoobism
    {
        [Test]
        public static void HowRU()
        {
            Assert.AreEqual("HI HOW R U 2DAY?????", Kata.N00bify("Hi, how are you today?"));
        }

        [Test]
        public static void LongSentence()
        {
            Assert.AreEqual("OMG I think IT would B nice IF we COULD all GET along",
               Kata.N00bify("I think it would be nice if we could all get along."));
        }

        [Test]
        public static void CommasMatter()
        {
            Assert.AreEqual("Letz EAT Grandma!1!",
               Kata.N00bify("Let's eat, Grandma!"));
        }
    }
}
