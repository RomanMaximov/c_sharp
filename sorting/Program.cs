using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            int step = 500;
            int[] temp = new int[100000];

            var rand = new Random();
            for (int i = 0; i < 100000; ++i)
            {
                temp[i] = rand.Next(-5000, 5000);
            }

            List<int> v1 = new List<int>(temp);
            List<int> v2 = new List<int>(temp);
            List<int> v3 = new List<int>(temp);


            Sort sort = new Sort();

            Console.WriteLine("v1: ");
            sort.arrPrint(ref v1, step);
            Console.WriteLine("\n");

            Console.WriteLine("v2: ");
            sort.arrPrint(ref v2, step);
            Console.WriteLine("\n");

            Console.WriteLine("v3: ");
            sort.arrPrint(ref v3, step);
            Console.WriteLine("\n");
            Console.WriteLine("===========================================================");

            sort.BucketSort(ref v1);

            // QuickSort runtime calculation
            var startTime = System.Diagnostics.Stopwatch.StartNew();

            sort.QuickSort(ref v2, 0, v2.Count());

            startTime.Stop();
            var resultTime = startTime.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:000}",
                resultTime.Hours,
                resultTime.Minutes,
                resultTime.Seconds,
                resultTime.Milliseconds);
            Console.WriteLine("QuickSort runtime = " + elapsedTime);
            Console.WriteLine();

            sort.SortX(ref v3);

            Console.WriteLine("===========================================================");
            Console.WriteLine();

            Console.WriteLine("v1: ");
            sort.arrPrint(ref v1, step);
            Console.WriteLine("\n");

            Console.WriteLine("v2: ");
            sort.arrPrint(ref v2, step);
            Console.WriteLine("\n");

            Console.WriteLine("v3: ");
            sort.arrPrint(ref v3, step);
            Console.WriteLine();
        }
    }
}
