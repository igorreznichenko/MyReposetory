using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayList
{
    
    class Program
    {
        static bool СheckSimple(int val)
        {
            if (val == 2 || val == 3)
                return true;
            if (val % 3 == 0 || val % 2 == 0 )
                return false;
            int i = 5;
            while (i < Math.Sqrt(val))
            {
                i++;
                if (i % 3 == 0)
                    return false; 
                if (val % i == 0)
                    return false;
            }
            return true;

        }
        static void Main(string[] args)
        {
            List<int> list;
            int[] a;
            int[] a1;
            int n, k, count = 0;
            int i, val;
            bool b;
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
                    Console.WriteLine("Input n > 1 !");
            } while (b == false || n < 1);
            a = new int[n];
            list = new List<int>(n);

            for(i = 0; i< n; i++)
            {

                do
                {
                    Console.Write("a[{0}] = ", i+1);
                    value = Console.ReadLine();
                    b = int.TryParse(value, out val);
                    if (b == false)
                        Console.WriteLine("Error : Input string !");
                    else
                    {
                        if (val < 2)
                            Console.WriteLine("Input elem > 1 !");
                        else
                        {
                            b = СheckSimple(val);
                            if (b == false)
                                Console.WriteLine("Error : Number not natural");
                        }
                    }
                } while (b == false || val < 2);
                    list.Add(val);
            }

            a1 = new int[n];

            a1 = list.ToArray();
         
            Array.Sort(a1);

            i = 1;
            k = a1[0];
            count++;

            while(i < n)
            {
                if (a1[i] == k)
                    count++;
                else
                {
                    Console.WriteLine("Amount of {0} : {1} ", k, count);
                    k = a1[i];
                    count = 1;
                }
                i++;

            }
            k = a1[i - 1];
            Console.WriteLine("Amount of {0} : {1} ", k, count);
           
            


            foreach(int i1 in list)
            {
                Console.Write(i1 + " ");
            }

        }
    }
}