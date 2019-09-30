using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array2dodatk
{
    class Program
    {
        static void Main(string[] args)
        {
            int min, max;
            int[,] arr;
            int n, m, i, j;
            int pmx1, pmx2, pmn1, pmn2;
            bool b;
            Random d = new Random();
            string value;
            pmx1 = pmx2 = pmn1 = pmn2 = 0;

            Console.WriteLine("Input N");
            do
            {
                value = Console.ReadLine();
                b = int.TryParse(value, out n);
                if (b == false)
                    Console.WriteLine("Error : Input string !");
                else
                    if (n < 1)
                    Console.WriteLine("Input n > 0 !");

            } while (n < 1 || b == false);

            Console.WriteLine("Input M");
            do
            {
                value = Console.ReadLine();
                b = int.TryParse(value, out m);
                if (b == false)
                    Console.WriteLine("Error : Input string !");
                else
                    if (m < 1)
                    Console.WriteLine("Input M > 0 !");

            } while (m < 1 || b == false);

            arr = new int[n, m];

            for (i = 0; i < n; i++)
            {
               
                for (j = 0; j < m; j++)
                {
                    arr[i, j] = d.Next(100);
                    Console.Write(arr[i, j] + " ");
                }
                Console.WriteLine();
            }

            min = arr[0, 0];
            max = arr[0, 0];
            for(i = 0; i< n; i++)
            {
                for(j = 0; j < m; j++)
                {
                    if (arr[i, j] > max)
                    {
                        max = arr[i, j];
                        pmx1 = i;
                        pmx2 = j;                   
                    }
                    if (arr[i, j] < min)
                    {
                        min = arr[i, j];
                        pmn1 = i;
                        pmn2 = j;
                    }

                    
                }
            }
            Console.Write("Rows of max : ");
            for (i = 0; i < m; i++)
                Console.Write(arr[pmx1, i] + " ");
            Console.WriteLine();

            Console.Write("Colum of max : ");
            for (i = 0; i < n; i++)
                Console.Write(arr[i, pmx2] + " ");
            Console.WriteLine();

            Console.Write("Rows of min : ");
            for (i = 0; i < m; i++)
                Console.Write(arr[pmn1, i] + " ");
            Console.WriteLine();

            Console.Write("Colum of min : ");
            for (i = 0; i < n; i++)
                Console.Write(arr[i, pmn2] + " ");
           


        }
    }
}
//28.Дана матриця розміру m *  n. Продублювати рядок (стовпчик) матриці, що містить її 1) мінімальний; 2) максимальний елемент. 