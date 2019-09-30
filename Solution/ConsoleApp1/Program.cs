using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    
    class Program
    {
        static void Main(string[] args)
        {
            int x, y;
            string value;
            bool b;
            Console.WriteLine("Input X : ");

            do
            {
                value = Console.ReadLine();

                b = Int32.TryParse(value, out x);
                if (b == false)
                    Console.WriteLine("Error : Input X Is Integer !");
            } while (b == false);

            Console.WriteLine("Input Y : ");

            do
            {
                value = Console.ReadLine();

                b = Int32.TryParse(value, out y);
                if (b == false)
                    Console.WriteLine("Error : Input Y Is Integer !");
            } while (b == false);

            if (x > 0 && y > 0)
                Console.WriteLine("I quadr");
            else
            if (x < 0 && y < 0)
                Console.WriteLine("III quadr");
            else
                Console.WriteLine("Not I and nt III");


        }
    }
}
//3.Перевірити істинність вислову: "Дані числа x, у є координатами точки, що лежить у першому або третьому квадранті". 