using System;
using static System.Math;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr;
            int i, j;
            int n;
            int min = int.MaxValue;
            int p1 = -1, p2 = -1;
            Random d = new Random();
            bool b;
            string value;
            Console.WriteLine("Input size of array : ");
            do
            {
                value = Console.ReadLine();
                b = Int32.TryParse(value, out n);
                if (b == false)
                    Console.WriteLine("Error : Input string value !");
                else
                if (n < 2)
                    Console.WriteLine("Input n > 1 !");
            } while (n < 2 || b == false);

            arr = new int[n];
            for (i = 0; i < n; i++)
            {
                arr[i] = d.Next(100);
                Console.Write(arr[i] + " ");
            }
            Console.ReadLine();
            i = 0;
            while(min != 0 && i < n)
            {
                j = i+1;
                while (min != 0 && j < n)
                {
                    if (min > Abs(arr[i] - arr[j]))
                    {
                        min = Abs(arr[i] - arr[j]);
                        p1 = i + 1;
                        p2 = j + 1;
                    }
                    j++;

                }
                i++;
            }
            Console.WriteLine("pos 1 : " + p1);
            Console.WriteLine("pos 2 : " + p2);

        }
    }
}
//Даний масив розміру N.Знайти номери двох найближчих чисел з цього масиву.