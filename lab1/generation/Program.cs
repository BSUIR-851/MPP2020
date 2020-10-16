using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace generation
{
    internal class Program
    {
        public static List<char> GetSymbols()
        {
            var list = new List<char>();
            for (char c = '0'; c <= '9'; c++) 
            {
                list.Add(c);
            }
            
            for (char c = 'A'; c <= 'Z'; c++) 
            {
                list.Add(c);
            }
            
            for (char c = 'a'; c <= 'z'; c++) 
            {
                list.Add(c);
            }
            list.Add('\n');
            return list;
        }
        
        public static void Main(string[] args)
        {
            var symbols = GetSymbols();
            var symbolsLen = symbols.Count;
            int amount;
            Console.Write("Enter the amount of bytes to generate: ");
            try
            {
                amount = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception e) when (e is FormatException || e is OverflowException)
            {
                amount = 1073741824;
            }

            var stopWatch = new Stopwatch();
            stopWatch.Start();
            using (var writer = new StreamWriter("C:\\Study\\SPP\\lab1\\generation\\bin\\Debug\\test.txt", 
                false, Encoding.Unicode))
            {
                var wrote = 0;
                var random = new Random();
            
                while (wrote < amount)
                {
                    writer.Write(symbols[random.Next(symbolsLen)]);
                    wrote++;
                }
            }
            stopWatch.Stop();
            var ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);
            
        }
    }
}