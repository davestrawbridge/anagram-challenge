using System;
using System.Diagnostics;
using System.IO;

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

            Console.WriteLine($"time = {(double) sw.ElapsedMilliseconds / 1000} ");
        }
    }
}