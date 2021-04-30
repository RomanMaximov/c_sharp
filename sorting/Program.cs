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
            List<int> v1 = new List<int>();
            List<int> v2 = new List<int>();
            
            int step = 500;

            var rand = new Random();
            for (int i = 0; i < 100000; ++i)
            {
                v1.Add(rand.Next(-5000, 5000));
                v2.Add(rand.Next(-5000, 5000));
            }

            Sort sort = new Sort();

            Console.WriteLine("v1: ");
            sort.arrPrint(ref v1, step);
            Console.WriteLine("\n");

            Console.WriteLine("v2: ");
            sort.arrPrint(ref v2, step);
            Console.WriteLine();

            //Console.WriteLine("===========================================================");

            sort.BucketSort(ref v1);
            
            sort.QuickSort(ref v2, 0, v2.Count());

            Console.WriteLine("===========================================================");
            Console.WriteLine();

            Console.WriteLine("v1: ");
            sort.arrPrint(ref v1, step);
            Console.WriteLine("\n");

            Console.WriteLine("v2: ");
            sort.arrPrint(ref v2, step);
            Console.WriteLine();
        }
    }
}
