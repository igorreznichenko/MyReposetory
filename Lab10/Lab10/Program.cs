using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10
{

    static class Extension_Methods
    {
        public static void Reverse(this int i)
        {
            while (i != 0)
            {
                Console.Write(i % 10);
                i /= 10;

            }
            Console.WriteLine();
        }
        public static void Reverse(this string g)
        {
            for (int i = g.Length - 1; i >= 0; i--)
            {
                Console.Write(g[i]);
            }
            Console.WriteLine();
        }
        public static void Reverse_with_Sign(this string g, char sign)
        {

            int i = 0;
            string s1 = "";
            string s2 = "";

            while (g[i] != sign)
            {
                s1 += g[i];
                i++;
            }
            i++;
            while (i < g.Length)
            {
                s2 += g[i];
                i++;
            }
            for (i = s1.Length - 1; i >= 0; i--)
            {
                Console.Write(s1[i]);
            }
            Console.Write(sign);
            for (i = s2.Length - 1; i >= 0; i--)
            {
                Console.Write(s2[i]);
            }
            Console.WriteLine();
        }
        public static void Reverse(this double d)
        {
            string s = d.ToString();
            string s1 = "", s2 = "";

            int i = 0;
            while (s[i] != ',')
            {
                s1 += s[i];
                i++;
            }

            i++;

            while (i < s.Length)
            {
                s2 += s[i];
                i++;
            }

            for (i = s1.Length - 1; i >= 0; i--)
            {
                Console.Write(s1[i]);
            }
            Console.Write('.');

            for (i = s2.Length - 1; i >= 0; i--)
            {
                Console.Write(s2[i]);
            }

            Console.WriteLine();
        }
        static int[] Reverce(this int[] arr)
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
        //Завдання 6 друга частина
       public static void Out_Array(this int[] a)
        {
            int i;
            for(i = 1; i < a.Length; i += 2)
            {
                Console.Write(a[i] + " ");
            }
            Console.WriteLine();
            for (i = 0; i < a.Length; i += 2)
            {
                Console.Write(a[i] + " ");
            }
            Console.WriteLine();
        }
    }
    

    class Program
    {
        static void Main(string[] args)
        {
            int n = 10;
            int[] a = new int[n];
            for(int i = 0; i<n; i++)
            {
                a[i] = i + 1;
            }
            a.Out_Array();
        }
    }
}