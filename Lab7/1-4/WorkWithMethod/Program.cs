using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWithMethod
{
    class Program
    {
        static void ReverseInt(int i)
        {
            while(i!= 0)
            {
                Console.Write(i % 10);
                i /= 10;

            }
            Console.WriteLine();
        }
        static void ReverseString(string s)
        {
            for (int i = s.Length - 1; i >= 0; i--)
            {
                Console.Write(s[i]);
            }
            Console.WriteLine();
        }

        static void ReverseDouble(double a)
        {
            string s = a.ToString();
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
        static void ReverceStringSign(string s, char sign)
        {
            int i = 0;
            string s1 = "";
            string s2 = "";

            while (s[i] != sign)
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
                for(i =s1.Length-1; i>= 0; i--)
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

      
        static void Main(string[] args)
        {
            int i = 345;
            double d = 234.567;
            string s = "ABC";
            string s1 = "ABC,DOFG";
            char sign = ',';
            ReverseInt(i);
            ReverseDouble(d);
            ReverseString(s);
            ReverceStringSign(s1, sign);

        }
    }

}
