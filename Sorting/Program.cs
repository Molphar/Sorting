using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace Sorting
{
    class Program
    {

        public static void Bubble(List<int> arr)
        {
            for (int i = 0; i < arr.Count - 1; i++)
                for (int j = 0; j < arr.Count - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j + 1];
                        arr[j] += arr[j + 1];
                        arr[j + 1] = arr[j] - arr[j + 1];
                        arr[j] -= arr[j + 1];
                    }
                }
        }

        public static void FillCollection(List<int> list, int size)
        {
            Random rand = new Random();

            for (int i = 0; i < size; i++)
                list.Add(rand.Next(0, size + 1));
        }

        public static void Print(IEnumerable l)
        {
            foreach (int o in l)
                Console.Write($"{o} ");
        }

        static void Main(string[] args)
        {
            List<int> intList = new List<int>();

            FillCollection(intList, 100);

            Print(intList);

            Stopwatch sw = new Stopwatch();

            sw.Start();
            Bubble(intList);
            sw.Stop();

            Console.WriteLine($"\nTime taken: {sw.Elapsed.TotalMilliseconds}ms");

            Print(intList);

            Console.ReadKey();
        }
    }
}
