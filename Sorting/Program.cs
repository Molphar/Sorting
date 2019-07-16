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

        public static void RecursiveBubble(List<int> arr, int size)
        {
            if (size == 0)
                return;

            for (int j = 0; j < size - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    int temp = arr[j + 1];
                    arr[j] += arr[j + 1];
                    arr[j + 1] = arr[j] - arr[j + 1];
                    arr[j] -= arr[j + 1];
                }
            }
            RecursiveBubble(arr, size - 1);
        }

        public static void FillCollection(List<int> list, int size)
        {
            Random rand = new Random();

            for (int i = 0; i < size; i++)
                list.Add(rand.Next(0, size + 1));
        }

        public static void Print(IEnumerable l)
        {
            foreach (var o in l)
                Console.Write($"{o} ");
            Console.WriteLine();
        }

        public static void CalculateTime(Action SortMeth)
        {
            Stopwatch sw = new Stopwatch();

            sw.Start();
            SortMeth();
            sw.Stop();
            Console.WriteLine($"Time taken: {sw.Elapsed.TotalMilliseconds}ms");
        }

        static void Main(string[] args)
        {
            List<int> intList = new List<int>();

            FillCollection(intList, 100);

            List<int> intListRec = new List<int>(intList);

            Print(intList);

            CalculateTime(() => Bubble(intList));

            Print(intList);

            Print(intListRec);

            CalculateTime(() => RecursiveBubble(intListRec, intListRec.Count));

            Print(intListRec);

            Console.ReadKey();
        }
    }
}
