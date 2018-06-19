using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba3
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int count = int.Parse(Console.ReadLine());
            int[] list1 = new int[count];
            int[] list2 = new int[count];
            int[] list3 = new int[count];
            int[] list4 = new int[count];
            int s;
            for (int i = 0; i < count; i++)
            {
                s = int.Parse(Console.ReadLine());
                list1[i] = s;
                list2[i] = s;
                list3[i] = s;
                list4[i] = s;
                Console.WriteLine(i + " " + s);
            }
            Console.WriteLine("\n");
            Stopwatch t1 = Stopwatch.StartNew();
            Quicksort(list1, 0, count-1);
            t1.Stop();
            Stopwatch t2 = Stopwatch.StartNew();
            InsertionSort(list2);
            t2.Stop();
            Stopwatch t3 = Stopwatch.StartNew();
            list3 = MergeSort(list3);
            t3.Stop();
            Stopwatch t4 = Stopwatch.StartNew();
            BucketSort(list4);
            t4.Stop();
            Console.WriteLine("QuickSort time: " + t1.Elapsed);
            writeArray(list1);
            Console.WriteLine("InsertionSort time: " + t2.Elapsed);
            writeArray(list2);
            Console.WriteLine("MergeSort time: " + t3.Elapsed);
            writeArray(list3);
            Console.WriteLine("BucketSort time: " + t4.Elapsed);
            writeArray(list4);
            Console.ReadLine();

        }
        static void writeArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i] + " ");
            }
        }
        static void InsertionSort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int cur = array[i];
                int j = i;
                while (j > 0 && cur < array[j -1])
                {
                    array[j] = array[j - 1];
                    j--;
                }
                array[j] = cur;
            }
        }
        static int[] MergeSort(int[] array)
        {
            if (array.Length == 1)
                return array;
            int midPoint = array.Length / 2;
            return Merge(MergeSort(array.Take(midPoint).ToArray()), MergeSort(array.Skip(midPoint).ToArray()));
        }
        static int[] Merge(int[] array1, int[] array2)
        {
            int a = 0, b = 0;
            int[] merged = new int[array1.Length + array2.Length];
            for (int i = 0; i < array1.Length + array2.Length; i++)
            {
                if (b < array2.Length && a < array1.Length)
                    if (array1[a] > array2[b])
                        merged[i] = array2[b++];
                    else
                        merged[i] = array1[a++];
                else
                    if (b < array2.Length)
                        merged[i] = array2[b++];
                    else
                        merged[i] = array1[a++];
            }
            return merged;
        }
        static void Quicksort (int[] array, int start, int end)
        {
            if (start >= end)
                return;
            int pivot = partition(array, start, end);
            Quicksort(array, start, pivot - 1);
            Quicksort(array, pivot + 1, end);
        }
        static int partition(int[] array, int start, int end)
        {
            int temp;
            int marker = start;
            for (int i = start; i <= end; i++)
            {
                if (array[i] < array[end])
                {
                    temp = array[marker];
                    array[marker] = array[i];
                    array[i] = temp;
                    marker += 1;
                }
            }
            temp = array[marker];
            array[marker] = array[end];
            array[end] = temp;
            return marker;
        }
        static void BucketSort (int[] data)
        {
            int maxValue = data[0];
            int minValue = data[0];
            for (int i = 1; i < data.Length; i++)
            {
                if (data[i] > maxValue)
                    maxValue = data[i];
                if (data[i] < minValue)
                    minValue = data[i];
            }
            List<int>[] bucket = new List<int>[maxValue - minValue + 1];
            for (int i = 0; i < bucket.Length; i++)
            {
                bucket[i] = new List<int>();
            }
            for (int i = 0; i < data.Length; i++)
            {
                bucket[data[i] - minValue].Add(data[i]);
            }
            int k = 0;
            for (int i = 0; i < bucket.Length; i++)
            {
                if (bucket[i].Count > 0)
                {
                    for (int j = 0; j < bucket[i].Count; j++)
                    {
                        data[k] = bucket[i][j];
                        k++;
                    }
                }
            }
        }
    }
}
