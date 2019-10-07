using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReturnArr
{
    class Program
    {
        static int[] ReversArray(int[] arr)
        {
            int k, i;
            int len = arr.Length;
            int m = arr.Length / 2;
            for (i = 0; i < m; i++)
            {
                k = arr[i];
                arr[i] = arr[len - 1 - i];
                arr[len - 1 - i] = k;
            }
            return arr;
        }
        static void ReverseArray(int[] arr, out int[] arr1)
        {
            int i, k;
            int len = arr.Length;
            int m = arr.Length / 2;
            arr1 = new int[arr.Length];
            for (i = 0; i < m; i++)
            {
                k = arr[i];
                arr[i] = arr[len - 1 - i];
                arr[len - 1 - i] = k;
            }
            for(i = 0; i< len ; i++)
            {
                arr1[i] = arr[i];
            }
        }
        
        static void Main(string[] args)
        {
            int i;
            int[] arr1;
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            arr = ReversArray(arr);
            ReverseArray(arr, out arr1);
            for(i = 0; i<arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
            for(i = 0; i < arr.Length; i++)
            {
                Console.Write(arr1[i]+" ");
            }
        }
    }
}