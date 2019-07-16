using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Sorting
{

    public static class Extenstions
    {

        public static void Swap<T>(this IList<T> list, int left, int right)
        {
            T temp = list[left];
            list[left] = list[right];
            list[right] = temp;
        }
    }

    class Program
    {
        #region BubbleSort
        public static void Bubble(List<int> arr)
        {
            for (int i = 0; i < arr.Count - 1; i++)
                for (int j = 0; j < arr.Count - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        arr.Swap(j, j + 1);
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
                    arr.Swap(j, j + 1);
                }
            }
            RecursiveBubble(arr, size - 1);
        }
        #endregion

        #region QuickSort
        public static void Quick(List<int> list, int leftEnd, int rightEnd)
        {
            if (leftEnd < rightEnd)
            {
                int piv = PartiotionQuick(list, leftEnd, rightEnd);

                Quick(list, leftEnd, piv - 1);
                Quick(list, piv + 1, rightEnd);
            }
        }

        public static int PartiotionQuick(List<int> list, int leftEnd, int rightEnd)
        {
            //can be set as you want
            int pivot = list[rightEnd];

            int i = leftEnd;

            for (int j = leftEnd; j < rightEnd ; j++)
            {
                if (list[j] < pivot)
                {
                    list.Swap(i++, j);
                }

            }
            list.Swap(i, rightEnd);

            return i;
        }
        #endregion

        #region Help
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
        #endregion

        //https://stackoverflow.com/questions/2082615/pass-method-as-parameter-using-c-sharp
        public static void CalculateTime(Action SortMeth)
        {
            Stopwatch sw = new Stopwatch();

            sw.Start();
            SortMeth();
            sw.Stop();
            Console.WriteLine($"Time taken: {sw.Elapsed.TotalMilliseconds}ms");
        }

        #region MergeSort
        public static void Merge(List<int> list, int leftEnd, int rightEnd)
        {
            if(leftEnd < rightEnd)
            {
                int pivot = leftEnd + (rightEnd - rightEnd) / 2;
                Merge(list, leftEnd, pivot);
                Merge(list, pivot + 1, rightEnd);

                Combine(list, leftEnd, rightEnd, pivot);
            }
        }

        public static void Combine(List<int> list,int leftEnd,int rightEnd,int pivot)
        {
            int i, j, k = 0;
            int n1 = pivot - leftEnd + 1;
            int n2 = rightEnd - pivot;

            List<int> L = new List<int>();
            List<int> R = new List<int>();

            for (i = 0; i < n1; i++)
                L.Add(list[leftEnd + i]);
            for (j = 0; j < n2; j++)
                R.Add(list[pivot + 1 + j]);
            i = 0;
            j = 0;
            k = leftEnd;
            while( i < n1 && j < n2)
            {
                if(L[i] < R[j])
                {
                    list[k++] = L[i++];
                }
                else
                {
                    list[k++] = R[j++];
                }
            }

            while (i < n1)
            {
                list[k++] = L[i++];
            }

            while (j < n2)
            {
                list[k++] = R[j++];
            }


        }
        #endregion

        static void Main(string[] args)
        {

            List<int> intList = new List<int>();

            FillCollection(intList, 100);

            List<int> intListComparer = new List<int>(intList);

            Print(intList);

            Quick(intList, 0, intList.Count - 1);
            Print(intList);

            CalculateTime(() => Merge(intList, 0, intList.Count - 1));

            Console.ReadKey();
        }
    }
}
