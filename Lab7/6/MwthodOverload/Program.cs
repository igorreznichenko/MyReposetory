using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MwthodOverload
{
    class Program
    {
        static void MargArr(ref string  s1, ref string s, int beg, int end)
        {
            if (beg != end)
            {
                s1 += s[beg];
                MargArr(ref s1, ref s, beg + 1, end);
            }
            else
                return;



        }
        



        static void Reverse(int i)
        {
            if (i != 0)
            {
                Console.Write(i % 10);
                Reverse(i / 10);
            }
            else
                return;
            
        }
       static void Reverse(string s, int i)
        {
            if (i == 0)
                Console.Write(s[i]);
            else
            {
                Console.Write(s[i]);
                Reverse(s, i - 1);
            }
        }
        static void Reverse(double d)
        {
            string s = d.ToString();
            string s1 = "", s2 = "";
            int i;

            i = s.IndexOf(',');

            MargArr(ref s1, ref s, 0, i);
            MargArr(ref s2, ref s, i + 1, s.Length);
          
            Reverse(s1, s1.Length - 1);
            Console.Write(',');
            Reverse(s2, s2.Length - 1);

            Console.WriteLine();
        }

        static void Reverse(string s, char sign)
        {
            int i = 0;
            string s1 = "";
            string s2 = "";
            i = s.IndexOf(sign);

            MargArr(ref s1, ref s, 0, i);
            MargArr(ref s2, ref s, i + 1, s.Length);

            Reverse(s1,s1.Length-1);
            Console.Write(sign);
            Reverse(s2,s2.Length-1);
        
            Console.WriteLine();
        }




        static void Main(string[] args)
        {
            int i = 3456;
            string s = "ABC";
            double d = 123.456;
            string l = "ABC,EFG";
            char sign = ',';
            Reverse(i);
            Console.WriteLine();
            Reverse(s, s.Length-1);
            Console.WriteLine();
            Reverse(d);
            Reverse(l, sign);
        }
    }
}
