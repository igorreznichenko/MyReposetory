using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dodatk2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr;
            List<int> arr2 = new List<int>();
            int i,k, count, n;
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
                if (n < 1)
                    Console.WriteLine("Input n >  !");
            } while (n < 1 || b == false);

            arr = new int[n+1];
            for (i = 0; i < n; i++)
            {
                Console.WriteLine("a[{0}] = ", i + 1);
                do
                {
                    value = Console.ReadLine();
                    b = Int32.TryParse(value, out arr[i]);
                    if (b == false)
                        Console.WriteLine("Error : Input string value !");
                } while (b == false);
            }
            i = 0;
            

            while(i < n)
            {
                k = arr[i];
                count = 0;
                while (arr[i] == k && i < n)
                {
                    count++;
                   i++;
                }
                arr2.Add(count);

            }
            foreach (int val in arr2)
            {
                Console.Write(val + " ");
            }
        }
    }
}
//Даний масив цілих чисел розміру N.Назвемо серією групу однакових елементів, що розташовані підряд, а довжиною серії — кількість цих елементів (довжина серії може бути рівна 1).
//Вивести масив, що містить довжини всіх серій початкового масиву.