using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConAppAssignment14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arrayToSort = GenerateRandomArray(10); // Change the array size as required
            Console.WriteLine("Original Array:");
            PrintArray(arrayToSort);

            // Perform Bubble Sort and measure its performance
            int[] bubbleSortedArray = (int[])arrayToSort.Clone();
            var sw = Stopwatch.StartNew();
            BubbleSort(bubbleSortedArray);
            sw.Stop();
            Console.WriteLine("\nBubble Sorted Array:");
            PrintArray(bubbleSortedArray);
            Console.WriteLine($"Time taken by Bubble Sort: {sw.Elapsed.TotalMilliseconds} ms");

            // Perform Insertion Sort and measure its performance
            int[] insertionSortedArray = (int[])arrayToSort.Clone();
            sw.Restart();
            InsertionSort(insertionSortedArray);
            sw.Stop();
            Console.WriteLine("\nInsertion Sorted Array:");
            PrintArray(insertionSortedArray);
            Console.WriteLine($"Time taken by Insertion Sort: {sw.Elapsed.TotalMilliseconds} ms");

            // Perform Selection Sort and measure its performance
            int[] selectionSortedArray = (int[])arrayToSort.Clone();
            sw.Restart();
            SelectionSort(selectionSortedArray);
            sw.Stop();
            Console.WriteLine("\nSelection Sorted Array:");
            PrintArray(selectionSortedArray);
            Console.WriteLine($"Time taken by Selection Sort: {sw.Elapsed.TotalMilliseconds} ms");

            // Perform Merge Sort and measure its performance
            int[] mergeSortedArray = (int[])arrayToSort.Clone();
            sw.Restart();
            MergeSort(mergeSortedArray);
            sw.Stop();
            Console.WriteLine("\nMerge Sorted Array:");
            PrintArray(mergeSortedArray);
            Console.WriteLine($"Time taken by Merge Sort: {sw.Elapsed.TotalMilliseconds} ms");
            Console.ReadKey();
        }

        // Bubble Sort Algorithm
        static void BubbleSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                bool swapped = false;
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        Swap(arr, j, j + 1);
                        swapped = true;
                    }
                }
                // If no two elements were swapped in the inner loop, the array is already sorted
                if (!swapped)
                    break;
            }
        }

        // Insertion Sort Algorithm
        static void InsertionSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 1; i < n; i++)
            {
                int key = arr[i];
                int j = i - 1;
                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = key;
            }
        }

        // Selection Sort Algorithm
        static void SelectionSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (arr[j] < arr[minIndex])
                    {
                        minIndex = j;
                    }
                }
                Swap(arr, i, minIndex);
            }
        }

        // Merge Sort Algorithm
        static void MergeSort(int[] arr)
        {
            MergeSort(arr, 0, arr.Length - 1);
        }

        static void MergeSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int mid = (left + right) / 2;
                MergeSort(arr, left, mid);
                MergeSort(arr, mid + 1, right);
                Merge(arr, left, mid, right);
            }
        }

        static void Merge(int[] arr, int left, int mid, int right)
        {
            int n1 = mid - left + 1;
            int n2 = right - mid;

            int[] leftArr = new int[n1];
            int[] rightArr = new int[n2];

            for (int i = 0; i < n1; i++)
            {
                leftArr[i] = arr[left + i];
            }

            for (int j = 0; j < n2; j++)
            {
                rightArr[j] = arr[mid + 1 + j];
            }

            int p = 0, q = 0;
            int k = left;

            while (p < n1 && q < n2)
            {
                if (leftArr[p] <= rightArr[q])
                {
                    arr[k] = leftArr[p];
                    p++;
                }
                else
                {
                    arr[k] = rightArr[q];
                    q++;
                }
                k++;
            }

            while (p < n1)
            {
                arr[k] = leftArr[p];
                p++;
                k++;
            }

            while (q < n2)
            {
                arr[k] = rightArr[q];
                q++;
                k++;
            }
        }

        // Helper methods
        static void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        static int[] GenerateRandomArray(int size)
        {
            Random random = new Random();
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next(1, 1000); // Generate random integers between 1 and 1000
            }
            return array;
        }

        static void PrintArray(int[] arr)
        {
            foreach (var item in arr)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}
    

