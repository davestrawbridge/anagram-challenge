using System;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace anagram
{
    class Program
    {
        static void Main(string[] args)
        {
            var sw = new Stopwatch();

            sw.Start();
            var list = File.ReadAllLines("words.txt");

            sw.Stop();
            Console.WriteLine($"time to read = {(double) sw.ElapsedMilliseconds / 1000} ");

            Console.WriteLine($"Number of words: {list.Count()}");

            sw.Reset();
            sw.Start();
            var dict = new Dictionary<string, List<string>>();

            List<string> largestAndLongest = null;

            foreach (var word in list)
            {
                var a = word.ToCharArray();
                Array.Sort(a);
                var key = new string(a);

                List<string> set;
                if (!dict.TryGetValue(key, out set))
                {
                    set = new List<string>();
                    dict[key] = set;
                }
                set.Add(word);

                if (largestAndLongest == null || (set.Count > largestAndLongest.Count) || (set.Count == largestAndLongest.Count && word.Length > largestAndLongest.First().Length))
                    largestAndLongest = set;
            }
            sw.Stop();
            Console.WriteLine($"time to sort = {(double)sw.ElapsedMilliseconds / 1000} ");

            Console.WriteLine("Largest set with longest word:");
            foreach (var word in largestAndLongest)
                Console.WriteLine(word);

            //var anagramsets = dict.Where(x => x.Value.Count > 1).ToArray();
            //var longestfirst = anagramsets.OrderByDescending(x => x.Value.Count);

            Console.ReadLine();
        }
    }
}