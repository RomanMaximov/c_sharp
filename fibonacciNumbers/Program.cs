using System;
using System.Collections.Generic;

namespace fibonacciNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var fibonacciNumbers = new List<int> { 1, 1 };

            fibonacciNumbers.Add(fibonacciNumbers[fibonacciNumbers.Count - 1] + fibonacciNumbers[fibonacciNumbers.Count - 2]);

            /*foreach(var item in fibonacciNumbers)
                Console.WriteLine(item);*/
            for (int i = 4; fibonacciNumbers.Count < 20; i++)
            {
                fibonacciNumbers.Add(fibonacciNumbers[fibonacciNumbers.Count - 1] + fibonacciNumbers[fibonacciNumbers.Count - 2]);
            }

            for (int i = 0; i < fibonacciNumbers.Count; i++)
            {
                Console.WriteLine($"[{i+1}] = {fibonacciNumbers[i]}");
            }
        }
    }
}
