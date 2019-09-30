using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array2
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, j, k;
            int amr = 0, amc = 0;
            int amdr = 0, amdc = 0;
            int rowsdown = 0, rowsup = 0, columdown = 0, columup = 0;
            int m, n;
            int[,] arr;
            bool b;
            Random d = new Random();
            string value;

            Console.Write("N = ");
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

            Console.Write("M = ");
            do
            {
                value = Console.ReadLine();
                b = int.TryParse(value, out m);
                if (b == false)
                    Console.WriteLine("Error : Input string !");
                else
                if (m < 1)
                    Console.WriteLine("Input m > 0 !");
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


            for (i = 0; i < n; i++) //Рядки
            {
                amr = 1;
                amdr = 1;

                for (k = 1; k < m; k++)
                {
                    if (arr[i, k] >= arr[i, k - 1])
                        amr++;
                    else
                    {
                        if (arr[i, k] <= arr[i, k - 1])
                        {
                            amdr++;
                           
                        }
                    }
                }
                if (amr == m)
                    rowsup++;
                else
                if (amdr == m)
                    rowsdown++;


            }


            for (i = 0; i < m; i++) //Стовпчики
            {
                amc = 1;
                amdc = 1;
                for (k = 1; k < n; k++)
                {
                    if (arr[k, i] >= arr[k - 1, i])
                        amc++;
                    else
                        if (arr[k, i]  <= arr[k - 1, i])
                        amdc++;
                }
                if (amc == n)
                    columup++;
                else
                if (amdc == n)
                    columdown++;
            }


            Console.WriteLine("Rows up :" + rowsup);
            Console.WriteLine("Rows down :" + rowsdown);
            Console.WriteLine("Column up :" + columup);
            Console.WriteLine("Column down :" + columdown);
        
        }
    }
}
//Дана матриця розміру m * n.Вивести кількість 1) рядків; 2) стовпчиків, елементи яких монотонно зростають(спадають). 
